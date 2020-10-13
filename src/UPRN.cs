//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UPRN.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:51 - Stephen Ellwood
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
        ///     Unique Property Reference Number
        /// </summary>
        /// <remarks> Ensures the UPRN is correct</remarks>
        public sealed class Uprn : IUprn, IEquatable<Uprn>
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

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(Uprn lhs, Uprn rhs)
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
                public static bool operator !=(Uprn lhs, Uprn rhs) => !(lhs == rhs);

                #region Implementation of IEquatable<IUprn>

                /// <inheritdoc />
                public bool Equals(IUprn other) => Equals(other as Uprn);

                /// <summary>
                /// 
                /// </summary>
                /// <param name="uprn"></param>
                /// <returns></returns>
                public override bool Equals(object uprn) => Equals(uprn as Uprn);

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(Uprn other)
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