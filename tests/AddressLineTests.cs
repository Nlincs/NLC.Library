//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressLineTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:38
//  Altered - 17/12/2020 15:00 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using Moq;
using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class AddressLineTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private static AddressLines CreateSimpleAddressLine() => new AddressLines(null, null, null, null, null, null);

                [Test]
                public void CheckInterfaces()
                    {
                        // Arrange
                        var simpleAddressLine = CreateSimpleAddressLine();

                        // Act


                        // Assert
                        Assert.IsInstanceOf<ILocation>(simpleAddressLine);
                        Assert.IsInstanceOf<IAddressLines>(simpleAddressLine);
                    }

                [Test]
                public void AddressLineConstructor_ExpectedResults()
                    {
                        var addressLine = CreateSimpleAddressLine();
                        addressLine.AddressLine1 = "add1";
                        addressLine.AddressLine2 = "add2";
                        addressLine.AddressLine3 = "add3";
                        addressLine.AddressLine4 = "add4";
                        addressLine.AddressLine5 = "add5";
                        addressLine.AddressLine6 = "add6";

                        var actual = new AddressLines(addressLine);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo(addressLine.AddressLine1));
                        Assert.That(actual.Address2, Is.EqualTo(addressLine.AddressLine2));
                        Assert.That(actual.Address3, Is.EqualTo(addressLine.AddressLine3));
                        Assert.That(actual.Address4, Is.EqualTo(addressLine.AddressLine4));
                        Assert.That(actual.Address5, Is.EqualTo(addressLine.AddressLine5));
                        Assert.That(actual.Address6, Is.EqualTo(addressLine.AddressLine6));
                    }

                [Test]
                public void AddressNameNumberConstructor_ExpectedResults()
                    {
                        var address = new AddressNameNumber(
                            "name",
                            "number",
                            "street",
                            "location",
                            "town",
                            "county"
                        );

                        var actual = new AddressLines(address);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("name"));
                        Assert.That(actual.Address2, Is.EqualTo("number"));
                        Assert.That(actual.Address3, Is.EqualTo("street"));
                        Assert.That(actual.Address4, Is.EqualTo("location"));
                        Assert.That(actual.Address5, Is.EqualTo("town"));
                        Assert.That(actual.Address6, Is.EqualTo("county"));
                    }

                [Test]
                public void AddressNamedConstructor_ExpectedResults()
                    {
                        var address = new AddressNamed(
                            "primary",
                            "secondary",
                            "street",
                            "location",
                            "town",
                            "county"
                        );

                        var actual = new AddressLines(address);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("primary"));
                        Assert.That(actual.Address2, Is.EqualTo("secondary"));
                        Assert.That(actual.Address3, Is.EqualTo("street"));
                        Assert.That(actual.Address4, Is.EqualTo("location"));
                        Assert.That(actual.Address5, Is.EqualTo("town"));
                        Assert.That(actual.Address6, Is.EqualTo("county"));
                    }


                [Test]
                public void EmptyAddressIsEmpty()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();

                        var expected = "";

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void EmptyAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddressLine();

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void FullAddressReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();


                        var address1 = "address1";
                        var address2 = "Address2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";

                        var postCode = "DN17 2AB";

                        simpleAddressLine.Address1 = address1;
                        simpleAddressLine.Address2 = address2;
                        simpleAddressLine.Address3 = address3;
                        simpleAddressLine.Address4 = address4;
                        simpleAddressLine.Address5 = address5;
                        simpleAddressLine.PostCode = new PostCode(postCode);

                        var expected = address1 + ", " + address2 + ", " + address3 + ", " + address4 + ", " +
                                       address5 + " " +
                                       postCode;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                public void MatchedAddressesDifferentUprnAreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "12321";
                        var add4 = "Somewhere we know";
                        var add5 = "address5";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";

                        var uprn1 = "123";
                        var uprn2 = "12";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Address1 = add11;
                        sut2.Address2 = add21;
                        sut2.Address3 = add31;
                        sut2.Address4 = add41;
                        sut2.Address5 = add51;
                        sut2.Uprn = new Uprn(uprn2);


                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                    }


                [Test]
                public void NonNullAddressIsNotEmptyCheck()
                    {
                        var sut = CreateSimpleAddressLine();
                        sut.Address1 = "   1  ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.False);
                    }


                [Test]
                public void NullAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddressLine();
                        sut.Address1 = "     ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void PartialAddress12345ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();


                        var address1 = "address1";
                        var address2 = "Address2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";

                        simpleAddressLine.Address1 = address1;
                        simpleAddressLine.Address2 = address2;
                        simpleAddressLine.Address3 = address3;
                        simpleAddressLine.Address4 = address4;
                        simpleAddressLine.Address5 = address5;

                        var expected = address1 + ", " + address2 + ", " + address3 + ", " + address4 + ", " + address5;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialAddress135ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();


                        var address1 = "address1";
                        var address3 = "add3";
                        var address5 = "a5";

                        simpleAddressLine.Address1 = address1;
                        simpleAddressLine.Address3 = address3;
                        simpleAddressLine.Address5 = address5;

                        var expected = address1 + ", " + address3 + ", " + address5;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialAddress2ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();

                        var postCode = "DN17 2AB";
                        var address = "Address2";

                        simpleAddressLine.PostCode = new PostCode(postCode);
                        simpleAddressLine.Address2 = address;

                        var expected = address + " " + postCode;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PostCodeOnlyReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressLine();

                        var postCode = "DN17 2AB";
                        simpleAddressLine.PostCode = new PostCode(postCode);

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(postCode));
                    }

                [Test]
                public void UnmatchedPartialAreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add1 ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address2 = add1;

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Address2 = add2;

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                    }

                [Test]
                public void Simplify_EmptyAddress_returnsExpected()
                    {
                        var sut = CreateSimpleAddressLine();

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(""));
                        Assert.That(sut.Address2, Is.EqualTo(""));
                        Assert.That(sut.Address3, Is.EqualTo(""));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Simplify_AllAddress_returnsExpected()
                    {
                        var add1 = "add1";
                        var add2 = "add2";
                        var add3 = "ADD3";
                        var add4 = "aDD4";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine1 = add1;
                        sut.AddressLine2 = add2;
                        sut.AddressLine3 = add3;
                        sut.AddressLine4 = add4;
                        sut.AddressLine5 = add5;
                        sut.AddressLine6 = add6;

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add4));
                        Assert.That(sut.Address5, Is.EqualTo(add5));
                        Assert.That(sut.Address6, Is.EqualTo(add6));
                    }

                [Test]
                public void Simplify_OneAddress_Start_returnsExpected()
                    {
                        var add1 = "add1";


                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine1 = add1;


                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.EqualTo(""));
                        Assert.That(sut.Address3, Is.EqualTo(""));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void Simplify_OneAddress_End_returnsExpected()
                    {
                        var add6 = "add6";


                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine6 = add6;


                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add6));
                        Assert.That(sut.Address2, Is.EqualTo(""));
                        Assert.That(sut.Address3, Is.EqualTo(""));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Simplify_OneAddress_BothEnds_returnsExpected()
                    {
                        var add1 = "add1";
                        var add6 = "add6";


                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine1 = add1;

                        sut.AddressLine6 = add6;


                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.EqualTo(add6));
                        Assert.That(sut.Address3, Is.EqualTo(""));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Simplify_ThreeLines_returnsExpected()
                    {
                        var add2 = "add2";
                        var add4 = "add4";
                        var add5 = "add5";


                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine2 = add2;

                        sut.AddressLine4 = add4;
                        sut.AddressLine5 = add5;


                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add2));
                        Assert.That(sut.Address2, Is.EqualTo(add4));
                        Assert.That(sut.Address3, Is.EqualTo(add5));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Simplify_4Address_returnsExpected()
                    {
                        var add1 = "add1";
                        var add2 = "add2";

                        var add4 = "aDD4";

                        var add6 = "address 6";

                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine1 = add1;
                        sut.AddressLine2 = add2;
                        sut.AddressLine3 = "";
                        sut.AddressLine4 = add4;
                        sut.AddressLine5 = "";
                        sut.AddressLine6 = add6;

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add4));
                        Assert.That(sut.Address4, Is.EqualTo(add6));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Simplify_5Address_returnsExpected()
                    {
                        var add1 = "add1";
                        var add2 = "add2";
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = CreateSimpleAddressLine();

                        sut.AddressLine1 = add1;
                        sut.AddressLine2 = add2;
                        sut.AddressLine3 = add3;
                        sut.AddressLine4 = add4;
                        sut.AddressLine5 = add5;
                        sut.AddressLine6 = add6;

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void Restore_returnsExpected()
                    {
                        var add1 = "add1";

                        var add3 = "ADD3";
                        var add6 = "address 6";

                        var expected = new AddressLines(add1, null, add3, null, null, add6);

                        var sut = new AddressNameNumber(expected);

                        sut.Simplify();
                        sut.Address6 = "new address 6";

                        sut.Restore();

                        Assert.That(sut, Is.Not.Null);

                        Assert.That(sut.FullAddress(), Is.EqualTo(expected.FullAddress()));
                        Assert.That(sut.Address1, Is.EqualTo(add1));
                        Assert.That(sut.Address2, Is.Null);
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.Null);
                        Assert.That(sut.Address5, Is.Null);
                        Assert.That(sut.Address6, Is.EqualTo(add6));
                    }

                [Test]
                public void RestoreEmpty_returnsExpected()
                    {
                      
                        var expected = new AddressLines(null, null, null, null, null, null);

                        var sut = new AddressNameNumber(expected);

                        sut.Simplify();
                        sut.Address6 = "new address 6";

                        sut.Restore();

                        Assert.That(sut, Is.Not.Null);

                        Assert.That(sut.FullAddress(), Is.EqualTo(expected.FullAddress()));
                        Assert.That(sut.Address1, Is.Null);
                        Assert.That(sut.Address2, Is.Null);
                        Assert.That(sut.Address3, Is.Null);
                        Assert.That(sut.Address4, Is.Null);
                        Assert.That(sut.Address5, Is.Null);
                        Assert.That(sut.Address6, Is.Null);
                    }

                [Test]
                public void AddressLinesConstructor_ExpectedResults()
                    {
                        var addressLine = CreateSimpleAddressLine();
                        addressLine.AddressLine1 = "add1";
                        addressLine.AddressLine2 = "add2";
                        addressLine.AddressLine3 = "add3";
                        addressLine.AddressLine4 = "add4";
                        addressLine.AddressLine5 = "add5";
                        addressLine.AddressLine6 = "add6";

                        var actual = new AddressNamed(addressLine);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("add1"));
                        Assert.That(actual.Address2, Is.EqualTo("add2"));
                        Assert.That(actual.Address3, Is.EqualTo("add3"));
                        Assert.That(actual.Address4, Is.EqualTo("add4"));
                        Assert.That(actual.Address5, Is.EqualTo("add5"));
                        Assert.That(actual.Address6, Is.EqualTo("add6"));
                    }
            }
    }