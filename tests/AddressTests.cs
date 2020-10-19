//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressTests.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:38
//  Altered - 19/10/2020 13:41 - Stephen Ellwood
// 
//  Project : - NLC.Library.Tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        /// <summary>
        ///     disparate test object testing
        /// </summary>
        [TestFixture]
        public class AddressTests
            {
                private Address CreateAddress() => new Address();

                private Address PopulatedAddress() => new Address
                    {
                        Address1 = "add1",
                        Address2 = "add2",
                        Address3 = "add3",
                        Address4 = "add4",
                        Address5 = "add5",
                        Address6 = "add6",
                    };

                [Test]
                public void CheckInterfaces()
                    {
                        var sut = CreateAddress();

                        Assert.IsInstanceOf<IAddress>(sut);
                        Assert.IsInstanceOf<ILocation>(sut);
                        Assert.IsInstanceOf<IAddressLines>(sut);
                        Assert.IsInstanceOf<IAddressNamed>(sut);
                        Assert.IsInstanceOf<IAddressNameNumber>(sut);
                    }

                [Test]
                public void InterfacesWork()
                    {
                        var sut = PopulatedAddress();

                        var actualLines = sut.AddressLines();
                        var actualNamed = sut.AddressNamed();
                        var actualNameNumber = sut.AddressNameNumber();

                        Assert.That(actualLines, Is.Not.Null);
                        Assert.That(actualLines.AddressLine1, Is.EqualTo("add1"));
                        Assert.That(actualLines.AddressLine2, Is.EqualTo("add2"));
                        Assert.That(actualLines.AddressLine3, Is.EqualTo("add3"));
                        Assert.That(actualLines.AddressLine4, Is.EqualTo("add4"));
                        Assert.That(actualLines.AddressLine5, Is.EqualTo("add5"));
                        Assert.That(actualLines.AddressLine6, Is.EqualTo("add6"));


                        Assert.That(actualNamed, Is.Not.Null);
                        Assert.That(actualNamed.PrimaryAddress, Is.EqualTo("add1"));
                        Assert.That(actualNamed.SecondaryAddress, Is.EqualTo("add2"));
                        Assert.That(actualNamed.Street, Is.EqualTo("add3"));
                        Assert.That(actualNamed.Location, Is.EqualTo("add4"));
                        Assert.That(actualNamed.Town, Is.EqualTo("add5"));
                        Assert.That(actualNamed.County, Is.EqualTo("add6"));

                        Assert.That(actualNameNumber, Is.Not.Null);
                        Assert.That(actualNameNumber.HouseName, Is.EqualTo("add1"));
                        Assert.That(actualNameNumber.HouseNumber, Is.EqualTo("add2"));
                        Assert.That(actualNameNumber.Street, Is.EqualTo("add3"));
                        Assert.That(actualNameNumber.Location, Is.EqualTo("add4"));
                        Assert.That(actualNameNumber.Town, Is.EqualTo("add5"));
                        Assert.That(actualNameNumber.County, Is.EqualTo("add6"));
                    }

                [Test]
                public void FieldsReturnExpected()
                    {
                        var sut = PopulatedAddress();

                        Assert.That(sut, Is.Not.Null);
                        Assert.That(sut.AddressLine1, Is.EqualTo("add1"));
                        Assert.That(sut.AddressLine2, Is.EqualTo("add2"));
                        Assert.That(sut.AddressLine3, Is.EqualTo("add3"));
                        Assert.That(sut.AddressLine4, Is.EqualTo("add4"));
                        Assert.That(sut.AddressLine5, Is.EqualTo("add5"));
                        Assert.That(sut.AddressLine6, Is.EqualTo("add6"));

                        Assert.That(sut.PrimaryAddress, Is.EqualTo("add1"));
                        Assert.That(sut.SecondaryAddress, Is.EqualTo("add2"));
                        Assert.That(sut.Street, Is.EqualTo("add3"));
                        Assert.That(sut.Location, Is.EqualTo("add4"));
                        Assert.That(sut.Town, Is.EqualTo("add5"));
                        Assert.That(sut.County, Is.EqualTo("add6"));

                        Assert.That(sut.HouseName, Is.EqualTo("add1"));
                        Assert.That(sut.HouseNumber, Is.EqualTo("add2"));
                    }
            }
    }