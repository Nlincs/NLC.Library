//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=PostCode.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:16 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions;
using NLC.Library.Extensions.NationalGovernment.eGIF;
using NLC.Library.Interfaces;
using System.Globalization;

namespace NLC.Library
    {
        /// <summary>
        ///     Post Code
        /// </summary>
        /// <remarks>
        ///     The format is validated against the standard definition and is fo the form AANN NAA / ANN NAA where A = alphabetic
        ///     character and
        ///     N = numerical value
        /// </remarks>
        public sealed class PostCode : IPostCode
            {
                private string _value;

                /// <summary>
                ///     Initialises a new instance of the <see cref="PostCode" /> class.
                /// </summary>
                public PostCode() => _value = string.Empty;

                /// <summary>
                ///     Initialises a new instance of the <see cref="PostCode" /> class.
                /// </summary>
                /// <param name="outward"></param>
                /// <param name="inward"></param>
                public PostCode(string outward, string inward)
                    {
                        Outward = outward;
                        Inward = inward;

                        SetPostCode(outward + " " + inward);
                    }

                /// <summary>
                ///     Initialises a new instance of the <see cref="PostCode" /> class.
                /// </summary>
                /// <param name="postcode">The postcode.</param>
                public PostCode(string postcode) => SetPostCode(postcode == null ? "" : postcode.Trim());


                /// <summary>
                ///     Gets or sets the area.
                /// </summary>
                /// <value>
                ///     The area element of the post code is the leading letters
                ///     eg for DN16 1AB it is DN
                /// </value>
                public string Area
                {
                    get
                    {
                        if (IsUkValid())
                            {
                                return Value.Substring(0,
                                    char.IsLetter(Value,
                                        1)
                                        ? 2
                                        : 1);
                            }

                        return string.Empty;
                    }

                    set
                    {
                        // do nowt
                    }
                }

                /// <summary>
                ///     Gets or sets the district.
                /// </summary>
                /// <value>
                ///     The district element of the post code is the same as the outward
                ///     element ie the first half of the postcode eg for DN16 1AB it is
                ///     DN16 <see cref="Outward" />
                /// </value>
                public string District
                {
                    get => Value.WordCount() == 2 ? Value.FirstWord() : "";
                    set
                    {
                        // do nothing
                    }
                }

                /// <summary>
                ///     Gets or sets the inward element
                /// </summary>
                /// <value>
                ///     The inward element is the second half of the postcode
                ///     eg for DN16 1AB it would be 1AB
                /// </value>
                public string Inward
                {
                    get => IsUkValid() ? Value.LastWord() : "";
                    set
                    {
                        // do nothing
                    }
                }

                /// <inheritdoc />
                bool? IPostCode.IsActive() => IsActive();

                /// <summary>
                ///     Is the post code anonymous
                /// </summary>
                /// <value>
                ///     True if the post code is known to be anonymous
                ///     false if not
                ///     nothing if unknown
                /// </value>
                public bool? IsAnonymous() => Value == "DN00 000" || Value == "ZZ99 ZZZ" || Value == "ZZ99 9ZZ";

                /// <inheritdoc />
                bool? IPostCode.IsDummy() => IsDummy();

                /// <inheritdoc />
                bool? IPostCode.IsNorthlincs() => IsNorthlincs();

                /// <summary>
                ///     Gets a value indicating whether this instance is northlincs anonymous.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is northlincs anonymous; otherwise, <c>false</c>.
                /// </value>
                public bool IsNorthlincsAnonymous() => Value.Equals("DN00 000");


                /// <summary>
                ///     Gets a value indicating whether this instance is uk valid.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is uk valid; otherwise, <c>false</c>.
                /// </value>
                public bool IsUkValid() => _value != string.Empty && this.IsValidUkPostCode();

                /// <summary>
                ///     Gets the mosaic post code.
                /// </summary>
                /// <value>
                ///     The mosaic post code.
                /// </value>
                public string MosaicPostCode()
                    {
                        if (IsUkValid())
                            {
                                var word3 = Inward;
                                var word1 = Area;
                                var word2 = District.Substring(word1.Length,
                                    Outward.Length - Area.Length).Trim(); // this is the text
                                word2 = word2.PadLeft(4 - (Area.Length + word2.Length));
                                return word1 + " " + word2 + " " + word3;
                            }

                        return "";
                    }

                /// <summary>
                ///     Gets or sets the outward element
                /// </summary>
                /// <value>
                ///     The outward element is the first half of the postcode
                ///     eg for DN16 1AB it would be DN16
                /// </value>
                /// <remarks>Same as <see cref="District" /></remarks>
                public string Outward
                {
                    get => District;
                    set
                    {
                        // do nowt
                    }
                }

                // Extra functionality added SE Sept 2015

                /// <summary>
                ///     Gets the padded post code.
                /// </summary>
                /// <value>
                ///     The padded post code is the post code with spaces added so that the
                ///     whole post code is 8 characters wide. The spaces will always be between the
                ///     two elements of the code eg 'DN1 2AB' becomes 'DN1  2AB' (ie two spaces)
                /// </value>
                public string PaddedPostCode()
                    {
                        if (IsUkValid())
                            {
                                return Outward.PadRight(5) + Inward;
                            }

                        return "";
                    }

                /// <inheritdoc />
                public string ShortPostCode() => Outward + Inward;

                /// <summary>
                ///     Gets or sets the sector.
                /// </summary>
                /// <value>
                ///     The sector element of the post code is the outward element
                ///     plus the numeric part of the inward element
                ///     eg for DN16 1AB it will be DN16 1
                /// </value>
                /// <remarks> in all cases this is simply a case or removing the last two characters</remarks>
                public string Sector
                {
                    get
                    {
                        if (IsUkValid())
                            {
                                return Value.Substring(0,
                                    Value.Length - 2);
                            }

                        return "";
                    }
                    set
                    {
                        // do nothing
                    }
                }

                /// <summary>
                ///     Is the post code unknown
                /// </summary>
                /// <value>
                ///     Flag to indicate if the post code is an unknown one or not, equivalent to UK validity
                /// </value>
                public bool Unknown
                {
                    get => !IsUkValid();
                    set { }
                }

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                /// <value>
                ///     The actual post code value supplied
                /// </value>
                public string Value
                {
                    get => _value;
                    set => _value = CleanPostCode(value).ToUpper(CultureInfo.InvariantCulture);
                }

                /// <summary>
                ///     Gets or sets a value indicating whether this instance is active.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
                /// </value>
                public static bool? IsActive() => null;


                /// <summary>
                ///     Gets or sets a value indicating whether this instance is dummy.
                /// </summary>
                /// <value>
                ///     <c>true</c> if this instance is dummy; otherwise, <c>false</c>.
                /// </value>
                public static bool? IsDummy() => null;

                /// <summary>
                ///     Gets the is northlincs.
                /// </summary>
                /// <value>
                ///     The is northlincs.
                /// </value>
                public static bool? IsNorthlincs() => null;

                private void SetPostCode(string postcode)
                    {
                        if (string.IsNullOrEmpty(postcode))
                            {
                                Value = "";
                            }
                        else
                            {
                                var valid = postcode.IsValidUkPostCode();
                                Value = valid ? postcode.Trim() : CleanPostCode(postcode);
                            }
                    }

                /// <summary>
                ///     Clean up a postcode
                /// </summary>
                /// <param name="postcode">postcode to clean</param>
                /// <returns>standard formatted postcode with a single space</returns>
                /// <remarks>returns a string containing a postcode with just one space</remarks>
                private string CleanPostCode(string postcode)
                    {
                        postcode = postcode.Trim();
                        if (postcode.Length >= 5)
                            {
                                try
                                    {
                                        int startLen;
                                        do
                                            {
                                                // handle multiple mid spaces
                                                startLen = postcode.Length;
                                                postcode = postcode.ReplaceAll("  ",
                                                    " ");
                                            } while (startLen != postcode.Length);

                                        if (postcode.Length > 8)
                                            {
                                                return "";
                                            }

                                        var result = postcode.ReplaceAll(" ", "");
                                        var word2 = result.Right(3);
                                        var word1 = result.Substring(0,
                                            result.Length - 3).Trim();

                                        return word1 + " " + word2;
                                    }
                                catch
                                    {
                                        // something went wrong
                                        return string.Empty;
                                    }
                            }

                        // invalid so set null
                        return string.Empty;
                    }
            }
    }