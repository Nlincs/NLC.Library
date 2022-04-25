//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=EnumerableExtensionTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:52 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NLC.Library.Extensions;
using NUnit.Framework;

namespace NLC.Library.Tests.Extensions
    {
        [TestFixture]
        public class EnumerableExtensionTests
            {
                [Test]
                public void SplitBuckets10To3_ReturnsExpected()
                    {
                        var list10 = new List<int>
                            {
                                1,
                                2,
                                3,
                                4,
                                5,
                                6,
                                7,
                                8,
                                9,
                                10
                            };

                        var actual = list10.SplitToBuckets(3);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Count, Is.EqualTo(3));
                        CollectionAssert.AllItemsAreNotNull(actual);

                        var first = actual.ToArray()[0];
                        Assert.That(first.Count, Is.EqualTo(4));

                        var second = actual.ToArray()[1];
                        Assert.That(second.Count, Is.EqualTo(3));

                        var last = actual.Last();
                        Assert.That(last.Count, Is.EqualTo(3));
                    }

                [Test]
                public void SplitBuckets99To10_ReturnsExpected()
                    {
                        var list99 = new List<int>();

                        for (var i = 1; i <= 99; i++)
                            {
                                list99.Add(i);
                            }

                        var actual = list99.SplitToBuckets(10);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.Count, Is.EqualTo(10));
                        CollectionAssert.AllItemsAreNotNull(actual);

                        var max = 0;
                        var min = 99;

                        foreach (var sublist in actual)
                            {
                                max = Math.Max(max, sublist.Count);
                                min = Math.Min(min, sublist.Count);
                            }

                        // sub lists should be length 9 or 10
                        Assert.That(max, Is.EqualTo(10));
                        Assert.That(min, Is.EqualTo(9));

                        // should be one sub list of length 9 and rest should be 10
                        var len10 = actual.FindAll(x => x.Count == 10);
                        var len9 = actual.FindAll(x => x.Count == 9);

                        Assert.That(len10.Count, Is.EqualTo(9));
                        Assert.That(len9.Count, Is.EqualTo(1));
                    }
            }
    }