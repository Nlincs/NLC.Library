//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumber.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:36
//  Altered - 16/12/2020 16:08 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;
using PhoneNumbers;
using System;

namespace NLC.Library
    {
        // this encapsulates the telephone number as defined in 
        // http://umbr4.cabinetoffice.gov.uk/govtalk/schemasstandards/e-gif/datastandards/contact_information/uk_telephone_number.aspx
        // Modified Oct 2020 to make use of Google library libphonenumber-csharp


        /// <summary>
        ///     Telephone number
        /// </summary>
        /// <remarks>Ensure the phone number is correctly formatted </remarks>
        public sealed class TelephoneNumber : ITelephoneNumber
            {
                private PhoneNumberUtil _phoneNumberUtil;

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                public TelephoneNumber()
                    {
                        originalNumber = "";
                        Setup();
                    }

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                public TelephoneNumber(string telephoneNumber)
                    {
                        originalNumber = telephoneNumber;
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                /// <summary>
                ///     Initializes a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                /// <param name="isoCountryCode"></param>
                public TelephoneNumber(string telephoneNumber, string isoCountryCode)
                    {
                        originalNumber = telephoneNumber;
                        IsoCountryCode = isoCountryCode;
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                /// <summary>
                ///     Stores original number passed in
                /// </summary>
                private string originalNumber { get; set; }


                public string IsoCountryCode { get; set; } = "GB";

                private PhoneNumber phoneNumber { get; set; }

                /// <summary>
                ///     Value of phone number
                /// </summary>
                public string Value
                {
                    get
                    {
                        if (phoneNumber == null)
                            {
                                return "";
                            }

                        var result = phoneNumber.NationalNumber.ToString();
                        if (result.Length < 1)
                            {
                                return "";
                            }
                        // restore leading 0 if it was in the original
                        if (OriginalHasLeadingZero())
                            {
                                result = "0" + result;
                            }

                        return result;
                    }

                    set
                    {
                        if (originalNumber == null || originalNumber.Trim() == "")
                            {
                                originalNumber = value;
                            }

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
                public bool IsValid
                {
                    get
                    {
                        if (phoneNumber == null)
                            {
                                return false;
                            }

                        return _phoneNumberUtil.IsValidNumber(phoneNumber);
                    }
                }

                private bool OriginalHasLeadingZero()
                    {
                        if (originalNumber == null || originalNumber.Length <= 1)
                            {
                                return false;
                            }

                        return originalNumber.Trim().Substring(0, 1) == "0";
                    }


                private void Setup() => _phoneNumberUtil = PhoneNumberUtil.GetInstance();
            }
    }