//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNameNumberTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 07/12/2021 00:56
//  Altered - 07/12/2021 09:14 - Stephen Ellwood
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
        public class AddressNameNumberTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private AddressNameNumber CreateSimpleAddressNameNumber() =>
                    new AddressNameNumber(null, null, null, null, null, null);

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

                [Test]
                public void AddressLineConstructor_ExpectedResults()
                    {
                        var addressLine = CreateSimpleAddressNameNumber();
                        addressLine.HouseName = "add1";
                        addressLine.HouseNumber = "add2";
                        addressLine.Street = "add3";
                        addressLine.Location = "add4";
                        addressLine.Town = "add5";
                        addressLine.County = "add6";

                        var actual = new AddressNameNumber(addressLine);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("add1"));
                        Assert.That(actual.Address2, Is.EqualTo("add2"));
                        Assert.That(actual.Address3, Is.EqualTo("add3"));
                        Assert.That(actual.Address4, Is.EqualTo("add4"));
                        Assert.That(actual.Address5, Is.EqualTo("add5"));
                        Assert.That(actual.Address6, Is.EqualTo("add6"));
                    }

                [Test]
                public void AddressNamedConstructor_ExpectedResults()
                    {
                        var address = new AddressNamed("add1", "add2", "add3", "add4", "add5", "add6");

                        var actual = new AddressNameNumber(address);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("add1"));
                        Assert.That(actual.Address2, Is.EqualTo("add2"));
                        Assert.That(actual.Address3, Is.EqualTo("add3"));
                        Assert.That(actual.Address4, Is.EqualTo("add4"));
                        Assert.That(actual.Address5, Is.EqualTo("add5"));
                        Assert.That(actual.Address6, Is.EqualTo("add6"));
                    }

                [Test]
                public void AddressSimplify_HouseNumber_NoNameNumber_ReturnsExpected()
                    {

                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = CreateSimpleAddressNameNumber();

                        sut.Street = add3;
                        sut.Location = add4;
                        sut.Town = add5;
                        sut.County = add6;

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.Address1, Is.EqualTo(add3));
                        Assert.That(sut.Address2, Is.EqualTo(add5));
                        Assert.That(sut.Address3, Is.EqualTo(add6));
                        Assert.That(sut.Address4, Is.EqualTo(""));
                        Assert.That(sut.Address5, Is.EqualTo(""));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void AddressSimplify_HouseNameHasNumber_ReturnsExpected()
                    {
                        var add1 = 21.ToString();
       
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, null, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(""));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add1));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void AddressSimplify_HouseNameHasNumberSwaps_ReturnsExpected()
                    {
                        var add1 = 21.ToString();
                        var add2 = "add2";
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, add2, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(add2));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add1));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void AddressSimplify_HouseNameHasPartialNumber_ReturnsExpected()
                    {
                        var add1number = 21;
                        var add1Name = " the knowle";

                        var add1 = add1number + add1Name;
                        
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, null, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(add1Name.Trim()));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add1number.ToString()));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void AddressSimplify_HouseNameHasPartialNumber_NoSwaps_ReturnsExpected()
                    {
                        var add1number = 21;
                        var add1Name = " the knowle";

                        var add1 = add1number + add1Name;
                        var add2 = "add2";
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, add2, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(add1));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void AddressSimplify_HouseNumberHasNumber_ReturnsExpected()
                    {
                        var add2 = 21.ToString();

                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(null, add2, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(""));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void AddressSimplify_HouseNumberHasNumber_HouseNameNotEmpty_ReturnsExpected()
                    {
                        var add1 = "13 the street";
                        var add2 = 21.ToString();
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, add2, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(add1));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }


                [Test]
                public void AddressSimplify_HouseNumberHasPartialNumber_ReturnsExpected()
                    {
                        var add1number = 21.ToString();
                        var add1Name = " the knowle";

                        var add1 = add1number + add1Name;

                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(add1, null, add3, add4, add5, add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseName, Is.EqualTo(add1Name.Trim()));
                        Assert.That(sut.HouseNumber, Is.EqualTo(add1number));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }

                [Test]
                public void AddressSimplify_HouseNumberHasPartiaNumber_HouseNameNotEmpty_ReturnsExpected()
                    {
                        var add1 = 21.ToString();
                        var add2 = "13 name the house";
                        var add3 = "ADD3";
                        var add4 = "";
                        var add5 = "add_5";
                        var add6 = "address 6";

                        var sut = new AddressNameNumber(HouseNumber: add1, houseName: add2, Street: add3, Location: add4, Town: add5, County: add6);

                        sut.Simplify();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.HouseNumber, Is.EqualTo(add1));
                        Assert.That(sut.HouseName, Is.EqualTo(add2));
                        Assert.That(sut.Address3, Is.EqualTo(add3));
                        Assert.That(sut.Address4, Is.EqualTo(add5));
                        Assert.That(sut.Address5, Is.EqualTo(add6));
                        Assert.That(sut.Address6, Is.EqualTo(""));
                    }
            }
    }