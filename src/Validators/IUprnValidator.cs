//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUprnValidator.cs company="North Lincolnshire Council">
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