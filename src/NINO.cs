//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=NINO.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:43 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Extensions;

namespace NLC.Library
    {
        /// <summary>
        ///     National Insurance Number
        /// </summary>
        /// <remarks>
        ///     The format for the Nino is validated against the standard definition. Details of standard can be found at
        ///     www.hmrc.gov.uk/manuals/nimanual/nim39110.htm or wiki If the final character is a space, this must be included
        /// </remarks>
        public class Nino
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="Nino" /> class.
                ///     Start with an construct
                /// </summary>
                public Nino() => Value = string.Empty;

                /// <summary>
                ///     Initializes a new instance of the <see cref="Nino" /> class.
                ///     Get value of passed nino variable and store it in Value
                /// </summary>
                /// <param name="nino">The nino.</param>
                public Nino(string nino) => Value = nino;

                /// <summary>
                ///     Gets a value indicating whether this instance has trailing space.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance has trailing space; otherwise, <c>false</c>.
                /// </value>
                public bool HasTrailingSpace => Value.Substring(Value.Length - 1) == " ";

                /// <summary>
                ///     Gets the left 2 characters
                /// </summary>
                /// <value>
                ///     Returns the first 2 characters, these should be alphabetic
                /// </value>
                public string Left => Value.Substring(0,
                    2);

                /// <summary>
                ///     Gets the length ignoring the trailing space if there is one
                /// </summary>
                /// <value>
                ///     The length.
                /// </value>
                public int Length => Value.Trim().Length;

                /// <summary>
                ///     Since C# doesn't have a mid function, we will create our own which will get the numbers from a NINO
                ///     and hold it in memory
                /// </summary>
                /// <value>
                ///     Gets the middle 5 or 6 characters which should be a long the number of characters depends on the
                ///     existence of a trailing space
                /// </value>
                /// <exception cref="System.IO.InvalidDataException">Invalid NINO</exception>
                public string Mid
                {
                    get
                    {
                        try
                            {
                                var extract = HasTrailingSpace ? 5 : 6;
                                return Value.Substring(2,
                                    extract);
                            }
                        catch
                            {
                                return null;
                            }
                    }
                }

                /// <summary>
                ///     Since C# doesn't have a right function, we will create our own which will get the trailing letter
                ///     from a NIN and hold it in memory
                /// </summary>
                /// <value>
                ///     Get the right most character which should be alphabetic
                /// </value>
                /// <exception cref="System.IO.InvalidDataException">Invalid NINO</exception>
                public string Right
                {
                    get
                    {
                        switch (Length)
                            {
                                case 9:

                                    // return the last character
                                    return Value.Substring(8);
                                case 8:

                                    // return the second to last character (the last one should be a space
                                    return Value.Substring(7,
                                        1);
                                default:
                                    return null;
                            }
                    }
                }

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                /// <value>
                ///     The value.
                /// </value>
                public string Value { get; set; }

                /// <summary>
                ///     Determines whether [is ecs valid].
                /// </summary>
                /// <returns></returns>
                public bool IsEcsValid()
                    {
                        // Determine whether [is Ecs Valid]
                        // Should be in format AANNNNNNA, where A represents an alphabetic character and
                        // N represents a numeric character.
                        // Note1: Nino is not case sensitive
                        // Note2: Checks here AREN'T the same as official ones (implemented in NLC.Library)
                        // http://interim.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/identifiers/national_insurance_number.aspx
                        try
                            {
                                if (string.IsNullOrEmpty(Value))
                                    {
                                        return false;
                                    }

                                if (Value.Length != 9)
                                    {
                                        return false;
                                    }

                                if (Right.IsAlphabetic() == false)
                                    {
                                        return false;
                                    }

                                if (Left.IsAlphabetic() == false)
                                    {
                                        return false;
                                    }

                                return Mid.IsLong() && Mid.IsNumericCharacters();

                                // if we get here we know that mid evaluates to a long but
                                // need to know if its all numeric characters
                            }
                        catch (Exception)
                            {
                                // /something went badly wrong, usually something wierd with right or left or something like that
                                // but we don't care, we just know that
                                return false;
                            }
                    }
            }
    }