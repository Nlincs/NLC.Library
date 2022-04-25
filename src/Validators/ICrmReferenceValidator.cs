//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ICrmReferenceValidator.cs company="North Lincolnshire Council">
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
        public interface ICrmReferenceValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="crmReference"></param>
                /// <returns></returns>
                bool ValidCrmReference(string crmReference);
            }
    }