//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNamed.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:36
//  Altered - 16/10/2020 14:43 - Stephen Ellwood
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
        public AddressNamed(string PrimaryAddress, string SecondaryAddress, string Street, string Location, string Town, string County):base(PrimaryAddress, SecondaryAddress, Street, Location, Town, County)
            {
                Address1 = PrimaryAddress;
                Address2 = SecondaryAddress;
                Address3 = Street;
                Address4 = Location;
                Address5 = Town;
                Address6 = County;
            }

        public AddressNamed(IAddressLines address) : base(address)
                    {
                    }

                public AddressNamed(IAddressNameNumber address) : base(address)
                    {
                    }

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