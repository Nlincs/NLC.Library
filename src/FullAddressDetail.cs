//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=FullAddressDetail.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 13/10/2020 16:36
//  Altered - 14/10/2020 11:30 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace NLC.Library
    {
        /// <summary>
        ///     Full address and detail
        /// </summary>
        /// <remarks>
        ///     Address and uprn, usrn etc.
        /// </remarks>
        public class FullAddressDetail : AddressBase, IEquatable<FullAddressDetail>
            {
                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator !=(FullAddressDetail lhs, FullAddressDetail rhs) => !(lhs == rhs);

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(FullAddressDetail lhs, FullAddressDetail rhs)
                    {
                        // Check for null on left side.
                        if (lhs is null)
                            {
                                // Only the left side is null.
                                return rhs is null;
                            }

                        // Equals handles case of null on right side.
                        return lhs.Equals(rhs);
                    }

                #region Overrides of AddressBase

                /// <inheritdoc />
                public override string FullAddress() =>
                    base.FullAddress(PrimaryAddress, SecondaryAddress, Street, Location, Town, County);

                #endregion

                #region Equality members

                /// <inheritdoc />
                public bool Equals(FullAddressDetail other)
                    {
                        if (ReferenceEquals(null, other))
                            {
                                return false;
                            }

                        if (ReferenceEquals(this, other))
                            {
                                return true;
                            }

                        return base.Equals(other) && PrimaryAddress == other.PrimaryAddress &&
                               SecondaryAddress == other.SecondaryAddress && Street == other.Street &&
                               Location == other.Location;
                    }

                /// <inheritdoc />
                public override bool Equals(object obj)
                    {
                        if (ReferenceEquals(null, obj))
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

                        return Equals((FullAddressDetail)obj);
                    }

                /// <inheritdoc />
                public override int GetHashCode()
                    {
           
                                var hashCode = base.GetHashCode();
                                hashCode = (hashCode * 397) ^
                                           (PrimaryAddress != null ? PrimaryAddress.GetHashCode() : 0);
                                hashCode = (hashCode * 397) ^
                                           (SecondaryAddress != null ? SecondaryAddress.GetHashCode() : 0);
                                hashCode = (hashCode * 397) ^ (Street != null ? Street.GetHashCode() : 0);
                                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                                return hashCode;
                    }

                #endregion

                #region Implementation of ISimpleAddress

                /// <inheritdoc />
                public string PrimaryAddress { get; set; }

                /// <inheritdoc />
                public string SecondaryAddress { get; set; }

                /// <inheritdoc />
                public string Street { get; set; }

                /// <inheritdoc />
                public string Location { get; set; }

                /// <inheritdoc />
                public string Town { get; set; }

                /// <inheritdoc />
                public string County { get; set; }

                #endregion
            }
    }