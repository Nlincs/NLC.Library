//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressLines.cs company="North Lincolnshire Council">
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
        public class AddressLines : AddressBase, IAddressLines
            {
                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address1"></param>
                /// <param name="address2"></param>
                /// <param name="address3"></param>
                /// <param name="address4"></param>
                /// <param name="address5"></param>
                /// <param name="address6"></param>
                public AddressLines(string address1, string address2, string address3, string address4, string address5,
                    string address6) : base(address1, address2, address3, address4, address5, address6)
                    {
                        Address1 = address1;
                        Address2 = address2;
                        Address3 = address3;
                        Address4 = address4;
                        Address5 = address5;
                        Address6 = address6;
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressLines(IAddressLines address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressLines(IAddressNameNumber address) : base(address)
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public AddressLines(IAddressNamed address) : base(address)
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
            }
    }