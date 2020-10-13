//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=GovernmentDataTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:37
//  Altered - 16/10/2020 16:35 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions.NationalGovernment.eGIF;
using NUnit.Framework;

namespace NLC.Library.Tests.Extensions
    {
        [TestFixture]
        [Category("NLC.Library")]
        [Category("GovernmentData")]
        public class GovernmentDataTests
            {
                [Test]
                [Combinatorial]
                public void ArbitraryDateCombinationsReturnFalse([Values("!0",
                        "1234567890",
                        "2",
                        "31",
                        "",
                        "1e")]
                    string day,
                    [Values("/",
                        "1/2",
                        "2-2"
                    )]
                    string month,
                    [Values("1800",
                        "2050")]
                    string year)
                    {
                        var input = year + "-" + month + "-" + day;

                        var actual = input.IsValidDate();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Combinatorial]
                public void ArbitraryPCodesAreValid([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        var input = new PostCode(outcode + " " + incode);

                        var actual = input.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Combinatorial]
                public void ArbitraryPostCodesAreValid([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)
                    {
                        var input = outcode + " " + incode;

                        var actual = input.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }


                [Test]
                [Combinatorial]
                public void InValidDateCombinationsReturnFalse([Values(0,
                        2,
                        31,
                        32,
                        56)]
                    int day,
                    [Values(0,
                        32,
                        13
                    )]
                    int month,
                    [Values(1800,
                        2050)]
                    int year)
                    {
                        var input = year + "-" + month.ToString("00") + "-" + day.ToString("00");

                        var actual = input.IsValidDate();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.False);
                    }

                /// <summary>
                ///     Test to see if the NI number is rejected if any of the 6 numeric values are incorrectly placed
                /// </summary>
                /// <returns>False</returns>
                [Test]
                [Sequential]
                public void NinoWithExactly9Chars6NumericIncorrect([Values("ABC23456A",
                        "AB1 3456A",
                        "AB12B456C",
                        "AB123G56 ",
                        "AB1234I6A",
                        "AB12345PA")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }

                /// <summary>
                ///     Test to see if the NI number is rejected if specific combinations of first 2 alphas are entered
                /// </summary>
                /// <returns>False</returns>
                [Test]
                [Sequential]
                public void NinoWithExactly9CharsBadCombos([Values("GB012345A",
                        "BG392859A",
                        "NK224351 ",
                        "KN483920C",
                        "TN543210B",
                        "NT942840A",
                        "ZZ947392C")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }

                /// <summary>
                ///     Test to see if the NI number is rejected if first character out of scope
                /// </summary>
                /// <returns>False</returns>
                [Test]
                [Sequential]
                public void NinoWithExactly9CharsFirstBadAlphas([Values(" T012345E",
                        "0T012345E",
                        "1T012345E",
                        "2T012345E",
                        "3T012345E",
                        "4T012345E",
                        "5T012345E",
                        "6T012345E",
                        "7T012345E",
                        "8T012345E",
                        "9T012345E",
                        "DA013451A",
                        "FB123456A",
                        "IB123456A",
                        "QA123456A",
                        "UK123456 ",
                        "VT123456A")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }

                [Test]
                [Sequential]
                public void NinoWithExactly9CharsIsValid([Values("ab123346a",
                        "xz654321 ")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(true));
                    }

                /// <summary>
                ///     Test to see if the NI number is rejected if last character out of scope
                /// </summary>
                /// <returns>False</returns>
                [Test]
                [Sequential]
                public void NinoWithExactly9CharsLastBadAlpha([Values("VT012345E",
                        "VT012345F",
                        "VT012345G",
                        "VT012345H",
                        "VT012345I",
                        "VT012345J",
                        "VT012345K",
                        "VT012345L",
                        "VT012345M",
                        "VT012345N",
                        "VT012345O",
                        "VT012345P",
                        "VT012345Q",
                        "VT012345R",
                        "VT012345S",
                        "VT012345T",
                        "VT012345U",
                        "VT012345V",
                        "VT012345W",
                        "VT012345X",
                        "VT012345Y",
                        "VT012345Z",
                        "VT0123450",
                        "VT0123451",
                        "VT0123452",
                        "VT0123453",
                        "VT0123454",
                        "VT0123455",
                        "VT0123456",
                        "VT0123457",
                        "VT0123458",
                        "VT0123459")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }

                /// <summary>
                ///     Test to see if the NI number is rejected if second character out of scope
                /// </summary>
                /// <returns>False</returns>
                [Test]
                [Sequential]
                public void NinoWithExactly9CharsSecondBadAlphas([Values("T 012345E",
                        "TO012345E",
                        "T1012345E",
                        "T2012345E",
                        "T3012345E",
                        "T4012345E",
                        "T5012345E",
                        "T6012345E",
                        "T7012345E",
                        "T8012345E",
                        "T9012345E",
                        "AD013451A",
                        "BF123456A",
                        "BI123456A",
                        "AO123456A",
                        "AQ123456A",
                        "KU123456 ",
                        "TV123456A")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }

                [Test]
                [Sequential]
                public void NinoWithout9CharsIsInvalid([Values("",
                        " ",
                        "12345678",
                        "0.123456",
                        "abcdefghi",
                        "0123456789")]
                    string nino)
                    {
                        var actual = nino.IsValidNiNumber();
                        Assert.That(actual,
                            Is.EqualTo(false));
                    }


                [Test]
                [Combinatorial]
                public void RandomInvalidPCodesAreFalse([Values("TN4444",
                        "     ",
                        "DN 23 33 23",
                        "3",
                        "-",
                        "ABCDEFGHIJKLMNO",
                        "C",
                        ""
                    )]
                    string outcode,
                    [Values("",
                        "AZ",
                        "3D",
                        "2",
                        "C",
                        "9ZZ",
                        "   ")]
                    string incode)
                    {
                        var input = new PostCode(outcode + " " + incode);

                        var actual = input.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Combinatorial]
                public void RandomInvalidPostCodesAreFalse([Values("TN444",
                        "     ",
                        "DN 23 33 23",
                        "3",
                        "-",
                        "ABCDEFGHIJKLMNO",
                        "C",
                        ""
                    )]
                    string outcode,
                    [Values("",
                        "AZ",
                        "3D",
                        "2",
                        "C",
                        "9ZZ",
                        "   ")]
                    string incode)
                    {
                        var input = outcode + " " + incode;

                        var actual = input.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Combinatorial]
                public void RandomPCodesAreNotNLincsAnon([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)

                    {
                        var pcode = new PostCode(outcode + " " + incode);

                        var actual = pcode.IsNorthlincsAnonymousPostcode();

                        Assert.That(actual, Is.False);
                    }


                [Test]
                [Combinatorial]
                public void RandomPostCodesAreNotNLincsAnon([Values("TN4",
                        "DN3",
                        "DN17",
                        "DN37",
                        "DN33",
                        "CH5",
                        "M1",
                        "DN 3",
                        "W1P",
                        "EC1A")]
                    string outcode,
                    [Values("9BP",
                        "3AZ",
                        "3DE",
                        "2JT",
                        "3HW")]
                    string incode)

                    {
                        var pcode = outcode + " " + incode;

                        var actual = pcode.IsNorthlincsAnonymousPostcode();

                        Assert.That(actual, Is.False);
                    }

                [Test]
                public void TooManyWordsIsNotValid()
                    {
                        var input = "M 4 9 BP";


                        var actual = input.IsValidUkPostCode();

                        Assert.That(actual, Is.False);
                    }

                [Test]
                [Combinatorial]
                public void ValidDateCombinationsReturnTrue([Values(1,
                        2,
                        3,
                        28,
                        14)]
                    int day,
                    [Values(1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7,
                        8,
                        9,
                        10,
                        11,
                        12)]
                    int month,
                    [Values(1900,
                        2018,
                        1945,
                        2000)]
                    int year)
                    {
                        var input = year + "-" + month.ToString("00") + "-" + day.ToString("00");

                        var actual = input.IsValidDate();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Combinatorial]
                public void WierdPCodesWork([Values("GIR 0AA",
                        "SW1A 1AA")]
                    string pcode)
                    {
                        var postcode = new PostCode(pcode);

                        var actual = postcode.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Combinatorial]
                public void WierdPostCodesWork([Values("GIR 0AA",
                        "SW1A 1AA")]
                    string postcode)
                    {
                        var actual = postcode.IsValidUkPostCode();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }
            }
    }