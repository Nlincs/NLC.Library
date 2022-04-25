//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IFullAddress.cs company="North Lincolnshire Council">
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

using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Addressable Location
        /// </summary>
        public interface IFullAddress : IAddressLocation
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

                /// <summary>
                /// </summary>
                string HouseName { get; set; }

                /// <summary>
                /// </summary>
                string HouseNumber { get; set; }

                /// <summary>
                /// </summary>
                /// <returns></returns>
                AddressLines AddressLines();

                /// <summary>
                /// </summary>
                /// <returns></returns>
                AddressNamed AddressNamed();

                /// <summary>
                /// </summary>
                /// <returns></returns>
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