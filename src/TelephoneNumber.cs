//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumber.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 16:16
//  Altered - 12/10/2020 14:43 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NLC.Library.Interfaces;
using PhoneNumbers;

namespace NLC.Library
    {
        // this encapsulates the telephone number as defined in 
        // http://umbr4.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/contact_information/uk_telephone_number.aspx
        // Modified Oct 2020 to make use of Google library libphonenumber-csharp


        /// <summary>
        ///     Telephone number
        /// </summary>
        /// <remarks>Ensure the phone number is correctly formatted </remarks>
        public sealed class TelephoneNumber : ITelephoneNumber, IEquatable<TelephoneNumber>
            {
                private PhoneNumberUtil _phoneNumberUtil;

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                public TelephoneNumber() => Setup();

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                public TelephoneNumber(string telephoneNumber)
                    {
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                public TelephoneNumber(string telephoneNumber, string isoCountryCode)
                    {
                        IsoCountryCode = isoCountryCode;
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                public string IsoCountryCode { get; set; } = "GB";

                private PhoneNumber phoneNumber { get; set; }

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(TelephoneNumber other)
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
                ///     Value of phone number
                /// </summary>
                public string Value
                {
                    get => phoneNumber == null ? "" : phoneNumber.NationalNumber.ToString();
                    set
                    {
                        try
                            {
                                phoneNumber = _phoneNumberUtil.Parse(value, IsoCountryCode);
                            }
                        catch
                            {
                                phoneNumber = null;
                            }
                    }
                }

                /// <summary>
                ///     Country Code
                /// </summary>
                /// <value>string</value>
                /// <returns>The country code for the number</returns>
                /// <remarks>+44 for UK</remarks>
                public string CountryCode
                {
                    get => phoneNumber == null ? "" : phoneNumber.CountryCode.ToString();
                    set => throw new NotImplementedException();
                }

                /// <summary>
                ///     Gets or sets the extension number.
                /// </summary>
                /// <value>
                ///     The extension number.
                /// </value>
                public string ExtensionNumber
                {
                    get => phoneNumber == null ? "" : phoneNumber.Extension;
                    set => throw new NotImplementedException();
                }

                /// <summary>
                ///     Full National number
                /// </summary>
                /// <value>string</value>
                /// <returns>The full national telephone number</returns>
                /// <remarks>This should be the full national number i.e. with no leading 0</remarks>
                public string NationalNumber
                {
                    get => phoneNumber == null ? "" : phoneNumber.NationalNumber.ToString();
                    set
                    {
                        try
                            {
                                phoneNumber = _phoneNumberUtil.Parse(value, IsoCountryCode);
                            }
                        catch
                            {
                                phoneNumber = null;
                            }
                    }
                }

                /// <inheritdoc />
                public bool IsValid { get => NationalNumber != ""; }

                /// <inheritdoc />
                public bool Equals(ITelephoneNumber other) => Equals(other as TelephoneNumber);


                private void Setup() => _phoneNumberUtil = PhoneNumberUtil.GetInstance();


                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(TelephoneNumber lhs, TelephoneNumber rhs)
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
                public static bool operator !=(TelephoneNumber lhs, TelephoneNumber rhs) => !(lhs == rhs);


                /// <summary>
                /// </summary>
                /// <param name="obj"></param>
                /// <returns></returns>
                public override bool Equals(object obj) => Equals(obj as TelephoneNumber);

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public override int GetHashCode()
                    {
                        var hashCode = -2017556967;
                        hashCode = (hashCode * -1521134295) + base.GetHashCode();
                        hashCode = (hashCode * -1521134295) +
                                   EqualityComparer<string>.Default.GetHashCode(NationalNumber);
                        hashCode = (hashCode * -1521134295) +
                                   EqualityComparer<string>.Default.GetHashCode(ExtensionNumber);
                        return hashCode;
                    }
            }
    }