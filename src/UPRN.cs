//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UPRN.cs company="North Lincolnshire Council">
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

using NLC.Library.Interfaces;
using System;
using System.Xml.Serialization;

namespace NLC.Library
    {
        /// <summary>
        ///     Unique Property Reference Number
        /// </summary>
        /// <remarks> Ensures the UPRN is correct</remarks>
        public sealed class Uprn : IUprn
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="Uprn" /> class.
                /// </summary>
                public Uprn() => UprnValue = null;

                /// <summary>
                ///     Initializes a new instance of the <see cref="Uprn" /> class.
                /// </summary>
                /// <param name="value">
                ///     The value.
                /// </param>
                public Uprn(long value) => UprnValue = value;

                /// <summary>
                ///     Initializes a new instance of the <see cref="Uprn" /> class.
                /// </summary>
                /// <param name="value">
                ///     The value.
                /// </param>
                public Uprn(string value)
                    {
                        // if we pass the value nothing then it apears to come here
                        if (string.IsNullOrEmpty(value))
                            {
                                UprnValue = null;
                            }
                        else
                            {
                                if (long.TryParse(value.Trim(),
                                        out var result))
                                    {
                                        UprnValue = result;
                                    }
                                else
                                    {
                                        UprnValue = null;
                                    }
                            }
                    }

                /// <summary>
                ///     Gets the null uprn value.
                /// </summary>
                [XmlIgnore]
                public long NullUprnValue => -1;

                /// <summary>
                ///     Gets or sets the uprn value.
                /// </summary>
                private long? UprnValue { get; set; }

                /// <summary> Numeric value of the UPRN </summary>
                /// <value>long</value>
                /// <returns>If the UPRN has a numeric value then that is returned, otherwise returns an arbitrary value</returns>
                /// <exception cref="IndexOutOfRangeException" accessor="get">UPRN value</exception>
                public long Value
                {
                    get => UprnValue ?? NullUprnValue;

                    set
                    {
                        if (value > 0)
                            {
                                UprnValue = value;
                            }
                        else
                            {
                                UprnValue = null;
                            }
                    }
                }

                /// <summary> Determines whether this instance is default. </summary>
                /// <returns>True if the same as the default value, false otherwise</returns>
                public bool IsDefault()
                    {
                        if (UprnValue.HasValue)
                            {
                                return UprnValue.Value == NullUprnValue;
                            }

                        return true; // no value so this is the  default
                    }

                /// <summary> Is Street </summary>
                /// <value>Boolean</value>
                /// <returns>True if the uprn is a street record, false otherwise</returns>
                public bool IsStreet() => throw new NotImplementedException();

                /// <summary>
                ///     IsValid
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if the UPRN has a value, false otherwise</returns>
                /// <remarks>
                ///     <seealso cref="UprnValue"></seealso>
                /// </remarks>
                public bool IsValid()
                    {
                        if (UprnValue == null)
                            {
                                return false;
                            }

                        // Otherwise return the value which is set
                        return IsValidUprn(UprnValue.Value);
                    }


                /// <summary>
                ///     The is empty.
                /// </summary>
                /// <returns>
                ///     The <see cref="bool" />.
                /// </returns>
                public bool IsEmpty()
                    {
                        if (UprnValue == null)
                            {
                                return true;
                            }

                        // otherwise return false
                        return false;
                    }

                /// <summary>
                ///     ISValidUPRN
                /// </summary>
                /// <param name="uprn">
                /// </param>
                /// <remarks>
                ///     temp replacement for the extension method
                /// </remarks>
                /// <returns>
                ///     The <see cref="bool" />.
                /// </returns>
                public bool IsValidUprn(Uprn uprn) => IsValidUprn(uprn.Value);

                /// <summary>
                ///     The is valid uprn.
                /// </summary>
                /// <param name="uprn">
                ///     The uprn.
                /// </param>
                /// <returns>
                ///     The <see cref="bool" />.
                /// </returns>
                private bool IsValidUprn(long uprn)
                    {
                        var suprn = UprnValue.ToString().Trim();

                        if (suprn.Length < 1 || suprn.Length > 12)
                            {
                                return false;
                            }

                        if (uprn < 1)
                            {
                                return false;
                            }

                        return long.TryParse(suprn,
                            out _);
                    }
            }
    }