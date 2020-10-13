//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ContactTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 12:34 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using Moq;
using NLC.Library.Interfaces;
using NUnit.Framework;
using ServiceStack;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class ContactTests
            {
                [SetUp]
                public void SetUp()
                    {

                        mockRepository = new MockRepository(MockBehavior.Strict);
                     
                    }


                [TearDown]
                public void TearDown() => mockRepository.VerifyAll();

                private MockRepository mockRepository;
            

                private Contact CreateSimpleContact() => new Contact();

                [Test]
                public void CanSerialiseContact()
                    {
                        var title = "title";
                        var surname = "surname";
                        var forename = "forename";


                        var person = new Person {Title = title, Surname = surname, Forename = forename};

                        var address1 = "add1";
                        var address2 = "add2";
                        var address3 = "add3";
                        var address4 = "add4";
                        var address5 = "add5";
                        var uprn = new Uprn("12345");
                        var usrn = new Usrn();

                        var address = new AddressLines
                            {
                                Address1 = address1,
                                Address2 = address2,
                                Address3 = address3,
                                Address4 = address4,
                                Address5 = address5,
                                Uprn = uprn,
                                Usrn = usrn
                            };

                        var mobile =  new TelephoneNumber("123");
                        var preferred = new TelephoneNumber("789");

                        var sut = new Contact
                            {
                                Address = address,
                                HomePhone = new TelephoneNumber(),
                                MobilePhone = new TelephoneNumber("123"),
                                Person = person,
                                PreferredPhone = new TelephoneNumber("789")
                            };

                        var serialised = sut.ToJson();

                        Assert.That(serialised, Is.Not.Null.Or.Empty);
                        Assert.That(serialised.Length, Is.GreaterThan(40));

                        var deserialised = serialised.FromJson<Contact>();

                        Assert.That(deserialised, Is.Not.Null.Or.Empty);

                        Assert.That(deserialised.Person, Is.Not.Null);
                        Assert.That(deserialised.Person.Title, Is.EqualTo(title));
                        Assert.That(deserialised.Person.GivenName, Is.EqualTo(forename));
                        Assert.That(deserialised.Person.FamilyName, Is.EqualTo(surname));

                        Assert.That(deserialised.Address, Is.Not.Null.Or.Empty);

                        var actualAddress = (IAddressLines)deserialised.Address;
                        Assert.That(actualAddress.Address1, Is.EqualTo(address1));
                        Assert.That(actualAddress.Address2, Is.EqualTo(address2));
                        Assert.That(actualAddress.Address3, Is.EqualTo(address3));
                        Assert.That(actualAddress.Address4, Is.EqualTo(address4));
                        Assert.That(actualAddress.Address5, Is.EqualTo(address5));
                        Assert.That(actualAddress.Uprn, Is.Not.Null);

                        Assert.That(actualAddress.Uprn.Value.ToString(), Is.EqualTo(uprn.Value.ToString()));

                        Assert.That(deserialised.PreferredPhone, Is.Not.Null.Or.Empty);
                        Assert.That(deserialised.PreferredPhone, Is.EqualTo(preferred));
                        Assert.That(deserialised.MobilePhone, Is.Not.Null.Or.Empty);
                        Assert.That(deserialised.MobilePhone, Is.EqualTo(mobile));
                    }

                [Test]
                public void CheckInterfaces()
                    {
                        // Arrange
                        var simpleContact = CreateSimpleContact();

                        // Assert
                        Assert.IsInstanceOf<IContact>(simpleContact);
                    }

                [Test]
                public void ContactAcceptsSimpleAddress()
                    {
                        var primaryAddress = "padd";
                        var secondaryAddress = "2";
                        var county = "county";

                        var address = new AddressNamed
                            {
                                PrimaryAddress = primaryAddress,
                                SecondaryAddress = secondaryAddress,
                                County = county
                            };

                        var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(address);

                        var actual = sut.Address.FullAddress();


                        Assert.That(sut.Address, Is.EqualTo(address));
                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void ContactAcceptsSimpleAddressLine()
                    {
                        var primaryAddress = "padd";
                        var secondaryAddress = "2";
                        var county = "county";

                        var address = new AddressLines
                            {
                                Address1 = primaryAddress, Address2 = secondaryAddress, Address4 = county
                            };

                        var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(address);
                        var actual = sut.Address.FullAddress();


                        Assert.That(sut.Address, Is.EqualTo(address));
                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void ContactAcceptsSimpleAddressNameNumber()
                    {
                        var primaryAddress = "padd";
                        var secondaryAddress = "2";
                        var county = "county";

                        var address = new AddressNameNumber
                            {
                                HouseName = primaryAddress, HouseNumber = secondaryAddress, County = county
                            };

                        var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(address);
                        var actual = sut.Address.FullAddress();


                        Assert.That(sut.Address, Is.EqualTo(address));
                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }