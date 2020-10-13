//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=DateTimeExtensions.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 07/07/2020 09:49
//  Altered - 07/07/2020 10:47 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace NLC.Library.Extensions
    {
        /// <summary>
        ///     See if date range is set the right way around.
        /// </summary>
        public static class DatetimeExtensions
            {
                // according to wikipedia Daylight savings time (DST) in europe extends from 01:00 UTC on the last sunday in March
                // until 01:00 UTC on the last sunday in October


                private static readonly CultureInfo UkCulture = CultureInfo.CreateSpecificCulture("en-GB");

                /// <summary>
                ///     Calculate end of Daylight Savings Time
                /// </summary>
                /// <returns>
                ///     date of end of DST for given year
                /// </returns>
                /// <param name="year">
                ///     year we want the data for
                /// </param>
                /// <remarks>
                ///     Formula is Sunday(31-((((5 x YEAR)/4) + 1) mod 7) October at 01:00 UTC
                /// </remarks>
                public static DateTime DaylightSavingsTimeUkEnd(this int year) =>
                    CalcDstDate(year,
                        1);

                /// <summary>
                ///     Calculate start of Daylight Savings Time
                /// </summary>
                /// <returns>
                ///     date of start of DST for given year
                /// </returns>
                /// <param name="year">
                ///     year we want the data for
                /// </param>
                /// <remarks>
                ///     Formula is Sunday(31-((((5 x YEAR)/4) + 4) mod 7)
                /// </remarks>
                public static DateTime DaylightSavingsTimeUkStart(this int year) =>
                    CalcDstDate(year,
                        4);

                /// <summary>
                ///     Is in Daylight Savings Time
                /// </summary>
                /// <param name="date">Date of interest</param>
                /// <returns>true if date is in the Daylight Savings time period, false otherwise</returns>
                public static bool IsInDaylightSavingsTimeUk(this DateTime date)
                    {
                        {
                            var start = DaylightSavingsTimeUkStart(date.Year);
                            var end = DaylightSavingsTimeUkEnd(date.Year);

                            return Between(date, start, end);
                        }
                    }

                /// <summary>
                ///     Does the week contain a bank holiday
                /// </summary>
                /// <param name="date">
                ///     Any date in the week of interest
                /// </param>
                /// <returns>
                ///     True if the week contains a bank holiday, false otherwiseq
                /// </returns>
                /// <remarks>
                ///     Indicates if the week (Mon - Sun) contains one (or more bank holidays). Possibly useful if there is a bin
                ///     collection etc.
                /// </remarks>
                public static bool IsEnglishBankHolidayWeek(this DateTime date)
                    {
                     // first calculate the monday
                        DateTime monday;

                        if (date.DayOfWeek == DayOfWeek.Monday)
                            {
                                monday = date;
                            }
                        else
                            {
                                // work backwards to get the monday
                                monday = date;
                                do
                                    {
                                        // keep subtracting a day until we get to a monday
                                        monday = monday.AddDays(-1);
                                    } while (monday.DayOfWeek != DayOfWeek.Monday);
                            }

                        // now we have the date of the monday
                        var testDate = monday;
                        var result = false;

                        // work through the week
                        do
                            {
                                var isUkBankHoliday = IsUkBankHoliday(testDate);
                                if (isUkBankHoliday != null && (bool)isUkBankHoliday)
                                    {
                                        result = true;
                                    }

                                testDate = testDate.AddDays(1);

                                // when we hit the next monday we stop and the result variable will have our answer
                            } while (testDate.DayOfWeek != DayOfWeek.Monday);

                        return result;
                    }

                /// <summary>
                ///     Calculate the DST date
                /// </summary>
                /// <param name="year">
                ///     year of interest
                /// </param>
                /// <param name="add">
                ///     1 for start, 4 for end, anything else throws an exception
                /// </param>
                /// <returns>
                ///     date of start/end of DST in the UK for the given year
                ///     returns default if indeterminate
                /// </returns>
                /// <remarks>
                /// </remarks>
                private static DateTime CalcDstDate(int year,
                    int add)
                    {
                        var result = 5 * year;
                        result /= 4;
                        result += add;
                        result %= 7; // mod
                        result = 31 - result;

                        DateTime dt;

                        switch (add)
                            {
                                case 4:
                                    {
                                        dt = new DateTime(year,
                                            3,
                                            result);
                                        break;
                                    }

                                case 1:
                                    {
                                        dt = new DateTime(year,
                                            10,
                                            result);
                                        break;
                                    }

                                default:
                                    {
                                        return default;
                                    }
                            }

                        return dt;
                    }


                /// <summary>
                ///     Calculate Easter Sunday date in any given year
                /// </summary>
                /// <param name="yr">
                ///     The year to check
                /// </param>
                /// <returns>
                ///     The date of easter sunday for the given year
                /// </returns>
                /// <remarks>
                /// </remarks>
                public static DateTime EasterDate(this long yr)
                    {
                        // taken from http://www.cpearson.com/excel/Easter.aspx

                        var c = yr / 100;
                        var n = yr - (19 * (yr / 19));
                        var k = (c - 17) / 25;
                        var I = (c - (c / 4) - ((c - k) / 3)) + (19 * n) + 15;
                        I -= 30 * (I / 30);
                        I -= (I / 28) * (1 - ((I / 28) * (29 / (I + 1)) * ((21 - n) / 11)));
                        var j = ((yr + (yr / 4) + I + 2) - c) + (c / 4);
                        j -= 7 * (j / 7);
                        var l = I - j;
                        var m = 3 + ((l + 40) / 44);
                        var d = (l + 28) - (31 * (m / 4));

                        return new DateTime((int)yr,
                            (int)m,
                            (int)d);
                    }

                /// <summary>
                ///     First Monday Of the Month
                /// </summary>
                /// <param name="date">
                ///     Any date in the period that we want the first monday of the month for
                /// </param>
                /// <returns>
                ///     Date corresponding to the first monday of the month
                /// </returns>
                /// <remarks>
                /// </remarks>
                public static DateTime FirstMondayOfMonth(this DateTime date)
                    {
                        // generate a date that is the 1st of the month passed
                        var result = new DateTime(date.Year,
                            date.Month,
                            1);

                        while (result.DayOfWeek != DayOfWeek.Monday)
                            {
                                result = result.AddDays(1);
                            }

                        return result;
                    }

                /// <summary>
                ///     Is Date function
                /// </summary>
                /// <param name="date">date to check</param>
                /// <returns>true if the input parses to a date, false otherwise</returns>
                public static bool IsDate(this string date) =>
                    DateTime.TryParse(date, UkCulture, DateTimeStyles.None,
                        out _);


                /// <summary>
                ///     Is Date function
                /// </summary>
                /// <param name="date">date to check</param>
                /// <returns>true if the input parses to a date, false otherwise</returns>
                /// <remarks>This one also checks for Unix dates</remarks>
                public static bool IsAnyDate(this string date) => IsDate(date) || double.TryParse(date, out _);

                /// <summary>
                ///     String to DateTime
                /// </summary>
                /// <param name="date"></param>
                /// <returns>Any recognised uk format DateTime, including unix timestamps, null otherwise</returns>
                /// <remarks>
                ///     This should be used if there is a possibility that a unix timestamp will be passed, otherwise use standard
                ///     TryParse
                /// </remarks>
                public static DateTime? ToDateTime(this string date)
                    {
                        if (DateTime.TryParse(date, UkCulture, DateTimeStyles.None, out var start))
                            {
                                return start;
                            }

                        {
                            // .net can't recognise it so try for unix format date

                            if (!double.TryParse(date, out var startD))
                                {
                                    return new DateTime?();
                                }

                            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                            // Add the timestamp (number of seconds since the Epoch) to be converted
                            return dateTime.AddSeconds(startD);
                        }
                    }

                /// <summary>
                ///     Function to return the ISO week
                /// </summary>
                /// <param name="date">
                ///     The date to check
                /// </param>
                /// <returns>
                ///     The ISO week number of the date provided
                /// </returns>
                /// <remarks>
                ///     Taken from http://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
                /// </remarks>
                public static int IsoWeek(this DateTime date)
                    {
                        // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll
                        // be the same week# as whatever Thursday, Friday or Saturday are,
                        // and we always get those right
                        var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
                        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                            {
                                date = date.AddDays(3);
                            }

                        // Return the week of our adjusted day
                        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date,
                            CalendarWeekRule.FirstFourDayWeek,
                            DayOfWeek.Monday);
                    }

                /// <summary>
                ///     Last day of the month
                /// </summary>
                /// <param name="date">
                ///     any date in the month of interest
                /// </param>
                /// <returns>
                ///     Date corresponding to the last day of the month
                /// </returns>
                /// <remarks>
                ///     Should work correctly regardless of leap year, etc.
                /// </remarks>
                public static DateTime LastDayOfMonth(this DateTime date)
                    {
                        var tmp = new DateTime(date.Year,
                            date.Month,
                            1);

                        // calculate the first day of the next month and then take a day off to generate our result
                        tmp = tmp.AddMonths(1);

                        // now we have the first of the next month we subtract one day
                        return tmp.AddDays(-1);
                    }

                /// <summary>
                ///     Last Monday of the month
                /// </summary>
                /// <param name="date">
                ///     any date in the period of interest
                /// </param>
                /// <returns>
                ///     The date of the last monday in a month
                /// </returns>
                /// <remarks>
                /// </remarks>
                public static DateTime LastMondayOfMonth(this DateTime date)
                    {
                        // first get the last day of the month then work back until we get to a monday

                        var result = date.LastDayOfMonth();

                        while (result.DayOfWeek != DayOfWeek.Monday)
                            {
                                result = result.AddDays(-1);
                            }

                        return result;
                    }

                /// <summary>
                ///     Date of next monday
                /// </summary>
                /// <param name="date">date to compare against</param>
                /// <returns>The date of the next monday, if the day is a monday then return the same date</returns>
                public static DateTime NextMonday(this DateTime date)
                    {
                        if (date.DayOfWeek == DayOfWeek.Monday)
                            {
                                return date;
                            }

                        var result = date;

                        while (result.DayOfWeek != DayOfWeek.Monday)
                            {
                                result = result.AddDays(1);
                            }

                        return result;
                    }


                /// <summary>
                ///     Convert date to RSS formatted string
                /// </summary>
                /// <param name="date">
                ///     date to convert
                /// </param>
                /// <returns>
                ///     returns the date as an RSS formatted string
                /// </returns>
                /// <remarks>
                ///     taken from www.dotnetperls.com/pubdate
                /// </remarks>
                public static string RssFormat(this DateTime date) =>
                    date.ToString("ddd',' dd MMM yyyy HH':'mm':'ss") +
                    " " +
                    date.ToString("zzzz").Replace(":",
                        string.Empty);


                /// <summary>
                ///     Test to see if date range is set the right way around.
                /// </summary>
                /// <param name="dateToTest">
                ///     Date to check
                /// </param>
                /// <param name="startDate">
                ///     Earliest date for match
                /// </param>
                /// <param name="endDate">
                ///     latest date for match
                /// </param>
                /// <returns>
                ///     True if dateToTest is between start date and end date, false otherwise
                /// </returns>
                /// <remarks>
                ///     uses the MS compare results format
                /// </remarks>
                public static bool Between(this DateTime dateToTest,
                    DateTime startDate,
                    DateTime endDate)
                    {
                        // if the dates are the wrong way round we change them
                        if (endDate < startDate)
                            {
                                // swap around
                                var tmp = startDate;
                                startDate = endDate;
                                endDate = tmp;
                            }

                        try
                            {
                                return dateToTest.CompareTo(startDate) > 0 && dateToTest.CompareTo(endDate) < 0;
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     The prev 1 april.
                /// </summary>
                /// <param name="dateToTest">
                ///     The date to test.
                /// </param>
                /// <returns>
                ///     The <see cref="DateTime" />.
                /// </returns>
                public static DateTime Prev1April(this DateTime dateToTest)
                    {
                        var result = dateToTest.Month >= 4
                            ? new DateTime(dateToTest.Year,
                                4,
                                1)
                            : new DateTime(dateToTest.Year - 1,
                                4,
                                1);

                        return result;
                    }

                /// <summary>
                ///     Determines if a date is a UK bank holiday
                /// </summary>
                /// <param name="testDate">
                ///     The date to check
                /// </param>
                /// <returns>
                ///     True if the date is a bank holiday, false if not, nothing if an exception occurs
                /// </returns>
                public static bool? IsUkBankHoliday(this DateTime testDate)
                    {
                        {
                            try
                                {
                                    // this is an exceptional case as the bank holiday was moved to a week later
                                    // see below for the jubilee
                                    if (testDate ==
                                        new DateTime(2012,
                                            5,
                                            28))
                                        {
                                            return false;
                                        }

                                    if (testDate ==
                                        new DateTime(2012,
                                            6,
                                            4) ||
                                        testDate ==
                                        new DateTime(2012,
                                            6,
                                            5))
                                        {
                                            return true;
                                        }

                                    // bank holiday moved to VE day May 2020
                                    if (testDate ==
                                        new DateTime(2020,
                                            5,
                                            8))
                                        {
                                            return true;
                                        }

                                    if (testDate ==
                                        new DateTime(2020,
                                            5,
                                            4))
                                        {
                                            return false;
                                        }

                                    // first check for Easter
                                    if (testDate ==
                                        EasterDate(testDate.Year).AddDays(-2))
                                        {
                                            return true;
                                        }

                                    if (testDate ==
                                        EasterDate(testDate.Year).AddDays(1))
                                        {
                                            return true;
                                        }

                                    if (testDate.Month == 1)
                                        {
                                            // it's january so check for new year
                                            var dt = new DateTime(testDate.Year,
                                                1,
                                                1);

                                            switch (dt.DayOfWeek)
                                                {
                                                    case DayOfWeek.Saturday:

                                                        // first bank holiday is the 3rd
                                                        return testDate == dt.AddDays(2);
                                                    case DayOfWeek.Sunday:

                                                        // first bank holiday is the 2nd
                                                        return testDate == dt.AddDays(1);
                                                    default:

                                                        // first bank holiday is the day given
                                                        return testDate == dt;
                                                }
                                        }

                                    if (testDate.Month == 5)

                                        {
                                            // if day is monday and its first or last one we return true,
                                            // otherwise return false
                                            // May bank holidays (always a monday)
                                            return testDate == FirstMondayOfMonth(testDate) ||
                                                   testDate == LastMondayOfMonth(testDate);
                                        }


                                    if (testDate.Month == 8)

                                        {
                                            // August bank holidays (always a monday)
                                            return testDate == LastMondayOfMonth(testDate);
                                        }

                                    if (testDate.Month != 12)
                                        {
                                            return false;
                                        }

                                    // christmas day and boxing day
                                    var dtXmas = new DateTime(testDate.Year,
                                        12,
                                        25);

                                    switch (dtXmas.DayOfWeek)
                                        {
                                            case DayOfWeek.Friday:

                                                // in this case boxing day is the following monday
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(3);
                                            case DayOfWeek.Saturday:

                                                // Christmas day bank holiday is the 27th
                                                return testDate == dtXmas.AddDays(2) || testDate == dtXmas.AddDays(3);
                                            case DayOfWeek.Sunday:

                                                // christmas day bank holiday is the 26th
                                                return testDate == dtXmas.AddDays(1) || testDate == dtXmas.AddDays(2);
                                            case DayOfWeek.Monday:

                                                // first bank holiday is the day given
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(1);
                                            case DayOfWeek.Tuesday:

                                                // first bank holiday is the day given
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(1);
                                            case DayOfWeek.Wednesday:

                                                // first bank holiday is the day given
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(1);
                                            case DayOfWeek.Thursday:

                                                // first bank holiday is the day given
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(1);
                                            default:

                                                // first bank holiday is the day given
                                                return testDate == dtXmas || testDate == dtXmas.AddDays(1);
                                        }
                                }
                            catch
                                {
                                    return null;
                                }
                        }
                    }

                /// <summary>
                ///     Is a UK working day
                /// </summary>
                /// <param name="date">
                ///     Date to consider
                /// </param>
                /// <returns>
                ///     true if the date is a monday - friday and not a bank holiday, false otherwise
                /// </returns>
                /// <remarks>
                ///     <seealso cref="IsUkBankHoliday"></seealso>
                /// </remarks>
                public static bool IsUkWorkingDay(this DateTime date)
                    {
                  
                        var isUkBankHoliday = IsUkBankHoliday(date);
                        if (isUkBankHoliday != null && (bool)isUkBankHoliday)
                            {
                                return false;
                            }

                        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
                    }
            }
    }