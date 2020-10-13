//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ISimpleAddress.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:25 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Address with named fields
        /// </summary>
        public interface IAddressNamed : IAddressLocation
    {
                /// <summary>
                /// </summary>
                string PrimaryAddress { get; set; }

                /// <summary>
                /// </summary>
                string SecondaryAddress { get; set; }

                /// <summary>
                /// </summary>
                string Street { get; set; }

                /// <summary>
                /// </summary>
                string Location { get; set; }

                /// <summary>
                /// </summary>
                string Town { get; set; }

                /// <summary>
                /// </summary>
                string County { get; set; }
            }
    }