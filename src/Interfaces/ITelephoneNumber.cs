//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ITelephoneNumber.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The TelephoneNumber interface.
        /// </summary>
        public interface ITelephoneNumber
            {
                /// <summary>
                ///     Telephone Number Value
                /// </summary>
                string Value { get; set; }

                /// <summary>
                ///     Country Code
                /// </summary>
                /// <value>string</value>
                /// <returns>The country code for the number</returns>
                /// <remarks>+44 for UK</remarks>
                string CountryCode { get; set; }

                /// <summary>
                ///     Gets or sets the extension number.
                /// </summary>
                string ExtensionNumber { get; set; }

                /// <summary>
                ///     Full National number
                /// </summary>
                /// <value>string</value>
                /// <returns>The full national telephone number</returns>
                /// <remarks>This should be the full national number i.e. with no leading 0</remarks>
                string NationalNumber { get; set; }

                /// <summary>
                ///     Is valid telephone number
                /// </summary>
                bool IsValid { get; }
            }
    }