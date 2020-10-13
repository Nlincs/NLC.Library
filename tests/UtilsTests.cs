//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UtilsTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 13:00 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class UtilsTests
            {
                [Test]
                [Category("Library")]
                [Category("Unique")]
                public void UniqueTest()
                    {
                        string expected,
                            actual;
                        var length = 5;
                        var caseSensitive = false;

                        // loop a few times
                        for (var i = 0; i < 200; i++)
                            {
                                expected = Unique.GetValue(length,
                                    caseSensitive);
                                actual = Unique.GetValue(length,
                                    caseSensitive);

                                Assert.That(actual,
                                    Is.Not.EqualTo(expected));
                            }
                    }

                [Test]
                [Category("Library")]
                [Category("Unique")]
                public void UniqueTestCaseInsensitive()
                    {
                        string expected,
                            actual;
                        var length = 5;
                        var caseSensitive = true;

                        // loop a few times
                        for (var i = 0; i < 200; i++)
                            {
                                expected = Unique.GetValue(length,
                                    caseSensitive);
                                actual = Unique.GetValue(length,
                                    caseSensitive);

                                Assert.That(actual,
                                    Is.Not.EqualTo(expected));
                            }
                    }
            }
    }