//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimpleTelephoneNumberTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 14:23 - Stephen Ellwood
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
        [TestFixture]
        [Category("LIBRARY")]
        [Category("TelephoneNumber")]
        public class SimpleTelephoneNumberTests
            {
                [SetUp]
                public void Setup() => _sut = new TelephoneNumber();

                private TelephoneNumber _sut;


                [Test]
                public void ClassIsNotNull()
                    {
                        Assert.That(_sut, Is.Not.NaN);
                        Assert.That(_sut.Value, Is.EqualTo(""));
                        Assert.That(_sut, Is.InstanceOf<ITelephoneNumber>());
                    }

                [Test]
                public void EmptyInputReturnsEmptyPhoneNumber()
                    {
                        const string input = "";

                        var actual = new TelephoneNumber(input);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(input));
                    }

                [Test]
                public void NullInputReturnsEmptyPhoneNumber()
                    {
                        string input = null;

                        var actual = new TelephoneNumber(input);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Value, Is.EqualTo(""));
                    }


                [Test]
                public void SimpleNumberReturnsExpected()
                    {
                        var number = "12345 5789";
                        var expectedNumber = "123455789";


                        var simpleTel = new TelephoneNumber(number);

                        var actual = simpleTel.Value;

                        Assert.That(actual, Is.EqualTo(expectedNumber));
                    }

                [Test]
                [Sequential]
                public void SimpleTelephoneNumberIsEqual(
                    [Values("1", "2", "3")] string x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numSimpleTelephoneNumber = new TelephoneNumber(x);

                        var stringSimpleTelephoneNumber = new TelephoneNumber(s);

                        var actual = numSimpleTelephoneNumber == stringSimpleTelephoneNumber;

                        Assert.That(actual, Is.True);

                        Assert.That(numSimpleTelephoneNumber, Is.EqualTo(stringSimpleTelephoneNumber));
                    }

                [Test]
                public void SimpleTelephoneNumberIsEquatable()
                    {
                        var SimpleTelephoneNumber = new TelephoneNumber();

                        Assert.IsInstanceOf<IEquatable<ITelephoneNumber>>(SimpleTelephoneNumber);
                    }

                [Test]
                [Combinatorial]
                public void SimpleTelephoneNumberIsInequal(
                    [Values("1", "2", "3")] string x,
                    [Values("0123456789", "12")] string s)
                    {
                        var numSimpleTelephoneNumber = new TelephoneNumber(x);

                        var stringSimpleTelephoneNumber = new TelephoneNumber(s);

                        var actual = numSimpleTelephoneNumber != stringSimpleTelephoneNumber;

                        Assert.That(actual, Is.True);
                    }

                [Test]
                [Sequential]
                public void SimpleTelephoneNumberIsInequalTo(
                    [Values("1", "2", "3")] string x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numSimpleTelephoneNumber = new TelephoneNumber(x);

                        var stringSimpleTelephoneNumber = new TelephoneNumber(s);

                        var actual = numSimpleTelephoneNumber != stringSimpleTelephoneNumber;

                        Assert.That(actual, Is.False);
                    }

                [Test]
                [Combinatorial]
                public void SimpleTelephoneNumberIsNotEqual(
                    [Values("1", "2", "3")] string x,
                    [Values("0123456789", "12")] string s)
                    {
                        var numSimpleTelephoneNumber = new TelephoneNumber(x);

                        var stringSimpleTelephoneNumber = new TelephoneNumber(s);

                        var actual = numSimpleTelephoneNumber == stringSimpleTelephoneNumber;

                        Assert.That(actual, Is.False);

                        Assert.That(numSimpleTelephoneNumber, Is.Not.EqualTo(stringSimpleTelephoneNumber));
                    }
            }
    }