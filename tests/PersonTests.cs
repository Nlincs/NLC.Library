//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimplePersonTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
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
        public class PersonTests
            {
                [SetUp]
                public void SetUp() => mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => mockRepository.VerifyAll();

                private MockRepository mockRepository;

                private Person CreateSimplePerson() => new Person();

                [Test]
                public void CheckInterfaces()
                    {
                        // Arrange
                        var simplePerson = CreateSimplePerson();

                        // Act


                        // Assert
                        Assert.IsInstanceOf<IPerson>(simplePerson);
                    }

                [Test]
                public void Default_Person_IsNotValid()
                    {
                        var person = new Person();

                        Assert.That(person.IsValid, Is.False);
                    }

                [Test]
                public void EmptyPersonReturnsEmptyString()
                    {
                        var sut = CreateSimplePerson();

                        var actual = sut.FullName;
                        var expected = "";

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void FullNameReturnsExpected()
                    {
                        var sut = CreateSimplePerson();

                        var title = "Ms";
                        var forname = "somebody";
                        var surname = "Surname";

                        sut.Title = title;
                        sut.Forename = forname;
                        sut.Surname = surname;

                        var expected = title + " " + forname + " " + surname;

                        var actual = sut.FullName;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void NullForename_returnsExpectedFullName()
                    {
                        var sut = CreateSimplePerson();

                        string forename = null;
                        var surname = "Surname";

                        sut.Forename = forename;
                        sut.Surname = surname;

                        var expected = surname;

                        var actual = sut.FullName;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void NullName_returnsExpectedFullName()
                    {
                        var sut = CreateSimplePerson();

                        string forename = null;
                        string surname = null;

                        sut.Forename = forename;
                        sut.Surname = surname;

                        var expected = "";

                        var actual = sut.FullName;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void NullSurname_returnsExpectedFullName()
                    {
                        var sut = CreateSimplePerson();

                        var forename = "Forename";
                        string surname = null;

                        sut.Forename = forename;
                        sut.Surname = surname;

                        var expected = forename;

                        var actual = sut.FullName;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PartialNameReturnsExpected()
                    {
                        var sut = CreateSimplePerson();

                        var title = "Ms";
                        var surname = "Surname";

                        sut.Title = title;
                        sut.Surname = surname;

                        var expected = title + " " + surname;

                        var actual = sut.FullName;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void Person_NoName_IsNotValid()
                    {
                        var person = new Person {Title = "something",};

                        Assert.That(person.IsValid, Is.False);
                    }
            }
    }