//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ContactTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 19/10/2020 15:10
//  Altered - 17/12/2020 09:51 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
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
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);


                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;


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

                        var address = new Address(address1, address2, address3, address4, address5, null)
                            {
                                Uprn = uprn, Usrn = usrn
                            };

                        var mobile = new TelephoneNumber("123");
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

                        var actualAddress = deserialised.Address;
                        Assert.That(actualAddress.Address1, Is.EqualTo(address1));
                        Assert.That(actualAddress.Address2, Is.EqualTo(address2));
                        Assert.That(actualAddress.Address3, Is.EqualTo(address3));
                        Assert.That(actualAddress.Address4, Is.EqualTo(address4));
                        Assert.That(actualAddress.Address5, Is.EqualTo(address5));
                        Assert.That(actualAddress.Uprn, Is.Not.Null);

                        Assert.That(actualAddress.Uprn.Value.ToString(), Is.EqualTo(uprn.Value.ToString()));

                        Assert.That(deserialised.PreferredPhone, Is.Not.Null.Or.Empty);
                        Assert.That(deserialised.PreferredPhone.Value, Is.EqualTo(preferred.Value));
                        Assert.That(deserialised.MobilePhone, Is.Not.Null.Or.Empty);
                        Assert.That(deserialised.MobilePhone.Value, Is.EqualTo(mobile.Value));
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

                        var address = new AddressNamed(primaryAddress,secondaryAddress,null,null,null,county);

                        var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(new Address(address));

                        var actual = sut.Address.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void ContactAcceptsSimpleAddressLine()
                    {
                        var primaryAddress = "padd";
                        var secondaryAddress = "2";
                        var county = "county";

                        var address = new AddressLines(primaryAddress, secondaryAddress, null, null, null, county);

            var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(new Address(address));
                        var actual = sut.Address.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void ContactAcceptsSimpleAddressNameNumber()
                    {
                        var primaryAddress = "padd";
                        var secondaryAddress = "2";
                        var county = "county";

                        var address = new AddressNameNumber(primaryAddress, secondaryAddress, null, null, null, county);

            var expected = primaryAddress + ", " + secondaryAddress + ", " + county;

                        var sut = new Contact(new Address(address));
                        var actual = sut.Address.FullAddress();

                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }