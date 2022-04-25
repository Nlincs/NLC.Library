//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumber.cs company="North Lincolnshire Council">
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
                ///     Initialises a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                public TelephoneNumber()
                    {
                        OriginalNumber = "";
                        Setup();
                    }

                /// <summary>
                ///     Initialises a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                public TelephoneNumber(string telephoneNumber)
                    {
                        OriginalNumber = telephoneNumber;
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                /// <summary>
                ///     Initialises a new instance of the <see cref="TelephoneNumber" /> class.
                /// </summary>
                /// <param name="telephoneNumber">The telephone number.</param>
                /// <param name="isoCountryCode"></param>
                public TelephoneNumber(string telephoneNumber, string isoCountryCode)
                    {
                        OriginalNumber = telephoneNumber;
                        IsoCountryCode = isoCountryCode;
                        Setup();
                        NationalNumber = telephoneNumber == null ? string.Empty : telephoneNumber.Trim();
                    }

                /// <summary>
                ///     Stores original number passed in
                /// </summary>
                private string OriginalNumber { get; set; }

                /// <summary>
                /// </summary>
                public string IsoCountryCode { get; set; } = "GB";

                /// <summary>
                /// </summary>
                private PhoneNumber PhoneNumber { get; set; }

                /// <summary>
                ///     Value of phone number
                /// </summary>
                public string Value
                {
                    get
                    {
                        if (PhoneNumber == null)
                            {
                                return "";
                            }

                        var result = PhoneNumber.NationalNumber.ToString();
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
                        if (OriginalNumber == null || OriginalNumber.Trim() == "")
                            {
                                OriginalNumber = value;
                            }

                        try
                            {
                                PhoneNumber = _phoneNumberUtil.Parse(value, IsoCountryCode);
                            }
                        catch
                            {
                                PhoneNumber = null;
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
                    get => PhoneNumber == null ? "" : PhoneNumber.CountryCode.ToString();
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
                    get => PhoneNumber == null ? "" : PhoneNumber.Extension;
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
                    get => PhoneNumber == null ? "" : PhoneNumber.NationalNumber.ToString();
                    set
                    {
                        try
                            {
                                PhoneNumber = _phoneNumberUtil.Parse(value, IsoCountryCode);
                            }
                        catch
                            {
                                PhoneNumber = null;
                            }
                    }
                }

                /// <inheritdoc />
                public bool IsValid
                {
                    get
                    {
                        return PhoneNumber != null && _phoneNumberUtil.IsValidNumber(PhoneNumber);
                    }
                }

                private bool OriginalHasLeadingZero()
                    {
                        if (OriginalNumber == null || OriginalNumber.Length <= 1)
                            {
                                return false;
                            }

                        return OriginalNumber.Trim().Substring(0, 1) == "0";
                    }


                private void Setup() => _phoneNumberUtil = PhoneNumberUtil.GetInstance();
            }
    }