//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddressNameNumber.cs company="North Lincolnshire Council">
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
        /// </summary>
        public interface IAddressNameNumber : ILocation
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