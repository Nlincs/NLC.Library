//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=DirectorySize.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Enums
    {
        /// <summary>
        ///     The scale to use for the size of the file
        /// </summary>
        /// <remarks>Variants of bytes</remarks>
        public enum DirectorySize
            {
                /// <summary>
                ///     The bytes.
                /// </summary>
                Bytes,

                /// <summary>
                ///     The kilobytes.
                /// </summary>
                Kilobytes,

                /// <summary>
                ///     The megabytes.
                /// </summary>
                Megabytes,

                /// <summary>
                ///     The gigabytes.
                /// </summary>
                Gigabytes
            }
    }