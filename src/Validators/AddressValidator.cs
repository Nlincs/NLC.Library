//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressValidator.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Validators
    {
        /// <summary>
        ///     Validate address
        /// </summary>
        /// <remarks>determines if address is empty</remarks>
        public class AddressValidator : IAddressValidator
            {
                #region Implementation of IAddressValidator

                /// <inheritdoc />
                public bool ValidAddress(string address)
                    {
                        if (address == null) { return false; }

                        return address.Trim() != "";
                    }

                /// <inheritdoc />
                public bool ValidAddress(string address1, string address2, string address3, string address4,
                    string address5, string address6)
                    {
                        var checkAddress = new AddressLines(address1,
                            address2,
                            address3,
                            address4,
                            address5,
                            address6
                        );
                        return !checkAddress.IsEmptyAddress();
                    }

                #endregion
            }
    }