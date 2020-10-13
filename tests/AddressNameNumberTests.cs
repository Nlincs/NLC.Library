//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimpleAddressNameNumberTests.cs company="North Lincolnshire Council">
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
        public class AddressNameNumberTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private AddressNameNumber CreateSimpleAddressNameNumber() => new AddressNameNumber();

                [Test]
                public void CheckInterfaces()
                    {
                        // Arrange
                        var simpleAddressLine = CreateSimpleAddressNameNumber();

                        // Act


                        // Assert
                        Assert.IsInstanceOf<ILocation>(simpleAddressLine);
                        Assert.IsInstanceOf<IAddressNameNumber>(simpleAddressLine);
                    }

                [Test]
                public void EmptyAddressIsEmpty()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();

                        var expected = "";

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void EmptyAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddressNameNumber();

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void FullAddressReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();


                        var address1 = "address1";
                        var address2 = "2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";
                        var address6 = "county";

                        var postCode = "DN17 2AB";

                        simpleAddressLine.HouseName = address1;
                        simpleAddressLine.HouseNumber = address2;
                        simpleAddressLine.Street = address3;
                        simpleAddressLine.Location = address4;
                        simpleAddressLine.Town = address5;
                        simpleAddressLine.County = address6;
                        simpleAddressLine.PostCode = new PostCode(postCode);

                        var expected = address1 + ", " +
                                       address2 + ", " +
                                       address3 + ", " +
                                       address4 + ", " +
                                       address5 + ", " +
                                       address6 + " " +
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
                        var add6 = "county";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";
                        var add61 = "county";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.HouseName = add1;
                        sut1.HouseNumber = add2;
                        sut1.Street = add3;
                        sut1.Location = add4;
                        sut1.Town = add5;
                        sut1.County = add6;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;
                        sut2.County = add61;


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
                        var add6 = "county";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";
                        var add61 = "county";

                        var uprn1 = "123";
                        var uprn2 = "12";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.HouseName = add1;
                        sut1.HouseNumber = add2;
                        sut1.Street = add3;
                        sut1.Location = add4;
                        sut1.Town = add5;
                        sut1.County = add6;
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;
                        sut2.County = add61;
                        sut2.Uprn = new Uprn(uprn2);


                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                    }

                [Test]
                public void MatchedDifferentLineslAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.Location = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.County = add2;

                        Assert.That(sut1, Is.EqualTo(sut2));
                    }

                [Test]
                public void MatchedPartialAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.County = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.County = add2;

                        Assert.That(sut1, Is.EqualTo(sut2));
                    }

                [Test]
                public void NonNullAddressIsNotEmptyCheck()
                    {
                        var sut = CreateSimpleAddressNameNumber();
                        sut.HouseNumber = "   1  ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.False);
                    }


                [Test]
                public void NullAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddressNameNumber();
                        sut.County = "     ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void PartialAddress12345ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();


                        var address1 = "address1";
                        var address2 = "2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";

                        simpleAddressLine.HouseName = address1;
                        simpleAddressLine.HouseNumber = address2;
                        simpleAddressLine.Street = address3;
                        simpleAddressLine.Location = address4;
                        simpleAddressLine.Town = address5;

                        var expected = address1 + ", " + address2 + ", " + address3 + ", " + address4 + ", " + address5;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialAddress135ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();


                        var address1 = "address1";
                        var address3 = "add3";
                        var address5 = "a5";

                        simpleAddressLine.HouseName = address1;
                        simpleAddressLine.Street = address3;
                        simpleAddressLine.Town = address5;

                        var expected = address1 + ", " + address3 + ", " + address5;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialAddress2ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();

                        var postCode = "DN17 2AB";
                        var address = "2";

                        simpleAddressLine.PostCode = new PostCode(postCode);
                        simpleAddressLine.HouseNumber = address;

                        var expected = address + " " + postCode;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PostCodeOnlyReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddressNameNumber();

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

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Uprn = new Uprn(uprn2);

                        Assert.That(sut1, Is.EqualTo(sut2));
                    }

                [Test]
                public void UnmatchedPartialAreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add1 ";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.Location = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Location = add2;

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                    }
            }
    }