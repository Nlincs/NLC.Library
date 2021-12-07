//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressBase.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/12/2020 16:18
//  Altered - 17/12/2020 17:38 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Address base class
        /// </summary>
        public abstract class AddressBase : ILocation
            {
                private string _address1;
                private string _address2;
                private string _address3;
                private string _address4;
                private string _address5;
                private string _address6;

                protected AddressBase(IAddressLines address)
                    {
                        OriginalAddress = address;

                        Address1 = address.AddressLine1;
                        Address2 = address.AddressLine2;
                        Address3 = address.AddressLine3;
                        Address4 = address.AddressLine4;
                        Address5 = address.AddressLine5;
                        Address6 = address.AddressLine6;
                    }

                protected AddressBase(IAddressNameNumber address)
                    {
                        OriginalAddress = address;

                        Address1 = address.HouseName;
                        Address2 = address.HouseNumber;
                        Address3 = address.Street;
                        Address4 = address.Location;
                        Address5 = address.Town;
                        Address6 = address.County;
                    }

                protected AddressBase(IAddressNamed address)
                    {
                        OriginalAddress = address;

                        Address1 = address.PrimaryAddress;
                        Address2 = address.SecondaryAddress;
                        Address3 = address.Street;
                        Address4 = address.Location;
                        Address5 = address.Town;
                        Address6 = address.County;
                    }

                protected AddressBase(string address1, string address2, string address3, string address4,
                    string address5, string address6)
                    {
                        _address1 = address1;
                        _address2 = address2;
                        _address3 = address3;
                        _address4 = address4;
                        _address5 = address5;
                        _address6 = address6;
                    }

                protected AddressBase()
                    {
                        var defaultAddress = "";
                        Address1 = defaultAddress;
                        Address2 = defaultAddress;
                        Address3 = defaultAddress;
                        Address4 = defaultAddress;
                        Address5 = defaultAddress;
                        Address6 = defaultAddress;
                    }


                /// <summary>
                ///     Original address at creation of instance
                /// </summary>
                /// <remarks>
                ///     Sometimes needed when rearranging
                /// </remarks>
                protected IAddress OriginalAddress { get; set; }


                /// <summary>
                /// </summary>
                /// <returns></returns>
                public virtual string FullAddress() =>
                    FullAddress(Address1, Address2, Address3, Address4, Address5, Address6);

                /// <inheritdoc />
                public virtual string FullAddress(IAddress address) =>
                    FullAddress(address.Address1, address.Address2, address.Address3, address.Address4,
                        address.Address5, address.Address6);

                public string FullAddress(string line1, string line2, string line3, string line4,
                    string line5, string line6) => FullAddress(line1, line2, line3, line4, line5, line6, true);

                /// <inheritdoc />
                public virtual bool IsEmptyAddress() => FullAddress() == "";

                /// <inheritdoc />
                public string AddressSortField { get; set; }


                /// <inheritdoc />
                public IUprn Uprn { get; set; }

                /// <inheritdoc />
                public IUsrn Usrn { get; set; }

                public IPostCode PostCode { get; set; }

                /// <inheritdoc />
                public double? Easting { get; set; }

                /// <inheritdoc />
                public double? Northing { get; set; }


                /// <summary>
                /// </summary>
                /// <param name="line1"></param>
                /// <param name="line2"></param>
                /// <param name="line3"></param>
                /// <param name="line4"></param>
                /// <param name="line5"></param>
                /// <param name="line6"></param>
                /// <param name="includePostCode">false to not include postcode in full address, true (default) otherwise</param>
                /// <returns></returns>
                public string FullAddress(string line1, string line2, string line3, string line4,
                    string line5, string line6, bool includePostCode)
                    {
                        if (line1 == null) { line1 = ""; }

                        if (line2 == null)
                            {
                                line2 = "";
                            }

                        if (line3 == null)
                            {
                                line3 = "";
                            }

                        if (line4 == null)
                            {
                                line4 = "";
                            }

                        if (line5 == null)
                            {
                                line5 = "";
                            }

                        if (line6 == null)
                            {
                                line6 = "";
                            }

                        var pAdd = line1.Trim();
                        var sAdd = line2.Trim();
                        var str = line3.Trim();
                        var loc = line4.Trim();
                        var town = line5.Trim();
                        var county = line6.Trim();


                        var result = pAdd;

                        if (result == "")
                            {
                                result = sAdd;
                            }
                        else
                            {
                                if (sAdd != "")
                                    {
                                        result = result + ", " + sAdd;
                                    }
                            }

                        if (result == "")
                            {
                                result = str;
                            }
                        else
                            {
                                if (str != "")
                                    {
                                        result = result + ", " + str;
                                    }
                            }


                        if (result == "")
                            {
                                result = loc;
                            }
                        else
                            {
                                if (loc != "")
                                    {
                                        result = result + ", " + loc;
                                    }
                            }

                        if (result == "")
                            {
                                result = town;
                            }
                        else
                            {
                                if (town != "")
                                    {
                                        result = result + ", " + town;
                                    }
                            }

                        if (result == "")
                            {
                                result = county;
                            }
                        else
                            {
                                if (county != "")
                                    {
                                        result = result + ", " + county;
                                    }
                            }


                        if (includePostCode)
                            {
                                if (result == "")
                                    {
                                        if (PostCode != null && PostCode.IsUkValid())
                                            {
                                                result = PostCode.Value;
                                            }
                                    }
                                else
                                    {
                                        if (PostCode != null && PostCode.IsUkValid())
                                            {
                                                result = result + " " + PostCode.Value;
                                            }
                                    }
                            }

                        return result;
                    }


                /// <summary>
                ///     Restore original address
                /// </summary>
                public void Restore()
                    {
                        Address1 = OriginalAddress.Address1;
                        Address2 = OriginalAddress.Address2;
                        Address3 = OriginalAddress.Address3;
                        Address4 = OriginalAddress.Address4;
                        Address5 = OriginalAddress.Address5;
                        Address6 = OriginalAddress.Address6;
                    }


                /// <summary>
                /// </summary>
                /// <returns></returns>
                public bool IsValid() => FullAddress().Trim() == "" && (Uprn == null || !Uprn.IsValid());

                /// <summary>
                ///     Simplify address
                /// </summary>
                /// <remarks>
                ///     This basically is intended to remove empty lines from the address fields and push the remainder up.
                ///     It can mess up the consistency for named fields but that is always a risk with user input
                ///     Postcode is ignored - previously it may have been added to the last line
                /// </remarks>
                public void Simplify()
                    {
                        var dummyLine = "##DUMMY ADDRESS LINE##";
                        // first tidy up
                        Address1 = Address1 == null ? "" : Address1.Trim();
                        Address2 = Address2 == null ? "" : Address2.Trim();
                        Address3 = Address3 == null ? "" : Address3.Trim();
                        Address4 = Address4 == null ? "" : Address4.Trim();
                        Address5 = Address5 == null ? "" : Address5.Trim();
                        Address6 = Address6 == null ? "" : Address6.Trim();

                        // check for house number
                        // we only check the first two addresses and deal if needed

                        // house number is intended to be in address 2 but it could be swapped so we check here

                        var houseNameIsNumeric = Address1.Trim().IsLong();
                        var houseNameIsPartialNumeric = Address1.Trim().FirstWord().IsLong();
                        var houseNumberIsNumeric = Address2.Trim().IsLong();
                        var houseNumberIsPartialNumeric = Address2.Trim().FirstWord().IsLong();

                        if (houseNameIsNumeric)
                            {
                                long.TryParse(Address1, out var houseNumber);
                                // address1 is fully numeric so we swap
                                Address1 = Address2 == null || Address2.Trim() == "" ? dummyLine : Address2;
                                Address2 = houseNumber.ToString();
                            }
                        else
                            {
                                if (houseNameIsPartialNumeric)
                                    {
                                        // address1 is partial numeric, if address2 is empty we move the number
                                        if (Address2 == null || Address2.Trim() == "")
                                            {
                                                long.TryParse(Address1.Trim().FirstWord(), out var houseNumber);
                                                Address1 = Address1.Substring(houseNumber.ToString().Length);
                                                Address2 = houseNumber.ToString();
                                            }
                                    }
                                else
                                    {
                                        if (houseNumberIsNumeric &&
                                            (Address1 == null || Address1.Trim() == ""))
                                            {
                                                // housenumber is numeric and house nameis empty so we add dummy line to prevent losing empty line which will throw out the order
                                                Address1 = dummyLine;
                                            }
                                        else
                                            {
                                                if (houseNumberIsPartialNumeric &&
                                                    (Address1 == null || Address1.Trim() == ""))
                                                    {
                                                        // housenumber contains a partial numeric e.g. 32 High street so we split it out
                                                        long.TryParse(Address2.Trim().FirstWord(),
                                                            out var house2Number);
                                                        Address1 = Address2.Substring(house2Number.ToString().Length);
                                                        Address2 = house2Number.ToString();
                                                    }
                                            }
                                    }
                            }

                        var tempFullAddress = FullAddress(Address1, Address2, Address3, Address4, Address5, Address6,
                            false);

                        // remove any redundancy so that we have a comma separated string
                        tempFullAddress.ReplaceAllMid(",,", "", 0, tempFullAddress.Length);

                        // now split on comma
                        var tempAddress = tempFullAddress.Split(',');

                        var tempAddressLen = tempAddress.Length;

                        switch (tempAddressLen)
                            {
                                case 1:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = "";
                                    Address3 = "";
                                    Address4 = "";
                                    Address5 = "";
                                    Address6 = "";
                                    break;
                                case 2:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();

                                    Address3 = "";
                                    Address4 = "";
                                    Address5 = "";
                                    Address6 = "";
                                    break;

                                case 3:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();
                                    Address3 = tempAddress[2].Trim();
                                    Address4 = "";
                                    Address5 = "";
                                    Address6 = "";
                                    break;

                                case 4:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();
                                    Address3 = tempAddress[2].Trim();
                                    Address4 = tempAddress[3].Trim();
                                    Address5 = "";
                                    Address6 = "";
                                    break;


                                case 5:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();
                                    Address3 = tempAddress[2].Trim();
                                    Address4 = tempAddress[3].Trim();
                                    Address5 = tempAddress[4].Trim();
                                    Address6 = "";

                                    break;

                                case 6:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();
                                    Address3 = tempAddress[2].Trim();
                                    Address4 = tempAddress[3].Trim();
                                    Address5 = tempAddress[4].Trim();
                                    Address6 = tempAddress[5].Trim();

                                    break;
                                default:
                                    Address1 = tempAddress[0].Trim();
                                    Address2 = tempAddress[1].Trim();
                                    Address3 = tempAddress[2].Trim();
                                    Address4 = tempAddress[3].Trim();
                                    Address5 = tempAddress[4].Trim();
                                    Address6 = tempAddress[5].Trim();
                                    break;
                            }

                        // now remove dummy if it exists
                        if (Address1 == dummyLine)
                            {
                                Address1 = "";
                            }
                    }

                #region Implementation of IAddress

                // House Name
                /// <inheritdoc />
                public string Address1 { get; set; } = "";

                // House Number
                /// <inheritdoc />
                public string Address2 { get; set; } = "";

                /// <inheritdoc />
                public string Address3 { get; set; } = "";

                /// <inheritdoc />
                public string Address4 { get; set; } = "";

                /// <inheritdoc />
                public string Address5 { get; set; } = "";

                /// <inheritdoc />
                public string Address6 { get; set; } = "";

                #endregion
            }
    }