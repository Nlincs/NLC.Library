//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ICRMReference.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The CRMReference interface.
        /// </summary>
        public interface ICrmReference
            {
                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                string Value { get; set; }

                /// <summary>
                ///     The is valid.
                /// </summary>
                /// <returns>
                ///     The <see cref="bool" />.
                /// </returns>
                bool IsValid();
            }
    }