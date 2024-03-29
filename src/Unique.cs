//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Unique.cs company="North Lincolnshire Council">
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

using System.Security.Cryptography;
using System.Text;

namespace NLC.Library
    {
        /// <summary> Generate a pseudo unique value </summary>
        /// <returns>a string containing a semi unique value up to the maximum characters specified</returns>
        /// <remarks>The string returned is optionally case sensitive ie A123 is considered different to a123</remarks>
        public static class Unique
            {
                // Set an initial length of 20 characters for a pseudo unique reference, and set case sensitivity to false as this isn't required

                /// <summary>
                ///     Gets the value.
                /// </summary>
                /// <param name="length">The length.</param>
                /// <param name="caseSensitive">if set to <c>true</c> [case sensitive].</param>
                /// <returns></returns>
                public static string GetValue(int length,
                    bool caseSensitive)
                    {
                        // now lets declare a new array and variable to hold all required characters

                        var a = caseSensitive
                            ? @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
                            : "abcdefghijklmnopqrstuvwxyz1234567890";

                        var chars = a.ToCharArray();
                        var size = length;
                        var data = new byte[1];

                        using (var crypto = new RNGCryptoServiceProvider())
                            {
                                crypto.GetNonZeroBytes(data);
                                data = new byte[size];
                                crypto.GetNonZeroBytes(data);
                                var result = new StringBuilder(size);

                                foreach (var b in data)
                                    {
                                        result.Append(chars[b % (chars.Length - 1)]);
                                    }

                                return result.ToString();
                            }
                    }

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public static string GetValue() => GetValue(20, false);

                /// <summary>
                /// </summary>
                /// <param name="length"></param>
                ///     <returns></returns>
                public static string GetValue(int length) => GetValue(length, false);

                /// <summary>
                /// </summary>
                /// <param name="caseSensitive"></param>
                /// <returns></returns>
                public static string GetValue(bool caseSensitive) => GetValue(20, caseSensitive);
            }
    }