//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UsrnValidator.cs company="North Lincolnshire Council">
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

namespace NLC.Library.Validators
    {
        /// <summary>
        /// </summary>
        public class UsrnValidator : IUsrnValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                public bool ValidUsrn(string usrn)
                    {
                        var _usrn = new Usrn(usrn);
                        return _usrn.IsValid();
                    }

                /// <inheritdoc />
                public bool ValidUsrn(int usrn)
                    {
                        var _usrn = new Usrn(usrn);
                        return _usrn.IsValid();
                    }

                /// <inheritdoc />
                public bool ValidUsrn(long usrn)
                    {
                        var _usrn = new Usrn(usrn);
                        return _usrn.IsValid();
                    }
            }
    }