[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/Nlincs/NLC.Library)

![](https://www.northlincs.gov.uk/nlc-logo-b)

# NLC Code Library

<!-- ![.NET Core](https://github.com/NelNlc/Library/workflows/.NET%20Core/badge.svg) 
[![Build Status](https://dev.azure.com/NLBC/Library/_apis/build/status/NelNlc.Library?branchName=master)](https://dev.azure.com/NLBC/Library/_build/latest?definitionId=3&branchName=master)
[![Build Status](https://travis-ci.org/NelNlc/Library.svg?branch=master)](https://travis-ci.org/NelNlc/Library)
[![Build status](https://ci.appveyor.com/api/projects/status/94xxq3hq0qek8qll?svg=true)](https://ci.appveyor.com/project/ellwoods/library)
[![Known Vulnerabilities](https://snyk.io/test/github/Nlincs/Library/badge.svg?targetFile=src/Library.csproj)](https://snyk.io/test/github/Nlincs/Library?targetFile=src/Library.csproj) -->

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/53beda2ce15e45c8b662363f2c1f1344)](https://www.codacy.com/gh/Nlincs/NLC.Library/dashboard?utm_source=github.com&utm_medium=referral&utm_content=Nlincs/NLC.Library&utm_campaign=Badge_Grade)

Library of extensions and models for netstandard 2.0.
This is the latest c# incarnation of this library. Some of the functionality is now available in standard libraries and can be ignored, it has been left in for legacy reasons in particular where there are slight differences in functionality. The library provides various generic functions e.g. string and DateTime and also provides functions and models based on local governement in the UK, e.g. UPRN, USRN.

## Extensions

### Strings

This is a range of string operations, including a concept of words ie a set of characters with a given delimiter

-   Boolean Value - attempts to determine if a string contains some sort of boolean e.g. "true", "no", "0"
-   Instr - the C# equivalent of the VB function
-   Replace
-   Right - equivalent to the VB function

#### String tests

-   Is Numeric - attempts to determine if a string contains a valid Number
-   Is Numeric Characters - checks for numeric only characters in a String
-   Is Long
-   Is Integer
-   Is Alphabetic - checks for alphabetic only characters - a-z
-   Is Alphabetic character
-   Is Numeric character
-   Is Alphanumeric - checks a string only contains alphanumerics
-   Is Alphanumeric character
-   Is Valid file name - checks that the characters in the file name are valid for Windows
-   Is Unicode
-   Is All Whitespace - checks if all of a string is whitespace

#### Word functions

-   Word Count
-   first Word
-   Nth Word
-   Last Word
-   Truncate - truncates a string so that words aren't chopped off mid Word. Optionally adds an ellipsis too
-   split - returns a string array of the words in the input
-   Camel case split

#### Replace functions

-   Replace All - replaces all instances of a substring in the input
-   Replace All From - Replaces all instances of a substring from the input starting at a specific point in the input
-   Replace To 
-   Replace All To - Replaces all instances of a substring from the input up to a given location
-   Replace Mid - replaces a substring within a substring of the input
-   ReplaceAllMid - replaces all substrings within a substring of the input
-   Replace Whitespace
-   Replace Unicode
-   Remove Unicode
-   LTrim, RTrim
-   Replace Duplicate spaces
-   Sanitise - returns the input with all of the set of characters provided having been removed
-   Sanitise Non Alpha Numerics - attempts to remove all non alphanumerics from the input (optionally keeps spaces, optionally keeps simple punctuation e.g. full stops)

#### string formatting

-   Pretty XML - Takes an XML string and outputs it _prettified_

### DateTime

This includes date calculations and checks. Unless otherwise specified these are based on UK format dates

-   Easter date
-   First Monday of month date
-   ISO Week
-   Last day of month 
-   Last Monday of month date
-   Next Monday date
-   RSSFormat - Format date as RSS style DateTime
-   Between - Determines if a date is between two others
-   Previous 1st April date
-   Is UK English bank holiday
-   Is English bank holiday week - is there an english/welsh bank holiday in this week (starting on the Monday)
-   Is UK English working day - this checks if the day is a weekend or an english/welsh bank holiday
-   Daylight Savings Time UK end - Date that DST ends in the UK
-   Daylight Savings Time UK start - Start of DST in the UK
-   Is in daylight savings time UK
-   Is Date
-   Is Any Date - checks if date, including Unix style dates

### Enumerable

-   Pick Random
-   Shuffle
-   Split To list - split into fixed size pages, possibly with some remainder in the final page
-   Split to buckets - splits an enumerable into sublists of equal size with the remainder being distributed equally

### Uri

-   Is Bookmark
-   Relative to absolute
-   Is page bookmark - is a link to a bookmark on the same page
-   Root
-   Fix path - adds trailing slash if missing
-   Depth
-   Remove bookmark element - remove bookmark from link
-   Page base - root of page, removes page element from link
-   Is mail - is the link a mailto
-   Has Query
-   Is same root as - are two domains the same treating http and https as the same
-   Is same page root as - are the two page roots the same treating http and https as the same

### NLC specific

Two methods used for validity checks at North Lincolnshire Council

-   Is Valid CRM Number
-   Is Valid Text - this checks that only allowed characters are in the input Text

### e-Gif

This implements some of the business rules from the former data standards catalog. 

There are validity checks for 

-   National Insurance Number
-   NASS number
-   Dates - in governmental specified format (CCYY-MM-DD)
-   UPRN
-   USRN
-   UK PostCode - note however that this may be rendered partially redundant by changes made by the post office

## Models

These classes are for general use. Many of them are fairly trivial however they have validation and are useful for overloading functions for what are essentially the same datatypes

-   Post Code
-   Uprn
-   Usrn
-   Person - basic representation of an individual, primarily name
-   AddressLines - basic address in the form of address lines
-   AddressNameNumber - basic address with house name and house number fields 
-   AddressNamed - Address with named fields, contains primary address and secondary address
-   Contact - basic representation of contact details, including address, phone numbers etc
-   Telephone Number - basic phone number details, uses Google library which means it can cope with any phone number as long as the correct ISO country code is used. Defaults ISO code to GB
-   CRM Reference - this is NLC specific but could be adapted
-   NASS 
-   National Insurance number (NINO)

NOTE - the address classes have an equality operator, including between the different types. 
Person has no equality operator as that could be taken to imply two people are the same when they aren't
e.g. S. Ellwood could be Sam or Sophie

## Dependencies

The only dependency is the Google telephone library

© SE 2020
