//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=StringExtensionsTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:37
//  Altered - 19/04/2022 11:56 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;

namespace NLC.Library.Tests.Extensions
    {
        /// <summary>
        /// </summary>
        [TestFixture]
        public class StringExtensionsTests
            {
                [Test]
                [Category("BooleanValue")]
                [Sequential]
                public void BooleanValueIsFalse([Values("false",
                        "N",
                        "no",
                        "F",
                        " f")]
                    string input)
                    {
                        var actual = input.BooleanValue();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Category("BooleanValue")]
                [Sequential]
                public void BooleanValueIsNothingForNonBool([Values("",
                        " ",
                        "123",
                        "Hello",
                        "trumped",
                        "I think this is untrue",
                        "True true    ")]
                    string input)
                    {
                        var actual = input.BooleanValue();

                        Assert.That(actual,
                            Is.Null.Or.Empty);
                    }

                [Test]
                [Category("BooleanValue")]
                [Sequential]
                public void BooleanValueIsTrue([Values("true",
                        "T",
                        "y",
                        "yes",
                        " TrUe")]
                    string input)
                    {
                        var actual = input.BooleanValue();

                        Assert.That(actual,
                            Is.True);
                    }

                [Category("CamelCaseSplit")]
                [Test]
                public void CamelCaseSplitsToExpectedWords()
                    {
                        var input = "thisIsATest";

                        var results = input.CamelCaseSplit();
                        Assert.That(results,
                            Is.Not.Null);
                        Assert.That(results[0],
                            Is.EqualTo("This"));
                        Assert.That(results[1],
                            Is.EqualTo("Is"));
                        Assert.That(results[2],
                            Is.EqualTo("A"));
                        Assert.That(results[3],
                            Is.EqualTo("Test"));
                    }

                [Category("CamelCaseSplit")]
                [Test]
                public void CamelCaseSplitsToExpectedWords2()
                    {
                        var input = "UPRN";

                        var results = input.CamelCaseSplit();
                        Assert.That(results,
                            Is.Not.Null);
                        Assert.That(results[0],
                            Is.EqualTo("UPRN"));
                    }

                [Test]
                [Category("CamelCaseSplit")]
                [Sequential]
                public void CamelCaseSplitWorksAsExpected([Values("",
                        "This is a test",
                        "T")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.CamelCaseSplit();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual.FirstOrDefault(),
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("IsAlphabeticCharacter")]
                [Sequential]
                public void CharacterIsAlphabeticIsTrue([Values("T",
                        "y",
                        "a")]
                    string input)
                    {
                        var actual = input.IsAlphabeticCharacter();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Category("IsNumericCharacter")]
                public void EmptyIsNumericCharactersIsFalse()
                    {
                        var input = string.Empty;

                        var actual = input.IsNumericCharacters();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Category("PrettyXml")]
                public void EmptyStringDoesntError()
                    {
                        var expected = "";

                        var testString = "";

                        var actual = testString.PrettyXml();

                        Assert.That(expected,
                            Is.EqualTo(actual));
                    }

                [Test]
                [Category("FirstWord")]
                public void FirstWordDoesNotIgnoreLeadingSpace()
                    {
                        var input = " This Is A Test";
                        var expected = "";

                        var actual = input.FirstWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("FirstWord")]
                public void FirstWordEqualsWord1()
                    {
                        var input = "This is some random string";

                        var expected = "This";

                        var firstwordResult = input.FirstWord();
                        var wordNResult = input.NthWord(1);

                        Assert.That(firstwordResult,
                            Is.EqualTo(wordNResult));
                        Assert.That(firstwordResult,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("FirstWord")]
                public void FirstWordFound()
                    {
                        var input = "This Is A Test";
                        var expected = "This";

                        var actual = input.FirstWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("FirstWord")]
                public void FirstWordOfOne()
                    {
                        var input = "ThisIsATest";
                        var expected = "ThisIsATest";

                        var actual = input.FirstWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("InStr")]
                public void InstrProducesExpectedOutput(
                    [Values("       ",
                        "I dont think this works",
                        "no  ",
                        "F",
                        " f",
                        "FFFFFFFFF")]
                    string input,
                    [Values("",
                        "N",
                        "no  ",
                        "F ",
                        "f",
                        "FF")]
                    string lookFor,
                    [Values(1,
                        0,
                        1,
                        0,
                        2,
                        1)]
                    int expected)
                    {
                        // expected output - https://msdn.microsoft.com/en-us/vba/language-reference-vba/articles/instr-function?f=255&MSPPError=-2147217396


                        var actual = input.InStr(lookFor);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("IsAllWhitespace")]
                [Combinatorial]
                public void IsAllWhiteSpaceIsFalse([Values("0",
                        "  .  ",
                        "_ ")]
                    string sInput,
                    [Values(' ',
                        '\x0',
                        '\x8',
                        '\u0133')]
                    char cinput)
                    {
                        var input = sInput + cinput;

                        var actual = input.IsAllWhitespace();

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Category("IsAllWhitespace")]
                [Combinatorial]
                public void IsAllWhiteSpaceIsTrue([Values("",
                        "    ",
                        " ")]
                    string sinput,
                    [Values(' ',
                        '\x0',
                        '\x8',
                        '\u0133')]
                    char cinput)
                    {
                        var input = sinput + cinput;

                        var actual = input.IsAllWhitespace();

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Category("IsAlphabeticCharacter")]
                [Sequential]
                public void IsAlphabeticCharacterIsFalse([Values("true.",
                        "1",
                        "",
                        " ",
                        "\"",
                        ",",
                        "hi it's me")]
                    string input)
                    {
                        var actual = input.IsAlphabeticCharacter();

                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Sequential]
                [Category("IsAlphabetic")]
                public void IsAlphabeticIsFalse([Values("true.",
                        "1",
                        "",
                        " ",
                        "hi it's me")]
                    string input)
                    {
                        var actual = input.IsAlphabetic();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Sequential]
                [Category("IsAlphabetic")]
                public void IsAlphabeticIsTrue([Values("true",
                        "T",
                        "y",
                        "yes",
                        "TrUe")]
                    string input)
                    {
                        var actual = input.IsAlphabetic();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsAlphaNumericCharacter")]
                public void IsAlphanumericCharacterIsFalse([Values("true",
                        "1 ",
                        "",
                        " ",
                        "hi it's me",
                        "2^3",
                        "1e")]
                    string input)
                    {
                        var actual = input.IsAlphaNumericCharacter();

                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Sequential]
                [Category("IsAlphaNumericCharacter")]
                public void IsAlphanumericCharacterIsTrue([Values("T",
                        "y",
                        "a",
                        "1",
                        "2",
                        "A",
                        "e")]
                    string input)
                    {
                        var actual = input.IsAlphaNumericCharacter();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsAlphaNumeric")]
                public void IsAlphanumericIsFalse([Values("true.",
                        "1 ",
                        "",
                        " ",
                        "hi it's me",
                        "2^3")]
                    string input)
                    {
                        var actual = input.IsAlphaNumeric();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Sequential]
                [Category("IsAlphaNumeric")]
                public void IsAlphanumericIsTrue([Values("T",
                        "y",
                        "a",
                        "1",
                        "123",
                        "1A1",
                        "2e3")]
                    string input)
                    {
                        var actual = input.IsAlphaNumeric();

                        Assert.That(actual,
                            Is.True);
                    }


                [Test]
                [Sequential]
                [Category("Unicode")]
                public void IsHtmlUnicode_ExpectedTrue([Values("&AElig;", "&Ucirc;", "&#330;")] string input)
                    {
                        var actual = WebUtility.HtmlDecode(input).IsUnicode();

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsInteger")]
                public void IsIntegerIsFalse([Values("1.567 ",
                        "2e3",
                        "true",
                        "111-1010",
                        "",
                        " ",
                        "hi it's me",
                        "2^3",
                        "1e")]
                    string input)
                    {
                        var actual = input.IsInteger();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Sequential]
                [Category("IsInteger")]
                public void IsIntegerIsTrue([Values("0",
                        "1",
                        "-26",
                        "290")]
                    string input)
                    {
                        var actual = input.IsInteger();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsLong")]
                public void IslongIsFalse([Values("1.567 ",
                        "2e3",
                        "true",
                        "111-1010",
                        "",
                        " ",
                        "hi it's me",
                        "2^3",
                        "1e")]
                    string input)
                    {
                        var actual = input.IsLong();

                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Sequential]
                [Category("IsLong")]
                public void IsLongIsTrue([Values("0",
                        "1",
                        "-26",
                        "2147483647",
                        "-3147483647")]
                    string input)
                    {
                        var actual = input.IsLong();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsNumeric")]
                public void IsNumericCharacterIsFalse([Values("1.567. ",
                        "2e3e2",
                        "true",
                        "111-1010",
                        "",
                        " 65",
                        "hi it's me",
                        "2^3",
                        "1e")]
                    string input)
                    {
                        var actual = input.IsNumericCharacter();

                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Sequential]
                [Category("IsNumericCharacter")]
                public void IsNumericCharacterIsTrue([Values("0",
                        "1",
                        "9")]
                    string input)
                    {
                        var actual = input.IsNumericCharacter();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsNumericCharacter")]
                public void IsNumericCharactersIsTrue([Values("0",
                        "1",
                        "67890")]
                    string input)
                    {
                        var actual = input.IsNumericCharacters();

                        Assert.That(actual,
                            Is.True);
                    }

                [Test]
                [Sequential]
                [Category("IsNumeric")]
                public void IsNumericIsFalse([Values("1.567. ",
                        "2e3e2",
                        "true",
                        "111-1010",
                        "",
                        " ",
                        "hi it's me",
                        "2^3",
                        "1e")]
                    string input)
                    {
                        var actual = input.IsNumeric();

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Sequential]
                [Category("IsNumeric")]
                public void IsNumericIsTrue([Values("0",
                        "1",
                        "-26",
                        "2147483647",
                        "-3147483647",
                        "2,147,483,647",
                        "2e4")]
                    string input)
                    {
                        var actual = input.IsNumeric();

                        Assert.That(actual,
                            Is.True);
                    }


                [Test]
                [Sequential]
                [Category("Unicode")]
                public void IsUnicode_ExpectedFalse([Values(" ", "1", "Z", "z0\n")] string input)
                    {
                        var actual = input.IsUnicode();

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual,
                            Is.False);
                    }

                [Test]
                [Sequential]
                [Category("Unicode")]
                public void IsUnicode_ExpectedTrue([Values('\u0b85', '\u0b86', '\u0080')] char input)
                    {
                        var actual = input.IsUnicode();

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual,
                            Is.True);
                    }
#if Windows
                [Test]
                [Category("IsValidFileName")]
                [Sequential]
                public void IsValidFileName_ExpectFalse([Values("\n",
                        "\0",
                        "this--is--string\r",
                        "----\nThis--is----also a string---",
                        "This/is/a/normal/string", "&&*($", "*.*", "*")]
                    string input)
                    {
                      

                        var actual = input.IsValidWindowsFileName();

                        Assert.That(actual, Is.False);
                    }

                [Test]
                [Category("IsValidFileName")]
                [Sequential]
                public void IsValidFileName_ExpectTrue([Values(@"e:\Somefile.txt",
                        @"\\SomeServer\Path\File.txt",
                        "thisIsString.html")]
                    string input)
                    {
                   

                        var actual = input.IsValidWindowsFileName();

                        Assert.That(actual, Is.True);
                    }
#endif
                [Test]
                [Sequential]
                [Category("IsWhitespace")]
                public void IsWhiteSpaceIsFalse([Values('0',
                        '\u0001',
                        '\x88')]
                    char input)
                    {
                        var actual = input.IsWhitespace();

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.False);
                    }


                [Test]
                [Sequential]
                [Category("IsWhitespace")]
                public void IsWhiteSpaceIsTrue([Values(' ',
                        '\u0000',
                        '\x08', '\n', '\r', '\t')]
                    char input)
                    {
                        var actual = input.IsWhitespace();

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.True);
                    }


                [Test]
                [Category("LastWord")]
                public void LasttWordDoesNotIgnoreTrailingSpace()
                    {
                        var input = " This Is A Test ";
                        var expected = "";

                        var actual = input.LastWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("LastWord")]
                public void LastWordEqualsWordN()
                    {
                        var input = "This is some random string";
                        var words = 5;

                        Assert.That(input.WordCount(),
                            Is.EqualTo(words));

                        var expected = "string";

                        var lastwordResult = input.LastWord();
                        var wordNResult = input.NthWord(words);

                        Assert.That(lastwordResult,
                            Is.EqualTo(wordNResult));
                        Assert.That(lastwordResult,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("LastWord")]
                public void LastWordFound()
                    {
                        var input = "This Is A Test";
                        var expected = "Test";

                        var actual = input.LastWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("LastWord")]
                public void LastWordOfOne()
                    {
                        var input = "ThisIsATest";
                        var expected = "ThisIsATest";

                        var actual = input.LastWord();
                        Assert.That(actual,
                            Is.Not.Null.Or.Empty);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("FirstWord")]
                public void LongFirstWordSeperatorReturnsEmptyString()
                    {
                        {
                            var input = " This Is A Test ";
                            var sep = "This is also a test but it's too long";
                            var expected = "";

                            var actual = input.FirstWord(sep);
                            Assert.That(actual,
                                Is.Not.Null.Or.Empty);

                            Assert.That(actual,
                                Is.EqualTo(expected));
                        }
                    }

                [Test]
                [Category("LastWord")]
                public void LongLastWordSeperatorReturnsAll()
                    {
                        {
                            var input = " This Is A Test ";
                            var sep = "This is also a test but it's too long";
                            var expected = " This Is A Test ";

                            var actual = input.LastWord(sep);
                            Assert.That(actual,
                                Is.Not.Null.Or.Empty);

                            Assert.That(actual,
                                Is.EqualTo(expected));
                        }
                    }

                [Test]
                [Sequential]
                [Category("LTrim")]
                public void LTrimProducesExpectedOutput([Values("",
                        "N",
                        "no  ",
                        " F ",
                        " f")]
                    string input,
                    [Values("",
                        "N",
                        "no  ",
                        "F ",
                        "f")]
                    string expected)
                    {
                        var actual = input.LTrim(" ");

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("NthWord")]
                public void NthWordReturnsExpectedResults([Values("This is a string",
                        "This is a string")]
                    string input,
                    [Values(2,
                        3)]
                    int wordNumber,
                    [Values("is",
                        "a")]
                    string nthWord)
                    {
                        var expected = nthWord;

                        var actual = input.NthWord(wordNumber);

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("NthWord")]
                public void OutOfRangeWordReturnsNull([Values(-2,
                        0,
                        5,
                        10)]
                    int wordNumber)
                    {
                        var input = "This is a string";

                        var actual = input.NthWord(wordNumber);

                        Assert.That(actual,
                            Is.Null);
                    }

                [Test]
                [Category("Unicode")]
                public void RemoveMidUnicode_ExpectedResults()
                    {
                        var start = " 0\r\n te" + '\u0b85' + "st";
                        var input = "\u0b85\u0b85" + start + '\u0080';

                        var expected = " 0\r\n test";

                        var actual = input.ReplaceUnicode();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("Unicode")]
                public void RemoveUnicode_ExpectedResults()
                    {
                        var start = " 0\r\n test";
                        var input = '\u0b85' + start + '\u0080';

                        var actual = input.ReplaceUnicode();

                        Assert.That(actual, Is.EqualTo(start));
                    }

                [Test]
                [Category("ReplaceAllFrom")]
                public void ReplaceAlFromlDuplicatedReplaceAllforStart0()
                    {
                        var test = "thi s is a string";


                        var rAll = test.ReplaceAll("s",
                            "s_nt");
                        var rAllFrom = test.ReplaceAllFrom("s",
                            "s_nt",
                            0);

                        Assert.That(rAll,
                            Is.Not.Null);
                        Assert.That(rAllFrom,
                            Is.Not.Null);
                        Assert.That(rAll,
                            Is.EqualTo(rAllFrom));
                    }

                [Test]
                [Category("ReplaceAllFrom")]
                public void ReplaceAlFromlDuplicatedReplaceforStart0()
                    {
                        var test = "thi s is a string";


                        var rAll = test.Replace("s",
                            "s_nt");
                        var rAllFrom = test.ReplaceFrom("s",
                            "s_nt",
                            0);

                        Assert.That(rAll,
                            Is.Not.Null);
                        Assert.That(rAllFrom,
                            Is.Not.Null);
                        Assert.That(rAll,
                            Is.EqualTo(rAllFrom));
                    }

                [Test]
                [Category("ReplaceAll")]
                public void ReplaceAllDuplicatedReturnsExpectedValues()
                    {
                        var test = "aaaa";

                        var expected = "aa";

                        var actual = test.ReplaceAll("aa",
                            "a");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAllFrom")]
                public void ReplaceAllFromAfterEndOfStringReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceAllFrom("s",
                            "123",
                            30);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceAllFrom")]
                public void ReplaceAllFromDoesNothingForNoMatch([Values("h",
                        ".")]
                    string lookfor,
                    [Values(5,
                        0)]
                    int start)
                    {
                        var input = "This is a string";

                        var expected = input;

                        var actual = input.ReplaceAllFrom(lookfor,
                            "2",
                            start);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAllMid")]
                public void ReplaceAllMidDuplicatesReplaceAllFromForStart0()
                    {
                        var input = "This is a string";

                        var expected = input.Replace("a",
                            " is not");

                        Assert.That(expected,
                            Is.Not.Null);

                        var actual = input.ReplaceAllMid("a",
                            " is not",
                            0,
                            input.Length);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAllMid")]
                public void ReplaceAllMidFromAfterEndOfStringReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceAllMid("s",
                            "123",
                            30,
                            90);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceAllMid")]
                public void ReplaceAllMidSwappedNumbersReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceAllMid("s",
                            "123",
                            390,
                            9);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceAllMid")]
                public void ReplaceAllMidUpToTooLowReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceAllMid("s",
                            "123",
                            390,
                            -1);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAll")]
                public void ReplaceAllNoMatchReturnsStart()
                    {
                        var test = "<root><test></test></root>";

                        var expected = test;

                        var actual = test.ReplaceAll(".",
                            "{");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceAll")]
                public void ReplaceAllReturnsExpectedValues()
                    {
                        var test = "<root><test></test></root>";

                        var expected = "{root>{test>{/test>{/root>";

                        var actual = test.ReplaceAll("<",
                            "{");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceAllTo")]
                public void ReplaceAllToAfterEndIsSameAsReplaceAll()
                    {
                        var input = "This is some string";

                        var expected = input.Replace("s",
                            "123");

                        var actual = input.ReplaceAllTo("s",
                            "123",
                            50);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAllTo")]
                public void ReplaceAllToReturnsExpectedResult()
                    {
                        var input = "This issome string";

                        var expected = "Thi123 i123some string";

                        var actual = input.ReplaceAllTo("s",
                            "123",
                            8);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceAllTo")]
                public void ReplaceAllToReturnsOrginalFor0()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceAllTo("s",
                            "123",
                            0);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("Replace")]
                public void ReplaceDuplicatedReturnsExpectedValues()
                    {
                        var test = "aaaa";

                        var expected = "aa";

                        var actual = test.Replace("aa",
                            "a");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceDuplicateSpaces")]
                public void ReplaceDuplicateSpacesWorks([Values("  m  ",
                        "This  is  a  string  ",
                        "     ",
                        "",
                        "12345",
                        " ",
                        "This is a normal string")]
                    string input)
                    {
                        var expected = -1;

                        var result = input.ReplaceDuplicateSpaces();
                        var actual = result.IndexOf("  ",
                            StringComparison.Ordinal);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceFrom")]
                public void ReplaceFromAfterEndOfStringReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceFrom("s",
                            "123",
                            30);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceFrom")]
                public void ReplaceFromDoesNothingForNoMatch([Values("h",
                        ".")]
                    string lookfor,
                    [Values(5,
                        0)]
                    int start)
                    {
                        var input = "This is a string";

                        var expected = input;

                        var actual = input.ReplaceFrom(lookfor,
                            "2",
                            start);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("Replace")]
                public void ReplaceMidDuplicatesReplaceFromForStart0()
                    {
                        var input = "This is a string";

                        var expected = input.Replace("a",
                            " is not");

                        Assert.That(expected,
                            Is.Not.Null);

                        var actual = input.ReplaceMid("a",
                            " is not",
                            0,
                            input.Length);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceMid")]
                public void ReplaceMidFromAfterEndOfStringReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceMid("s",
                            "123",
                            30,
                            90);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceMid")]
                public void ReplaceMidSwappedNumbersReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceMid("s",
                            "123",
                            390,
                            9);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("Unicode")]
                public void ReplaceMidUnicode_ExpectedResults()
                    {
                        var start = " 0\r\n te" + '\u0b85' + "st";
                        var input = "\u0b85\u0b85" + start + '\u0080';

                        var expected = "__ 0\r\n te_st_";

                        var actual = input.ReplaceUnicode("_");

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceMid")]
                public void ReplaceMidUpToTooLowReturnsOriginal()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceMid("s",
                            "123",
                            390,
                            -1);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("Replace")]
                public void ReplaceNoMatchReturnsStart()
                    {
                        var test = "<root><test></test></root>";

                        var expected = test;

                        var actual = test.Replace(".",
                            "{");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("Replace")]
                public void ReplaceReturnsExpectedValues()
                    {
                        var test = "<root><test></test></root>";

                        var expected = "{root>{test>{/test>{/root>";

                        var actual = test.Replace("<",
                            "{");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("ReplaceTo")]
                public void ReplaceToAfterEndIsSameAsReplace()
                    {
                        var input = "This is some string";

                        var expected = input.Replace("s",
                            "123");

                        var actual = input.ReplaceTo("s",
                            "123",
                            50);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceTo")]
                public void ReplaceToReturnsExpectedResult()
                    {
                        var input = "This issome string";

                        var expected = "Thi123 i123some string";

                        var actual = input.ReplaceTo("s",
                            "123",
                            8);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("ReplaceTo")]
                public void ReplaceToReturnsOrginalFor0()
                    {
                        var input = "This is some string";

                        var expected = input;

                        var actual = input.ReplaceTo("s",
                            "123",
                            0);
                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("Unicode")]
                [Sequential]
                public void ReplaceUnicode_allAscii_ExpectedResults(
                    [Values(" 0\r\n test", "\"1234 \";", "&#xx330;", "")]
                    string input)
                    {
                        var replaceWith = "12345";
                        var expected = input;

                        var actual = input.ReplaceUnicode(replaceWith);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("NLLib-2")]
                [Category("ReplaceWhitespace")]
                [Sequential]
                public void ReplaceWhiteSpaceNoSpaceKeepsSpaces([Values("  m  ",
                        "This  is  a  string  ",
                        "     ",
                        "",
                        "12345",
                        " ",
                        "This is a normal string")]
                    string input)
                    {
                        var expected = input.Length;

                        var result = input.ReplaceWhitespace("", false);
                        var actual = result.Length;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceWhitespace")]
                public void ReplaceWhiteSpacesNoEffectIfNone([Values("m",
                        "This_is_a_string",
                        "..",
                        "",
                        "12345",
                        "-",
                        "Thisisanormalstring")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.ReplaceWhitespace("");


                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceWhitespaceNoSpace")]
                public void ReplaceWhiteSpacesNoSpaceNoEffectIfNone([Values("m",
                        "This_is_a_string",
                        "..",
                        "",
                        "12345",
                        "-",
                        "Thisisanormalstring")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.ReplaceWhitespace("", false);


                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceWhitespace")]
                public void ReplaceWhiteSpacesNoSpaceWorks([Values("  m  ",
                        "This  is  a  string  ",
                        "     ",
                        " ",
                        "This is a normal string")]
                    string input)
                    {
                        var result = input.ReplaceWhitespace("", false);
                        var actual = result.IndexOf(" ",
                            StringComparison.Ordinal);

                        Assert.That(actual,
                            Is.GreaterThanOrEqualTo(0));
                    }

                [Test]
                [Sequential]
                [Category("ReplaceWhitespace")]
                public void ReplaceWhiteSpacesWorks([Values("  m  ",
                        "This  is  a  string  ",
                        "     ",
                        "",
                        "12345",
                        " ",
                        "This is a normal string")]
                    string input)
                    {
                        var expected = -1;

                        var result = input.ReplaceWhitespace("");
                        var actual = result.IndexOf(" ",
                            StringComparison.Ordinal);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Sequential]
                [Category("Right")]
                public void RightReturnsExpectedValue([Values("This is a string",
                        "1234",
                        "  ")]
                    string input,
                    [Values(6,
                        1,
                        2)]
                    int length,
                    [Values("string",
                        "4",
                        "  ")]
                    string result)
                    {
                        var expected = result;
                        var actual = input.Right(length);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                [Category("Right")]
                public void RightReturnsOriginalForWierdValues([Values("This is a string",
                        "1234",
                        "  ")]
                    string input,
                    [Values(0,
                        35)]
                    int length)
                    {
                        var expected = input;
                        var actual = input.Right(length);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void RtrimIsSameAsTrimEndWithSpace([Values("   ",
                        "    1234",
                        "qwe",
                        " wsd")]
                    string input)
                    {
                        var expected = input.TrimEnd(' ');

                        Assert.That(expected,
                            Is.Not.Null);

                        var actual = input.RTrim(" ");

                        Assert.That(actual,
                            Is.Not.Null);

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void RTrimProducesExpectedOutput([Values("",
                        "N",
                        "no  ",
                        " F ",
                        " f")]
                    string input,
                    [Values("",
                        "N",
                        "no",
                        " F",
                        " f")]
                    string expected)
                    {
                        var actual = input.RTrim(" ");

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseDoesntChangeInput([Values("ThisIsAString",
                        "",
                        "_____")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.Sanitise(" ");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumDoesntChangeInput([Values("ThisIsAString",
                        "",
                        "1234")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.SanitiseNonAlphaNum();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumFalseDoesntChangeInput([Values("ThisIsAString",
                        "",
                        "1234")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.SanitiseNonAlphaNum(false);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumKeepPuncRemovesAllExpected([Values("This, Is  A String.",
                        " ",
                        "  _____  1 ")]
                    string input,
                    [Values("This,IsAString.",
                        "",
                        "1")]
                    string expect)
                    {
                        var expected = expect;

                        var actual = input.SanitiseNonAlphaNum(false,
                            true);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumKeepPuncTrueSpacesDoesntChangeInput([Values("This Is A String ",
                        "",
                        "   ",
                        "1234")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.SanitiseNonAlphaNum(true,
                            true);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumKeepSpacesDoesntChangeInput([Values("This Is A String ",
                        "",
                        "   ",
                        "1234")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.SanitiseNonAlphaNum(true);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumPuncFalseDoesntChangeInput([Values("ThisIsAString",
                        "",
                        "1234")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.SanitiseNonAlphaNum(false,
                            false);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseNonAlphaNumRemovesAllExpected([Values("This Is  A String",
                        " ",
                        "  _____   ")]
                    string input,
                    [Values("ThisIsAString",
                        "",
                        "_____")]
                    string expect)
                    {
                        var expected = expect;

                        var actual = input.Sanitise(" ");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SanitiseRemovesAllExpected([Values("This Is  A String",
                        " ",
                        "  _____   ")]
                    string input,
                    [Values("ThisIsAString",
                        "",
                        "_____")]
                    string expect)
                    {
                        var expected = expect;

                        var actual = input.Sanitise(" ");

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void SplitNoSeperatorReturnsOriginal([Values("",
                        "   ",
                        " this is a string with no seperator ")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.Split(".".ToCharArray());

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo(expected));

                        // check only one string returned
                        Assert.That(actual.Length,
                            Is.EqualTo(1));
                    }

                [Test]
                public void TruncateAfterSeperatorWorks()
                    {
                        var input = "This is a string";

                        var actual = input.Truncate(8);

                        Assert.That(actual[0],
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo("This is"));
                        Assert.That(actual[1],
                            Is.EqualTo("a string"));
                    }

                [Test]
                public void TruncateBeforeSeperatorWorks()
                    {
                        var input = "This is a string";

                        var actual = input.Truncate(7);

                        Assert.That(actual[0],
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo("This is"));
                        Assert.That(actual[1],
                            Is.EqualTo("a string"));
                    }

                [Test]
                [Sequential]
                public void TruncateDoesNotTruncateTooShort([Values("This is a string",
                        "",
                        "ThisIsAlsoAString")]
                    string input)
                    {
                        var expected = input;

                        var actual = input.Truncate(17);

                        Assert.That(actual[0],
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo(expected));
                        Assert.That(actual[1],
                            Is.Null);
                    }


                [Test]
                [Sequential]
                public void TruncateDoesTruncateTooLong([Values("This is a string",
                        "ThisIsAlsoAString")]
                    string input,
                    [Values("This is a",
                        "ThisIsAlsoASt")]
                    string truncated)
                    {
                        var expected = truncated;

                        var actual = input.Truncate(13);

                        Assert.That(actual[0],
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo(expected));
                        Assert.That(actual[1],
                            Is.Not.Null);
                    }


                [Test]
                public void TruncateMidWordStringWorks()
                    {
                        var input = "This is a string";

                        var actual = input.Truncate(6);

                        Assert.That(actual[0],
                            Is.Not.Null);
                        Assert.That(actual[0],
                            Is.EqualTo("This"));
                        Assert.That(actual[1],
                            Is.EqualTo("is a string"));
                    }

                [Test]
                public void ValidXmlReturnsString()
                    {
                        var test = "<root><test></test></root>";

                        var newline = Environment.NewLine;
                        var actual = test.PrettyXml();
                        Assert.That(actual.Length,
                            Is.GreaterThan(1));
                        Assert.That(actual.Contains(newline),
                            Is.True);
                        Assert.That(actual.InStr("<root/>" + newline),
                            Is.EqualTo(0));
                    }

                [Test]
                [Sequential]
                public void WordCountCharIsSameAsNormalTests([Values("",
                        " ",
                        "this is a string",
                        "  This is   also a string   ")]
                    string input,
                    [Values(0,
                        0,
                        4,
                        5)]
                    int count)
                    {
                        var expected = count;

                        var seperator = new[] { ' ' };

                        var actual = input.WordCount(seperator);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Sequential]
                public void WordCountTests([Values("",
                        " ",
                        "this is a string",
                        "  This is   also a string   ")]
                    string input,
                    [Values(0,
                        0,
                        4,
                        5)]
                    int count)
                    {
                        var expected = count;

                        var actual = input.WordCount();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void WordCountTestsWithSeperator([Values("",
                        "--",
                        "this--is--string",
                        "----This--is----also a string---",
                        "This is a normal string")]
                    string input,
                    [Values(0,
                        0,
                        3,
                        3,
                        1)]
                    int count)
                    {
                        var expected = count;

                        var seperator = new[] { '-' };
                        var actual = input.WordCount(seperator);

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }


                [Test]
                [Category("LTrimCSV")]
                public void LTrimRemovesCommas()
                    {
                        var input = " ,Some test text, ";
                        var expected = "Some test text, ";


                        var actual = input.LTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("LTrimCSV")]
                [Sequential]
                public void LTrimRemovesCommasVarious([Values("", "    ", ",,,,", ", ,,,  ,")] string input)
                    {
                        var expected = "";

                        var actual = input.LTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("LTrimCSV")]
                [Sequential]
                public void LTrimRemovesCommasVariousWithText(
                    [Values("Some text", "    Some text", ",,,, Some text", ", ,,,  ,Some text")]
                    string input)
                    {
                        var expected = "Some text";

                        var actual = input.LTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                [Category("RTrimCSV")]
                public void RTrimRemovesCommas()
                    {
                        var input = " ,Some test text, ";
                        var expected = " ,Some test text";

                        var actual = input.RTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("RTrimCSV")]
                [Sequential]
                public void RTrimRemovesCommasVarious([Values("", "    ", ",,,,", ", ,,,  ,")] string input)
                    {
                        var expected = "";

                        var actual = input.RTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("RTrimCSV")]
                [Sequential]
                public void RTrimRemovesCommasVariousWithText(
                    [Values("Some text", "Some text    ", "Some text,,,, ", "Some text, ,,,  ,")]
                    string input)
                    {
                        var expected = "Some text";

                        var actual = input.RTrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("TrimCSV")]
                public void TrimRemovesCommas()
                    {
                        var input = " ,Some test text, ";
                        var expected = "Some test text";

                        var actual = input.TrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("TrimCSV")]
                [Sequential]
                public void TrimRemovesCommasVarious([Values("", "    ", ",,,,", ", ,,,  ,")] string input)
                    {
                        var expected = "";

                        var actual = input.TrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("TrimCSV")]
                [Sequential]
                public void TrimRemovesCommasVariousWithText(
                    [Values("Some text", ",,,   Some text    ", ",,,,Some text,,,, ", ", , , , Some text, ,,,  ,")]
                    string input)
                    {
                        var expected = "Some text";

                        var actual = input.TrimCSV();

                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }