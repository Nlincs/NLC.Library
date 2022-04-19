//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=StringExtensions.cs company="North Lincolnshire Council">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 19/04/2022 11:51 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace NLC.Library.Extensions
    {
        /// <summary> Extensions to String </summary>
        /// <remarks>Extensions to the inbuilt string object</remarks>
        public static class StringExtensions
            {
#if Windows
                /// <summary> Does the file name and path contain valid characters for a windows file </summary>
                /// <param name="fileNameAndPath">The file name and path of interest</param>
                /// <returns>True if all the characters are valid, false otherwise</returns>
                /// <remarks>
                ///     Note that this does not show that the file exists, just that the characters
                ///     in the filename are all valid
                ///     Note also that this is a string extension not FileInfo etc
                /// </remarks>
                public static bool IsValidWindowsFileName(this string fileNameAndPath)
                    {
                        
              
                        if (string.IsNullOrEmpty(fileNameAndPath))
                            {
                                return false;
                            }

                        // taken from http://stackoverflow.com/questions/1014242/valid-filename-check-what-is-the-best-way
                        string fileName;
                        var theDirectory = fileNameAndPath;
                        var p = Path.DirectorySeparatorChar;
                        var splitPath = fileNameAndPath.Split(p);
                        if (splitPath.Length > 1)
                            {
                                fileName = splitPath[splitPath.Length - 1];
                                theDirectory = string.Join(p.ToString(),
                                    splitPath,
                                    0,
                                    splitPath.Length - 1);
                            }
                        else
                            {
                                fileName = fileNameAndPath.Trim();
                            }

                        if (Path.GetInvalidFileNameChars().Any(c => fileName.Contains(c.ToString())))
                            {
                                return false;
                            }

                        if (fileName.Trim() == "")
                            {
                                return false;
                            }

                        foreach (var c in Path.GetInvalidPathChars())
                            {
                                if (theDirectory.Contains(c.ToString()))
                                    {
                                        return false;
                                    }
                            }

                        return true;
                 
                    }
#endif
                /// <summary>
                ///     Extract a boolean parameter from a string
                /// </summary>
                /// <param name="myString">The string to examine</param>
                /// <returns>
                ///     nothing if not boolean or there are multiple words, true or false otherwise. If the first letter or word is
                ///     t or y or true or yes then true,if the first word is n or f or no or false then false, anything else including a
                ///     null
                ///     or empty string return nothing
                /// </returns>
                /// <remarks>
                ///     Only the first word is considered.
                ///     The values 0 for false and 1 for true are ignored to minimise confusion
                /// </remarks>
                public static bool? BooleanValue(this string myString)
                    {
                        if (string.IsNullOrEmpty(myString))
                            {
                                return null;
                            }

                        if (WordCount(myString) != 1)
                            {
                                return null;
                            }

                        // first try standard .net parsing
                        if (string.IsNullOrEmpty(myString))
                            {
                                return null;
                            }
                        // .net can't parse it so we take a look at the first characters of the string

                        var firstWord = myString.Trim().FirstWord().ToUpper(CultureInfo.InvariantCulture);

                        switch (firstWord.ToUpper(CultureInfo.InvariantCulture))
                            {
                                case "TRUE":
                                case "YES":
                                case "T":
                                case "Y":
                                    return true;
                                case "FALSE":
                                case "NO":
                                case "F":
                                case "N":
                                    return false;
                                default:
                                    return null;
                            }
                    }

                /// <summary>
                ///     First word
                /// </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <returns>
                ///     the string up to the first occurence of the seperator, if the first characters are equal to the seperator then
                ///     an empty string will be returned
                /// </returns>
                /// <remarks>Returns the first word in a given paragraph</remarks>
                public static string FirstWord(this string paragraph) => FirstWord(paragraph, " ");

                /// <summary>
                ///     First word
                /// </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <param name="wordSeperator">The word seperator</param>
                /// <returns>
                ///     the string up to the first occurence of the seperator, if the first characters are equal to the seperator then
                ///     an empty string will be returned
                /// </returns>
                /// <remarks>Returns the first word in a given paragraph</remarks>
                public static string FirstWord(this string paragraph,
                    string wordSeperator)
                    {
                        var words = paragraph.Split(wordSeperator.ToCharArray());
                        return words[0];
                    }

                /// <summary>
                ///     Instr
                /// </summary>
                /// <param name="stringToBeSearched">The string to be searched.</param>
                /// <param name="stringToLookFor">The string to look for.</param>
                /// <returns>The C# equivalent of the vb function</returns>
                public static int InStr(this string stringToBeSearched,
                    string stringToLookFor) =>
                    stringToBeSearched.IndexOf(stringToLookFor,
                        StringComparison.Ordinal) +
                    1;

                /// <summary>
                ///     Determines if the string holds only alphabetic characters
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>True if the string only contains alphabetic characters, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     Checks that only the letters of the alphabet are in a string, i.e. no numbers or special characters or spaces etc.
                ///     <seealso cref="IsAlphabeticCharacter"></seealso>
                /// </remarks>
                public static bool IsAlphabetic(this string stringToTest)
                    {
                        var result = true;
                        if (string.IsNullOrEmpty(stringToTest))
                            {
                                return false;
                            }

                        try
                            {
                                for (var f = 0; f <= stringToTest.Length - 1; f++)
                                    {
                                        var alphaResult = IsAlphabeticCharacter(stringToTest[f].ToString());
                                        result = result && alphaResult;
                                    }

                                return result;
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if the character string holds a single alphabetic character
                /// </summary>
                /// <param name="charToTest">The character string to check</param>
                /// <returns>
                ///     True if the character is alphabetic, false if not, or if the string is not one character or an exception
                ///     occurs
                /// </returns>
                /// <remarks>
                ///     Checks a single character string to see if it is alphabetic, i.e. no numbers or special characters or spaces etc.
                ///     <seealso cref="IsAlphabetic"></seealso>
                /// </remarks>
                public static bool IsAlphabeticCharacter(this string charToTest)
                    {
                        try
                            {
                                if (charToTest.Length != 1)
                                    {
                                        return false;
                                    }

                                var c = charToTest[0];
                                return char.IsLetter(c);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if the string holds only alphanumeric characters
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>True if the string only contains alphanumeric characters, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     Checks that only alphanumerics are in a string, i.e.no special characters or spaces etc.
                ///     <seealso cref="IsAlphabeticCharacter"></seealso>
                /// </remarks>
                public static bool IsAlphaNumeric(this string stringToTest)
                    {
                        var result = true;
                        if (string.IsNullOrEmpty(stringToTest))
                            {
                                return false;
                            }

                        try
                            {
                                for (var f = 0; f <= stringToTest.Length - 1; f++)
                                    {
                                        bool? alphaResult = IsAlphaNumericCharacter(stringToTest[f].ToString());

                                        result = result && alphaResult.Value;
                                    }

                                return result;
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if the character string holds a single alphanumeric character
                /// </summary>
                /// <param name="charToTest">The character string to check</param>
                /// <returns>
                ///     True if the character is alphanumeric, false if not or if the string is not one character or an
                ///     exception occurs
                /// </returns>
                /// <remarks>
                ///     Checks a single character string to see if it is alphabetic or numeric, i.e. no special characters or spaces etc.
                ///     <seealso cref="IsAlphabetic"></seealso>
                /// </remarks>
                public static bool IsAlphaNumericCharacter(this string charToTest)
                    {
                        try
                            {
                                if (charToTest.Length != 1)
                                    {
                                        return false;
                                    }

                                var c = charToTest[0];
                                return char.IsLetterOrDigit(c);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if the string holds an integer value
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>True if the string contains a integer, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     <seealso cref="IsLong"></seealso>
                /// </remarks>
                public static bool IsInteger(this string stringToTest)
                    {
                        try
                            {
                                return int.TryParse(stringToTest,
                                    out _);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if the string holds a long integer value
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>True if the string contains a long integer, false if not, nothing if an exception occurs</returns>
                /// <remarks>
                ///     <seealso cref="IsLong"></seealso>
                /// </remarks>
                public static bool IsLong(this string stringToTest)
                    {
                        try
                            {
                                return long.TryParse(stringToTest,
                                    out _);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if a string holds a numeric value
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>
                ///     True if the string contains a number,
                ///     false if not, nothing if an exception occurs
                /// </returns>
                public static bool IsNumeric(this string stringToTest)
                    {
                        try
                            {
                                return double.TryParse(stringToTest,
                                    out _);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary> Determines if the character string holds a single digit character </summary>
                /// <param name="charToTest">The character string to check</param>
                /// <returns>
                ///     True if the character is numeric, false if not or if the string is not one character or an exception
                ///     occurs
                /// </returns>
                /// <remarks>
                ///     Checks a single character string to see if it is numeric, i.e. no alpha or special characters or spaces etc.
                ///     <seealso cref="IsAlphabetic"></seealso>
                /// </remarks>
                public static bool IsNumericCharacter(this string charToTest)
                    {
                        try
                            {
                                if (charToTest.Length != 1)
                                    {
                                        return false;
                                    }

                                var c = charToTest[0];
                                return char.IsDigit(c);
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Determines if a string holds all numeric characters
                /// </summary>
                /// <param name="stringToTest">The string to check</param>
                /// <returns>
                ///     True if the string contains only numeric characters,
                ///     false if not or if an exception occurs
                /// </returns>
                /// <remarks></remarks>
                public static bool IsNumericCharacters(this string stringToTest)
                    {
                        var result = true;

                        if (string.IsNullOrEmpty(stringToTest))
                            {
                                return false;
                            }

                        try
                            {
                                for (var f = 0; f <= stringToTest.Length - 1; f++)
                                    {
                                        var numResult = char.IsDigit(stringToTest[f]);

                                        result = result && numResult;
                                    }

                                return result;
                            }
                        catch
                            {
                                return false;
                            }
                    }

                /// <summary>
                ///     Does the input include unicode
                /// </summary>
                /// <param name="input">the string of interest</param>
                /// <returns>
                ///     true if there is a unicode character in the string.
                /// </returns>
                public static bool IsUnicode(this string input)
                    {
                        var result = false;
                        var chars = input.ToCharArray();

                        foreach (var item in chars)
                            {
                                result = result || IsUnicode(item);
                            }

                        return result;
                    }

                /// <summary>
                ///     Is the input a Unicode character
                /// </summary>
                /// <param name="input">the char of interest</param>
                /// <returns>
                ///     true if the input is a unicode character, false otherwise
                /// </returns>
                public static bool IsUnicode(this char input) => input > 127;

                /// <summary>
                ///     Remove Unicode characters
                /// </summary>
                /// <param name="input">the string of interest</param>
                /// <returns>
                ///     The input string with no unicode characters
                /// </returns>
                /// <remarks>
                ///     Unicode characters are any over 127
                /// </remarks>
                public static string ReplaceUnicode(this string input)
                    {
                        var chars = input.ToCharArray();
                        var result = new StringBuilder();

                        foreach (var item in chars)
                            {
                                if (!IsUnicode(item))
                                    {
                                        result.Append(item.ToString());
                                    }
                            }

                        return result.ToString();
                    }

                /// <summary>
                ///     Remove Unicode from string
                /// </summary>
                /// <param name="input">The string of interest</param>
                /// <returns></returns>
                public static string RemoveUnicode(this string input)
                    {
                        var chars = input.ToCharArray();
                        var result = new StringBuilder();

                        foreach (var item in chars)
                            {
                                if (!IsUnicode(item))
                                    {
                                        result.Append(item.ToString());
                                    }
                            }

                        return result.ToString();
                    }

                /// <summary>
                ///     Replace Unicode characters with a string
                /// </summary>
                /// <param name="input">the string of interest</param>
                /// <param name="replaceWith">The string to replace the unicode characters with</param>
                /// <returns>
                ///     The input string with all unicode characters exchanged for a string
                /// </returns>
                /// <remarks>
                ///     Unicode characters are any over 127
                /// </remarks>
                public static string ReplaceUnicode(this string input, string replaceWith)
                    {
                        if (replaceWith.Trim() == "")
                            {
                                return input.ReplaceUnicode();
                            }

                        var chars = input.ToCharArray();
                        var result = new StringBuilder();

                        foreach (var item in chars)
                            {
                                result.Append(IsUnicode(item) ? replaceWith : item.ToString());
                            }

                        return result.ToString();
                    }

                /// <summary> Last Word </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <returns>
                ///     String, if the last characters of the input paragraph is equal to the seperator then an empty string is
                ///     returned
                /// </returns>
                /// <remarks>Returns the last word from the paragraph using WordSeperator to terminate words</remarks>
                public static string LastWord(this string paragraph) => LastWord(paragraph, " ");

                /// <summary> Last Word </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <param name="wordSeperator">The word seperator</param>
                /// <returns>
                ///     String, if the last characters of the input paragraph is equal to the seperator then an empty string is
                ///     returned
                /// </returns>
                /// <remarks>Returns the last word from the paragraph using WordSeperator to terminate words</remarks>
                public static string LastWord(this string paragraph,
                    string wordSeperator)
                    {
                        // if the seperator is too long we handle it here
                        if (wordSeperator.Length > paragraph.Length)
                            {
                                return paragraph;
                            }

                        // now check that the paragraph doesn't end with a seperator
                        // if it does then the last word is clearly null
                        var sepLen = wordSeperator.Length;
                        var paraLen = paragraph.Length;

                        if (paragraph.Substring(paraLen - sepLen) == wordSeperator)
                            {
                                return "";
                            }

                        var words = paragraph.Split(wordSeperator.ToCharArray());
                        var c = words.Length;
                        return words[c - 1];
                    }

                /// <summary> LTrim </summary>
                /// <param name="textToTrim">String to be trimmed</param>
                /// <param name="seperator">character string to be trimmed</param>
                /// <returns>string with any leading multiple seperators remvoved</returns>
                /// <remarks>similar to standard LTrim function but considers characters other than spaces</remarks>
                public static string LTrim(this string textToTrim,
                    string seperator)
                    {
                        // do nothing
                        if (seperator.Length > textToTrim.Length)
                            {
                                return textToTrim;
                            }

                        if (seperator.Length == 0 || textToTrim.Length == 0)
                            {
                                return textToTrim;
                            }

                        var result = textToTrim;

                        while (result.Substring(0,
                                   seperator.Length) ==
                               seperator)
                            {
                                if (result == seperator)
                                    {
                                        result = "";
                                        break;
                                    }

                                result = result.Substring(seperator.Length);
                            }

                        return result;
                    }

                /// <summary> Nth Word </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <param name="n">positive integer indicating which word to return</param>
                /// <returns>String</returns>
                /// <remarks>Returns the Nth word from the paragraph using WordSeperator to terminate words</remarks>
                public static string NthWord(this string paragraph,
                    int n) =>
                    NthWord(paragraph, n, " ");

                /// <summary> Nth Word </summary>
                /// <param name="paragraph">The paragraph to search</param>
                /// <param name="n">positive integer indicating which word to return</param>
                /// <param name="wordSeperator">The word seperator</param>
                /// <returns>String</returns>
                /// <remarks>Returns the Nth word from the paragraph using WordSeperator to terminate words</remarks>
                public static string NthWord(this string paragraph,
                    int n,
                    string wordSeperator)
                    {
                        var words = paragraph.Split(wordSeperator.ToCharArray());

                        if (n < 1)
                            {
                                return null;
                            }

                        return words.Length >= n ? words[n - 1] : null;
                    }

                // Pretty print XML

                /// <summary>
                ///     Pretty XML
                /// </summary>
                /// <param name="xml">the string to format, this should be valid xml in a string</param>
                /// <returns>a string containing the formatted xml</returns>
                /// <remarks>This is a pretty print function, in that it formats the string</remarks>
                public static string PrettyXml(this string xml)
                    {
                        var stringBuilder = new StringBuilder();

                        try
                            {
                                var element = XElement.Parse(xml);
                                var settings = new XmlWriterSettings
                                    {
                                        OmitXmlDeclaration = true, Indent = true, NewLineOnAttributes = true
                                    };

                                using (var xmlWriter = XmlWriter.Create(stringBuilder,
                                           settings))
                                    {
                                        element.Save(xmlWriter);
                                    }

                                return stringBuilder.ToString();
                            }
                        catch (Exception)
                            {
                                return xml;
                            }
                    }

                /// <summary>
                ///     Replace all instances of one substring with another
                /// </summary>
                /// <param name="stringToSearch">
                ///     The string that is going to have its contents replaced
                /// </param>
                /// <param name="stringToReplace">
                ///     The string that you want to replace
                /// </param>
                /// <param name="replaceWith">
                ///     The string to use as a replacement
                /// </param>
                /// <returns>
                ///     string
                /// </returns>
                /// <remarks>
                ///     Replaces all values of StringToReplace with the value ReplaceWith in StringToSearch, and repeats for multiples so
                ///     replacing 'aa' with 'a' would turn 'aaaa' into 'aa'
                ///     This is the standard string.replace functionality
                /// </remarks>
                public static string ReplaceAll(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith) =>
                    stringToSearch.Replace(stringToReplace,
                        replaceWith);

                /// <summary> Replace All instances after a certain point </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="startFrom">The position of the first character to use in the replacement</param>
                /// <returns>
                ///     Starting from the Nth character of StringToSearch (where N = StartFrom) replace all instances of StringToReplace
                ///     with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAll"></seealso>
                /// </remarks>
                public static string ReplaceAllFrom(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int startFrom)
                    {
                        if (startFrom > stringToSearch.Length)
                            {
                                return stringToSearch;
                            }

                        if (startFrom < 1)
                            {
                                startFrom = 1;
                            }

                        // split the string into 2 then do normal replace
                        var part1 = stringToSearch.Substring(0,
                            startFrom - 1);
                        var part2 = Right(stringToSearch,
                            stringToSearch.Length - part1.Length);

                        // now we can do the replace on part2 only then rejoin the string
                        part2 = ReplaceAll(part2,
                            stringToReplace,
                            replaceWith);

                        return part1 + part2;
                    }

                /// <summary> Replace all instances in the middle of a string </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="startFrom">The position of the first character to use in the replacement</param>
                /// <param name="upTo">The position of the last character to use in the replacement</param>
                /// <returns>
                ///     Starting with the Mth and ending with the Nth character of StringToSearch (where M = StartFrom and N = UpTo)
                ///     replace all instances of StringToReplace with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAll"></seealso>
                /// </remarks>
                public static string ReplaceAllMid(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int startFrom,
                    int upTo)
                    {
                        // no work needed
                        if (startFrom > upTo)
                            {
                                return stringToSearch;
                            }

                        if (startFrom > stringToSearch.Length)
                            {
                                return stringToSearch;
                            }

                        if (startFrom < 1)
                            {
                                startFrom = 1;
                            }

                        if (upTo < 1)
                            {
                                return stringToSearch;
                            }

                        if (upTo > stringToSearch.Length)
                            {
                                upTo = stringToSearch.Length;
                            }

                        // split the string into 3 then do normal replace

                        var part1 = stringToSearch.Substring(0,
                            startFrom - 1);
                        var part2 = stringToSearch.Substring(startFrom - 1,
                            upTo - startFrom);
                        var part3 = Right(stringToSearch,
                            stringToSearch.Length - (part1.Length + part2.Length));

                        // now we can do the replace on part2 only then rejoin the string
                        part2 = ReplaceAll(part2,
                            stringToReplace,
                            replaceWith);

                        return part1 + part2 + part3;
                    }

                /// <summary> Replace all instances up to a certain point </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="upTo">The position of the last character to use in the replacement - 0 based</param>
                /// <returns>
                ///     Ending with the Nth character of StringToSearch (where N = UpTo) replace all instances of StringToReplace
                ///     with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAll"></seealso>
                /// </remarks>
                public static string ReplaceAllTo(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int upTo)
                    {
                        if (upTo < 1)
                            {
                                return stringToSearch;
                            }

                        if (upTo > stringToSearch.Length)
                            {
                                upTo = stringToSearch.Length;
                            }

                        // split the string into 2 then do normal replace
                        var part1 = stringToSearch.Substring(0,
                            upTo - 1);
                        var part2 = Right(stringToSearch,
                            stringToSearch.Length - part1.Length);

                        // now we can do the replace on part2 only then rejoin the string
                        part1 = ReplaceAll(part1,
                            stringToReplace,
                            replaceWith);

                        return part1 + part2;
                    }

                /// <summary> Replace All Duplicated spaces </summary>
                /// <param name="stringToSearch">The string of interest</param>
                /// <returns>string e.g. "    " becomes " "</returns>
                /// <remarks>Replaces all multiple space instances with a single space</remarks>
                public static string ReplaceDuplicateSpaces(this string stringToSearch)
                    {
                        if (stringToSearch.Length < 2)
                            {
                                return stringToSearch; // too short for duplication 
                            }

                        while (stringToSearch.IndexOf("  ", StringComparison.Ordinal) != -1)
                            {
                                stringToSearch = stringToSearch.ReplaceAll("  ",
                                    " ");
                            }

                        return stringToSearch;
                    }

                /// <summary> Replace instances after a certain point </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="startFrom">The position of the first character to use in the replacement</param>
                /// <returns>
                ///     Starting from the Nth character of StringToSearch (where N = StartFrom) replace all instances of StringToReplace
                ///     with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAllFrom" />
                /// </remarks>
                public static string ReplaceFrom(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int startFrom) =>
                    ReplaceAllFrom(stringToSearch,
                        stringToReplace,
                        replaceWith,
                        startFrom);

                /// <summary> Replace instances in the middle of a string </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="startFrom">The position of the first character to use in the replacement</param>
                /// <param name="upTo">The position of the last character to use in the replacement</param>
                /// <returns>
                ///     Starting with the Mth and ending with the Nth character of StringToSearch (where M = StartFrom and N = UpTo)
                ///     replace all instances of StringToReplace with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAllMid" />
                /// </remarks>
                public static string ReplaceMid(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int startFrom,
                    int upTo) =>
                    ReplaceAllMid(stringToSearch,
                        stringToReplace,
                        replaceWith,
                        startFrom,
                        upTo);

                /// <summary> Replace instances up to a certain point </summary>
                /// <param name="stringToSearch">The string that is going to have some of its contents replaced</param>
                /// <param name="stringToReplace">The string you want to replace</param>
                /// <param name="replaceWith">The string to use as a replacement</param>
                /// <param name="upTo">The position of the last character to use in the replacement</param>
                /// <returns>
                ///     Ending with the Nth character of StringToSearch (where N = UpTo) replace all instances of StringToReplace
                ///     with ReplaceWith
                /// </returns>
                /// <remarks>
                ///     <seealso cref="ReplaceAllTo" />
                /// </remarks>
                public static string ReplaceTo(this string stringToSearch,
                    string stringToReplace,
                    string replaceWith,
                    int upTo) =>
                    ReplaceAllTo(stringToSearch,
                        stringToReplace,
                        replaceWith,
                        upTo);

                /// <summary>
                ///     Is Whitespace
                /// </summary>
                /// <param name="character">character to check</param>
                /// <returns>true if the character is classed as whitespace, false otherwise</returns>
                /// <remarks>
                ///     extends the IsWhitespace built in funcitonality to include other non printing characters
                ///     There are other valid unicode whitespace characters but they aren't considered here
                /// </remarks>
                public static bool IsWhitespace(this char character) =>
                    character.Equals('\x0') || character.Equals('\x8') || character.Equals('\x9') ||
                    character.Equals('\u0010') || character.Equals('\u0011') || character.Equals('\u0012') ||
                    character.Equals('\u0013') || character.Equals(' ') || character.Equals('\u0133') ||
                    character.Equals('\u0160') || character.Equals('\n') || character.Equals('\r') ||
                    character.Equals('\t');

                /// <summary>
                ///     Is All Whitespace
                /// </summary>
                /// <param name="characters">The string to check</param>
                /// <returns>true is all the characters in the input are whitespace, false otherwise</returns>
                /// <remarks>
                ///     <seealso cref="IsWhitespace" />
                /// </remarks>
                public static bool IsAllWhitespace(this string characters)
                    {
                        foreach (var c in characters)
                            {
                                if (!c.IsWhitespace())
                                    {
                                        return false;
                                    }
                            }

                        return true;
                    }

                /// <summary> Replaces all occurences of whitespace with a specific character string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <param name="replaceWith">The character(s) to replace the whitespace, defaults to CivicaParagraphSeperator</param>
                /// <returns>The original string with whitespace replaced by the ReplaceWith parameter</returns>
                /// <remarks>checks for most of the ascii values in the range 8-13 (ish)</remarks>
                public static string ReplaceWhitespace(this string replaceIn,
                    string replaceWith) =>
                    ReplaceWhitespace(replaceIn, replaceWith, true);

                /// <summary> Replaces all occurences of whitespace with a specific character string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <param name="replaceWith">The character(s) to replace the whitespace, defaults to CivicaParagraphSeperator</param>
                /// <param name="ReplaceSpace">should spaces be replaced</param>
                /// <returns>The original string with whitespace replaced by the ReplaceWith parameter</returns>
                /// <remarks>checks for most of the ascii values in the range 8-13 (ish)</remarks>
                public static string ReplaceWhitespace(this string replaceIn,
                    string replaceWith, bool ReplaceSpace)
                    {
                        var results = new StringBuilder();
                        string sResults;
                        if (ReplaceSpace)
                            {
                                foreach (var c in replaceIn)
                                    {
                                        results.Append(c.IsWhitespace() ? replaceWith : c.ToString());
                                    }

                                sResults = results.ToString();
                            }
                        else
                            {
                                // this is the original version that is used as part of the civica integration
                                // this version (as you can see) won't replace spaces
                                sResults = replaceIn.Replace((char)13 + ((char)10).ToString(), replaceWith); //vbCrLf
                                sResults = sResults.Replace(((char)13).ToString(), replaceWith); //vbCr
                                sResults = sResults.Replace(((char)10).ToString(), replaceWith); //vbLf
                                sResults = sResults.Replace(((char)9).ToString(), replaceWith); //vbTab
                                //results = results.Replace(((char)10).ToString(), replaceWith); //vbNewLine
                                sResults = sResults.Replace(((char)0).ToString(), replaceWith); //vbNullChar
                                //results = results.Replace(((char)10).ToString(), replaceWith); //vbFormFeed
                                sResults = sResults.Replace(((char)11).ToString(), replaceWith); //vbVerticalTab
                                sResults = sResults.Replace(((char)8).ToString(), replaceWith); //vbBack
                            }

                        return sResults;
                    }

                // Taken from www.dotnetperls.com/right
                // =======================================================

                /// <summary> Rights the specified length. </summary>
                /// <param name="value">The value.</param>
                /// <param name="length">The length.</param>
                /// <returns>C# equivalent to the VB right function on strings</returns>
                public static string Right(this string value,
                    int length)
                    {
                        if (length <= 0)
                            {
                                return value;
                            }

                        return length <= value.Length ? value.Substring(value.Length - length) : value;
                    }

                /// <summary> RTrim </summary>
                /// <param name="textToTrim">String to be trimmed</param>
                /// <param name="seperator">character string to be trimmed</param>
                /// <returns>string with any trailing multiple seperators remvoved</returns>
                /// <remarks>similar to standard RTrim function but considers characters other than spaces</remarks>
                public static string RTrim(this string textToTrim,
                    string seperator)
                    {
                        if (seperator.Length > textToTrim.Length)
                            {
                                return textToTrim;
                            }

                        if (seperator.Length == 0 || textToTrim.Length == 0)
                            {
                                return textToTrim;
                            }

                        var result = textToTrim;

                        while (result.Substring(result.Length - seperator.Length) == seperator)
                            {
                                if (result == seperator)
                                    {
                                        result = "";
                                        break;
                                    }

                                result = result.Substring(0,
                                    result.Length - seperator.Length);
                            }

                        return result;
                    }

                /// <summary> Removes any of a set of characters from a string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <param name="replaceChars">The character(s) to be removed</param>
                /// <returns>The original string with all the characters from the ReplaceChars string removed</returns>
                /// <remarks>
                ///     Any of the characters in ReplaceChars wil lbe removed from the ReplaceIn string,
                ///     primarily intended for sanitising user input i.e. removing any characters that are not meant to be
                ///     used
                /// </remarks>
                public static string Sanitise(this string replaceIn,
                    string replaceChars) =>
                    replaceChars.Aggregate(replaceIn,
                        (current,
                            c) => current.Replace(c.ToString(),
                            ""));

                /// <summary> Removes any non Alphanumeric characters from a string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <returns>The original string with all the non alphanumeric characters removed</returns>
                /// <remarks>
                ///     Any non alphanumeric characters (including spaces) will be removed from the ReplaceIn string,
                ///     primarily intended for sanitising user input i.e. removing any characters that are not meant to be
                ///     used e.g. before going to SQL Server
                /// </remarks>
                public static string SanitiseNonAlphaNum(this string replaceIn)
                    {
                        var results = new StringBuilder();
                        int i;

                        for (i = 0; i <= replaceIn.Length - 1; i++)
                            {
                                if (char.IsLetterOrDigit(replaceIn,
                                        i))
                                    {
                                        results.Append(replaceIn[i]);
                                    }
                            }

                        return results.ToString();
                    }

                /// <summary> Removes any non Alphanumeric characters from a string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <param name="keepSpaces">Boolean, true to keep spaces, false to remove them</param>
                /// <returns>The original string with all the non alphanumeric characters (optionally apart from spaces) removed</returns>
                /// <remarks>
                ///     Any non alphanumeric characters (optionally apart from spaces) will be removed from the ReplaceIn string,
                ///     primarily intended for sanitising user input i.e. removing any characters that are not meant to be
                ///     used e.g. before going to SQL Server
                /// </remarks>
                public static string SanitiseNonAlphaNum(this string replaceIn,
                    bool keepSpaces)
                    {
                        if (keepSpaces == false)
                            {
                                return SanitiseNonAlphaNum(replaceIn);
                            }

                        // if we get here we want to keep spaces
                        var sResults = new StringBuilder();

                        int i;

                        for (i = 0; i <= replaceIn.Length - 1; i++)
                            {
                                if (char.IsLetterOrDigit(replaceIn,
                                        i) ||
                                    replaceIn[i] == ' ')
                                    {
                                        sResults.Append(replaceIn[i]);
                                    }
                            }

                        return sResults.ToString();
                    }

                /// <summary> Removes any non Alphanumeric characters from a string </summary>
                /// <param name="replaceIn">The string that is to have text replaced</param>
                /// <param name="keepSpaces">Boolean, true to keep spaces, false to remove them</param>
                /// <param name="keepSimplePunctuation">Boolean, true to keep full stops and comma's, false to remove them</param>
                /// <returns>
                ///     The original string with all the non alphanumeric characters (optionally apart from spaces and/or commas and
                ///     full stops) removed
                /// </returns>
                /// <remarks>
                ///     Any non alphanumeric characters (optionally apart from spaces) will be removed from the ReplaceIn string,
                ///     primarily intended for sanitising user input i.e. removing any characters that are not meant to be
                ///     used e.g. before going to SQL Server
                /// </remarks>
                public static string SanitiseNonAlphaNum(this string replaceIn,
                    bool keepSpaces,
                    bool keepSimplePunctuation)
                    {
                        if (keepSimplePunctuation == false)
                            {
                                return SanitiseNonAlphaNum(replaceIn,
                                    keepSpaces);
                            }

                        if (keepSpaces)
                            {
                                // if we get here we must require punctuation, so it's just whether we keep spaces or not

                                // if we get here we want to keep spaces
                                var results = new StringBuilder();
                                int i;

                                for (i = 0; i <= replaceIn.Length - 1; i++)
                                    {
                                        if (char.IsLetterOrDigit(replaceIn,
                                                i) ||
                                            replaceIn[i] == ' ' ||
                                            replaceIn[i] == '.' ||
                                            replaceIn[i] == ',')
                                            {
                                                results.Append(replaceIn[i]);
                                            }
                                    }

                                return results.ToString();
                            }
                        else
                            {
                                // if we get here we don't want to keep spaces
                                var results = new StringBuilder();
                                int i;

                                for (i = 0; i <= replaceIn.Length - 1; i++)
                                    {
                                        if (char.IsLetterOrDigit(replaceIn,
                                                i) ||
                                            replaceIn[i] == '.' ||
                                            replaceIn[i] == ',')
                                            {
                                                results.Append(replaceIn[i]);
                                            }
                                    }

                                return results.ToString();
                            }
                    }

                /// <summary> Trims the specified string to trim. </summary>
                /// <param name="stringToTrim">The string to trim.</param>
                /// <returns></returns>
                public static string Trim(this string stringToTrim) => stringToTrim.Trim();

                /// <summary> Trim </summary>
                /// <param name="textToTrim">String to be trimmed</param>
                /// <param name="seperator">character string to be trimmed</param>
                /// <returns>string with any leading or trailing multiple seperators remvoved</returns>
                /// <remarks>similar to standard Trim function but considers characters other than spaces</remarks>
                public static string Trim(this string textToTrim,
                    string seperator) =>
                    RTrim(LTrim(textToTrim,
                            seperator),
                        seperator);

                /// <summary> Truncate </summary>
                /// <param name="paragraph">String to truncate</param>
                /// <param name="length">Maximum number of characters to keep</param>
                /// <returns>String Array, Result[0] will contain the truncated paragraph, the remainder will be in Result[1]</returns>
                /// <remarks>
                ///     truncates a string so that words aren't cut in two if possible,
                /// </remarks>
                public static string[] Truncate(this string paragraph,
                    int length) =>
                    Truncate(paragraph,
                        ' ',
                        length);


                /// <summary> Truncate </summary>
                /// <param name="paragraph">String to truncate</param>
                /// <param name="seperator">The word seperator to use, the first character is the only one considered to be seperators</param>
                /// <param name="length">Maximum number of characters to keep</param>
                /// <returns>String Array, Result[0] will contain the truncated paragraph, the remainder will be in Result[1]</returns>
                /// <remarks>
                ///     truncates a string so that words aren't cut in two, A word is defined
                ///     as a sequence of characters delimited by one or more seperators or the start or end of the string
                /// </remarks>
                public static string[] Truncate(this string paragraph,
                    string seperator,
                    int length)
                    {
                        var sep = seperator.ToCharArray();


                        return Truncate(paragraph,
                            sep[0],
                            length);
                    }

                /// <summary> Truncate </summary>
                /// <param name="paragraph">String to truncate</param>
                /// <param name="seperator">The word seperator to use</param>
                /// <param name="length">Maximum number of characters to keep</param>
                /// <returns>List<string></string>, Result[0] will contain the truncated paragraph, the remainder will be in Result[1]</returns>
                /// <remarks>
                ///     truncates a string so that words aren't cut in two, A word is defined
                ///     as a sequence of characters delimited by one or more seperators or the start or end of the string
                /// </remarks>
                public static string[] Truncate(this string paragraph,
                    char seperator,
                    int length)
                    {
                        var result = new string[2];

                        if (paragraph == seperator.ToString())
                            {
                                result[0] = "";
                                return result;
                            }

                        if (paragraph.Length < 1)
                            {
                                result[0] = "";
                                return result;
                            }

                        var parlen = paragraph.Length;

                        // deal with the simple case first
                        if (parlen <= length)
                            {
                                result[0] = paragraph;
                                return result;
                            }


                        // if there is just one word all we can do is cut
                        if (paragraph.WordCount(seperator) == 1)
                            {
                                result[0] = paragraph.Substring(0,
                                    length);
                                result[1] = paragraph.Substring(length,
                                    paragraph.Length - length);
                                return result;
                            }

                        // now we have the case where the char at position length is a seperator
                        // if it is we have our split, same applies for position length -1

                        var parArray = paragraph.ToCharArray();
                        if (parArray[length] == seperator || parArray[length - 1] == seperator)
                            {
                                result[0] = paragraph.Substring(0,
                                    length).RTrim(seperator.ToString());
                                result[1] = paragraph.Substring(length,
                                    paragraph.Length - length).LTrim(seperator.ToString());
                                return result;
                            }

                        // we now know that the character at position length (or length-1) is not a seperator
                        // ie its in the middle of a word

                        var para1 = paragraph.Substring(0,
                            length);
                        var para2 = paragraph.Substring(length,
                            paragraph.Length - length);

                        // get start of word so we can add it back to the remainder
                        var lastOne = para1.LastWord(seperator.ToString());
                        para2 = lastOne + para2;

                        // now remove this from the end of para1
                        para1 = para1.Substring(0,
                            para1.Length - (lastOne.Length + 1));

                        result[0] = para1;
                        result[1] = para2;

                        return result;
                    }

                /// <summary>Simple word count function </summary>
                /// <param name="paragraph">The text to count the words of</param>
                /// <returns>an integer indicating the number of words found</returns>
                /// <remarks>
                ///     This is a very simple count based on the number of spaces, if there is a
                ///     double space it will be ignored in the count
                /// </remarks>
                public static long WordCount(this string paragraph)
                    {
                        // if it only consists of spaces then there are no "words"
                        paragraph = paragraph.Trim();
                        if (paragraph.Length < 1)
                            {
                                return 0;
                            }

                        char[] space = { ' ' };

                        var words = paragraph.Split(space,
                            StringSplitOptions.RemoveEmptyEntries);

                        return words.Length;
                    }

                /// <summary>Simple word count function </summary>
                /// <param name="paragraph">The text to count the words of</param>
                /// <param name="seperator">The chars to use to distinguish between "words"</param>
                /// <returns>an integer indicating the number of words found</returns>
                /// <remarks>
                ///     This is a very simple count based on the number of seperators, if there is a
                ///     double seperator it will be ignored in the word count
                /// </remarks>
                public static long WordCount(this string paragraph,
                    char[] seperator)
                    {
                        var words = paragraph.Split(seperator,
                            StringSplitOptions.RemoveEmptyEntries);

                        return words.Length;
                    }

                /// <summary>Simple word count function </summary>
                /// <param name="paragraph">The text to count the words of</param>
                /// <param name="seperator">The chars to use to distinguish between "words"</param>
                /// <returns>an integer indicating the number of words found</returns>
                /// <remarks>
                ///     This is a very simple count based on the number of seperators, if there is a
                ///     double seperator it will be ignored in the word count
                /// </remarks>
                public static long WordCount(this string paragraph,
                    char seperator)
                    {
                        var sep = new[] { seperator };

                        return WordCount(paragraph,
                            sep);
                    }

                /// <summary>
                ///     CamelCase String splitter
                /// </summary>
                /// <param name="stringToSplit">string to seperate into words</param>
                /// <returns>
                ///     List of strings as determined by the case change
                ///     If the leading character is lower case it will be returned as upper
                /// </returns>
                /// <remarks>
                ///     All credits to Ajith R Nair see
                ///     https://social.msdn.microsoft.com/Forums/en-US/791963c8-9e20-4e9e-b184-f0e592b943b0/split-a-camel-case-string?forum=csharpgeneral
                ///     all issues are my own
                /// </remarks>
                public static List<string> CamelCaseSplit(this string stringToSplit)
                    {
                        var result = new List<string>();
                        var wasPreviousUppercase = false;
                        var current = new StringBuilder();

                        if (string.IsNullOrEmpty(stringToSplit))
                            {
                                result.Add("");
                                return result;
                            }

                        foreach (var c in stringToSplit)
                            {
                                if (char.IsUpper(c))
                                    {
                                        if (wasPreviousUppercase)
                                            {
                                                current.Append(c);
                                            }
                                        else
                                            {
                                                if (current.Length > 0)
                                                    {
                                                        result.Add(current.ToString());
                                                        current.Length = 0;
                                                    }

                                                current.Append(c);
                                            }

                                        wasPreviousUppercase = true;
                                    }
                                else // lowercase
                                    {
                                        if (wasPreviousUppercase && current.Length > 1)
                                            {
                                                var carried = current[current.Length - 1];
                                                --current.Length;
                                                result.Add(current.ToString());
                                                current.Length = 0;
                                                current.Append(carried);
                                            }

                                        wasPreviousUppercase = false;

                                        current.Append(current.Length == 0 ? char.ToUpper(c) : c);
                                    }
                            }

                        if (current.Length > 0)
                            {
                                result.Add(current.ToString());
                            }

                        return result;
                    }

                /// <summary>
                ///     trim leading whitespace and comma's
                /// </summary>
                /// <param name="input"></param>
                /// <returns>string that begins with a character that isn't a space or a comma or is empty, otherwise returns empty string</returns>
                public static string LTrimCSV(this string input)
                    {
                        if (input == null || input.Trim() == "")
                            {
                                return string.Empty;
                            }

                        var counter = 0;
                        var exit = false;

                        do
                            {
                                if (IsCSVDelimiter(input[counter]))
                                    {
                                        counter++;
                                    }
                                else
                                    {
                                        exit = true;
                                    }
                            } while (!exit && counter < input.Length);

                        return input.Substring(counter);
                    }


                /// <summary>
                ///     trim trailing whitespace and comma's
                /// </summary>
                /// <param name="input"></param>
                /// <returns>string that ends with a character that isn't a space or a comma or is empty, otherwise returns empty string</returns>
                public static string RTrimCSV(this string input)
                    {
                        if (input == null || input.Trim() == "")
                            {
                                return string.Empty;
                            }

                        var counter = input.Length - 1;
                        var exit = false;

                        do
                            {
                                if (IsCSVDelimiter(input[counter]))
                                    {
                                        counter--;
                                    }
                                else
                                    {
                                        exit = true;
                                    }
                            } while (!exit && counter >= 0);

                        return input.Substring(0, counter + 1);
                    }

                /// <summary>
                ///     trim leading and trailing whitespace and comma's
                /// </summary>
                /// <param name="input"></param>
                /// <returns>string that ends with a character that isn't a space or a comma or is empty, otherwise returns empty string</returns>
                public static string TrimCSV(this string input)
                    {
                        if (input == null || input.Trim() == "")
                            {
                                return string.Empty;
                            }

                        return LTrimCSV(RTrimCSV(input));
                    }


                /// <summary>
                ///     determines if the input is a elimiter as used in CSV
                /// </summary>
                /// <param name="input"></param>
                /// <returns></returns>
                public static bool IsCSVDelimiter(this char input) => input == ' ' || input == ',';
            }
    }