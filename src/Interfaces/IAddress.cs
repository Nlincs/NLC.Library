//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IAddress.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 09/10/2020 09:59
//  Altered - 09/10/2020 09:59 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Basic address
        /// </summary>
        /// <remarks>
        /// This is just address lines for simplicity
        /// For postcode, uprn etc <see cref="IAddressLines"/>
        /// This is the base address that will be in all address object ie everything gets converted to this</remarks>
        public interface IAddress
            {
                /// <summary>
                /// </summary>
                string Address1 { get; set; }

                /// <summary>
                /// </summary>
                string Address2 { get; set; }

                /// <summary>
                /// </summary>
                string Address3 { get; set; }

                /// <summary>
                /// </summary>
                string Address4 { get; set; }

                /// <summary>
                /// </summary>
                string Address5 { get; set; }

                string Address6 { get; set; }
            }
    }