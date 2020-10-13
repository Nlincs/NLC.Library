//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimpleTelephoneNumberTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:38
//  Altered - 16/10/2020 14:06 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

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
                   
                        var actual = new TelephoneNumber(null);

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