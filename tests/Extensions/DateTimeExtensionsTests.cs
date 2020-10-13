//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=DateTimeExtensionsTests.cs company="North Lincolnshire Council">
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
using System.Globalization;
using NLC.Library.Extensions;
using NUnit.Framework;

namespace NLC.Library.Tests.Extensions
    {
        [TestFixture]
        [Category("Date")]
        public class DateTimeExtensionsTests
            {
                //check to see if both true and false results show correctly
                //function returns the date of easter sunday

                //uses http://www.maa.mhn.de/StarDate/publ_holidays.html
                private readonly CultureInfo _ukCulture = CultureInfo.CreateSpecificCulture("en-GB");


                [Test]
                [Sequential]
                public void ArbitraryDatesReturnCorrectIsoWeek([Values("24/1/2018",
                        "1/1/2018",
                        "31/12/2018",
                        "16/12/2018",
                        "8/1/2040")]
                    string date,
                    [Values(4,
                        1,
                        1,
                        50,
                        1)]
                    int actualWeek)
                    {
                        var expected = actualWeek;

                        if (!DateTime.TryParse(date, _ukCulture, DateTimeStyles.None,
                            out var dtResult))
                            {
                                return;
                            }

                        var actual = dtResult.IsoWeek();

                        Assert.That(actual,
                            Is.Not.Null);
                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                [Category("EasterDate")]
                [Category("Date")]
                public void CheckEasterFalse()
                    {
                        //Checks the formula and ensure easter returns false when inplemented (dates aren't easter)
                        //Check 1943, 1996, 2008 and 2060

                        //1943
                        long year = 1943;
                        var expected = new DateTime(1943,
                            4,
                            23);
                        var actual = year.EasterDate();
                        Assert.AreNotEqual(expected,
                            actual);

                        //1996
                        year = 1996;
                        expected = new DateTime(1996,
                            4,
                            5);
                        actual = year.EasterDate();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2008
                        year = 2008;
                        expected = new DateTime(2008,
                            3,
                            24);
                        actual = year.EasterDate();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2060
                        year = 2060;
                        expected = new DateTime(2060,
                            4,
                            30);
                        actual = year.EasterDate();
                        Assert.AreNotEqual(expected,
                            actual);
                    }

                [Test]
                [Category("EasterDate")]
                [Category("Date")]
                public void CheckEasterTrue()
                    {
                        //Checks the formula and ensure easter returns true when inplemented (dates are easter)
                        //Check 1943, 1996, 2008 and 2060

                        //1943
                        long year = 1943;
                        var expected = new DateTime(1943,
                            4,
                            25);
                        var actual = year.EasterDate();
                        Assert.AreEqual(expected,
                            actual);

                        //1996
                        year = 1996;
                        expected = new DateTime(1996,
                            4,
                            7);
                        actual = year.EasterDate();
                        Assert.AreEqual(expected,
                            actual);

                        //2008
                        year = 2008;
                        expected = new DateTime(2008,
                            3,
                            23);
                        actual = year.EasterDate();
                        Assert.AreEqual(expected,
                            actual);

                        //2060
                        year = 2060;
                        expected = new DateTime(2060,
                            4,
                            18);
                        actual = year.EasterDate();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Daylight Saving Time")]
                [Category("Date")]
                public void DstEndInValid()
                    {
                        //Test to see the end of the Daylight Savings Time - Last Sunday in October
                        //Test range - 2010-2019

                        //2010
                        var year = 2010;
                        var expected = new DateTime(2010,
                            10,
                            30);
                        var actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2011
                        year += 1;
                        expected = new DateTime(2011,
                            11,
                            1);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2012
                        year += 1;
                        expected = new DateTime(2012,
                            10,
                            27);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2013
                        year += 1;
                        expected = new DateTime(2013,
                            10,
                            2);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2014
                        year += 1;
                        expected = new DateTime(2014,
                            10,
                            29);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2015
                        year += 1;
                        expected = new DateTime(2015,
                            10,
                            30);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2016
                        year += 1;
                        expected = new DateTime(2016,
                            10,
                            31);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2017
                        year += 1;
                        expected = new DateTime(2017,
                            12,
                            25);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2018
                        year += 1;
                        expected = new DateTime(2018,
                            10,
                            25);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2019
                        year += 1;
                        expected = new DateTime(2019,
                            10,
                            24);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreNotEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Daylight Saving Time")]
                [Category("Date")]
                public void DstEndValid()
                    {
                        //Test to see the end of the Daylight Savings Time - Last Sunday in October
                        //Test range - 2010-2019

                        //2010
                        var year = 2010;
                        var expected = new DateTime(2010,
                            10,
                            31);
                        var actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2011
                        year += 1;
                        expected = new DateTime(2011,
                            10,
                            30);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2012
                        year += 1;
                        expected = new DateTime(2012,
                            10,
                            28);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2013
                        year += 1;
                        expected = new DateTime(2013,
                            10,
                            27);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2014
                        year += 1;
                        expected = new DateTime(2014,
                            10,
                            26);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2015
                        year += 1;
                        expected = new DateTime(2015,
                            10,
                            25);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2016
                        year += 1;
                        expected = new DateTime(2016,
                            10,
                            30);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2017
                        year += 1;
                        expected = new DateTime(2017,
                            10,
                            29);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2018
                        year += 1;
                        expected = new DateTime(2018,
                            10,
                            28);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);

                        //2019
                        year += 1;
                        expected = new DateTime(2019,
                            10,
                            27);
                        actual = year.DaylightSavingsTimeUkEnd();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Daylight Saving Time")]
                [Category("Date")]
                public void DstStartInvalid()
                    {
                        //Ensures false data doesn't return unexpected results
                        //Test carried from 2010-2019

                        //2010
                        var year = 2010;
                        var expected = new DateTime(2010,
                            3,
                            21);
                        var actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2011
                        year += 1;
                        expected = new DateTime(2011,
                            4,
                            4);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2012
                        year += 1;
                        expected = new DateTime(2012,
                            3,
                            24);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2013
                        year += 1;
                        expected = new DateTime(2013,
                            4,
                            6);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2014
                        year += 1;
                        expected = new DateTime(2014,
                            3,
                            28);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2015
                        year += 1;
                        expected = new DateTime(2015,
                            3,
                            27);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2016
                        year += 1;
                        expected = new DateTime(2016,
                            3,
                            31);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2017
                        year += 1;
                        expected = new DateTime(2017,
                            3,
                            16);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2018
                        year += 1;
                        expected = new DateTime(2018,
                            1,
                            1);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);

                        //2019
                        year += 1;
                        expected = new DateTime(2019,
                            3,
                            13);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreNotEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Daylight Saving Time")]
                [Category("Date")]
                public void DstStartValid()
                    {
                        //Tests when Daylight Savings Start in the UK, based on the last Sunday of the Month
                        //Test carried from 2010-2019

                        //2010
                        var year = 2010;
                        var expected = new DateTime(2010,
                            3,
                            28);
                        var actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2011
                        year += 1;
                        expected = new DateTime(2011,
                            3,
                            27);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2012
                        year += 1;
                        expected = new DateTime(2012,
                            3,
                            25);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2013
                        year += 1;
                        expected = new DateTime(2013,
                            3,
                            31);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2014
                        year += 1;
                        expected = new DateTime(2014,
                            3,
                            30);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2015
                        year += 1;
                        expected = new DateTime(2015,
                            3,
                            29);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2016
                        year += 1;
                        expected = new DateTime(2016,
                            3,
                            27);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2017
                        year += 1;
                        expected = new DateTime(2017,
                            3,
                            26);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2018
                        year += 1;
                        expected = new DateTime(2018,
                            3,
                            25);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);

                        //2019
                        year += 1;
                        expected = new DateTime(2019,
                            3,
                            31);
                        actual = year.DaylightSavingsTimeUkStart();
                        Assert.AreEqual(expected,
                            actual);
                    }


                [Test]
                public void Invalid_IsAnyDate_ReturnsFalse([Values("31/12/20160",
                        "31.13.2016",
                        "32-12-2016",
                        "2016-0-31",
                        "29/2/2015",
                        "0/0/0",
                        "12/31/2016",
                        "",
                        "2345.5.5.0",
                        "abc")]
                    string date)
                    {
                        var expected = false;
                        var input = date;
                        var actual = input.IsAnyDate();
                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                [Sequential]
                public void InvalidDatesReturnFalse([Values("31/12/20160",
                        "31.13.2016",
                        "32-12-2016",
                        "2016-0-31",
                        "29/2/2015",
                        "0/0/0",
                        "12/31/2016")]
                    string date)
                    {
                        var expected = false;

                        var input = date;

                        var actual = input.IsDate();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                /// <summary>
                ///     The is date empty returns false.
                /// </summary>
                [Test]
                public void IsDateEmptyReturnsFalse()
                    {
                        var expected = false;

                        var input = "";

                        var actual = input.IsDate();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                /// <summary> A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return:True - New Year falls on a Monday in 2018</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekMondayNewYear()
                    {
                        var testDate = new DateTime(2018,
                            1,
                            1);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary> A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return:True - New Year falls on a sunday in 2012</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekSundayNewYear()
                    {
                        var testDate = new DateTime(2012,
                            1,
                            1);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary>A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return: true - boxing day falls on a monday</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekTestMondayBoxingDay()
                    {
                        var testDate = new DateTime(2011,
                            12,
                            31);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary> A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return: False - Bank Hols are moved to the following Mon/Tues.Current week does not contain a bank holiday</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekTestSundayXmas()
                    {
                        var testDate = new DateTime(2011,
                            12,
                            24);
                        const bool expected = false;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary> A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return: False - 20/9/20 does not contain bank holiday</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekTestToFail()
                    {
                        var testDate = new DateTime(2011,
                            9,
                            20);
                        Assert.That(testDate.IsEnglishBankHolidayWeek(),
                            Is.False);
                    }

                /// <summary> A test for IsEnglishBankHolidayWeek </summary>
                /// <returns>return: True - 20/9/1 does contain a bank holiday</returns>
                [Test]
                [Category("Date")]
                public void IsEnglishBankHolidayWeekTestToSucceed()
                    {
                        var testDate = new DateTime(2011,
                            9,
                            1);
                        Assert.That(testDate.IsEnglishBankHolidayWeek(),
                            Is.True);
                    }

                /// <summary> A test for IsUKBankHolidayWeek </summary>
                /// <returns>return:True - Bank Holiday</returns>
                [Test]
                [Category("Date")]
                public void IsFormerJubileeHolidayAHoliday()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            5);
                        const bool expected = false;
                        var actual = testDate.IsUkWorkingDay();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsFormerJubileeHolidayAHolidayWeek()
                    {
                        var testDate = new DateTime(2012,
                            5,
                            28);
                        const bool expected = false;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary> A test for IsUKBankHolidayWeek </summary>
                /// <returns>return:False - Not Bank Holiday</returns>
                [Test]
                [Category("Date")]
                public void IsJubileeBankHolidayAHoliday()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            4);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeBankHolidayAHolidayWeek()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            4);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary> A test for IsUKBankHolidayWeek </summary>
                /// <returns>return:True - Special Bank Holiday</returns>
                [Test]
                [Category("Date")]
                public void IsJubileeHolidayAHoliday()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            5);
                        const bool expected = true;
                        bool? actual;
                        actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeHolidayAHolidayWeek()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            5);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeSundayAHoliday()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            3);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeSundayAHolidayWeek()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            3);
                        const bool expected = false;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeWednesdayAHoliday()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            6);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                public void IsJubileeWednesdayAHolidayWeek()
                    {
                        var testDate = new DateTime(2012,
                            6,
                            6);
                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDayFriday()
                    {
                        var testDate = new DateTime(2008,
                            12,
                            26);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDayMonday()
                    {
                        var testDate = new DateTime(2006,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDaySaturday()
                    {
                        var testDate = new DateTime(2009,
                            12,
                            26);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDaySunday()
                    {
                        var testDate = new DateTime(2010,
                            12,
                            26);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBdayThursday()
                    {
                        var testDate = new DateTime(2013,
                            12,
                            26);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDayTuesday()
                    {
                        var testDate = new DateTime(2006,
                            12,
                            26);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayBDayWednesday()
                    {
                        var testDate = new DateTime(2007,
                            12,
                            26);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayEasterMonday()
                    {
                        var testDate = new DateTime(2013,
                            4,
                            1);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayFirstMondayInMay()
                    {
                        var testDate = new DateTime(2013,
                            5,
                            6);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayFirstMondayNonMay()
                    {
                        var testDate = new DateTime(2013,
                            10,
                            1);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayFriday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            8);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayGoodFriday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            29);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayJanOne()
                    {
                        var testDate = new DateTime(2013,
                            1,
                            1);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayJanOneSaturday()
                    {
                        var testDate = new DateTime(2011,
                            1,
                            1);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayJanOneSaturdayMonday()
                    {
                        var testDate = new DateTime(2011,
                            1,
                            3);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayJanOneSaturdaySunday()
                    {
                        var testDate = new DateTime(2011,
                            1,
                            2);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayJanOneSunday()
                    {
                        var testDate = new DateTime(2012,
                            1,
                            1);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayLastMondayInMay()
                    {
                        var testDate = new DateTime(2013,
                            5,
                            27);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayLastMondayNonMay()
                    {
                        var testDate = new DateTime(2013,
                            10,
                            29);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayMonday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            4);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                [Category("UK Bank Holiday")]
                public void IsUkBankHolidaySaturday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            9);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidaySecondMondayInMay()
                    {
                        var testDate = new DateTime(2013,
                            5,
                            13);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidaySecondMondayNonMay()
                    {
                        var testDate = new DateTime(2013,
                            10,
                            8);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("Date")]
                [Category("UK Bank Holiday")]
                public void IsUkBankHolidaySunday()
                    {
                        //Test will return false as Bank Holiday is 
                        var testDate = new DateTime(2013,
                            3,
                            10);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayThursday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            7);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayTuesday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            5);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayWednesday()
                    {
                        var testDate = new DateTime(2013,
                            3,
                            6);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasFriday()
                    {
                        var testDate = new DateTime(2009,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasMonday()
                    {
                        var testDate = new DateTime(2006,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasSaturday()
                    {
                        var testDate = new DateTime(2010,
                            12,
                            25);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasSunday()
                    {
                        var testDate = new DateTime(2011,
                            12,
                            25);
                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasThursday()
                    {
                        var testDate = new DateTime(2008,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasTuesday()
                    {
                        var testDate = new DateTime(2012,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                [Test]
                [Category("UK Bank Holiday")]
                [Category("Date")]
                public void IsUkBankHolidayXmasWednesday()
                    {
                        var testDate = new DateTime(2013,
                            12,
                            25);
                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected,
                            actual);
                    }

                /// <summary>
                ///     Check next monday function
                /// </summary>
                /// <remarks>
                ///     It should be
                ///     1. a monday
                ///     2. after start date
                ///     3. no more than 7 days after start date
                /// </remarks>
                [Test]
                public void NextMondayIsAMonday()
                    {
                        var testDate = new DateTime(2016,
                            1,
                            1);

                        var nextMon = testDate.NextMonday();

                        var diff = nextMon - testDate;

                        Assert.That(nextMon.DayOfWeek,
                            Is.EqualTo(DayOfWeek.Monday));
                        Assert.That(nextMon,
                            Is.GreaterThan(testDate));
                        Assert.That(diff.Days,
                            Is.LessThanOrEqualTo(7));
                        Assert.That(diff.Days,
                            Is.GreaterThan(0));
                    }

                /// <summary>
                ///     The non numeric input returns false.
                /// </summary>
                /// <param name="date">
                ///     The date.
                /// </param>
                [Test]
                [Sequential]
                public void NonNumericInputReturnsFalse([Values(" ",
                        "        ",
                        "steve",
                        "SteveSteve",
                        "Steve Fred Joe Noddy",
                        " _ ",
                        "$%^&*",
                        "One",
                        "1/1/1/1/1",
                        "2nd Feb",
                        "0.1",
                        "0.0.0",
                        "1234456")]
                    string date)
                    {
                        var expected = false;

                        var input = date;

                        var actual = input.IsDate();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                /// <summary>
                ///     The sensible dates return true.
                /// </summary>
                /// <param name="date">
                ///     The date.
                /// </param>
                [Test]
                [Sequential]
                public void SensibleDatesReturnTrue([Values("31/12/2016",
                        "31.12.2016",
                        "31-12-2016",
                        "2016-12-31",
                        "1 Feb, 2016")]
                    string date)
                    {
                        var expected = true;

                        var input = date;

                        var actual = input.IsDate();

                        Assert.That(actual,
                            Is.EqualTo(expected));
                    }

                [Test]
                public void Summer_dates_are_in_UK_DST([Values("30/06/2016",
                        "1499040000")]
                    string date)
                    {
                        var expected = true;
                        var input = date.ToDateTime().Value;
                        var actual = input.IsInDaylightSavingsTimeUk();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void ToDate_Returns_ExpectedValue([Values("31/12/2016",
                        "1483142400", "1483142400.00")]
                    string date)
                    {
                        var expected = new DateTime(2016, 12, 31);
                        var input = date;
                        var actual = input.ToDateTime();
                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void Valid_IsAnyDate_ReturnsTrue([Values("31/12/2016",
                        "31.10.2016",
                        "2345.5.5", "1555334468")]
                    string date)
                    {
                        var expected = true;
                        var input = date;
                        var actual = input.IsAnyDate();
                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("Date")]
                public void VeDayMove_MovedBankHoliday_IsBankHoliday()
                    {
                        var testDate = new DateTime(2020, 5, 8);

                        const bool expected = true;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected, actual);
                    }

                [Test]
                [Sequential]
                [Category("Date")]
                public void VeDayMove_MovedBankHoliday_IsBankHolidayWeek(
                    [Values(4, 5, 6, 7, 8)] int dow)
                    {
                        var testDate = new DateTime(2020, 5, dow);

                        const bool expected = true;
                        var actual = testDate.IsEnglishBankHolidayWeek();
                        Assert.AreEqual(expected, actual);
                    }

                [Test]
                [Category("Date")]
                public void VeDayMove_OriginalBankHoliday_IsNotBankHoliday()
                    {
                        var testDate = new DateTime(2020, 5, 4);

                        const bool expected = false;
                        var actual = testDate.IsUkBankHoliday();
                        Assert.AreEqual(expected, actual);
                    }


                [Test]
                public void Winter_dates_are_not_in_UK_DST([Values("31/12/2016",
                        "1548787800")]
                    string date)
                    {
                        var expected = false;
                        var input = date.ToDateTime().Value;
                        var actual = input.IsInDaylightSavingsTimeUk();

                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }