//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddressLines.cs company="North Lincolnshire Council">
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
        ///     Address and location
        /// </summary>
        /// <remarks>includes uprn, postcode etc.</remarks>
        public interface IAddressLines : ILocation
            {
                /// <summary>
                /// </summary>
                string AddressLine1 { get; set; }

                /// <summary>
                /// </summary>
                string AddressLine2 { get; set; }

                /// <summary>
                /// </summary>
                string AddressLine3 { get; set; }

                /// <summary>
                /// </summary>
                string AddressLine4 { get; set; }

                /// <summary>
                /// </summary>
                string AddressLine5 { get; set; }

                /// <summary>
                /// </summary>
                string AddressLine6 { get; set; }
            }
    }