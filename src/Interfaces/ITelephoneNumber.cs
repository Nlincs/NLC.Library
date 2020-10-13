//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ITelephoneNumber.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 13:57 - Stephen Ellwood
// 
//  Project : - Library
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
                bool IsValid { get;  }
            }
    }