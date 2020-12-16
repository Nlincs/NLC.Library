//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Contact.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 19/10/2020 15:10
//  Altered - 16/12/2020 15:09 - Stephen Ellwood
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
                public Contact()
                    {
                    }

                public Contact(IFullAddress address) => Address = address;

                #region Implementation of IFullContact

                /// <inheritdoc />
                public IPerson Person { get; set; }

                /// <inheritdoc />
                public IFullAddress Address { get; set; }

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