//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUPRN.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 12/06/2020 15:28
//  Altered - 12/06/2020 15:28 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The UPRN interface.
        /// </summary>
        public interface IUprn 
            {
                /// <summary>
                ///     Numeric value of the UPRN
                /// </summary>
                /// <value>long</value>
                /// <returns>If the UPRN has a numeric value then that is returned, otherwise returns an arbitrary value</returns>
                /// <remarks></remarks>
                long Value { get; set; }

                /// <summary>
                ///     Determines whether this instance is default.
                /// </summary>
                /// <returns>True if the same as the default value, false otherwise</returns>
                bool IsDefault();

                /// <summary>
                ///     Is Street
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if the uprn is a street record, false otherwise</returns>
                /// <remarks>This may only apply in NLC</remarks>
                bool IsStreet();
        
                /// <summary>
                ///     IsValid
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if the UPRN has a value, false otherwise</returns>
                /// <remarks>
                ///     <seealso cref="Uprn.UprnValue"></seealso>
                /// </remarks>
                bool IsValid();
            }
    }