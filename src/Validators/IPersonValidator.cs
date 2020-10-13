//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPersonValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:30 - Stephen Ellwood
// 
//  Project : - Library
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