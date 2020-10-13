//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=PersonValidator.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 06/07/2020 10:01
//  Altered - 06/07/2020 12:35 - Stephen Ellwood
// 
//  Project : - Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Interfaces;

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public class PersonValidator : IPersonValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="person"></param>
                /// <returns></returns>
                public bool ValidPerson(IPerson person) => person.IsValid();

                /// <inheritdoc />
                public bool ValidPerson(string surname, string forename)
                    {
                        var person = new Person {FamilyName = surname, GivenName = forename};
                        return person.IsValid();
                    }
            }
    }