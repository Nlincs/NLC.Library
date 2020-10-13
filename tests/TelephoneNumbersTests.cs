//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=TelephoneNumbersTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 12:58
//  Altered - 06/07/2020 14:12 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class TelephoneNumbersTests
            {
                [Test]
                public void Add_StateUnderTest_ExpectedBehavior()
                    {
                        // Arrange
                        var telephoneNumbers = new TelephoneNumbers();
                        ITelephoneNumber item = null;

                        // Act
                        telephoneNumbers.Add(
                            // ReSharper disable once ExpressionIsAlwaysNull
                            item);

                        // Assert
                        Assert.That(telephoneNumbers.Count, Is.EqualTo(0));
                    }

                [Test]
                public void CantRmove_FromEmpty()
                    {
                        // Arrange
                        var telephoneNumbers = new TelephoneNumbers();
                       

                        // Act

                        telephoneNumbers.Remove(1);
                        // Assert
                        Assert.That(telephoneNumbers.Count, Is.EqualTo(0));
                    }

                [Test]
                public void TelephoneNumberList_StateUnderTest_ExpectedBehavior()
                    {
                        // Arrange
                        var telephoneNumbers = new TelephoneNumbers();

                        // Act
                        var result = telephoneNumbers.All();

                        // Assert
                        Assert.That(result, Is.Null.Or.Empty);
                    }
            }
    }