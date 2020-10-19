//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IFullAddress.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 19/10/2020 14:51
//  Altered - 19/10/2020 14:52 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Addressable Location
        /// </summary>
        public interface IFullAddress : IAddressLocation
            {
                string AddressLine1 { get; set; }

                string AddressLine2 { get; set; }

                string AddressLine3 { get; set; }

                string AddressLine4 { get; set; }

                string AddressLine5 { get; set; }

                string AddressLine6 { get; set; }

                string PrimaryAddress { get; set; }

                string SecondaryAddress { get; set; }

                string Street { get; set; }

                string Location { get; set; }

                string Town { get; set; }

                string County { get; set; }

                string HouseName { get; set; }

                string HouseNumber { get; set; }


                AddressLines AddressLines();

                AddressNamed AddressNamed();

                AddressNameNumber AddressNameNumber();

                /// <summary>
                ///     Simplify address
                /// </summary>
                /// <remarks>
                ///     removes empty lines in address
                /// </remarks>
                void Simplify();
            }
    }