//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ILocation.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 09/10/2020 10:08 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Location
        /// </summary>
        /// <remarks>Location of property/street section</remarks>
        public interface ILocation : IEquatable<ILocation>
            {
                /// <summary>
                /// </summary>
                IUprn Uprn { get; set; }

                /// <summary>
                /// </summary>
                IUsrn Usrn { get; set; }

                /// <summary>
                /// </summary>
                IPostCode PostCode { get; set; }

                /// <summary>
                /// </summary>
                double? Easting { get; set; }

                /// <summary>
                /// </summary>
                double? Northing { get; set; }

                /// <summary>
                ///     This is part of the address that can be used for sorting
                /// </summary>
                string AddressSortField { get; set; }

                /// <summary>
                ///     Is Empty Address
                /// </summary>
                /// <remarks>checks if the address lines are all empty</remarks>
                bool IsEmptyAddress();

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <remarks>This is the address on a single line</remarks>
                string FullAddress(string line1, string line2, string line3, string line4,
                    string line5, string line6);

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <returns></returns>
                /// <remarks>This is to be overridden, it's here so it's accessible</remarks>
                string FullAddress();

                /// <summary>
                ///     Formatted Address
                /// </summary>
                /// <remarks>This is the address on a single line</remarks>
                string FullAddress(IAddress address);
            }
    }