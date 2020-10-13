//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ICrmReferenceValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 12:58
//  Altered - 06/07/2020 13:02 - Stephen Ellwood
// 
//  Project : - Library
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