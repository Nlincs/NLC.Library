//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UsrnValidator.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:17 - Stephen Ellwood
// 
//  Project : - NLC.Library
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