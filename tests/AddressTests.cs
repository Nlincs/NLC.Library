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


                [Test]
                public void EqualAddress_AreEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   ";
                        var uprn3 = "1234 ";

                        var sut1 = CreateSimpleAddress();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddress();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddress();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut1.Equals(sut3));
                        Assert.That(sut2.Equals(sut3));

                        Assert.That(sut1 == sut2);
                        Assert.That(sut1 == sut3);
                        Assert.That(sut2 == sut3);
                    }


                [Test]
                public void EqualAddressLine_AreEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   ";
                        var uprn3 = "1234 ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddressLine();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut1.Equals(sut3));
                        Assert.That(sut2.Equals(sut3));

                        Assert.That(sut1 == sut2);
                        Assert.That(sut1 == sut3);
                        Assert.That(sut2 == sut3);
                    }

                [Test]
                public void EqualAddressNameNumber_AreEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   ";
                        var uprn3 = "1234 ";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddressNameNumber();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut1.Equals(sut3));
                        Assert.That(sut2.Equals(sut3));

                        Assert.That(sut1 == sut2);
                        Assert.That(sut1 == sut3);
                        Assert.That(sut2 == sut3);
                    }

                [Test]
                public void MatchedAddresses_AreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "12321";
                        var add4 = "Somewhere we know";
                        var add5 = "address5";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";

                        var add12 = "  Add ";
                        var add22 = "  Add ";
                        var add32 = " 12321   ";
                        var add42 = "Somewhere we know ";
                        var add52 = " address5";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;

                        var sut3 = CreateSimpleAddress();
                        sut3.PrimaryAddress = add12;
                        sut3.SecondaryAddress = add22;
                        sut3.Street = add32;
                        sut3.Location = add42;
                        sut3.Town = add52;


                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut2.Equals(sut3));
                        Assert.That(sut1.Equals(sut3));


                    
                    }

                [Test]
                public void MatchedAddressesAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "12321";
                        var add4 = "Somewhere we know";
                        var add5 = "address5";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";

                        var add12 = "  Add ";
                        var add22 = "  Add ";
                        var add32 = " 12321   ";
                        var add42 = "Somewhere we know ";
                        var add52 = " address5";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;

                        var sut3 = CreateSimpleAddress();
                        sut3.PrimaryAddress = add12;
                        sut3.SecondaryAddress = add22;
                        sut3.Street = add32;
                        sut3.Location = add42;
                        sut3.Town = add52;


                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut2.Equals(sut3));
                        Assert.That(sut1.Equals(sut3));
            
                    }

                [Test]
                public void MatchedAddressesDifferentUprn_AreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "12321";
                        var add4 = "Somewhere we know";
                        var add5 = "address5";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";

                        var add12 = "  Add ";
                        var add22 = "  Add ";
                        var add32 = " 12321   ";
                        var add42 = "Somewhere we know ";
                        var add52 = " address5";

                        var uprn1 = "123";
                        var uprn2 = "12";
                        var uprn3 = "23";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddress();
                        sut3.PrimaryAddress = add12;
                        sut3.SecondaryAddress = add22;
                        sut3.Street = add32;
                        sut3.Location = add42;
                        sut3.Town = add52;
                        sut3.Uprn = new Uprn(uprn3);


                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut2.Equals(sut3));
                        Assert.That(!sut1.Equals(sut3));

                    }

                [Test]
                public void MatchedAddressesDifferentUprnAreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "12321";
                        var add4 = "Somewhere we know";
                        var add5 = "address5";

                        var add11 = "  Add";
                        var add21 = "  Add ";
                        var add31 = "12321   ";
                        var add41 = "Somewhere we know";
                        var add51 = "address5";

                        var add12 = "  Add ";
                        var add22 = "  Add ";
                        var add32 = " 12321   ";
                        var add42 = "Somewhere we know ";
                        var add52 = " address5";

                        var uprn1 = "123";
                        var uprn2 = "12";
                        var uprn3 = "23";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;
                        sut1.Address2 = add2;
                        sut1.Address3 = add3;
                        sut1.Address4 = add4;
                        sut1.Address5 = add5;
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add11;
                        sut2.HouseNumber = add21;
                        sut2.Street = add31;
                        sut2.Location = add41;
                        sut2.Town = add51;
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddress();
                        sut3.PrimaryAddress = add12;
                        sut3.SecondaryAddress = add22;
                        sut3.Street = add32;
                        sut3.Location = add42;
                        sut3.Town = add52;
                        sut3.Uprn = new Uprn(uprn3);


                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut2.Equals(sut3));
                        Assert.That(!sut1.Equals(sut3));

                    }


                [Test]
                public void MatchedDifferentLineslAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "Add ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Location = add2;

                        var sut3 = CreateSimpleAddress();
                        sut3.County = add3;

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut2.Equals(sut3));
                        Assert.That(sut1.Equals(sut3));

                    }

                [Test]
                public void MatchedPartialAreEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add ";
                        var add3 = "Add ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address1 = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.HouseName = add2;

                        var sut3 = CreateSimpleAddress();
                        sut3.PrimaryAddress = add3;

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut2.Equals(sut3));
                        Assert.That(sut1.Equals(sut3));

                    }


                [Test]
                public void SameUprnAreEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   ";
                        var uprn3 = "1234 ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddress();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.EqualTo(sut2));
                        Assert.That(sut1, Is.EqualTo(sut3));
                        Assert.That(sut2, Is.EqualTo(sut3));

                        Assert.That(sut1.Equals(sut2));
                        Assert.That(sut2.Equals(sut3));
                        Assert.That(sut1.Equals(sut3));

                    }


                [Test]
                public void UnEqualAddress_AreNotEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234 1  ";
                        var uprn3 = "1234 a";

                        var sut1 = CreateSimpleAddress();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddress();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddress();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut1.Equals(sut3));
                        Assert.That(!sut2.Equals(sut3));

                        Assert.That(sut1 != sut2);
                        Assert.That(sut1 != sut3);
                        Assert.That(sut2 != sut3);
                    }

                [Test]
                public void UnEqualAddressLine_AreNotEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234   1";
                        var uprn3 = "e1234 ";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressLine();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddressLine();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut1.Equals(sut3));
                        Assert.That(!sut2.Equals(sut3));

                        Assert.That(sut1 != sut2);
                        Assert.That(sut1 != sut3);
                        Assert.That(sut2 != sut3);
                    }

                [Test]
                public void UnEqualAddressNameNumber_AreNotEqual()
                    {
                        var uprn1 = "1234";
                        var uprn2 = "  1234 1   ";
                        var uprn3 = "1234 _";

                        var sut1 = CreateSimpleAddressNameNumber();
                        sut1.Uprn = new Uprn(uprn1);

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Uprn = new Uprn(uprn2);

                        var sut3 = CreateSimpleAddressNameNumber();
                        sut3.Uprn = new Uprn(uprn3);

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut1.Equals(sut3));
                        Assert.That(!sut2.Equals(sut3));

                        Assert.That(sut1 != sut2);
                        Assert.That(sut1 != sut3);
                        Assert.That(sut2 != sut3);
                    }

                [Test]
                public void UnmatchedPartialAreNotEqual()
                    {
                        var add1 = "Add";
                        var add2 = "  Add1 ";
                        var add3 = " Add,";

                        var sut1 = CreateSimpleAddressLine();
                        sut1.Address2 = add1;

                        var sut2 = CreateSimpleAddressNameNumber();
                        sut2.Town = add2;

                        var sut3 = CreateSimpleAddress();
                        sut3.County = add3;

                        Assert.That(sut1, Is.Not.EqualTo(sut2));
                        Assert.That(sut1, Is.Not.EqualTo(sut3));
                        Assert.That(sut2, Is.Not.EqualTo(sut3));

                        Assert.That(!sut1.Equals(sut2));
                        Assert.That(!sut2.Equals(sut3));
                        Assert.That(!sut1.Equals(sut3));

                    }
            }
    }