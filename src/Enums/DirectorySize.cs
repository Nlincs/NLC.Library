//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=DirectorySize.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 11:31 - Stephen Ellwood
// 
//  Project : - Library
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