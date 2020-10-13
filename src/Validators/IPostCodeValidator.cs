//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPostCodeValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 09/10/2020 11:02 - Stephen Ellwood
// 
//  Project : - Library
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