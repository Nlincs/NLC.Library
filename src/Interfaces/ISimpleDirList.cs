//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ISimpleDirList.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:35
//  Altered - 14/10/2020 11:11 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using NLC.Library.Enums;

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The SimpleDirList interface.
        /// </summary>
        public interface ISimpleDirList
            {
                /// <summary>
                ///     File filter to search for
                /// </summary>
                /// <value>string</value>
                /// <returns>String holding the file filter to search for</returns>
                /// <remarks>e.g. *.* the default value will search for all files. Multiple filters are not catered for</remarks>
                string FileFilter { get; set; }

                /// <summary>
                ///     Show full file name
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if we want the full filename in the results, false if we want the short name</returns>
                /// <remarks>
                ///     The full file name includes the path as part of the file name, the short file name is just the name of the file
                ///     without the path information
                /// </remarks>
                bool FullFileName { get; set; }

                /// <summary>
                ///     Include Subdirectories in the list
                /// </summary>
                /// <value>System.IO.SearchOption <see cref="System.IO.SearchOption"></see></value>
                /// <returns>TopDirectoryOnly to only search a single directory, AllDirectories to search the root and all subdirectories </returns>
                /// <remarks></remarks>
                SearchOption IncludeSubdirectories { get; set; }

                /// <summary>
                ///     Show details
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if we want the headers and footers included in the results, false otherwise</returns>
                /// <remarks>Turning these off can be useful for automated processing</remarks>
                bool ShowDetails { get; set; }

                /// <summary>
                ///     Show the file size
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if we want the size of the file in the results, false otherwise</returns>
                /// <remarks></remarks>
                bool ShowFileSize { get; set; }

                /// <summary>
                ///     Show timestamp
                /// </summary>
                /// <value>Boolean</value>
                /// <returns>True if we want the file created date in the results, false otherwise</returns>
                /// <remarks></remarks>
                bool ShowTimeStamp { get; set; }

                /// <summary>
                ///     Calculate size of a file
                /// </summary>
                /// <param name="file">The file that we want the size of as a Fileinfo object<see cref="FileInfo"></see></param>
                /// <returns>String containing the size of the file</returns>
                /// <remarks>
                ///     The conversion to kilobytes etc uses the factor 1024, in some cases this can generate a number in scientific format
                ///     e.g.
                ///     10.123E2 Gb
                /// </remarks>
                string FileSize(FileInfo file);

                /// <summary>
                ///     Calculate size of a file
                /// </summary>
                /// <param name="file">The file that we want the size of as a Fileinfo object<see cref="FileInfo"></see></param>
                /// <param name="scale">
                ///     Optional Scale indicating the scale that you want the result as
                /// </param>
                /// <returns>String containing the size of the file</returns>
                /// <remarks>
                ///     The conversion to kilobytes etc uses the factor 1024, in some cases this can generate a number in scientific format
                ///     e.g.
                ///     10.123E2 Gb
                /// </remarks>
                string FileSize(FileInfo file,
                    DirectorySize scale);

                /// <summary>
                ///     Calculate size of a file
                /// </summary>
                /// <param name="path">The path of file that we want the size of<see cref="FileInfo"></see></param>
                /// <returns>String containing the size of the file</returns>
                /// <remarks>
                ///     The conversion to kilobytes etc uses the factor 1024, in some cases this can generate a number in scientific format
                ///     e.g.
                ///     10.123E2 Gb
                /// </remarks>
                string FileSize(string path);

                /// <summary>
                ///     Calculate size of a file
                /// </summary>
                /// <param name="path">The path of file that we want the size of<see cref="FileInfo"></see></param>
                /// <param name="scale">
                ///     Optional Scale indicating the scale that you want the result as
                /// </param>
                /// <returns>String containing the size of the file</returns>
                /// <remarks>
                ///     The conversion to kilobytes etc uses the factor 1024, in some cases this can generate a number in scientific format
                ///     e.g.
                ///     10.123E2 Gb
                /// </remarks>
                string FileSize(string path,
                    DirectorySize scale);

                /// <summary>
                ///     List the files
                /// </summary>
                /// <param name="directoryPath">The path of the root directory to produce a listing of</param>
                /// <returns>List (of string), an invalid path returns a list of string with one entry - Invalid Path</returns>
                /// <remarks>
                ///     This is the routine that searches the directory/directories and produces a list where each item in the list
                ///     holds the required information on a file according to the properties set in this class, optionally there may also
                ///     be header
                ///     and footer information in the list
                /// </remarks>
                /// >
                List<string> ListFiles(string directoryPath);

                /// <summary>
                ///     List the files
                /// </summary>
                /// <param name="path">The path of the root directory to produce a listing of</param>
                /// <returns>List (of string), an invalid path returns a list of string with one entry - Invalid Path</returns>
                /// <remarks>
                ///     This is the routine that searches the directory/directories and produces a list where each item in the list
                ///     holds the required information on a file according to the properties set in this class, optionally there may also
                ///     be header
                ///     and footer information in the list
                /// </remarks>
                List<string> ListFiles(DirectoryInfo path);
            }
    }