//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UriExtensions.cs company="North Lincolnshire Council">
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

using System;
using System.Linq;

namespace NLC.Library.Extensions
    {
        /// <summary>
        ///     Extensions to Uri
        /// </summary>
        public static class UriExtensions
            {
                /// <summary>
                ///     Attempts to determine if a url is to a bookmark
                /// </summary>
                /// <param name="uri"></param>
                /// <returns></returns>
                public static bool IsBookmark(this Uri uri) => uri.Fragment.StartsWith("#");


                /// <summary>
                ///     Convert a relative uri to an absolute one
                /// </summary>
                /// <param name="relativeUri">The relative uri to convert</param>
                /// <param name="rootUri">The root to start from</param>
                /// <returns>
                ///     If either Uri is not valid then we return an empty Uri,
                ///     If the relative Uri is an absolute uri we return that
                ///     otherwise we return the absolute path
                /// </returns>
                public static Uri RelativeToAbsolute(this Uri relativeUri, Uri rootUri)
                    {
                        Uri url;

                        if (relativeUri == null || rootUri == null || rootUri.IsAbsoluteUri == false)
                            {
                                return default;
                            }


                        if (!rootUri.AbsoluteUri.EndsWith("/"))
                            {
                                var str = rootUri.AbsoluteUri + "/";
                                url = new Uri(str);
                            }
                        else
                            {
                                url = rootUri;
                            }

                        if (relativeUri.IsAbsoluteUri)
                            {
                                return relativeUri;
                            }

                        try
                            {
                                return new Uri(url, relativeUri);
                            }
                        catch
                            {
                                return new Uri("");
                            }
                    }


                /// <summary>
                ///     Is a page link to a bookmark on the same page e.g. "#book"
                /// </summary>
                /// <param name="link">link of interest</param>
                /// <returns>true if the link begins with a #, false otherwise</returns>
                public static bool IsPageBookmark(this string link) =>
                    link.Contains("/")
                        ? link.Trim().LastWord("/").StartsWith("#")
                        : link.Trim().StartsWith("#");

                /// <summary>
                ///     Root including prefix etc.
                /// </summary>
                /// <param name="uri">The url to check</param>
                /// <returns>string</returns>
                /// <remarks>
                ///     Takes a uri and returns the root url e.g. https://www.mysite.com:80/test/me
                ///     will return https://www.mysite.com:80/
                ///     <seealso cref="PageBase" />
                /// </remarks>
                public static string Root(this Uri uri)
                    {
                        if (uri.Scheme != "http" && uri.Scheme != "https")
                            {
                                return null;
                            }

                        return uri.Scheme + "://" + uri.Authority + "/";
                    }

                /// <summary>
                ///     Fix uri path
                /// </summary>
                /// <param name="uri">path to fix</param>
                /// <returns>a uri that has a trailing forward slash if appropriate</returns>
                /// <remarks>appends a forward slash if there isn't one. Only applies to http an https</remarks>
                public static Uri FixPath(this Uri uri)
                    {
                        if (uri.Scheme != "http" && uri.Scheme != "https")
                            {
                                return null;
                            }

                        var url = uri.AbsoluteUri;

                        var last = uri.Segments.Last();

                        if (last.StartsWith("?") || last.Contains("&"))
                            {
                                return uri;
                            }

                        return last == "/" ? uri : new Uri(url + "/");
                    }


                /// <summary>
                ///     Depth of a URI
                /// </summary>
                /// <param name="uri">the uri to consider</param>
                /// <returns>Number of segments in the Uri</returns>
                public static int Depth(this Uri uri)
                    {
                        if (uri.Scheme != "http" && uri.Scheme != "https")
                            {
                                return 0;
                            }

                        return Math.Max(uri.Segments.Length - 1, 0);
                    }


                /// <summary>
                ///     Remove bookmark element from a Uri
                /// </summary>
                /// <param name="input"></param>
                /// <returns></returns>
                /// <remarks>removes everything after the last # symbol - sometimes this may not work as expected </remarks>
                public static Uri RemoveBookmarkElement(this Uri input)
                    {
                        var url = input.AbsoluteUri;

                        var lastHash = url.LastIndexOf('#');

                        var pageUrl = lastHash <= 0 ? url : url.Substring(0, lastHash);

                        try
                            {
                                return new Uri(pageUrl);
                            }
                        catch
                            {
                                return new Uri("");
                            }
                    }


                /// <summary>
                ///     Page base
                /// </summary>
                /// <param name="url">url of interest</param>
                /// <returns>
                ///     the root of the page url e.g. http://mysite.com/this/is/page.htm
                ///     would return http://mysite.com/this/is/
                ///     <seealso cref="Root" />
                /// </returns>
                public static Uri PageBase(this Uri url)
                    {
                        if (url.AbsoluteUri.EndsWith("/"))
                            {
                                return url;
                            }

                        var lastSlash = url.AbsoluteUri.LastIndexOf('/') + 1;

                        var pageUrl = lastSlash <= 0 ? url.AbsoluteUri : url.AbsoluteUri.Substring(0, lastSlash);

                        try
                            {
                                return new Uri(pageUrl);
                            }
                        catch
                            {
                                return new Uri("");
                            }
                    }

                /// <summary>
                ///     Is a link a mailto
                /// </summary>
                /// <param name="link">link of interest</param>
                /// <returns>true if the link begins with mailto, false otherwise</returns>
                public static bool IsMail(this Uri link) => link.Scheme == "mailto";

                /// <summary>
                ///     Does the URI have a query element
                /// </summary>
                /// <param name="url"></param>
                /// <returns>true if there is a query element, false otherwise</returns>
                public static bool HasQuery(this Uri url) => url.Query != "";


                /// <summary>
                ///     Is this a bookmark link
                /// </summary>
                /// <param name="link">link of interest</param>
                /// <returns>true if the link is a bookmark link, regardless of where.</returns>
                public static bool IsBookmark(this string link)
                    {
                        var thisUri = new Uri(link, UriKind.RelativeOrAbsolute);

                        return thisUri.Fragment.StartsWith("#");
                    }

                /// <summary>
                ///     Are the uri's from the same http domain
                /// </summary>
                /// <param name="url1"></param>
                /// <param name="url2"></param>
                /// <returns>true if the domains match, false otherwise</returns>
                /// <remarks>
                ///     This only considers HTTP and HTTPS
                ///     Note also that this is case insensitive
                /// </remarks>
                public static bool IsSameRootAs(this Uri url1, Uri url2)
                    {
                        if (!url1.Scheme.ToLower().StartsWith("http") || !url2.Scheme.ToLower().StartsWith("http"))
                            {
                                return false; // only deal with http
                            }

                        var uridom = url1.Host.ToLower();
                        var uri2dom = url2.Host.ToLower();

                        // working as though http and https are the same
                        var uri1port = url1.Port;
                        if (uri1port == 443)
                            {
                                uri1port = 80;
                            }

                        var url2port = url2.Port;
                        if (url2port == 443)
                            {
                                url2port = 80;
                            }

                        return uridom == uri2dom && uri1port == url2port;
                    }

                /// <summary>
                ///     Are the uri's from the same page root
                /// </summary>
                /// <param name="url1"></param>
                /// <param name="url2"></param>
                /// <returns>true if the page roots match, false otherwise</returns>
                /// <remarks>
                ///     This only considers HTTP and HTTPS
                ///     Note also that this is case insensitive
                /// </remarks>
                public static bool IsSamePageRootAs(this Uri url1, Uri url2)
                    {
                        if (!url1.Scheme.ToLower().StartsWith("http") || !url2.Scheme.ToLower().StartsWith("http"))
                            {
                                return false; // only deal with http
                            }

                        var pr1 = url1.PageBase();
                        var pr2 = url2.PageBase();


                        var uridom = pr1.Host.ToLower();
                        var uri2dom = pr2.Host.ToLower();

                        // working as though http and https are the same
                        var uri1port = pr1.Port;
                        if (uri1port == 443)
                            {
                                uri1port = 80;
                            }

                        var url2port = pr2.Port;
                        if (url2port == 443)
                            {
                                url2port = 80;
                            }

                        var path1 = pr1.AbsolutePath.ToLower();
                        var path2 = pr2.AbsolutePath.ToLower();


                        return uridom == uri2dom && uri1port == url2port && path1 == path2;
                    }
            }
    }