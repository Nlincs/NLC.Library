//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNamedTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:38
//  Altered - 17/12/2020 09:54 - Stephen Ellwood
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
        public class AddressNamedTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private AddressNamed CreateSimpleAddress() => new AddressNamed(null, null, null, null, null, null);

                [Test]
                public void CheckInterfaces()
                    {
                        // Arrange
                        var simpleAddressLine = CreateSimpleAddress();

                        // Act


                        // Assert
                        Assert.IsInstanceOf<ILocation>(simpleAddressLine);
                        Assert.IsInstanceOf<IAddressNamed>(simpleAddressLine);
                    }

                [Test]
                public void EmptyAddressIsEmpty()
                    {
                        var simpleAddressLine = CreateSimpleAddress();

                        var expected = "";

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                public void EmptyAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddress();

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void FullAddressReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddress();


                        var address1 = "address1";
                        var address2 = "Address2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";
                        var address6 = "county";

                        var postCode = "DN17 2AB";

                        simpleAddressLine.PrimaryAddress = address1;
                        simpleAddressLine.SecondaryAddress = address2;
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

                        var sut1 = CreateSimpleAddress();
                        sut1.PrimaryAddress = add1;
                        sut1.SecondaryAddress = add2;
                        sut1.Street = add3;
                        sut1.Location = add4;
                        sut1.Town = add5;
                        sut1.County = add6;
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddress();
                        sut2.PrimaryAddress = add11;
                        sut2.SecondaryAddress = add21;
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
                        var sut = CreateSimpleAddress();
                        sut.PrimaryAddress = "   1  ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.False);
                    }


                [Test]
                public void NullAddressIsEmptyCheck()
                    {
                        var sut = CreateSimpleAddress();
                        sut.Location = "     ";

                        var actual = sut.IsEmptyAddress();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void PartialAddress12345ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddress();


                        var address1 = "address1";
                        var address2 = "Address2";
                        var address3 = "add3";
                        var address4 = "4";
                        var address5 = "a5";

                        simpleAddressLine.PrimaryAddress = address1;
                        simpleAddressLine.SecondaryAddress = address2;
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
                        var simpleAddressLine = CreateSimpleAddress();


                        var address1 = "address1";
                        var address3 = "add3";
                        var address5 = "a5";

                        simpleAddressLine.PrimaryAddress = address1;
                        simpleAddressLine.Street = address3;
                        simpleAddressLine.Town = address5;

                        var expected = address1 + ", " + address3 + ", " + address5;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialAddress2ReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddress();

                        var postCode = "DN17 2AB";
                        var address = "Address2";

                        simpleAddressLine.PostCode = new PostCode(postCode);
                        simpleAddressLine.SecondaryAddress = address;

                        var expected = address + " " + postCode;

                        var actual = simpleAddressLine.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PostCodeOnlyReturnsExpected()
                    {
                        var simpleAddressLine = CreateSimpleAddress();

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

                        var sut1 = CreateSimpleAddress();
                        sut1.Location = add1;

                        var sut2 = CreateSimpleAddress();
                        sut2.Location = add2;

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                    }

                [Test]
                public void AddressNamedConstructor_ExpectedResults()
                    {
                        var addressLine = CreateSimpleAddress();
                        addressLine.PrimaryAddress = "add1";
                        addressLine.SecondaryAddress = "add2";
                        addressLine.Street = "add3";
                        addressLine.Location = "add4";
                        addressLine.Town = "add5";
                        addressLine.County = "add6";

                        var actual = new AddressNamed(addressLine);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Address1, Is.EqualTo("add1"));
                        Assert.That(actual.Address2, Is.EqualTo("add2"));
                        Assert.That(actual.Address3, Is.EqualTo("add3"));
                        Assert.That(actual.Address4, Is.EqualTo("add4"));
                        Assert.That(actual.Address5, Is.EqualTo("add5"));
                        Assert.That(actual.Address6, Is.EqualTo("add6"));
                    }


                [Test]
                public void AddressLinesConstructor_ExpectedResults()
                    {
                        var address = new AddressNameNumber("add1", "add2", "add3", "add4", "add5", "add6");

                        var actual = new AddressNamed(address);

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