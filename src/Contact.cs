//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Contact.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 12:25 - Stephen Ellwood
// 
//  Project : - Library
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