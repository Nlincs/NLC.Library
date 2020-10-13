//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimpleAddressLineTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:55 - Stephen Ellwood
// 
//  Project : - Library.tests
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
                public void SetUp() => mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => mockRepository.VerifyAll();

                private MockRepository mockRepository;

                private AddressLines CreateSimpleAddressLine() => new AddressLines();

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
                public void MatchedAddressesAreEqual()
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

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Address1 = add11;
                        sut2.Address2 = add21;
                        sut2.Address3 = add31;
                        sut2.Address4 = add41;
                        sut2.Address5 = add51;


                        Assert.That(sut1, Is.EqualTo(sut2));
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
                public void MatchedDifferentLineslAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address2 = add1;

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Address4 = add2;

                        Assert.That(sut1, Is.EqualTo(sut2));
                    }

                [Test]
                public void MatchedPartialAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address2 = add1;

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Address2 = add2;

                        Assert.That(sut1, Is.EqualTo(sut2));
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
                public void SameUprnAreEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Uprn = new Uprn(uprn2);

                        Assert.That(sut1, Is.EqualTo(sut2));
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
            }
    }