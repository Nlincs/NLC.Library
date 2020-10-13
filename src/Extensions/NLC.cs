//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=NLC.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:20 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;

namespace NLC.Library.Extensions
    {
        /// <summary>
        ///     Generic Objects
        /// </summary>
        /// <remarks>Objects for general internal use</remarks>
        public static class Nlc
            {
                // NLC specific extensions, initially for the SOA but can be used anywhere.

                /// <summary>
                ///     Is valid CRM number
                /// </summary>
                /// <param name="crmNumber">the number to check as a string</param>
                /// <returns>true if the number is a valid CRM number. False if not a valid CRM number, nothing if unclear</returns>
                /// <remarks></remarks>
                public static bool? IsValidCrmNumber(this string crmNumber)
                    {

                        // Throw New NotImplementedException
                        var result = true;

                        crmNumber = crmNumber.Trim().ToUpper(CultureInfo.InvariantCulture);

                        if (crmNumber.Length < 4 || crmNumber.Length > 20)
                            {
                                result = false;
                            }

                        // too short or too long

                        // now check for a valid CRM prefix
                        // and take it off
                        if (crmNumber.Substring(0,
                                2) ==
                            "CS")
                            {
                                crmNumber = crmNumber.Right(crmNumber.Length - 2);
                            }
                        else
                            {
                                var prefix = crmNumber.Substring(0,
                                    3);

                                switch (prefix)
                                    {
                                        case "CRM":
                                        case "SSN":
                                        case "SSW":
                                        case "SSH":
                                        case "ENV":
                                        case "JOB":
                                        case "WAS":
                                        case "COM":
                                        case "FOI":
                                        case "HOM":

                                            // valid prefixes
                                            crmNumber = crmNumber.Right(crmNumber.Length - 3);
                                            break;
                                        default:

                                            // invalid CRM number
                                            return false;
                                    }
                            }

                        // what's left should be numeric

                        if (long.TryParse(crmNumber,
                            out _))
                            {
                                // we have success
                            }
                        else
                            {
                                result = false;
                            }

                        return result;
                    }

                /// <summary>
                ///     Is Valid Text
                /// </summary>
                /// <param name="text">The text to check</param>
                /// <param name="invalidChars">The invalid characters to check for</param>
                /// <returns>
                ///     each entry in the list indicates the position and character that is invalid,
                ///     Empty list if none
                ///     Null if no invalidCharacters supplied
                /// </returns>
                /// <remarks>
                ///     Originally written as some characters are not valid to be inserted using web services
                ///     into the back office systems e.g. some back offices cannot accept an ampersand. Scans through every
                ///     character in the input string so that it can return all the values that are invalid.
                ///     this is not the most efficient way of looking for invalid characters but this routine locates
                ///     them all and indicates their location
                /// </remarks>
                public static List<string> IsValidText(this string text,
                    string invalidChars)
                    {
                        if (string.IsNullOrEmpty(invalidChars))
                            {
                                return null;
                            }

                        var result = new List<string>();
                        var position = 1;

                        foreach (var c in text)
                            {
                                if (invalidChars.Contains(c.ToString()))
                                    {
                                        result.Add("Position " + position + ": Invalid character - " + c);
                                    }

                                position += 1;
                            }

                        return result;
                    }
            }
    }