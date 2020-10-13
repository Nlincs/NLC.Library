//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UPRNTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:56 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        /* Series of tests to check the functionality of UPRN works as it should be, analysing the behaviour and ensuring it's working
    * as it should be. */

        [TestFixture]
        public class UprnTests
            {
                /// <summary>
                ///     test Value set
                /// </summary>
                /// <param name="uprn"></param>
                [Test]
                [Sequential]
                public void AssignedZeroOrNegativeUprnValueIsNull([Values(0,
                        -1,
                        -300)]
                    int uprn)
                    {
                        var sut = new Uprn {Value = uprn};
                        var actual = sut.Value;

                        var expected = sut.NullUprnValue;

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void ConstructorAcceptsLong()
                    {
                        //Check that long values are accepted
                        long test = 1234;
                        var sut = new Uprn(test);
                        Assert.That(sut,
                            Is.Not.Null);
                    }

                [Test]
                [Sequential]
                public void ConstructorAcceptsString([Values("hello world",
                        "12345",
                        "Sample",
                        "!ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â£$$^&*():")]
                    string test)
                    {
                        //Check that string values are accepted
                        var sut = new Uprn(test);
                        Assert.That(sut,
                            Is.Not.Null);
                    }

                [Test]
                public void CorrectValueIsNotDefault()
                    {
                        //Test to see a correct value is no set as default (i.e. the default
                        //is actually null
                        long value = 12345;
                        var sut = new Uprn(value);
                        var actual = sut.IsDefault();
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                public void EmptyValueGivesIsValidFalse()
                    {
                        //Test to ensure an empty value is recorded as not being a valid result
                        var sut = new Uprn();
                        var actual = sut.IsValid();
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                public void EmptyValueIsDefault()
                    {
                        //Check to ensure that the default return value is null to reduce errors overall
                        var sut = new Uprn();
                        var actual = sut.IsDefault();
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                public void EmptyValueIsEmpty()
                    {
                        //Test to ensure no other value is returned if nothing is passed
                        var sut = new Uprn();
                        var actual = sut.IsEmpty();
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                public void InvalidStringIsDefault([Values("abc",
                        "def",
                        "!$%^")]
                    string value)
                    {
                        var sut = new Uprn(value);
                        var actual = sut.IsDefault();
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                public void InvalidStringIsEmpty([Values("abc",
                        "def",
                        "!$$%")]
                    string value)
                    {
                        var sut = new Uprn(value);
                        var actual = sut.IsEmpty();
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                public void InvalidStringIsValidFalse([Values("abc",
                        "def",
                        "!$%^")]
                    string value)
                    {
                        var sut = new Uprn(value);
                        var actual = sut.IsValid();
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                public void NewEmptyUprnIsNotNull()
                    {
                        //Check that reference isn't empty
                        var sut = new Uprn();
                        Assert.That(sut,
                            Is.Not.Null);
                    }

                [Test]
                public void NonEmptyValueIsNotEmpty()
                    {
                        //Test to ensure that any passed value that isn't empty is recorded as not being empty
                        var value = 12345;
                        var sut = new Uprn(value);
                        var actual = sut.IsEmpty();
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                public void NullUprnValueIsCorrect()
                    {
                        long expected = -1;
                        var sut = new Uprn();
                        var actual = sut.NullUprnValue;
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void NullUprnValueIsDefault()
                    {
                        var u1 = new Uprn();
                        var sut = new Uprn(u1.NullUprnValue);
                        var actual = sut.IsDefault();
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                public void SensibleLongValuesAreValid([Values(1,
                        8090, 0123456789012, 23)]
                    long input)
                    {
                        
                        var uprn = new Uprn(input);
                        var actual = uprn.IsValidUprn(uprn);

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void SensibleStringValuesAreValid([Values("1",
                        "8090", "0123456789012", "        23     ")]
                    string input)
                    {
                      
                        var uprn = new Uprn(input);
                        var actual = uprn.IsValidUprn(uprn);

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void UprnHasCorrectValue()
                    {
                        //Check to see the UPRN contains a correct value, and this is passed correctly
                        long expected = 12345;
                        var sut = new Uprn(expected);
                        var actual = sut.Value;
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

           

                [Test]
                [Combinatorial]
                public void UprnIsInequal(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numUprn = new Uprn(x);

                        var stringUprn = new Uprn(s);

                        var actual = numUprn != stringUprn;

                        Assert.That(actual, Is.True);
                    }

           

                [Test]

                // ReSharper disable once InconsistentNaming
                public void UPRNIsIUPRN()
                    {
                        //Test to see if UPRN is an instance of IUPRN
                        var sut = new Uprn();
                        Assert.That(sut,
                            Is.InstanceOf(typeof(IUprn)));
                    }

                [Test]
                [Combinatorial]
                public void UprnIsNotEqual(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numUprn = new Uprn(x);

                        var stringUprn = new Uprn(s);

                        var actual = numUprn == stringUprn;

                        Assert.That(actual, Is.False);

                        Assert.That(numUprn, Is.Not.EqualTo(stringUprn));
                    }

                [Test]
                [Sequential]
                public void UprnReferenceIsEqual(
                    [Values("1", "2", "3")] string s)
                    {
                        var stringUprn = new Uprn(s);

                        Assert.That(stringUprn, Is.EqualTo(stringUprn));
                    }

                [Test]
                public void WierdLongValuesAreNotValid([Values(-1, 0, 01234567890123)] long input)
                    {
                        
                        var uprn = new Uprn(input);
                        var actual = uprn.IsValidUprn(uprn);

                        Assert.That(actual, Is.False);
                    }

                [Test]
                public void WierdValuesAreNotValid([Values("",
                        "-1", "01234567890123", "e", "uprn", "   0.12")]
                    string input)
                    {
                     

                        var uprn = new Uprn(input);
                        var actual = uprn.IsValidUprn(uprn);

                        Assert.That(actual, Is.False);
                    }
            }
    }