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

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     Location
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