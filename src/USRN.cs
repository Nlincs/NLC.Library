//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=USRN.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:52 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Unique Street Reference Number
        /// </summary>
        /// <remarks> Ensures the USRN is correct</remarks>
        public sealed class Usrn : IUsrn, IEquatable<Usrn>
            {
                // Firstly lets set the constructs and variable declarations

                /// <summary>
                ///     Initializes a new instance of the <see cref="Usrn" /> class.
                /// </summary>
                public Usrn()
                    {
                    }

                /// <summary>
                ///     Initializes a new instance of the <see cref="Usrn" /> class.
                /// </summary>
                /// <param name="usrn">
                ///     The USRN.
                /// </param>
                public Usrn(long usrn)
                    {
                        // If USRN is greater then 0, then return the value
                        if (usrn > 0)
                            {
                                UsrnValue = usrn;
                            }
                        else
                            {
                                UsrnValue = null;
                            }
                    }


                /// <summary>
                ///     Initializes a new instance of the <see cref="Usrn" /> class.
                /// </summary>
                /// <param name="usrn">
                ///     The USRN.
                /// </param>
                public Usrn(string usrn)
                    {
                        // convert string value to long and try to parse it into the USRNValue variable
                        if (string.IsNullOrEmpty(usrn))
                            {
                                UsrnValue = null;
                            }
                        else
                            {
                                if (long.TryParse(usrn.Trim(),
                                    out var value))
                                    {
                                        UsrnValue = value;
                                    }
                                else
                                    {
                                        UsrnValue = null;
                                    }
                            }
                    }

                /// <summary>
                ///     Gets the null USRN value.
                /// </summary>
                [XmlIgnore]
                public long NullUsrnValue => -1;

                /// <summary>
                ///     Gets or sets the USRN value.
                /// </summary>
                private long? UsrnValue { get; set; }

                /// <summary> Gets or sets the value of the USRN </summary>
                /// <value> Long integer </value>
                /// <returns> If the USRN has a value that is returned, otherwise returns an arbitrary value</returns>
                /// <remarks>
                ///     <seealso cref="UsrnValue"></seealso>
                /// </remarks>
                public long Value
                {
                    get => UsrnValue ?? NullUsrnValue;

                    set => UsrnValue = value > 0 ? (long?)value : null;
                }

                /// <summary> IsValid USRN</summary>
                /// <value> Boolean</value>
                /// <returns> True if the UPRN has a value, false otherwise</returns>
                /// <remarks>
                ///     Note that in this case an empty usrn is invalid
                ///     <seealso cref="UsrnValue"></seealso>
                /// </remarks>
                public bool IsValid()
                    {
                        if (UsrnValue == null)
                            {
                                return false;
                            }

                        {
                            return IsValidUsrn(UsrnValue.ToString());
                        }
                    }

                /// <summary> Determines whether this instance is default. </summary>
                /// <returns>True if the same as the default value, false otherwise</returns>
                public bool IsDefault()
                    {
                        if (UsrnValue.HasValue)
                            {
                                return UsrnValue.Value == NullUsrnValue;
                            }

                        return true; // no value so this is the  default
                    }

                /// <summary>
                ///     Determines whether this instance is empty.
                /// </summary>
                /// <returns>True if the USRN is empty, false otherwise</returns>
                public bool IsEmpty()
                    {
                        // If an empty value is expected, and USRNValue is empty, return true otherwise return false expression
                        if (UsrnValue == null)
                            {
                                return true;
                            }

                        {
                            return false;
                        }
                    }

                /// <summary>
                ///     Determines whether [is valid USRN] [the specified USRN].
                /// </summary>
                /// <param name="usrn">The USRN.</param>
                /// <returns>true if the USRN is valid, false otherwise</returns>
                /// <remarks>temporary fix until extension works here</remarks>
                public bool IsValidUsrn(long usrn) => IsValidUsrn(usrn.ToString());

                /// <summary>
                ///     Determines whether [is valid USRN] [the specified USRN].
                /// </summary>
                /// <param name="usrn">The USRN.</param>
                /// <returns>true if the USRN is valid, false otherwise</returns>
                public bool IsValidUsrn(string usrn)
                    {
                        usrn = usrn.Trim();

                        // If the length of usrn is less than 1 or greather than 12 then return false as no valid
                        if (usrn.Length <
                            1 ||
                            usrn.Length >
                            12)
                            {
                                return false;
                            }


                        if (long.TryParse(usrn,
                            out var value))
                            {
                                return value >= 1;
                            }

                        return false;
                    }

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(Usrn lhs, Usrn rhs)
                    {
                        // Check for null on left side.
                        if (lhs is null)
                            {
                                return rhs is null;

                                // Only the left side is null.
                            }

                        // Equals handles case of null on right side.
                        return lhs.Equals(rhs);
                    }

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator !=(Usrn lhs, Usrn rhs) => !(lhs == rhs);

                #region Implementation of IEquatable<IUsrn>

                /// <inheritdoc />
                public bool Equals(IUsrn other) => Equals(other as Usrn);

                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                public override bool Equals(object usrn) => Equals(usrn as Usrn);

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(Usrn other)
                    {
                        // If parameter is null, return false.
                        if (other is null)
                            {
                                return false;
                            }

                        // Optimization for a common success case.
                        if (ReferenceEquals(this, other))
                            {
                                return true;
                            }

                        // If run-time types are not exactly the same, return false.
                        if (GetType() != other.GetType())
                            {
                                return false;
                            }

                        // Return true if the fields match.
                        // Note that the base class is not invoked because it is
                        // System.Object, which defines Equals as reference equality.
                        return Value == other.Value;
                    }

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public override int GetHashCode()
                    {
                        // from https://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
                        // derived from http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
                        unchecked
                            {
                                // Choose large primes to avoid hashing collisions
                                const int hashingBase = (int)2166136261;
                                const int hashingMultiplier = 16777619;

                                var hash = hashingBase;
                                hash = (hash * hashingMultiplier) ^
                                       (!ReferenceEquals(null, Value) ? Value.GetHashCode() : 0);
                                return hash;
                            }
                    }

                #endregion
            }
    }
