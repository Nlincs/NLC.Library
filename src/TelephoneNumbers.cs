//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumbers.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 11:33
//  Altered - 12/10/2020 14:03 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        /// </summary>
        public class TelephoneNumbers : CollectionBase,
            ITelephoneNumbers
            {
                // This line declares the Item property as default and ReadOnly and 
                // declares that it will return a particular object.
                // because it is default we can use syntax like MyObject(0) to refer to MyObject.item(0)
                // http://msdn2.microsoft.com/en-us/library/2b6akew6(VS.71).aspx

                /// <summary>
                ///     Default item
                /// </summary>
                /// <param name="index">The index of the item to return</param>
                /// <value>n/a</value>
                /// <returns>The TelephoneNumber if one exists</returns>
                /// <remarks>Returns the ith item from the base list</remarks>
                public ITelephoneNumber this[int index] => (TelephoneNumber)List[index];

                // class to describe a collection of objects
                // http://msdn2.microsoft.com/en-us/library/xth2y6ft(VS.71).aspx
                /// <summary>
                ///     Adds an item to the collection
                /// </summary>
                /// <param name="item">The item to be added</param>
                /// <remarks>Adds an item to the base class list object</remarks>
                public void Add(ITelephoneNumber item)
                    {
                        // Invokes Add method of the List object 
                        if (item == null)
                            {
                                return;
                            }

                        List.Add(item);
                    }

                /// <summary>
                ///     Preferred numbers list
                /// </summary>
                /// <returns>list (of TelephoneNumber) <see cref="TelephoneNumber"></see></returns>
                /// <remarks>returns a list of all the preferred numbers</remarks>
                public List<ITelephoneNumber> PreferredNumbers() =>
                    // produce list using a predicate
                    // t.preferred implies t.preferred == true
                    throw new NotImplementedException();

                /// <summary>
                ///     Removes an item from the collection
                /// </summary>
                /// <param name="index">The index of the item to be removed</param>
                /// <remarks>Removes an item from the base class list object</remarks>
                /// <exception cref="IndexOutOfRangeException">Index out of allowed range</exception>
                public void Remove(int index)
                    {
                        // Check to see if there is an object at the supplied index.
                        if (index > Count - 1 || index < 0)
                            {
                                return;
                            }

                        // Invokes the RemoveAt method of the List object.
                        List.RemoveAt(index);
                    }

                /// <summary>
                ///     Collections as a list
                /// </summary>
                /// <returns>a list of the collection objects</returns>
                /// <remarks>Used for sorting</remarks>
                public List<ITelephoneNumber> All()
                    {
                        var result = new List<ITelephoneNumber>();

                        foreach (TelephoneNumber b in List)
                            {
                                result.Add(b);
                            }

                        return result;
                    }
            }
    }