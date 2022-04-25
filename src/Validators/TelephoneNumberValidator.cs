//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumberValidator.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:17 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        /// <summary>
        ///     Telephone Number Validator
        /// </summary>
        public class TelephoneNumberValidator : ITelephoneNumberValidator
            {
                #region Implementation of ITelephoneNumberValidator

                /// <inheritdoc />
                public bool ValidTelephoneNumber(string telephoneNumber)
                    {
                        var tel = new TelephoneNumber(telephoneNumber);
                        return tel.IsValid;
                    }

                /// <inheritdoc />
                public bool ValidTelephoneNumber(long telephoneNumber)
                    {
                        var tel = new TelephoneNumber(telephoneNumber.ToString());

                        return tel.IsValid;
                    }

                #endregion
            }
    }