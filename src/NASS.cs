//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=NASS.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:16 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions.NationalGovernment.eGIF;
using System;

namespace NLC.Library
    {
        /// <summary>
        ///     National Asylum seekers number
        /// </summary>
        /// <remarks>
        ///     The format is validated against the standard
        ///     definition and is fo the form YYMMNNNNN
        ///     where YY is last two digits of year, MM is month
        ///     and N is a digit
        /// </remarks>
        public class Nass
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="Nass" /> class.
                /// </summary>
                public Nass() => Value = string.Empty;

                /// <summary>
                ///     Initializes a new instance of the <see cref="Nass" /> class.
                ///     Retrieve the nass string and store it in the variable 'Value'
                /// </summary>
                /// <value>
                ///     Value
                /// </value>
                /// <param name="nass">
                ///     The nass.
                /// </param>
                public Nass(string nass) => Value = nass;

                /// <summary>
                ///     Gets the 3rd and 4th numbers, which represent the month
                /// </summary>
                /// <remarks>
                ///     Get the next two values starting at position 3
                ///     expression is Value.Substring(start character, length of split)
                /// </remarks>
                public string MonthPart => Value.Substring(2,
                    2);

                /// <summary>
                ///     Gets the final 6 numbers
                /// </summary>
                /// <remarks>
                ///     Lastly we need to get the remaining characters
                ///     Value.Length - 4 is used as we have already found the original 4 numbers, so we know there are only 5 left
                ///     We could alter this to display 5, however this setup will remain valid, even if the values change
                /// </remarks>
                public string NumberPart => Value.Substring(4, Value.Length - 4);

                /// <summary>
                ///     Lets initialise what Value can do
                /// </summary>
                public string Value { get; set; }

                /// <summary>
                ///     Gets the 1st and 2nd numbers, which represent the year
                /// </summary>
                /// <remarks>
                ///     Extract the first two characters starting at position 1  (YY)
                ///     In coding, the first character is always represented with a 0 unless explicitly set
                ///     expression is Value.Substring(start character, length of split)
                /// </remarks>
                public string YearPart => Value.Substring(0,
                    2);

                /// <summary>
                ///     NASS number validity
                /// </summary>
                /// <returns>True if the NASS number is of the correct format, false otherwise</returns>
                /// <remarks>
                ///     This indicates if the NASS number is valid according to Eligibility Checking Service requirements
                ///     which may (or may not) be as rigourous as the checking of the validity of the number
                /// </remarks>
                public bool IsEcsValid()
                    {
                        try
                            {
                                // return value of whether nass is in the right format
                                return Value.IsValidNassNumber();
                            }
                        catch (Exception)
                            {
                                // If this runs, a serious error has happened
                                return false;
                            }
                    }
            }
    }