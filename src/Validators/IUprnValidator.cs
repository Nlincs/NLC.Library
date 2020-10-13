//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUprnValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:32 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public interface IUprnValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="uprn"></param>
                /// <returns></returns>
                bool ValidUprn(string uprn);


                /// <summary>
                /// </summary>
                /// <param name="uprn"></param>
                /// <returns></returns>
                bool ValidUprn(int uprn);


                /// <summary>
                /// </summary>
                /// <param name="uprn"></param>
                /// <returns></returns>
                bool ValidUprn(long uprn);
            }
    }