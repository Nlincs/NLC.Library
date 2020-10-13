//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPerson.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:24 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        /// </summary>
        public interface IPerson
            {
                /// <summary>
                ///     Full formatted name
                /// </summary>
                string FullName { get; }

                /// <summary>
                /// </summary>
                string Title { get; set; }

                /// <summary>
                ///     Given name
                /// </summary>
                /// <remarks>usually forename</remarks>
                string GivenName { get; set; }

                /// <summary>
                ///     Forename
                /// </summary>
                /// <remarks>
                ///     <see cref="GivenName" />
                /// </remarks>
                string Forenames { get; set; }

                /// <summary>
                ///     Surname
                /// </summary>
                /// <remarks>
                ///     <see cref="FamilyName" />
                /// </remarks>
                string Surname { get; set; }

                /// <summary>
                ///     Family Name
                /// </summary>
                /// <remarks>usually surname</remarks>
                string FamilyName { get; set; }

                /// <summary>
                ///     Is Valid person
                /// </summary>
                /// <returns>True if the object contains some data</returns>
                /// <remarks>Must contain firstname or surname as a minimum</remarks>
                bool IsValid();

                /// <summary>
                ///     Has the person requested anonymity
                /// </summary>
                bool IsAnonymous { get; set; }
            }
    }