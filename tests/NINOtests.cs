//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=NINOtests.cs company="North Lincolnshire Council">
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
        [Category("ECS NINO")]
        public class NinoTests
            {
                [SetUp]
                public void Setup() => _sut = new Nino();

                private Nino _sut;

                [Test]
                [Sequential]
                public void AllAlphaRightReturnsIsValidTrue([Values("wf12345a ",
                        "ab123456a",
                        "ef123456z",
                        "za123456c",
                        "WF123456A")]
                    string starts)
                    {
                        //Return true as are all valid returns for this test
                        var sut2 = new Nino(starts);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void AlphaOrSpaceRightReturnsIsValidTrue([Values("wf12345a ",
                        "ab123456a",
                        "ab123456z")]
                    string ends)
                    {
                        //Checks that the last character is either alphabetic or space
                        var sut2 = new Nino(ends);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void Left2CharIsCorrect([Values("abc1",
                        "jg123456a",
                        "yz992415d")]
                    string nino,
                    [Values("ab",
                        "jg",
                        "yz")]
                    string expect)
                    {
                        //Test that we can get the first 2 characters
                        var expected = expect;
                        var sut2 = new Nino(nino);
                        var actual = sut2.Left;
                        Assert.AreEqual(actual,
                            expected);
                    }

                [Test]
                [Sequential]
                public void MidReturns6CharsIfLastIsNotSpace5Otherwise([Values("123456 ",
                        "sabcdef ",
                        "1.000123  ",
                        "987654321",
                        "wkfjdsjfk")]
                    string mids)
                    {
                        //Test that we can store 5 chars if the last character isnt a space, otherwise reduce to 5
                        int expected;
                        var sut2 = new Nino(mids);
                        if (sut2.HasTrailingSpace)
                            {
                                expected = 5;
                            }
                        else
                            {
                                expected = 6;
                            }

                        var actual = sut2.Mid.Length;
                        Assert.AreEqual(actual,
                            expected);
                    }

                [Test]
                [Sequential]
                public void MidReturnsCorrectChars([Values("ab123456a",
                        "abcdefghijkl",
                        "!£$%^&*(){}")]
                    string inputs,
                    [Values("123456",
                        "cdefgh",
                        "$%^&*(")]
                    string expect)
                    {
                        //Test that we can get the middle 6 values, no matter the length
                        var sut2 = new Nino(inputs);
                        var expected = expect;
                        var actual = sut2.Mid;
                        Assert.AreEqual(actual,
                            expected);
                    }

                [Test]
                public void NinoIsNotNull()
                    {
                        var sut2 = new Nino("12ABC12");
                        Assert.That(_sut,
                            Is.Not.Null,
                            "Null with empty constructor");
                        Assert.That(sut2,
                            Is.Not.Null,
                            "Null with single constructor");
                    }

                [Test]
                [Sequential]
                public void NinoWithExactly9CharsIsValid([Values("ab123346a",
                        "xz54321y ",
                        "JG773479B")]
                    string nino)
                    {
                        //Expected true as they match the criteria
                        var sut2 = new Nino(nino);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void NinoWithout9CharsIsInvalid([Values("",
                        " ",
                        "12345678",
                        "0.123456",
                        "abcdefghi")]
                    string nino)
                    {
                        //Expected false as there aren't exactly 9 characters
                        var sut2 = new Nino(nino);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            false);
                    }

                [Test]
                [Sequential]
                public void NonAlphaLeftReturnsIsValidFalse([Values("  123456a",
                        "123456c",
                        "b1234567.",
                        @"a 123456z",
                        @"\\123456z",
                        "-1.0000000")]
                    string starts)
                    {
                        //
                        var sut2 = new Nino(starts);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            false);
                    }

                [Test]
                [Sequential]
                public void NonAlphaRightReturnsIsValidFalse([Values("ab1234567",
                        "ab123456_",
                        "ab123456.",
                        "ab123456-",
                        @"ab123456\")]
                    string ends)
                    {
                        //Tests that the last character is alphabetic
                        var sut2 = new Nino(ends);
                        var actual = sut2.IsEcsValid();
                        Assert.AreEqual(actual,
                            false);
                    }

                [Test]
                [Sequential]
                public void Right1CharIsSpaceGivesTrailingSpaceTrue([Values("123 ",
                        "sabc ",
                        "1.000 ",
                        "    ")]
                    string ends)
                    {
                        //Test that we can get the right space if one exists
                        var sut2 = new Nino(ends);
                        var actual = sut2.HasTrailingSpace;
                        Assert.AreEqual(actual,
                            true);
                    }

                [Test]
                [Sequential]
                public void RightCharIsCorrect([Values("ab123456b",
                        "jg123456a",
                        "yz992415d")]
                    string nino,
                    [Values("b",
                        "a",
                        "d")]
                    string expect)
                    {
                        //Test that we can get the last character
                        var expected = expect;
                        var sut2 = new Nino(nino);
                        var actual = sut2.Right;
                        Assert.AreEqual(actual,
                            expected);
                    }

                // Criteria
                //1. Must be 9 characters.
                //2. First 2 characters must be alpha.
                //3. Next 6 characters must be numeric.
                //4. Final character can be A, B, C, D or space.
            }
    }