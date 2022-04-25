//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPersonValidator.cs company="North Lincolnshire Council">
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

using NLC.Library.Interfaces;

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public interface IPersonValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="person"></param>
                /// <returns></returns>
                bool ValidPerson(IPerson person);

                /// <summary>
                /// </summary>
                /// <param name="surname"></param>
                /// <param name="forename"></param>
                /// <returns></returns>
                bool ValidPerson(string surname, string forename);
            }
    }