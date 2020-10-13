//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUSRN.cs company="North Lincolnshire Council">
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
        ///     The USRN interface.
        /// </summary>
        public interface IUsrn : IEquatable<IUsrn>
            {
                /// <summary>
                ///     Value of the USRN
                /// </summary>
                /// <value>Long</value>
                /// <returns>If the USRN has a value that is returned, otherwise returns an arbitrary value</returns>
                /// <remarks>
                ///     <seealso cref="Usrn.UsrnValue"></seealso>
                /// </remarks>
                long Value { get; set; }

                /// <summary>
                ///     Determines whether this instance is default.
                /// </summary>
                /// <returns>True if the same as the default value, false otherwise</returns>
                bool IsDefault();

                /// <summary>
                ///     IsValid
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if the UPRN has a value, false otherwise</returns>
                /// <remarks>
                ///     <seealso cref="Usrn.UsrnValue"></seealso>
                /// </remarks>
                bool IsValid();
            }
    }