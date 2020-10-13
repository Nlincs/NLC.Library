//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=CrmReferenceValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:29 - Stephen Ellwood
// 
//  Project : - Library
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