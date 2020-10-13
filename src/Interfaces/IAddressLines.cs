//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ISimpleAddressLine.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:26 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Address and location
        /// </summary>
        /// <remarks>includes uprn, postcode etc.</remarks>
        public interface IAddressLines : IAddressLocation
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

                string AddressLine6 { get; set; }
    }
    }