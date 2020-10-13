//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressBase.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/08/2020 18:04
//  Altered - 09/10/2020 11:41 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     Address base class
        /// </summary>
        public abstract class AddressBase : IAddress, ILocation, IEquatable<AddressBase>
            {
                protected AddressBase(IAddressLines address)
                    {
                        Address = address;
                    }

                protected AddressBase(IAddressNameNumber address)
                    {
                        Address = address;
                    }

                protected AddressBase(IAddressNamed address)
                    {
                        Address = address;
                    }

                protected AddressBase()
                    {
                        
                    }

                public IAddress Address { get; set; }

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public abstract string FullAddress();

                /// <inheritdoc />
                public string FullAddress(IAddress address) => throw new NotImplementedException();


                /// <summary>
                /// </summary>
                /// <param name="line1"></param>
                /// <param name="line2"></param>
                /// <param name="line3"></param>
                /// <param name="line4"></param>
                /// <param name="line5"></param>
                /// <param name="line6"></param>
                /// <returns></returns>
                public string FullAddress(string line1, string line2, string line3, string line4,
                    string line5, string line6)
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

                        var padd = line1.Trim();
                        var sadd = line2.Trim();
                        var str = line3.Trim();
                        var loc = line4.Trim();
                        var town = line5.Trim();
                        var county = line6.Trim();


                        var result = padd;

                        if (result == "")
                            {
                                result = sadd;
                            }
                        else
                            {
                                if (sadd != "")
                                    {
                                        result = result + ", " + sadd;
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

                        return result;
                    }


                /// <inheritdoc />
                public IUprn Uprn { get; set; }

                /// <inheritdoc />
                public IUsrn Usrn { get; set; }

                public IPostCode PostCode { get; set; }

                /// <inheritdoc />
                public double? Easting { get; set; }

                /// <inheritdoc />
                public double? Northing { get; set; }

                /// <inheritdoc />
                public virtual bool IsEmptyAddress() => FullAddress() == "";

                /// <inheritdoc />
                public string AddressSortField { get; set; }

                /// <inheritdoc />
                public bool Equals(ILocation other)
                    {
                        if (other == null)
                            {
                                return false;
                            }

                        if (IsEmptyAddress() || other.IsEmptyAddress())
                            {
                                if (Uprn == null)
                                    {
                                        return false;
                                    }

                                if (Uprn.IsDefault())
                                    {
                                        return false;
                                    }

                                if (other.Uprn == null)
                                    {
                                        return false;
                                    }

                                if (other.Uprn.IsDefault())
                                    {
                                        return false;
                                    }

                                return Equals(Uprn, other.Uprn);
                            }

                        if (FullAddress() == other.FullAddress())
                            {
                                if (Uprn == null)
                                    {
                                        return true;
                                    }

                                if (other.Uprn == null)
                                    {
                                        return true;
                                    }


                                return Equals(Uprn, other.Uprn);
                            }

                        return false;
                    }

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public bool IsValid() => FullAddress().Trim() == "" && (Uprn == null || !Uprn.IsValid());

                /// <summary>
                ///     equality check
                /// </summary>
                /// <param name="other"></param>
                public bool Equals(AddressBase other)
                    {
                        if (other == null)
                            {
                                return false;
                            }

                        if (IsEmptyAddress() || other.IsEmptyAddress())
                            {
                                if (Uprn == null)
                                    {
                                        return false;
                                    }

                                if (Uprn.IsDefault())
                                    {
                                        return false;
                                    }

                                if (other.Uprn == null)
                                    {
                                        return false;
                                    }

                                if (Uprn.IsDefault())
                                    {
                                        return false;
                                    }

                                return Equals(Uprn, other.Uprn);
                            }

                        if (FullAddress() == other.FullAddress())
                            {
                                if (Uprn == null)
                                    {
                                        return true;
                                    }

                                if (other.Uprn == null)
                                    {
                                        return true;
                                    }

                                return Equals(Uprn, other.Uprn);
                            }

                        return false;
                    }

                /// <inheritdoc />
                public override bool Equals(object obj)
                    {
                        if (obj is null)
                            {
                                return false;
                            }

                        if (ReferenceEquals(this, obj))
                            {
                                return true;
                            }

                        if (obj.GetType() != GetType())
                            {
                                return false;
                            }

                        return Equals((AddressBase)obj);
                    }

                /// <inheritdoc />
                public override int GetHashCode()
                    {
     
                                return ((Uprn != null ? Uprn.GetHashCode() : 0) * 397) ^
                                       (Usrn != null ? Usrn.GetHashCode() : 0);
                    }

                #region Implementation of IAddress

                /// <inheritdoc />
                public string Address1 { get; set; }

                /// <inheritdoc />
                public string Address2 { get; set; }

                /// <inheritdoc />
                public string Address3 { get; set; }

                /// <inheritdoc />
                public string Address4 { get; set; }

                /// <inheritdoc />
                public string Address5 { get; set; }

                /// <inheritdoc />
                public string Address6 { get; set; }

                #endregion
            }
    }