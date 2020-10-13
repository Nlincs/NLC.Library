//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=CrmReferenceTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:54 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Moq;
using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class CrmReferenceTests
            {
                [SetUp]
                public void SetUp() => _mockRepository = new MockRepository(MockBehavior.Strict);

                [TearDown]
                public void TearDown() => _mockRepository.VerifyAll();

                private MockRepository _mockRepository;

                private CrmReference CreateCrmReference() => new CrmReference();

                private CrmReference CreateCrmReference(string crmRef) => new CrmReference(crmRef);

                [Test]
                [Sequential]
                public void CrmReferenceIsEqual(
                    [Values(1, 2, 3)] int x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numCrmReference = new CrmReference(x);

                        var stringCrmReference = new CrmReference(s);

                        var actual = numCrmReference == stringCrmReference;

                        Assert.That(actual, Is.True);

                        Assert.That(numCrmReference, Is.EqualTo(stringCrmReference));
                    }

                [Test]
                [Sequential]
                public void CrmReferenceIsEqual_ForLong(
                    [Values(1, 2, 3)] long x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numCrmReference = new CrmReference(x);

                        var stringCrmReference = new CrmReference(s);

                        var actual = numCrmReference == stringCrmReference;

                        Assert.That(actual, Is.True);

                        Assert.That(numCrmReference, Is.EqualTo(stringCrmReference));
                    }

                [Test]
                public void CrmReferenceIsEquatable()
                    {
                        var CrmReference = new CrmReference();

                        Assert.IsInstanceOf<IEquatable<ICrmReference>>(CrmReference);
                    }

                [Test]
                [Combinatorial]
                public void CrmReferenceIsInequal(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numCrmReference = new CrmReference(x);

                        var stringCrmReference = new CrmReference(s);

                        var actual = numCrmReference != stringCrmReference;

                        Assert.That(actual, Is.True);
                    }

                [Test]
                [Sequential]
                public void CrmReferenceIsInequalTo(
                    [Values(1, 2, 3)] int x,
                    [Values("1", "2", "3")] string s)
                    {
                        var numCrmReference = new CrmReference(x);

                        var stringCrmReference = new CrmReference(s);

                        var actual = numCrmReference != stringCrmReference;

                        Assert.That(actual, Is.False);
                    }

                [Test]
                [Combinatorial]
                public void CrmReferenceIsNotEqual(
                    [Values(1, 2, 3)] int x,
                    [Values("", "12")] string s)
                    {
                        var numCrmReference = new CrmReference(x);

                        var stringCrmReference = new CrmReference(s);

                        var actual = numCrmReference == stringCrmReference;

                        Assert.That(actual, Is.False);

                        Assert.That(numCrmReference, Is.Not.EqualTo(stringCrmReference));
                    }

                [Test]
                public void GetExternalRef_Null_ReturnsNull()
                    {
                        var sut = new CrmReference();

                        var actual = sut.NumericValue();

                        Assert.That(actual, Is.Null.Or.Empty);
                    }

                [Test]
                public void IsValid_StateUnderTest_ExpectedBehavior()
                    {
                        // Arrange
                        var sut = CreateCrmReference();


                        // Assert
                        Assert.That(sut, Is.Not.Null);
                    }

                [Test]
                public void IsValid_worksAsExpected()
                    {
                        var sut = CreateCrmReference();

                        sut.Value = "";

                        var actual = sut.IsValid();

                        Assert.That(actual, Is.True);
                    }

                [Test]
                public void IsValidNull_worksAsExpected()
                    {
                        var sut = CreateCrmReference();

                        sut.Value = null;

                        var actual = sut.IsValid();

                        Assert.That(actual, Is.False);
                    }


                [Test]
                [Sequential]
                public void NumericValue_ExtractsNumber(
                    [Values("1234", "ab123", "ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â£$%^7")]
                    string crmReference,
                    [Values("1234", "123", "7")] string expected)
                    {
                        var sut = new CrmReference(crmReference);

                        var actual = sut.NumericValue();

                        Assert.That(actual, Is.Not.Null);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void NumericValue_InvalidNumber(
                    [Values("a1234a", "ab", "ÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã‚Â¢ÃƒÂ¢Ã¢â‚¬Å¡Ã‚Â¬Ãƒâ€¦Ã‚Â¡ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã…Â¡ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â£$%^7_")]
                    string crmReference)
                    {
                        var sut = new CrmReference(crmReference);

                        var actual = sut.NumericValue();

                        Assert.That(actual, Is.Not.Null);

                        Assert.That(actual, Is.EqualTo(string.Empty));
                    }

                [Test]
                public void NumericValue_KeepsLeadingZero()
                    {
                        var crmNumber = "012345678901234";
                        var crmPrefix = "AF";
                        var crmPostFix = "567";


                        var crmRef = new CrmReference(crmPrefix + crmNumber + crmPostFix);

                        var expected = crmNumber + crmPostFix;

                        var actual = crmRef.NumericValue();

                        Assert.That(actual, Is.Not.Null);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void Operator_equals_Null_ReturnsFalse()
                    {
                        var rhs = new CrmReference();

                        Assert.That(null == rhs, Is.False);
                    }

                [Test]
                public void Operator_equals_ReturnsTrue()
                    {
                        var lhs = new CrmReference();
                        var rhs = new CrmReference();

                        Assert.That(lhs == rhs, Is.True);
                        Assert.That(lhs.Equals(rhs), Is.True);
                    }

                [Test]
                public void RandomStringIsValid()
                    {
                        var sut = CreateCrmReference("234");

                        var actual = sut.IsValid();
                        Assert.That(actual, Is.True);
                        Assert.That(sut.Value, Is.EqualTo("234"));
                    }
            }
    }