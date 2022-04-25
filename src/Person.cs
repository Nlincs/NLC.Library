//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=Person.cs company="North Lincolnshire Council">
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

using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        /// </summary>
        public class Person : IPerson
            {
                #region Implementation of IPerson

                /// <inheritdoc />
                public string FullName
                {
                    get
                    {
                        var title = Title?.Trim() ?? "";

                        var given = GivenName?.Trim() ?? "";
                        var family = FamilyName?.Trim() ?? "";

                        var result = title;

                        if (result == "")
                            {
                                result = given;
                            }
                        else
                            {
                                if (given != "")
                                    {
                                        result = result + " " + given;
                                    }
                            }

                        if (result == "")
                            {
                                result = FamilyName?.Trim() ?? "";
                            }
                        else
                            {
                                if (family != "")
                                    {
                                        result = result + " " + family;
                                    }
                            }

                        return result;
                    }
                }

                /// <inheritdoc />
                public string Title { get; set; } = "";

                /// <inheritdoc />
                public string GivenName { get; set; } = "";

                /// <inheritdoc />
                public string FamilyName { get; set; } = "";

                /// <inheritdoc />
                public bool IsValid() => GivenName.Trim() + FamilyName.Trim() != "";

                /// <inheritdoc />
                public bool IsAnonymous { get; set; }

                #endregion

                #region "Aliases"

                /// <summary>
                /// </summary>
                public string Surname
                {
                    get => FamilyName;
                    set => FamilyName = value;
                }

                /// <summary>
                /// </summary>
                public string Forename
                {
                    get => GivenName;
                    set => GivenName = value;
                }

                /// <summary>
                /// </summary>
                public string Forenames
                {
                    get => GivenName;
                    set => GivenName = value;
                }

                #endregion
            }
    }