//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressNamed.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 08/07/2020 16:16
//  Altered - 09/10/2020 10:58 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        /// </summary>
        public sealed class AddressNamed : AddressBase, IAddressNamed, IEquatable<AddressNamed>
            {
 
                /// <inheritdoc />
                public override bool IsEmptyAddress() => FullAddress() == "";

                /// <inheritdoc />
                public override string FullAddress() =>
                    base.FullAddress(PrimaryAddress, SecondaryAddress, Street, Location, Town, County);

                /// <inheritdoc />
                public string PrimaryAddress
                {
                    get => Address1;
                    set => Address1 = value;
                }

                /// <inheritdoc />
                public string SecondaryAddress
                {
                    get => Address2;
                    set => Address2 = value;
                }

                /// <inheritdoc />
                public string Street
                {
                    get => Address3;
                    set => Address3 = value;
                }

                /// <inheritdoc />
                public string Location
                {
                    get => Address4;
                    set => Address4 = value;
                }

                /// <inheritdoc />
                public string Town
                {
                    get => Address5;
                    set => Address5 = value;
                }

                /// <inheritdoc />
                public string County
                {
                    get => Address6;
                    set => Address6 = value;
                }

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(AddressNamed other) =>
                    other != null &&
                    base.Equals(other) &&
                    EqualityComparer<IUprn>.Default.Equals(Uprn, other.Uprn) &&
                    EqualityComparer<IUsrn>.Default.Equals(Usrn, other.Usrn) &&
                    EqualityComparer<IPostCode>.Default.Equals(PostCode, other.PostCode);


                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator !=(AddressNamed lhs, AddressNamed rhs) => !(lhs == rhs);

                /// <summary>
                /// </summary>
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator ==(AddressNamed lhs, AddressNamed rhs)
                    {
                        // Check for null on left side.
                        if (lhs is null)
                            {
                                return rhs is null;

                                // Only the left side is null.
                            }

                        // Equals handles case of null on right side.
                        return lhs.Equals(rhs);
                    }

                /// <summary>
                /// </summary>
                /// <param name="obj"></param>
                /// <returns></returns>
                public override bool Equals(object obj) => Equals(obj as AddressNamed);

                /// <summary>
                /// </summary>
                /// <returns></returns>
                public override int GetHashCode()
                    {
                        var hashCode = -2017556967;
                        hashCode = (hashCode * -1521134295) + base.GetHashCode();
                        hashCode = (hashCode * -1521134295) + EqualityComparer<IUprn>.Default.GetHashCode(Uprn);
                        hashCode = (hashCode * -1521134295) + EqualityComparer<IUsrn>.Default.GetHashCode(Usrn);
                        hashCode = (hashCode * -1521134295) + EqualityComparer<IPostCode>.Default.GetHashCode(PostCode);
                        return hashCode;
                    }
            }
    }