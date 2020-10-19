//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IContact.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:25
//  Altered - 12/10/2020 14:29 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Full Contact
        /// </summary>
        public interface IContact
            {
                /// <summary>
                ///     Person
                /// </summary>
                IPerson Person { get; set; }

                /// <summary>
                ///     Address detail, this includes things like uprn, usrn, full address etc
                /// </summary>
                Library.IFullAddress Address { get; set; }

                /// <summary>
                ///     Has the contact requested anonymity
                /// </summary>
                bool IsAnonymous { get; set; }

                /// <summary>
                ///     Preferred phone number
                /// </summary>
                TelephoneNumber PreferredPhone { get; set; }

                /// <summary>
                ///     Home phone
                /// </summary>
                TelephoneNumber HomePhone { get; set; }

                /// <summary>
                ///     Mobile phone
                /// </summary>
                TelephoneNumber MobilePhone { get; set; }

                /// <summary>
                ///     Work phone
                /// </summary>
                TelephoneNumber WorkPhone { get; set; }

                /// <summary>
                ///     email address
                /// </summary>
                string EmailAddress { get; set; }

                /// <summary>
                ///     Notes
                /// </summary>
                string Notes { get; set; }
            }
    }