//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ISimpleAddressNameNumber.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:27 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        /// </summary>
        public interface IAddressNameNumber : IAddressLocation
    {
                /// <summary>
                /// </summary>
                string HouseName { get; set; }

                /// <summary>
                /// </summary>
                string HouseNumber { get; set; }

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