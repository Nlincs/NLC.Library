//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUsrnValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:33 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public interface IUsrnValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(string usrn);


                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(int usrn);


                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(long usrn);
            }
    }