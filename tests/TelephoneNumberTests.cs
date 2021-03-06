//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumberTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 14:01 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class TelephoneNumberTests
            {
                [SetUp]
                public void Setup() => _sut = new TelephoneNumber();

                private TelephoneNumber _sut;


                [Test]
                public void ClassIsNotNull()
                    {
       
                        Assert.That(_sut, Is.Not.NaN);
                        Assert.That(_sut.Value, Is.Null.Or.Empty);
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
                        var number = "012345 5789";

                        var expectedNumber = "0123455789";

                        var simpleTel = new TelephoneNumber {Value = number};

                        var actual = simpleTel.Value;

                        Assert.That(actual, Is.EqualTo(expectedNumber));
                    }

          
                [Test]
                [Combinatorial]
                public void TelephoneNumberIsInequal(
                    [Values("1", "2", "3")] string x,
                    [Values("01234 567890", "12")] string s)
                    {
                        var numTelephoneNumber = new TelephoneNumber(x);

                        var stringTelephoneNumber = new TelephoneNumber(s);

                        Assert.That(numTelephoneNumber, Is.Not.EqualTo(stringTelephoneNumber));

                        Assert.That(!numTelephoneNumber.Equals(stringTelephoneNumber));

                        Assert.That(numTelephoneNumber != stringTelephoneNumber);
                    }

          
                [Test]
                [Combinatorial]
                public void TelephoneNumberIsNotEqual(
                    [Values("1", "2", "3")] string x,
                    [Values("01213456789", "12")] string s)
                    {
                        var numTelephoneNumber = new TelephoneNumber(x);

                        var stringTelephoneNumber = new TelephoneNumber(s);

                        var actual = numTelephoneNumber == stringTelephoneNumber;

                        Assert.That(actual, Is.False);

                        Assert.That(numTelephoneNumber, Is.Not.EqualTo(stringTelephoneNumber));
                    }
            }
    }