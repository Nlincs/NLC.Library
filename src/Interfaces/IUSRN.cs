//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUSRN.cs company="North Lincolnshire Council">
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
        ///     The USRN interface.
        /// </summary>
        public interface IUsrn
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