//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPostCodeValidator.cs company="North Lincolnshire Council">
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
        /// </summary>
        public interface IPostCodeValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="postCode"></param>
                /// <returns></returns>
                bool ValidPostCode(string postCode);
            }
    }