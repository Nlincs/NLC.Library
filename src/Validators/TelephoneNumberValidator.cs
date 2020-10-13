//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumberValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 12/10/2020 15:16
//  Altered - 12/10/2020 15:16 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
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