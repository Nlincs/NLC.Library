//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=CrmReferenceValidator.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public class CrmReferenceValidator : ICrmReferenceValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="CRMReference"></param>
                /// <returns></returns>
                public bool ValidCrmReference(string CRMReference)
                    {
                        var crmReference = new CrmReference();
                        return crmReference.IsValid();
                    }
            }
    }