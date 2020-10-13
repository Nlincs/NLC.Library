//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=EnumerableExtension.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:35
//  Altered - 14/10/2020 11:39 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace NLC.Library.Extensions
    {
        /// <summary>
        ///     Enumerable extensions
        ///     Code stolen from http://stackoverflow.com/questions/2019417/access-random-item-in-list
        /// </summary>
        public static class EnumerableExtension
            {
                /// <summary>
                ///     Pick random item
                /// </summary>
                /// <typeparam name="T">type of IEnumerable</typeparam>
                /// <param name="source">The object to choose the item from</param>
                /// <returns>a random item from the list</returns>
                /// <remarks>taken from http://stackoverflow.com/questions/2019417/access-random-item-in-list</remarks>
                public static T PickRandom<T>(this IEnumerable<T> source) => source.PickRandom(1).Single();

                /// <summary>
                ///     Pick N random items
                /// </summary>
                /// <typeparam name="T">Type of item</typeparam>
                /// <param name="source">Collection of objects</param>
                /// <param name="count">Numbner of items to return</param>
                /// <returns></returns>
                public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source,
                    int count) =>
                    source.Shuffle().Take(count);

                /// <summary>
                ///     Shuffle items randomly
                /// </summary>
                /// <typeparam name="T">type of item</typeparam>
                /// <param name="source">Collection of items</param>
                /// <returns>randomly ordered list of items</returns>
                public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) =>
                    source.OrderBy(x => Guid.NewGuid());


                /// <summary>
                ///     Split a list into pages
                /// </summary>
                /// <typeparam name="T">The type of the list</typeparam>
                /// <param name="input">The data to split</param>
                /// <param name="pageSize">The size of the pages</param>
                /// <returns>Enumerable of pages</returns>
                /// <remarks>https://stackoverflow.com/questions/11463734/split-a-list-into-smaller-lists-of-n-size</remarks>
                public static IEnumerable<List<T>> SplitToList<T>(this IEnumerable<T> input) =>
                    SplitToList(input, 1000);


                /// <summary>
                ///     Split a list into pages
                /// </summary>
                /// <typeparam name="T">The type of the list</typeparam>
                /// <param name="input">The data to split</param>
                /// <param name="pageSize">The size of the pages</param>
                /// <returns>Enumerable of pages</returns>
                /// <remarks>https://stackoverflow.com/questions/11463734/split-a-list-into-smaller-lists-of-n-size</remarks>
                public static IEnumerable<List<T>> SplitToList<T>(this IEnumerable<T> input, int pageSize)
                    {
                        var enumerable = input.ToList();
                        if (!(enumerable.Any() && pageSize >= 1))
                            {
                                yield return null;
                            }


                        for (var i = 0; i < enumerable.Count(); i += pageSize)
                            {
                                yield return enumerable.ToList()
                                    .GetRange(i, Math.Min(pageSize, enumerable.Count() - i));
                            }
                    }

                /// <summary>
                ///     Split a list into buckets
                /// </summary>
                /// <typeparam name="T">Type of list</typeparam>
                /// <param name="input">source data to split</param>
                /// <param name="bucketCount">Number of buckets</param>
                /// <returns>an enumerable of lists where all the sublists are as near as possible to the same size</returns>
                /// <remarks>
                ///     splits the input into approximately equal sized lists e.g splitting a list
                ///     of 100 elements into 3 would produce 2 lists of size 33 and one of 34
                ///     from https://stackoverflow.com/questions/3892734/split-c-sharp-collection-into-equal-parts-maintaining-sort
                /// </remarks>
                public static List<List<T>> SplitToBuckets<T>(this IEnumerable<T> input, int bucketCount)
                    {
                        var enumerable = input.ToList();
                        if (!enumerable.Any() || bucketCount <= 1)
                            {
                                return new List<List<T>>();
                            }

                        var toReturn = new List<List<T>>();

                        var splitFactor = decimal.Divide(enumerable.Count(), bucketCount);
                        var currentIndex = 0;

                        for (var i = 0; i < bucketCount; i++)
                            {
                                var toTake = Convert.ToInt32(
                                    i == 0 ? Math.Ceiling(splitFactor) :
                                    decimal.Compare(
                                        decimal.Divide(Convert.ToDecimal(currentIndex), Convert.ToDecimal(i)),
                                        splitFactor) > 0 ? Math.Floor(splitFactor) : Math.Ceiling(splitFactor));

                                toReturn.Add(enumerable.Skip(currentIndex).Take(toTake).ToList());
                                currentIndex += toTake;
                            }

                        return toReturn;
                    }
            }
    }