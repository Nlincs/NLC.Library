//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNameNumber.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:15 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        /// </summary>
        public sealed class AddressNameNumber : AddressBase, IAddressNameNumber
            {
                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="houseName"></param>
                /// <param name="HouseNumber"></param>
                /// <param name="Street"></param>
                /// <param name="Location"></param>
                /// <param name="Town"></param>
                /// <param name="County"></param>
                public AddressNameNumber(string houseName, string HouseNumber, string Street, string Location,
                    string Town, string County):base(houseName, HouseNumber, Street, Location, Town, County)
                    {
                        Address1 = houseName;
                        Address2 = HouseNumber;
                        Address3 = Street;
                        Address4 = Location;
                        Address5 = Town;
                        Address6 = County;
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNameNumber(IAddressLines address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNameNumber(IAddressNameNumber address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNameNumber(IAddressNamed address) : base(address)
                    {
                    }


                /// <inheritdoc />
                public string HouseName
                {
                    get => Address1;
                    set => Address1 = value;
                }

                /// <inheritdoc />
                public string HouseNumber
                {
                    get => Address2;
                    set => Address2 = value;
                }

                /// <inheritdoc />
                public string Street
                {
                    get => Address3;
                    set => Address3 = value;
                }

                /// <inheritdoc />
                public string Location
                {
                    get => Address4;
                    set => Address4 = value;
                }

                /// <inheritdoc />
                public string Town
                {
                    get => Address5;
                    set => Address5 = value;
                }

                /// <inheritdoc />
                public string County
                {
                    get => Address6;
                    set => Address6 = value;
                }
            }
    }