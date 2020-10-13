//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ITelephoneNumberValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 12/10/2020 15:14
//  Altered - 12/10/2020 15:14 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        public interface ITelephoneNumberValidator
            {
                bool ValidTelephoneNumber(string telephoneNumber);

                bool ValidTelephoneNumber(long telephoneNumber);
            }
    }