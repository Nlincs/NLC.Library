//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:54 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace NLC.Library.Tests
    {
        /// <summary>
        ///     disparate test object testing
        /// </summary>
        /// <remarks>
        ///     This is intended to test comparisons between different objects with the same base class
        ///     e.g. simpleAddress and SimpleAddressLine
        /// </remarks>
        [TestFixture]
        public class AddressTests
            {
                private AddressNameNumber CreateSimpleAddressNameNumber() => new AddressNameNumber();

                private AddressLines CreateSimpleAddressLine() => new AddressLines();

                private AddressNamed CreateSimpleAddress() => new AddressNamed();


                    }
            }
    