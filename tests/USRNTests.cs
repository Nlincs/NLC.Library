//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=USRNTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:59 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        /* Series of tests to check the functionality of UPRN works as it should be, analysing the behaviour and 
    * ensuring it's working as it should be. */

        [TestFixture]
        public class UsrnTests
            {
                /// <summary>
                ///     test Value set
                /// </summary>
                /// <param name="usrn"></param>
                [Test]
                [Sequential]
                public void AssignedZeroOrNegativeUprnValueIsNull([Values(0,
                        -1,
                        -300)]
                    int usrn)
                    {
                        var sut = new Usrn {Value = usrn};
                        var actual = sut.Value;

                        long? expected = sut.NullUsrnValue;

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void ConstructorAcceptsLong()
                    {
                        //Check that long values are accepted
                        long test = 1234;
                        var sut = new Usrn(test);
                        Assert.NotNull(sut);
                    }

                [Test]
                [Sequential]
                public void ConstructorAcceptsString([Values("hello world",
                        "12345",
                        "Sample",
                        "!Ã‚Â£$$^&*():")]
                    string test)
                    {
                        //Check that string values are accepted
                        var sut = new Usrn(test);
                        Assert.NotNull(sut);
                    }

                [Test]
                public void DefaultIsRecognised()
                    {
                        var input = new Usrn();
                        var expected = true;

                        var actual = input.IsDefault();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                public void EmptyValueGivesIsValidFalse()
                    {
                        //Test to ensure an empty value is recorded as not being a valid result
                        var sut = new Usrn();
                        var actual = sut.IsValid();
                        Assert.False(actual);
                    }

                [Test]
                public void EmptyValueIsEmpty()
                    {
                        //Test to ensure no other value is returned if nothing is passed
                        var sut = new Usrn();
                        var actual = sut.IsEmpty();
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void InvalidStringIsEmpty([Values("abc",
                        "def",
                        "!$$%")]
                    string value)
                    {
                        var sut = new Usrn(value);
                        var actual = sut.IsEmpty();
                        Assert.True(actual);
                    }

                [Test]
                [Sequential]
                public void InvalidStringIsValidFalse([Values("abc",
                        "def",
                        "!$%^")]
                    string value)
                    {
                        var sut = new Usrn(value);
                        var actual = sut.IsValid();
                        Assert.False(actual);
                    }

                [Test]
                public void NewEmptyUsrnIsNotNull()
                    {
                        //Check that reference isn't empty
                        var sut = new Usrn();
                        Assert.NotNull(sut);
                    }

                [Test]
                public void NonEmptyValueIsNotEmpty()
                    {
                        //Test to ensure that any passed value that isn't empty is recorded as not being empty
                        const long value = 12345;
                        var sut = new Usrn(value);
                        var actual = sut.IsEmpty();
                        Assert.AreEqual(actual,
                            false);
                    }

                [Test]
                public void SensibleLongValuesAreValid([Values(1,
                        8090,
                        012345678901,
                        23)]
                    long input)
                    {
                        var expected = true;

                        var usrn = new Usrn(input);
                        var actual = usrn.IsValidUsrn(input);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void SensibleStringValuesAreValid([Values("1",
                        "8090",
                        "012345678901",
                        "        23     ")]
                    string input)
                    {
                        var expected = true;

                        var usrn = new Usrn(input);
                        var actual = usrn.IsValidUsrn(input);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void UsrnHasCorrectValue()
                    {
                        //Check to see the USRN contains a correct value, and this is passed correctly
                        long expected = 12345;
                        var sut = new Usrn(expected);
                        var actual = sut.Value;
                        Assert.AreEqual(actual,
                            expected);
                    }

                [Test]
                [Sequential]
                public void UsrnIsEqual(
                    [Values(1, 2, 3)] int x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numUsrn = new Usrn(x);

                        var stringUsrn = new Usrn(s);

                        var actual = numUsrn == stringUsrn;

                        Assert.That(actual, Is.True);

                        Assert.That(numUsrn, Is.EqualTo(stringUsrn));
                    }

                [Test]
                public void UsrnIsEquatable()
                    {
                        var sut = new Usrn();

                        Assert.IsInstanceOf<IEquatable<IUsrn>>(sut);
                    }

                [Test]
                [Combinatorial]
                public void UsrnIsInequal(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numUsrn = new Usrn(x);

                        var stringUsrn = new Usrn(s);

                        var actual = numUsrn != stringUsrn;

                        Assert.That(actual, Is.True);
                    }

                [Test]
                [Sequential]
                public void UsrnIsInequalTo(
                    [Values(1, 2, 3)] int x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numUsrn = new Usrn(x);

                        var stringUsrn = new Usrn(s);

                        var actual = numUsrn != stringUsrn;

                        Assert.That(actual, Is.False);
                    }


                [Test]
                public void UsrnisIusrn()
                    {
                        //Test to see if USRN is an instance of IUSRN
                        var sut = new Usrn();
                        Assert.That(sut,
                            Is.InstanceOf(typeof(IUsrn)));
                    }

                [Test]
                [Combinatorial]
                public void UsrnIsNotEqual(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numUsrn = new Usrn(x);

                        var stringUsrn = new Usrn(s);

                        var actual = numUsrn == stringUsrn;

                        Assert.That(actual, Is.False);

                        Assert.That(numUsrn, Is.Not.EqualTo(stringUsrn));
                    }

                [Test]
                public void ValidUsrnIsNotDefault()
                    {
                        var input = new Usrn(123);

                        var expected = false;

                        var actual = input.IsDefault();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                public void ValidUsrnIsValid()
                    {
                        var input = new Usrn(123);

                        var expected = true;

                        var actual = input.IsValid();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void WierdLongValuesAreNotValid([Values(-1,
                        0,
                        01234567890123)]
                    long input)
                    {
                        var expected = false;

                        var usrn = new Usrn(input);
                        var actual = usrn.IsValidUsrn(input);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void WierdValuesAreNotValid([Values("",
                        "-1",
                        "01234567890123",
                        "e",
                        "uprn",
                        "   0.12")]
                    string input)
                    {
                        var expected = false;

                        var usrn = new Usrn(input);
                        var actual = usrn.IsValidUsrn(input);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }
            }
    }