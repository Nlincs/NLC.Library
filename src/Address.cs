//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Address.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/12/2020 16:06
//  Altered - 17/12/2020 16:14 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Full Address
        /// </summary>
        /// <remarks>
        ///     Location, including all address fields
        ///     intended to be used as a less structured format for addressable locations
        /// </remarks>
        public class Address : AddressBase, IFullAddress
            {
                public Address()
                    {
                        var defaultAddress = "";
                        Address1 = defaultAddress;
                        Address2 = defaultAddress;
                        Address3 = defaultAddress;
                        Address4 = defaultAddress;
                        Address5 = defaultAddress;
                        Address6 = defaultAddress;
                    }

                public Address(string address1, string address2, string address3, string address4, string address5,
                    string address6) : base(address1, address2, address3, address4, address5, address6)
                    {
                        Address1 = address1;
                        Address2 = address2;
                        Address3 = address3;
                        Address4 = address4;
                        Address5 = address5;
                        Address6 = address6;
                    }

                public Address(IAddressLines address) : base(address)
                    {
                    }

                public Address(IAddressNameNumber address) : base(address)
                    {
                    }

                public Address(IAddressNamed address) : base(address)
                    {
                    }

                /// <inheritdoc />
                public string AddressLine1
                {
                    get => Address1;
                    set => Address1 = value;
                }

                /// <inheritdoc />
                public string AddressLine2
                {
                    get => Address2;
                    set => Address2 = value;
                }


                /// <inheritdoc />
                public string AddressLine3
                {
                    get => Address3;
                    set => Address3 = value;
                }

                /// <inheritdoc />
                public string AddressLine4
                {
                    get => Address4;
                    set => Address4 = value;
                }

                /// <inheritdoc />
                public string AddressLine5
                {
                    get => Address5;
                    set => Address5 = value;
                }

                /// <inheritdoc />
                public string AddressLine6
                {
                    get => Address6;
                    set => Address6 = value;
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

                public string Street
                {
                    get => Address3;
                    set => Address3 = value;
                }

                public string Location
                {
                    get => Address4;
                    set => Address4 = value;
                }

                public string Town
                {
                    get => Address5;
                    set => Address5 = value;
                }

                public string County
                {
                    get => Address6;
                    set => Address6 = value;
                }

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


                public AddressLines AddressLines() =>
                    new AddressLines(
                        AddressLine1 = Address1,
                        AddressLine2 = Address2,
                        AddressLine3 = Address3,
                        AddressLine4 = Address4,
                        AddressLine5 = Address5,
                        AddressLine6 = Address6);

                public AddressNamed AddressNamed() =>
                    new AddressNamed(
                        PrimaryAddress = Address1,
                        SecondaryAddress = Address2,
                        Street = Address3,
                        Location = Address4,
                        Town = Address5,
                        County = Address6
                    );

                public AddressNameNumber AddressNameNumber() =>
                    new AddressNameNumber(
                        HouseName = Address1,
                        HouseNumber = Address2,
                        Street = Address3,
                        Location = Address4,
                        Town = Address5,
                        County = Address6
                    );
            }
    }