//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddress.cs company="North Lincolnshire Council">
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
        ///     Basic address
        /// </summary>
        /// <remarks>
        ///     This is just address lines for simplicity
        ///     For postcode, uprn etc <see cref="IAddressLines" />
        ///     This is the base address that will be in all address object ie everything gets converted to this
        /// </remarks>
        public interface IAddress
            {
                /// <summary>
                /// </summary>
                /// <remarks>
                ///     HouseName,
                ///     Primary Address
                /// </remarks>
                string Address1 { get; set; }

                /// <summary>
                /// </summary>
                /// <remarks>
                ///     HouseNumber,
                ///     Secondary Address
                /// </remarks>
                string Address2 { get; set; }

                /// <summary>
                /// </summary>
                /// <remarks>
                ///     Street
                /// </remarks>
                string Address3 { get; set; }

                /// <summary>
                /// </summary>
                /// <remarks>
                ///     Location
                /// </remarks>
                string Address4 { get; set; }

                /// <summary>
                /// </summary>
                /// <remarks>
                ///     Town
                /// </remarks>
                string Address5 { get; set; }

                /// <summary>
                /// </summary>
                /// <remarks>
                ///     County
                /// </remarks>
                string Address6 { get; set; }

                /// <summary>
                ///     This is part of the address that can be used for sorting
                /// </summary>
                string AddressSortField { get; set; }

                /// <summary>
                ///     Is Empty Address
                /// </summary>
                /// <remarks>checks if the address lines are all empty</remarks>
                bool IsEmptyAddress();

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <remarks>This is the address on a single line</remarks>
                string FullAddress(string line1, string line2, string line3, string line4,
                    string line5, string line6);

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <returns></returns>
                /// <remarks>This is to be overridden, it's here so it's accessible</remarks>
                string FullAddress();

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <remarks>This is the address on a single line</remarks>
                string FullAddress(IAddress address);
            }
    }