//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ILocation.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 07/12/2021 09:27
//  Altered - 25/04/2022 12:16 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Location elements of an address
        /// </summary>
        /// <remarks>Location of property/street section</remarks>
        public interface ILocation : IAddress
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
            }
    }