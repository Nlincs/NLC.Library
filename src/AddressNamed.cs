//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNamed.cs company="North Lincolnshire Council">
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
        public sealed class AddressNamed : AddressBase, IAddressNamed
            {
                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="primaryAddress"></param>
                /// <param name="secondaryAddress"></param>
                /// <param name="street"></param>
                /// <param name="location"></param>
                /// <param name="town"></param>
                /// <param name="county"></param>
                public AddressNamed(string primaryAddress, string secondaryAddress, string street, string location, string
                    town, string county):base(primaryAddress, secondaryAddress, street, location, town, county)
                    {
                        Address1 = primaryAddress;
                        Address2 = secondaryAddress;
                        Address3 = street;
                        Address4 = location;
                        Address5 = town;
                        Address6 = county;
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNamed(IAddressLines address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNamed(IAddressNameNumber address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressNamed(IAddressNamed address) : base(address)
                    {
                    }


                /// <inheritdoc />
                public string PrimaryAddress
                {
                    get => Address1;
                    set => Address1 = value;
                }

                /// <inheritdoc />
                public string SecondaryAddress
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