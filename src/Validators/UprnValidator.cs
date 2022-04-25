//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UprnValidator.cs company="North Lincolnshire Council">
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
        public class UprnValidator : IUprnValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="uprn"></param>
                /// <returns></returns>
                public bool ValidUprn(string uprn)
                    {
                        var _Uprn = new Uprn(uprn);
                        return _Uprn.IsValid();
                    }

                /// <inheritdoc />
                public bool ValidUprn(int Uprn)
                    {
                        var _Uprn = new Uprn(Uprn);
                        return _Uprn.IsValid();
                    }

                /// <inheritdoc />
                public bool ValidUprn(long Uprn)
                    {
                        var _Uprn = new Uprn(Uprn);
                        return _Uprn.IsValid();
                    }
            }
    }