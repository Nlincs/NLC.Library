//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=AddressLine.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/08/2020 17:58
//  Altered - 09/10/2020 10:42 - Stephen Ellwood
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
    public  class AddressLines : AddressBase, IAddressLines, IEquatable<AddressLines>
            {
                /// <inheritdoc />
                public override bool IsEmptyAddress() => FullAddress().Trim() == "";

                /// <inheritdoc />
                public override string FullAddress() =>
                    base.FullAddress(Address1, Address2, Address3, Address4, Address5, Address6);

                /// <summary>
                /// </summary>
                /// <param name="other"></param>
                /// <returns></returns>
                public bool Equals(AddressLines other) =>
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
                public static bool operator ==(AddressLines lhs, AddressLines rhs)
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
                /// <param name="lhs"></param>
                /// <param name="rhs"></param>
                /// <returns></returns>
                public static bool operator !=(AddressLines lhs, AddressLines rhs) => !(lhs == rhs);

                /// <summary>
                /// </summary>
                /// <param name="obj"></param>
                /// <returns></returns>
                public override bool Equals(object obj) => Equals(obj as AddressLines);

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

                #region Implementation of IAddressLines

                /// <inheritdoc />
                public string AddressLine1
                {
                    get => Address1;
                    set => Address1 = value;
                }

                /// <inheritdoc />
                public string AddressLine2
                {
                    get => Address2;
                    set => Address2 = value;
                }


                /// <inheritdoc />
                public string AddressLine3
                {
                    get => Address3;
                    set => Address3 = value;
                }

                /// <inheritdoc />
                public string AddressLine4
                {
                    get => Address4;
                    set => Address4 = value;
                }

                /// <inheritdoc />
                public string AddressLine5
                {
                    get => Address5;
                    set => Address5 = value;
                }

                /// <inheritdoc />
                public string AddressLine6
                {
                    get => Address6;
                    set => Address6 = value;
                }

                #endregion
            }
    }