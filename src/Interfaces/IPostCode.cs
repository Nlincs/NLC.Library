//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IPostCode.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The PostCode interface.
        /// </summary>
        public interface IPostCode
            {
                /// <summary>
                ///     Gets or sets the area.
                /// </summary>
                /// <value>
                ///     The area element of the post code is the leading letters
                ///     eg for DN16 1AB it is DN
                /// </value>
                string Area { get; set; }

                /// <summary>
                ///     Gets or sets the district.
                /// </summary>
                /// <value>
                ///     The district element of the post code is the same as the outward
                ///     element ie the first half of the postcode eg for DN16 1AB it is
                ///     DN16 <see cref="Outward" />
                /// </value>
                string District { get; set; }

                /// <summary>
                ///     Gets or sets the inward element
                /// </summary>
                /// <value>
                ///     The inward element is the second half of the postcode
                ///     eg for DN16 1AB it would be 1AB
                /// </value>
                string Inward { get; set; }

                /// <summary>
                ///     Gets or sets the outward element
                /// </summary>
                /// <value>
                ///     The outward element is the first half of the postcode
                ///     eg for DN16 1AB it would be DN16
                /// </value>
                string Outward { get; set; }

                /// <summary>
                ///     Gets or sets the sector.
                /// </summary>
                /// <value>
                ///     The sector element of the post code is the outward element
                ///     plus the numeric part of the inward element
                ///     eg for DN16 1AB it will be DN16 1
                /// </value>
                string Sector { get; set; }

                /// <summary>
                ///     Is the post code unknown
                /// </summary>
                /// <value>
                ///     Flag to indicate if the post code is an unknown one or not
                /// </value>
                bool Unknown { get; set; }

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                /// <value>
                ///     The actual post code value supplied
                /// </value>
                string Value { get; set; }

                /// <summary>
                ///     Gets or sets a value indicating whether this instance is active.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
                /// </value>
                bool? IsActive();

                /// <summary>
                ///     Is the post code anonymous
                /// </summary>
                /// <value>
                ///     True if the post code is known to be anonymous
                ///     false if not
                ///     nothing if unknown
                /// </value>
                bool? IsAnonymous();

                /// <summary>
                ///     Gets or sets a value indicating whether this instance is dummy.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is dummy; otherwise, <c>false</c>.
                /// </value>
                bool? IsDummy();

                /// <summary>
                ///     Is Post code in northlincs.
                /// </summary>
                /// <value>
                ///     True if the post code is in Northlincs, false if not, nothing if unknown
                /// </value>
                bool? IsNorthlincs();

                /// <summary>
                ///     Is the post code a northlincs anonymous one.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is northlincs anonymous; <c>false</c> otherwise,.
                /// </value>
                bool IsNorthlincsAnonymous();

                /// <summary>
                ///     Gets a value indicating whether this instance is uk valid.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is uk valid; <c>false</c> otherwise.
                /// </value>
                bool IsUkValid();

                /// <summary>
                ///     Gets the mosaic post code.
                /// </summary>
                /// <value>
                ///     The mosaic format post code.
                /// </value>
                string MosaicPostCode();

                // Extra functionallity added SE Sept 2015

                /// <summary>
                ///     Gets the padded post code.
                /// </summary>
                /// <value>
                ///     The padded post code is the post code with spaces added so that the
                ///     whole post code is 8 characters wide. The spaces will always be between the
                ///     two elements of the code eg 'DN1 2AB' becomes 'DN1  2AB' (ie two spaces)
                /// </value>
                string PaddedPostCode();

                /// <summary>
                ///     Short postcode
                /// </summary>
                /// <returns>Postcode without spaces</returns>
                string ShortPostCode();
            }
    }