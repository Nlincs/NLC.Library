//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=CRMReference.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:15 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NLC.Library.Extensions;
using NLC.Library.Interfaces;

namespace NLC.Library
    {
        /// <summary>
        ///     CRM Reference
        /// </summary>
        /// <remarks>
        ///     The format is validated against the standard definition
        /// </remarks>
        public sealed class CrmReference : ICrmReference
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value"></param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(int value) => Value = value.ToString();

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value"></param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(long value) => Value = value.ToString();

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference() => Value = "";

                /// <summary>
                ///     Initializes a new instance of the <see cref="CrmReference" /> class.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <exception cref="System.NotImplementedException">Not implemented</exception>
                public CrmReference(string value) => Value = value;

                /// <summary>
                ///     Gets or sets the value.
                /// </summary>
                /// <value>
                ///     The value.
                /// </value>
                public string Value { get; set; }

                /// <summary>
                ///     Determines whether this instance is valid.
                /// </summary>
                /// <returns></returns>
                /// <exception cref="System.NotImplementedException">Not Implemented</exception>
                public bool IsValid() => Value != null;

                /// <summary>
                ///     Extract the numeric part of the reference
                /// </summary>
                /// <returns>numeric part of the crm reference as a string, empty if no value</returns>
                /// <remarks>
                ///     Assumes that any non alpha is a prefix only. This finds the first numeric character
                ///     and checks if the rest of the string is a numeric
                /// </remarks>
                public string NumericValue()
                    {
                        if (Value == string.Empty)
                            {
                                return string.Empty;
                            }

                        var result = Value;

                        // assume that any non numeric are a prefix

                        while (result.Length > 0 && !result.Substring(0, 1).IsNumeric())
                            {
                                result = result.Substring(1);
                            }

                        // need length of result so we can restore leading 0 in the output
                        var resultLen = result.Length;

                        return long.TryParse(result, out var output)
                            ? output.ToString().PadLeft(resultLen, '0')
                            : string.Empty;
                    }
            }
    }