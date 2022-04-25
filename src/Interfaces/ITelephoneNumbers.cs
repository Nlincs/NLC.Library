//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ITelephoneNumbers.cs company="North Lincolnshire Council">
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

using System.Collections.Generic;

namespace NLC.Library.Interfaces
    {
        /// <summary>
        ///     The TelephoneNumbers interface.
        /// </summary>
        public interface ITelephoneNumbers
            {
                /// <summary>
                ///     Default item
                /// </summary>
                /// <param name="index">The index of the item to return</param>
                /// <value>n/a</value>
                /// <returns>The TelephoneNumber if one exists</returns>
                /// <remarks>Returns the ith item from the base list</remarks>
                ITelephoneNumber this[int index] { get; }

                /// <summary>
                ///     Adds an item to the collection
                /// </summary>
                /// <param name="item">The item to be added</param>
                /// <remarks>Adds an item to the base class list object</remarks>
                void Add(ITelephoneNumber item);

                /// <summary>
                ///     Preferred numbers list
                /// </summary>
                /// <returns>list (of TelephoneNumber) <see cref="TelephoneNumber"></see></returns>
                /// <remarks>returns a list of all the preferred numbers</remarks>
                List<ITelephoneNumber> PreferredNumbers();

                /// <summary>
                ///     Removes an item from the collection
                /// </summary>
                /// <param name="index">The index of the item to be removed</param>
                /// <remarks>Removes an item from the base class list object</remarks>
                void Remove(int index);

                /// <summary>
                ///     Collections as a list
                /// </summary>
                /// <returns>a list of the collection objects</returns>
                /// <remarks>Used for sorting</remarks>
                List<ITelephoneNumber> All();
            }
    }