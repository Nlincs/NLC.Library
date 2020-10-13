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
                        var length = 5;
                      

                        // loop a few times
                        for (var i = 0; i < 200; i++)
                            {
                                Unique.GetValue(length,
                                    false);
                                var actual = Unique.GetValue(length,
                                    false);

                                Assert.That(actual,
                                    Is.Not.False);
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
                     

                        // loop a few times
                        for (var i = 0; i < 200; i++)
                            {
                                expected = Unique.GetValue(length,true);
                                actual = Unique.GetValue(length,
                                    true);

                                Assert.That(actual,
                                    Is.Not.EqualTo(expected));
                            }
                    }
            }
    }