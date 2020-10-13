//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=NassTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:54 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        [Category("LIBRARY")]
        [Category("NASS")]
        public class NassTests
            {
                [SetUp]
                public void Setup() => _sut = new Nass();

                private Nass _sut;

                [Test]
                public void NassIsNotNull()
                    {
                        var sut2 = new Nass("12ABC12");
                        Assert.That(_sut,
                            Is.Not.Null,
                            "Null with empty constructor");
                        Assert.That(sut2,
                            Is.Not.Null,
                            "Null with single constructor");
                    }

                [Test]
                [Sequential]
                public void NassMonthOutOfRangeReturnValidFalse([Values("000000000",
                        "001300000",
                        "009900000",
                        "151632452",
                        "994319584")]
                    string input)
                    {
                        // Lets test to ensure that the months aren't less than 1 or more than 12
                        var sut2 = new Nass(input);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            false);
                    }

                [Test]
                [Sequential]
                public void NassMonthReturnsCorrectValue([Values("0023456789",
                        "993456789",
                        "152346789",
                        "453388445",
                        "871087654")]
                    string input,
                    [Values("23",
                        "34",
                        "23",
                        "33",
                        "10")]
                    string months)
                    {
                        //Lets test the month string, ensuring the months array matches that of the input array
                        //Test will reply with true
                        var sut2 = new Nass(input);
                        var actual = sut2.MonthPart;
                        Assert.AreEqual(actual,
                            months);
                    }

                [Test]
                [Sequential]
                public void NassNot9CharsReturnsValidFalse([Values("12345678",
                        "1234567890",
                        "",
                        " ",
                        "!Â£$%^&*(){",
                        "ABCDEFGH")]
                    string input)
                    {
                        //Expected false as there aren't exactly 9 characters
                        var sut2 = new Nass(input);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(false,
                            actual);
                    }

                [Test]
                [Sequential]
                public void NassNotAllNumericReturnsValidFalse([Values("123456 89",
                        "0000.0000",
                        "1e345g789",
                        "abcdefghi")]
                    string input)
                    {
                        //Expected false as not all of the characters are a numeric value
                        var sut2 = new Nass(input);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(false,
                            actual);
                    }

                [Test]
                [Sequential]
                public void NassNumberPartReturnsCorretValue([Values("0023456789",
                        "998765432",
                        "000000000",
                        "010112345")]
                    string input,
                    [Values("456789",
                        "65432",
                        "00000",
                        "12345")]
                    string lastChars)
                    {
                        //Lets test the final 5 characters, ensuing the lastChars array matches that of the input array
                        //Test will reply with true
                        var sut2 = new Nass(input);
                        var actual = sut2.NumberPart;
                        Assert.AreEqual(actual,
                            lastChars);
                    }

                [Test]
                [Sequential]
                public void NassSensibleIdReturnsValidTrue([Values("150312345",
                        "220119876",
                        "450953254",
                        "991204856")]
                    string input)
                    {
                        //Now lets test to ensure the sensible options [between 1 and 12] 
                        var sut2 = new Nass(input);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void NassYearReturnsCorrectValue([Values("0023456789",
                        "0000000000",
                        "993456789",
                        "152346789",
                        "453388445",
                        "871087654",
                        "998765432")]
                    string input,
                    [Values("00",
                        "00",
                        "99",
                        "15",
                        "45",
                        "87",
                        "99")]
                    string years)
                    {
                        //Lets test the year string, ensuring the years array matches that of the input array
                        //Test will reply with true
                        var sut2 = new Nass(input);
                        var actual = sut2.YearPart;
                        Assert.AreEqual(actual,
                            years);
                    }

                //1. Must be 9 numerical characters [0-9].

                // Criteria
                //2. First 2 characters must be year [e.g. 15 (2015)].
                //3. Next 2 characters must be months [e.g. 12 (December) - cannot be <=0 or >=13.]
                //4. Final 5 are random numeric characters.
                // I.E. 150612345 is valid 
            }
    }