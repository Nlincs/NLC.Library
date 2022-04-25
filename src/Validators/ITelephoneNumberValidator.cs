//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ITelephoneNumberValidator.cs company="North Lincolnshire Council">
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
        ///     TelephoneNumber Validator Interface
        /// </summary>
        public interface ITelephoneNumberValidator
            {
                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="telephoneNumber"></param>
                /// <returns></returns>
                bool ValidTelephoneNumber(string telephoneNumber);

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="telephoneNumber"></param>
                /// <returns></returns>
                bool ValidTelephoneNumber(long telephoneNumber);
            }
    }