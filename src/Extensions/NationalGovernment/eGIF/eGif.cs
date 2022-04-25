//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=eGif.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:15 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NLC.Library.Extensions.NationalGovernment.eGIF
    {
        /// <summary>
        ///     Government Data Standards
        /// </summary>
        /// <remarks>
        ///     Extensions to encapsulate elements of the government data dictionary
        ///     http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/identifiers/national_insurance_number.aspx
        /// </remarks>
        public static class GovernmentData
            {
                /// <summary>
                ///     Periodicity
                /// </summary>
                /// <remarks>Represents various periods of time</remarks>
                public enum Periodicity
                    {
                        /// <summary>
                        ///     The daily.
                        /// </summary>
                        Daily,

                        /// <summary>
                        ///     The weekly.
                        /// </summary>
                        Weekly,

                        /// <summary>
                        ///     The fortnightly.
                        /// </summary>
                        Fortnightly,

                        /// <summary>
                        ///     The four weekly.
                        /// </summary>
                        FourWeekly,

                        /// <summary>
                        ///     The calendar monthly.
                        /// </summary>
                        CalendarMonthly,

                        /// <summary>
                        ///     The quarterly.
                        /// </summary>
                        Quarterly,

                        /// <summary>
                        ///     The annually.
                        /// </summary>
                        Annually,

                        /// <summary>
                        ///     The irregularly.
                        /// </summary>
                        Irregularly,

                        /// <summary>
                        ///     The half yearly.
                        /// </summary>
                        HalfYearly,

                        /// <summary>
                        ///     The thirteen weekly.
                        /// </summary>
                        ThirteenWeekly,

                        /// <summary>
                        ///     The one off.
                        /// </summary>
                        OneOff
                    }

                /// <summary>
                ///     Is Northlincs Anonymous post code
                /// </summary>
                /// <param name="postcode">the postcode to test</param>
                /// <returns>true if the post code is what we internally use as anonymous</returns>
                /// <remarks>This is a fudge that allows us to log anonymous jobs across the board</remarks>
                public static bool IsNorthlincsAnonymousPostcode(this string postcode)
                    {
                        var pc = new PostCode(postcode);

                        return pc.IsNorthlincsAnonymous();
                    }

                /// <summary>
                ///     Is Northlincs Anonymous post code
                /// </summary>
                /// <param name="postcode">the postcode to test</param>
                /// <returns>true if the post code is what we internally use as anonymous</returns>
                /// <remarks>This is a fudge that allows us to log anonymous jobs across the board</remarks>
                public static bool IsNorthlincsAnonymousPostcode(this PostCode postcode) =>
                    postcode.IsNorthlincsAnonymous();

                /// <summary>
                ///     Checks if a date stored in string format is valid by government standards
                /// </summary>
                /// <param name="date">The date value to check</param>
                /// <returns>true if valid, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     See full definition -
                ///     http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/temporal/date.aspx
                ///     Date must be in CCYY-MM-DD format
                ///     Date cannot be in the future nor can it be before 1900
                /// </remarks>
                public static bool IsValidDate(this string date)
                    {
                        if (date.Length != 10)
                            {
                                return false;
                            }

                        // now we need to check for valid characters in appropriate positions
                        if (date.Substring(4,
                                1) !=
                            "-")
                            {
                                return false;
                            }

                        if (date.Substring(7,
                                1) !=
                            "-")
                            {
                                return false;
                            }

                        // now we need to check the numeric elements are valid

                        var y = date.Substring(0,
                            4);
                        var m = date.Substring(5,
                            2);

                        var d = date.Substring(date.Length - 2);

                        if (int.TryParse(y,
                                out var iy))
                            {
                                // iy has a valid integer representing the year
                                if (iy < 1900 || iy > DateTime.Now.Year)
                                    {
                                        return false;
                                    }
                            }
                        else
                            {
                                // parsing failed
                                return false;
                            }

                        if (int.TryParse(m,
                                out var im))
                            {
                                if (im < 1 || im > 12)
                                    {
                                        return false;
                                    }
                            }
                        else
                            {
                                // parsing failed
                                return false;
                            }

                        // CCYY should be a valid year number.
                        // MM in Range 01-12.
                        // DD in Range 01-31.
                        if (int.TryParse(d,
                                out var id))
                            {
                                if (id < 1 || id > 31)
                                    {
                                        return false;
                                    }


                                // parsing succeeded so we perform the rest of the validity checks
                                switch (im)
                                    {
                                        // long months must be true as we have checked number of days
                                        case 1:
                                        case 3:
                                        case 5:
                                        case 6:
                                        case 8:
                                        case 10:
                                        case 12:
                                            return true;

                                        case 4:
                                        case 7:
                                        case 9:
                                        case 11:

                                            // Days must not be greater than 30 in April, June, September and November.
                                            if (id > 30)
                                                {
                                                    return false;
                                                }

                                            break;
                                        case 2:

                                            // Days must not be greater than 28 in February except when 29 is allowed for a leap year.
                                            if (DateTime.IsLeapYear(iy))
                                                {
                                                    return id <= 29;
                                                }

                                            return id <= 28;
                                    }
                            }
                        else
                            {
                                // parsing failed
                                return false;
                            }

                        return true;
                    }

                /// <summary>
                ///     Check validity of an NASS number
                /// </summary>
                /// <param name="nassNumber">Number to check</param>
                /// <returns>True if valid, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     NASS should be in the format YYMMNNNNN, where YY represents the last two digits of a year,
                ///     MM represents a month as a two digit number and N represents a digit e.g. 090300017.
                ///     Notes:
                ///     Leading zeros are required, e.g. 90300017 will be rejected.
                /// </remarks>
                public static bool IsValidNassNumber(this string nassNumber)
                    {
                        if (nassNumber.IsInteger() == false)
                            {
                                return false;
                            }

                        if (nassNumber.Length != 9)
                            {
                                return false;
                            }

                        // as mm is a month it must have a value <= 12
                        var month = nassNumber.Substring(2,
                            2);
                        if (int.TryParse(month,
                                out var mnum))
                            {
                                if (mnum > 12 || mnum < 1)
                                    {
                                        return false;
                                    }
                            }
                        else
                            {
                                // conversion failed so return an error
                                return false;
                            }

                        // we got here so all tests passed
                        return true;
                    }

                // this is intended to implement some business rules for the government data standards catalog
                // starting with the NI number as specified here - http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/identifiers/national_insurance_number.aspx


                /// <summary>
                ///     Check validity of an NI number
                /// </summary>
                /// <param name="niNumber">Number to check</param>
                /// <returns>
                ///     True if valid, false if not, nothing if an exception occurs
                /// </returns>
                /// <remarks>
                ///     Criteria
                ///     1. Must be 9 characters.
                ///     2. First 2 characters must be alpha.
                ///     3. Next 6 characters must be numeric.
                ///     4. Final character can be A, B, C, D or space.
                ///     5. First character must not be D,F,I,Q,U or V
                ///     6. Second characters must not be D, F, I, O, Q, U or V.
                ///     7. First 2 characters must not be combinations of GB, NK, TN or ZZ (the term combinations covers both GB and BG
                ///     etc.)
                /// </remarks>
                public static bool IsValidNiNumber(this string niNumber)
                    {
                        //  Throw New NotImplementedException
                        var result = true;

                        if (niNumber == string.Empty)
                            {
                                return false;
                            }

                        try
                            {
                                niNumber = niNumber.TrimStart().ToUpper(CultureInfo.InvariantCulture);

                                if (niNumber.Length != 9)
                                    {
                                        result = false;
                                    }

                                if (niNumber.Substring(0,
                                        2).IsAlphabetic() ==
                                    false)
                                    {
                                        result = false;
                                    }

                                if (niNumber.Substring(2,
                                        6).IsInteger() ==
                                    false)
                                    {
                                        result = false;
                                    }

                                switch (niNumber.Substring(niNumber.Length - 1))
                                    {
                                        case "A":
                                        case "B":
                                        case "C":
                                        case "D":
                                        case " ":
                                            break;

                                        // ok so do nothing
                                        default:
                                            result = false;
                                            break;
                                    }

                                switch (niNumber.Substring(0,
                                            1))
                                    {
                                        case "D":
                                        case "F":
                                        case "I":
                                        case "Q":
                                        case "U":
                                        case "V":
                                            result = false;
                                            break;
                                    }

                                switch (niNumber.Substring(1,
                                            1))
                                    {
                                        case "D":
                                        case "F":
                                        case "I":
                                        case "O":
                                        case "Q":
                                        case "U":
                                        case "V":
                                            result = false;
                                            break;
                                    }

                                var firstTwo = niNumber.Substring(0,
                                    2);

                                switch (firstTwo)
                                    {
                                        case "GB":
                                        case "BG":
                                        case "NK":
                                        case "KN":
                                        case "TN":
                                        case "NT":
                                        case "ZZ":
                                            result = false;
                                            break;
                                    }
                            }
                        catch (Exception)
                            {
                                // if we get here something has gone wrong
                                result = false;
                            }

                        return result;
                    }

                /// <summary>
                ///     Valid UK Post Code
                /// </summary>
                /// <param name="postCode">The post code to check</param>
                /// <returns>true if the post code appears valid, false otherwise</returns>
                /// <remarks>
                ///     Attempts to check that the post code is a sensible one
                ///     based on http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/address/postcode.aspx
                ///     Valid Formats
                ///     The following is a list of the valid formats of postcode.An ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€šÃ‚Â¹ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¦ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã¢â‚¬Å“AÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¾ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢
                ///     indicates an
                ///     alphabetic
                ///     character, an ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€šÃ‚Â¹ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¦ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã¢â‚¬Å“NÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡Ãƒâ€šÃ‚Â¬ÃƒÆ’Ã¢â‚¬Â¦Ãƒâ€šÃ‚Â¾ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¢
                ///     indicates a numeric character.
                ///     Format Example
                ///     Outcode Incode Postcode
                ///     AN NAA M1ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±1AAÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±
                ///     ANN NAA M60ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±1NWÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±
                ///     AAN NAA CR2ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±6XHÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±
                ///     AANN NAA DN55ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±1PT
                ///     ANA NAA W1PÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±1HQÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±
                ///     AANA NAA EC1AÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â
                ///     ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â±1BB
                ///     (Where ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Â ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚ÂÃƒÆ’Ã†â€™Ãƒâ€
                ///     Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â± represents a space)
                ///     The following characters are never used in the inward part of the postcode:
                ///     C I K M O V
                /// </remarks>
                public static bool IsValidUkPostCode(this string postCode)
                    {
                        // we are going to accept a variety of formats for post code
                        // as well as the standard one we will include double spaces in the middle
                        // and "Mosaic" format e.g. AA N NAA

                        // now we determine the in and out codes
                        string outcode;
                        string incode;

                        // first trim stray white space and make the characters upper case
                        postCode = postCode.Trim().ToUpper(CultureInfo.InvariantCulture);

                        int startLen;
                        do
                            {
                                // handle multiple mid spaces
                                startLen = postCode.Length;
                                postCode = postCode.ReplaceAll("  ",
                                    " ");
                            } while (startLen > postCode.Length);

                        if (postCode.Length > 8) // unsure of mosaic format can have length 9 e.g. 
                            {
                                return false;
                            }

                        if (postCode.Length < 5)
                            {
                                return false;
                            }

                        // now account for the quirks
                        if (postCode == "GIR 0AA" || postCode == "DN00 000")
                            {
                                return true;
                            }

                        // first handle mosaic
                        // as this is effectively three words we concatenate the first two      
                        var wordCount = postCode.WordCount();
                        if (wordCount > 3)
                            {
                                return false; // too many words
                            }

                        switch (wordCount)
                            {
                                case 3:

                                    // assume mosaic format
                                    outcode = postCode.FirstWord() +
                                              postCode.NthWord(2);
                                    incode = postCode.LastWord();
                                    break;
                                case 2:
                                    outcode = postCode.FirstWord();
                                    incode = postCode.LastWord();
                                    break;
                                case 1:

                                    // mosaic format

                                    incode = postCode.Right(3);
                                    outcode = postCode.Substring(0,
                                        postCode.Length - 3);

                                    break;
                                default:
                                    return false;
                            }


                        // checks that a post code is alphanumeric and sensible length

                        var inCodePattern = new Regex("[0-9][abdefghjlnpqrstuwxyzABDEFGHJLNPQRSTUWXYZ]{2}");
                        var anPattern = new Regex("[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][0-9]");
                        var annPattern = new Regex("[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][0-9]{2}");
                        var aanPattern = new Regex("[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]{2}[0-9]");
                        var aannPattern =
                            new Regex("[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]{2}[0-9]{2}");
                        var anaPattern =
                            new Regex(
                                "[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][0-9][abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]");
                        var aanapAttern =
                            new Regex(
                                "[abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]{2}[0-9][abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]");

                        if (!inCodePattern.IsMatch(incode))
                            {
                                return false;
                            }

                        return anPattern.IsMatch(outcode) || annPattern.IsMatch(outcode) ||
                               aanPattern.IsMatch(outcode) ||
                               aannPattern.IsMatch(outcode) || anaPattern.IsMatch(outcode) ||
                               aanapAttern.IsMatch(outcode);
                    }

                /// <summary>
                ///     Valid Post Code
                /// </summary>
                /// <param name="postCode">The post code to check</param>
                /// <returns>true if the post code appears valid, false otherwise</returns>
                /// <remarks>
                ///     Attempts to check that the post code is a sensible one
                ///     based on http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/address/postcode.aspx
                /// </remarks>
                public static bool IsValidUkPostCode(this PostCode postCode) => IsValidUkPostCode(postCode.Value);


                /// <summary>
                ///     Periodicity Type
                /// </summary>
                /// <param name="period">The periodicity of interest</param>
                /// <returns>Translates a periodicity to the appropriate numeric character string, Empty string if unknown</returns>
                /// <remarks>
                ///     <seealso cref="Periodicity"></seealso>
                /// </remarks>
                public static string PeriodicityValue(this Periodicity period)
                    {
                        switch (period)
                            {
                                case Periodicity.Daily:
                                    return "01";
                                case Periodicity.Weekly:
                                    return "02";
                                case Periodicity.Fortnightly:
                                    return "03";
                                case Periodicity.FourWeekly:
                                    return "04";
                                case Periodicity.CalendarMonthly:
                                    return "05";
                                case Periodicity.Quarterly:
                                    return "06";
                                case Periodicity.Annually:
                                    return "07";
                                case Periodicity.Irregularly:
                                    return "08";
                                case Periodicity.HalfYearly:
                                    return "09";
                                case Periodicity.ThirteenWeekly:
                                    return "10";
                                case Periodicity.OneOff:
                                    return "11";
                                default:

                                    return "";
                            }
                    }
            }
    }