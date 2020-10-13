//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=SimplePerson.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:48 - Stephen Ellwood
// 
//  Project : - Library
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

                #endregion

                #region "Aliases"

                /// <summary>
                /// </summary>
                public string Surname
                {
                    get => FamilyName;
                    set => FamilyName = value;
                }


                public string Forename
                {
                    get => GivenName;
                    set => GivenName = value;
                }

                public string Forenames
                {
                    get => GivenName;
                    set => GivenName = value;
                }

                #endregion
            }
    }