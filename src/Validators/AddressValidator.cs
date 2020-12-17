//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 09/10/2020 11:11
//  Altered - 09/10/2020 11:11 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Validators
    {
        /// <summary>
        ///     Validate address
        /// </summary>
        /// <remarks>determines if address is empty</remarks>
        public class AddressValidator: IAddressValidator
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