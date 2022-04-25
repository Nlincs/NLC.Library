//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Contact.cs company="North Lincolnshire Council">
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
        ///     Contact
        /// </summary>
        /// <remarks>
        ///     Includes full address details
        /// </remarks>
        public class Contact : IContact
            {
                /// <summary>
                ///     Constructor
                /// </summary>
                public Contact()
                    {
                    }

                /// <summary>
                ///     Constructor
                /// </summary>
                /// <param name="address"></param>
                public Contact(IFullAddress address) => Address = address;

                #region Implementation of IFullContact

                /// <inheritdoc />
                public IPerson Person { get; set; }

                /// <inheritdoc />
                public IFullAddress Address { get; set; }

                /// <inheritdoc />
                public bool IsAnonymous { get; set; }

                /// <inheritdoc />
                public TelephoneNumber PreferredPhone { get; set; }

                /// <inheritdoc />
                public TelephoneNumber HomePhone { get; set; }

                /// <inheritdoc />
                public TelephoneNumber MobilePhone { get; set; }

                /// <inheritdoc />
                public TelephoneNumber WorkPhone { get; set; }

                /// <inheritdoc />
                public string EmailAddress { get; set; }

                /// <inheritdoc />
                public string Notes { get; set; }

                #endregion
            }
    }