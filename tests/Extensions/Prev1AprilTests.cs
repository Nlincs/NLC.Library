//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Prev1AprilTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:53 - Stephen Ellwood
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
        /// <summary>
        ///     The prev 1 april tests.
        /// </summary>
        [TestFixture]
        public class Prev1AprilTests
            {
                /// <summary>
                ///     The set up.
                /// </summary>
                [SetUp]
                public void SetUp() => _dtNow = DateTime.Now;

                /// <summary>
                ///     The dt now.
                /// </summary>
                private DateTime _dtNow;

                /// <summary>
                ///     The prev 1 april returns correct date for 31 mar.
                /// </summary>
                [Test]
                public void Prev1AprilReturnsCorrectDateFor31Mar()
                    {
                        var dateToTest = new DateTime(2015,
                            3,
                            31);
                        var expected = new DateTime(2014,
                            4,
                            1);

                        var actual = dateToTest.Prev1April();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                /// <summary>
                ///     The prev 1 april returns date time.
                /// </summary>
                [Test]
                public void Prev1AprilReturnsDateTime()
                    {
                        var actual = _dtNow.Prev1April();

                        Assert.That(actual,
                            Is.InstanceOf<DateTime>());
                    }

                /// <summary>
                ///     The prev 1 april returns previous date for 2 april.
                /// </summary>
                [Test]
                public void Prev1AprilReturnsPreviousDateFor2April()
                    {
                        var dateToTest = new DateTime(2015,
                            4,
                            2);
                        var expected = new DateTime(2015,
                            4,
                            1);

                        var actual = dateToTest.Prev1April();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                /// <summary>
                ///     The prev 1 april returns same date.
                /// </summary>
                [Test]
                public void Prev1AprilReturnsSameDate()
                    {
                        var expected = new DateTime(2014,
                            4,
                            1);

                        var actual = expected.Prev1April();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }
            }
    }