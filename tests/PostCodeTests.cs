//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=PostCodeTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:38
//  Altered - 14/10/2020 10:04 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Moq;
using NLC.Library.Extensions;
using NLC.Library.Extensions.NationalGovernment.eGIF;
using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class PostCodeTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private PostCode CreatePostCode() => new PostCode();

                [Test]
                public void AnonNLincsPostCodeIsRecognised()
                    {
                        var pcode = "DN00 000";
                        var input = new PostCode(pcode);

                        Assert.That(input.Value,
                            Is.EqualTo(pcode));

                        var expected = true;

                        var actual = input.IsNorthlincsAnonymous();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void AnonPostCodeIsRecognised()
                    {
                        var input = new PostCode("DN00 000");
                        var expected = true;

                        var actual = input.IsAnonymous();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void EmptyPostCodeIsUnknown()
                    {
                        var pcode = new PostCode();

                        Assert.That(pcode, Is.Not.Null);
                        Assert.That(pcode.Unknown, Is.True);
                    }

                [Test]
                public void EmptyPostCodeReturnEmptyElements()
                    {
                        var input = new PostCode();

                        var expected = "";

                        Assert.That(input.Area,
                            Is.EqualTo(expected));
                        Assert.That(input.Outward,
                            Is.EqualTo(expected));
                        Assert.That(input.District,
                            Is.EqualTo(expected));
                        Assert.That(input.Inward,
                            Is.EqualTo(expected));
                        Assert.That(input.Sector,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void MosaicPostCode([Values("TN4",
                        "DN 3",
                        "M1")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE")]
                    string incode,
                    [Values("TN 4 9BP",
                        "DN 3 3AZ",
                        "M  1 3DE")]
                    string expect)
                    {
                        // Arrange
                        var expected = expect;

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.MosaicPostCode();

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void NonNlincsAnonNotRecognised()
                    {
                        var input = "zz99 9zz";
                        var expected = false;

                        var actual = input.IsNorthlincsAnonymousPostcode();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void NullPostCodeDoesNotError()
                    {
                        string input = null;

                        var actual = new PostCode(input);

                        Assert.That(actual, Is.Not.Null);

                        Assert.That(actual.Value, Is.EqualTo(""));
                    }


                [Test]
                public void Operator_NonNull_DoesExpected()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var full = "DN33 3DE";

                        var lhs = new PostCode(outward, inward);
                        var rhs = new PostCode(full);


                        Assert.That(lhs, Is.EqualTo(rhs));
                        Assert.That(lhs.Equals(rhs), Is.True);
                        Assert.That(lhs == rhs);
                    }

                [Test]
                public void Operator_Null_DoesExpected()
                    {
                        var outward = "DN33";
                        var inward = "3DE";


                        var lhs = new PostCode(outward, inward);
                        var rhs = new PostCode();

                        Assert.That(lhs, Is.Not.Null);
                        Assert.That(lhs, Is.Not.EqualTo(rhs));
                        Assert.That(lhs.Equals(rhs), Is.False);
                        Assert.That(lhs != rhs);

                        Assert.That(rhs, Is.Not.EqualTo(null));
                        Assert.That(rhs.Equals(null), Is.False);
                        Assert.That(rhs != null);
                    }

                [Test]
                public void Operator_NullValue_DoesExpected()
                    {
                        var outward = "DN33";
                        var inward = "3DE";


                        var rhs = new PostCode(outward, inward);
                        PostCode lhs = null;

                        Assert.That(rhs, Is.Not.Null);
                        Assert.That(lhs, Is.Not.EqualTo(rhs));
                        Assert.That(lhs != rhs);
                    }


                [Test]
                public void Operator_Unequal_DoesExpected()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var full = "DN33 3DF";

                        var lhs = new PostCode(outward, inward);
                        var rhs = new PostCode(full);


                        Assert.That(lhs, Is.Not.EqualTo(rhs));
                        Assert.That(lhs.Equals(rhs), Is.False);
                        Assert.That(lhs != rhs);
                    }

                [Test]
                [Sequential]
                public void PaddedPostCode([Values("TN4",
                        "DN 3",
                        "M1",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode,
                    [Values("TN4  9BP",
                        "DN3  3AZ",
                        "M1   3DE",
                        "W1P  2JT",
                        "EC1A 3HW")]
                    string expect)
                    {
                        // Arrange
                        var expected = expect;

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.PaddedPostCode();

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                public void PostCode_ExpectedBehaviour()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var expected = "DN33 3DE";

                        var actual = new PostCode(outward, inward);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void PostCodeIsEqual(
                    [Values("LN1 2AB", "W2 3SX", "NL3 4BP")]
                    string x,
                    [Values("LN12AB", "W2   3SX", "  NL3    4BP   ")]
                    string s)
                    {
                        var numPostCode = new PostCode(x);

                        var stringPostCode = new PostCode(s);

                        var actual = numPostCode == stringPostCode;

                        Assert.That(actual, Is.True);

                        Assert.That(numPostCode, Is.EqualTo(stringPostCode));
                    }


                [Test]
                public void PostCodeIsEquatable()
                    {
                        var PostCode = new PostCode();

                        Assert.IsInstanceOf<IEquatable<IPostCode>>(PostCode);
                    }

                [Test]
                [Combinatorial]
                public void PostCodeIsInequal(
                    [Values("LN1 2AB", "W2 3SX", "NL3 4BP")]
                    string x,
                    [Values("", "LN1 1AB", "W2C 3SX")] string s)
                    {
                        var numPostCode = new PostCode(x);

                        var stringPostCode = new PostCode(s);

                        var actual = numPostCode != stringPostCode;

                        Assert.That(actual, Is.True);
                    }

                [Test]
                [Sequential]
                public void PostCodeIsInequalTo(
                    [Values("1", "2", "3")] string x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numPostCode = new PostCode(x);

                        var stringPostCode = new PostCode(s);

                        var actual = numPostCode != stringPostCode;

                        Assert.That(actual, Is.False);
                    }

                [Test]
                [Combinatorial]
                public void PostCodeIsNotEqual(
                    [Values("LN1 2AB", "W2 3SX", "NL3 4BP")]
                    string x,
                    [Values("", "LN1 1AB", "W2C 3SX")] string s)
                    {
                        var numPostCode = new PostCode(x);

                        var stringPostCode = new PostCode(s);

                        var actual = numPostCode == stringPostCode;

                        Assert.That(actual, Is.False);

                        Assert.That(numPostCode, Is.Not.EqualTo(stringPostCode));
                    }

                [Test]
                public void SensiblePostCodeIsValid()
                    {
                        // this was causing issue in systems

                        var input = "DN20 8SD";

                        var actual = new PostCode(input);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual.Value,
                            Is.EqualTo(input));
                        Assert.That(actual.IsValidUkPostCode,
                            Is.True);
                        Assert.That(actual.IsUkValid,
                            Is.True);
                    }

                [Test]
                public void SetArea_DoesNothing()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var newValue = "AAB";

                        var expected = "DN33 3DE";

                        var actual = new PostCode(outward, inward) {Area = newValue};


                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(expected));
                    }

                [Test]
                public void SetDistrict_DoesNothing()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var newValue = "AAB";

                        var expected = "DN33 3DE";

                        var actual = new PostCode(outward, inward) {District = newValue};


                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(expected));
                    }

                [Test]
                public void SetInward_DoesNothing()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var newValue = "AAB";

                        var expected = "DN33 3DE";

                        var actual = new PostCode(outward, inward) {Inward = newValue};


                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(expected));
                    }


                [Test]
                public void SetSector_DoesNothing()
                    {
                        var outward = "DN33";
                        var inward = "3DE";

                        var newValue = "AAB";

                        var expected = "DN33 3DE";

                        var actual = new PostCode(outward, inward) {Sector = newValue};


                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void TestArea([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW",
                        "9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode,
                    [Values("TN",
                        "DN",
                        "DN",
                        "DN",
                        "DN",
                        "CH",
                        "M",
                        "DN",
                        "W",
                        "EC")]
                    string expect)
                    {
                        // Arrange
                        var expected = expect;

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.Area;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                public void TestDistrict([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        // Arrange
                        var expected = outcode.ReplaceAll(" ",
                            "");

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.District;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void TestEquality([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        // Arrange
          
                        // Act
                        var postCode = CreatePostCode();
                        postCode.Value = outcode + " " + incode;
                        var pCode = new PostCode(outcode + " " + incode);

                        // Assert

                        Assert.That(postCode,
                            Is.Not.Null);
                        Assert.That(pCode,
                            Is.Not.Null);
                        Assert.That(postCode.Value,
                            Is.EqualTo(pCode.Value));
                    }

                [Test]
                public void TestInward([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        // Arrange
                        var expected = incode;

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.Inward;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void TestInwardNoSep([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        // Arrange
                        var expected = incode;

                        // Act

                        var pCode = new PostCode(outcode + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.Inward;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                public void TestOutward([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        // Arrange
                        var expected = outcode.ReplaceAll(" ",
                            ""); // allow for mosaic

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.Outward;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void TestSector([Values("TN4",
                        "DN 3",
                        "M1",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode,
                    [Values("TN4 9",
                        "DN3 3",
                        "M1 3",
                        "W1P 2",
                        "EC1A 3")]
                    string expect)
                    {
                        // Arrange
                        var expected = expect;

                        // Act

                        var pCode = new PostCode(outcode + " " + incode);
                        Assert.That(pCode,
                            Is.Not.Null);

                        var actual = pCode.Sector;

                        // Assert

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }
            }
    }