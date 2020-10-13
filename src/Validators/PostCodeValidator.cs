//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=PostCodeValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:35 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public class PostCodeValidator : IPostCodeValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="postCode"></param>
                /// <returns></returns>
                public bool ValidPostCode(string postCode)
                    {
                        var postCde = new PostCode(postCode);
                        return postCde.IsUkValid();
                    }
            }
    }