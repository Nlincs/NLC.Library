//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddressValidator.cs company="North Lincolnshire Council">
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
        public interface IAddressValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="address"></param>
                /// <returns></returns>
                bool ValidAddress(string address);

                /// <summary>
                /// </summary>
                /// <param name="address1"></param>
                /// <param name="address2"></param>
                /// <param name="address3"></param>
                /// <param name="address4"></param>
                /// <param name="address5"></param>
                /// <param name="address6"></param>
                /// <returns></returns>
                bool ValidAddress(string address1, string address2, string address3, string address4, string address5,
                    string address6);
            }
    }