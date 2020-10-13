//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=CRMReference.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:39 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Extensions;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     CRM Reference
        /// </summary>
        /// <remarks>
        ///     The format is validated against the standard definition
        /// </remarks>
        public sealed class CrmReference : ICrmReference, IEquatable<CrmReference>
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value"></param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(int value) => Value = value.ToString();

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value"></param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(long value) => Value = value.ToString();

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference() => Value = "";

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(string value) => Value = value;

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                /// <value>
                ///     The value.
                /// </value>
                public string Value { get; set; }

                /// <summary>
                ///     Determines whether this instance is valid.
                /// </summary>
                /// <returns></returns>
                /// <exception cref="System.NotImplementedException">Not Implemented</exception>
                public bool IsValid() => Value != null;

                /// <summary>
                ///     Extract the numeric part of the reference
                /// </summary>
                /// <returns>numeric part of the crm reference as a string, empty if no value</returns>
                /// <remarks>
                ///     Assumes that any non alpha is a prefix only. This finds the first numeric character
                ///     and checks if the rest of the string is a numeric
                /// </remarks>
                public string NumericValue()
                    {
                        if (Value == string.Empty)
                            {
                                return string.Empty;
                            }

                        var result = Value;

                        // assume that any non numeric are a prefix

                        while (result.Length > 0 && !result.Substring(0, 1).IsNumeric())
                            {
                                result = result.Substring(1);
                            }

                        // need length of result so we can restore leading 0 in the output
                        var resultLen = result.Length;

                        return long.TryParse(result, out var output)
                            ? output.ToString().PadLeft(resultLen, '0')
                            : string.Empty;
                    }

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(CrmReference lhs, CrmReference rhs)
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
                public static bool operator !=(CrmReference lhs, CrmReference rhs) => !(lhs == rhs);


                #region Implementation of IEquatable<IUprn>

                /// <inheritdoc />
                public bool Equals(ICrmReference other) => Equals(other as CrmReference);

                /// <summary>
                /// </summary>
                /// <param name="crmRef"></param>
                /// <returns></returns>
                public override bool Equals(object crmRef) => Equals(crmRef as CrmReference);

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(CrmReference other)
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
                                hash = (hash * hashingMultiplier) ^ (Value is object ? Value.GetHashCode() : 0);
                                return hash;
                            }
                    }

                #endregion
            }
    }