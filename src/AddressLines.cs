//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressLines.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:36
//  Altered - 16/10/2020 12:09 - Stephen Ellwood
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
                public AddressLines()
                    {
                    }

                public AddressLines(IAddressLines address) : base(address)
                    {
                    }

                public AddressLines(IAddressNameNumber address) : base(address)
                    {
                    }

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