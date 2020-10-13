//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNameNumber.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:36
//  Altered - 16/10/2020 12:07 - Stephen Ellwood
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
                public AddressNameNumber()
                    {
                    }

                public AddressNameNumber(IAddressLines address) : base(address)
                    {
                    }

                public AddressNameNumber(IAddressNameNumber address) : base(address)
                    {
                    }

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