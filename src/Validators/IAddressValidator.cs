//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddressValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 09/10/2020 11:02
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