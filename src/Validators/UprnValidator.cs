//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UprnValidator.cs company="North Lincolnshire Council">
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