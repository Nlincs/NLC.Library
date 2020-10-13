//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=BetweenTests.cs company="North Lincolnshire Council">
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
using NLC.Library.Extensions;
using NUnit.Framework;

namespace NLC.Library.Tests.Extensions
    {
        [TestFixture]
        public class BetweenTests
            {
                [SetUp]
                public void Setup()
                    {
                        _earlyDate1 = DateTime.Now.AddYears(-20);
                        _earlyDate2 = DateTime.Now.AddYears(-15);
                        _lateDate1 = DateTime.Now.AddYears(10);
                        _lateDate2 = DateTime.Now.AddYears(19);
                    }

                private DateTime _earlyDate1;

                private DateTime _earlyDate2;

                private DateTime _lateDate1;

                private DateTime _lateDate2;

                [Test]
                public void NowBetweenEarlyDate1AndEarlyDate2IsFalse()
                    {
                        // ReSharper disable once ConvertToConstant.Local

                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_earlyDate1,
                            _earlyDate2);

                        Assert.That(actual,Is.False);
                    }

                [Test]
                public void NowBetweenEarlyDate1AndLateDate1IsTrue()
                    {
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_earlyDate1,
                            _lateDate1);

                        Assert.That(actual,Is.True);
                    }

                [Test]
                public void NowBetweenEarlyDate1AndNowIsFalse()
                    {
                    
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_earlyDate1,
                            dateToTest);

                        Assert.That(actual, Is.False);
                    }

                [Test]
                public void NowBetweenEarlyDate2AndLateDate2IsTrue()
                    {
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_earlyDate2,
                            _lateDate2);

                        Assert.That(actual,Is.True);
                    }

                [Test]
                public void NowBetweenLateDate1AndLateDate2IsFalse()
                    {
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_lateDate1,
                            _lateDate2);

                        Assert.That(actual,Is.False);
                    }

                [Test]
                public void NowBetweenNowAndLateDate1IsFalse()
                    {
                
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(dateToTest,
                            _lateDate1);

                        Assert.That(
                            actual, Is.False);
                    }

                [Test]
                public void NowBetweenNowAndNowIsFalse()
                    {
                 
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(dateToTest,
                            dateToTest);

                        Assert.That(actual, Is.False);
                    }

                [Test]
                public void NowBetweenSwappedEarlyDate1AndEarlyDate2IsFalse()
                    {
                
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_earlyDate2,
                            _earlyDate1);

                        Assert.That(actual, Is.False);
                    }

                [Test]
                public void NowBetweenSwappedEarlyDate1AndLateDate1IsTrue()
                    {
                  
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_lateDate1,
                            _earlyDate1);

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void NowBetweenSwappedLateDate1AndLateDate2IsFalse()
                    {
                       
                        var dateToTest = DateTime.Now;

                        var actual = dateToTest.Between(_lateDate2,
                            _lateDate1);

                        Assert.That(actual, Is.False);
                    }
            }
    }