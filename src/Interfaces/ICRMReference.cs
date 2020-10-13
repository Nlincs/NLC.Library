//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ICRMReference.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 13:01 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The CRMReference interface.
        /// </summary>
        public interface ICrmReference : IEquatable<ICrmReference>
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