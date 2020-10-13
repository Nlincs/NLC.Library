//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UriExtensionsTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:53 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Extensions;
using NUnit.Framework;

namespace NLC.Library.Tests.Extensions
    {
        public class UriExtensionsTests
            {
                [Test]
                [Category("Uri")]
                public void IsBookmark_IsTrue([Values("#bookmark",
                        "/#bookmark",
                        "/Page#bookmark",
                        "http://www.mySite.com/MyPage#Bookmark",
                        "#")]
                    string input)
                    {
                        var sitebase = new Uri("http://www.mysite.com");

                        var expected = true;

                        var uri = new Uri(sitebase, input);

                        var actual = uri.IsBookmark();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Category("Uri")]
                public void IsBookmark_IsFalse([Values("bookmark",
                        "/bookmark",
                        "/PageBookmark",
                        "http://www.mySite.com/MyPage?Bookmark&z=%20a",
                        "")]
                    string input)
                    {
                        var sitebase = new Uri("http://www.mysite.com");

                        var expected = false;

                        var uri = new Uri(sitebase, input);

                        var actual = uri.IsBookmark();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                [Category("Uri")]
                public void RelativeToAbsolute_ReturnsExpected([Values("bookmark",
                        "/bookmark",
                        "/PageBookmark",
                        "this/is/data#bookmarked")]
                    string input)
                    {
                        var sitebase = new Uri("http://www.mysite.com?Bookmark&z=%20a");
                        var realbase = "http://www.mysite.com";

                        var relative = new Uri(input, UriKind.RelativeOrAbsolute);

                        if (!input.StartsWith("/"))
                            {
                                input = "/" + input;
                            }

                        var expectedBase = realbase + input;

                        var actual = relative.RelativeToAbsolute(sitebase);

                        Assert.That(actual, Is.Not.Null);
                        Assert.That(actual.AbsoluteUri, Is.EqualTo(expectedBase));
                    }

                [Test]
                [Category("Uri")]
                public void RelativeToAbsolute_Empty_ReturnsExpected()
                    {
                        var input = "";

                        var relative = new Uri(input, UriKind.RelativeOrAbsolute);

                        var actual = relative.RelativeToAbsolute(relative);

                        Assert.That(actual, Is.Null);
                    }

                [Test]
                public void IsMail_ReturnsFalse([Values("http://My.site.com/Some/New/pagemailto",
                        "ftp://ftp.mailto.com",
                        "https://mailto.com/")]
                    string input)
                    {
                        var uri = new Uri(input);

                        var expected = false;

                        var actual = uri.IsMail();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void IsMail_ReturnsTrue([Values("mailto:me@email.com",
                        "mailto://ftp.mailto.com",
                        "mailto://mailto.com/")]
                    string input)
                    {
                        var uri = new Uri(input);

                        var expected = true;

                        var actual = uri.IsMail();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void HasQuery_ReturnsFalse([Values("http://My.site.com/Some/New/pagemailto",
                        "ftp://ftp.mailto.com",
                        "https://mailto.com/")]
                    string input)
                    {
                        var uri = new Uri(input);

                        var expected = false;

                        var actual = uri.HasQuery();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void HasQuery_ReturnsTrue([Values("http://My.site.com/Some/New/pagemailto?page=123",
                        "https://mailto.com?page=abc&z=1")]
                    string input)
                    {
                        var uri = new Uri(input);

                        var expected = true;

                        var actual = uri.HasQuery();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void RemoveBookmark_InvalidUri_ReturnsInput()
                    {
                        var uri = new Uri("file://");

                        var actual = uri.RemoveBookmarkElement();

                        Assert.That(actual, Is.EqualTo(uri));
                    }

                [Test]
                public void RemoveBookmark_NoContent()
                    {
                        var input = "http://My.site.com/Some/New/pagemailto?page=123";

                        var uri = new Uri(input);

                        var expected = new Uri(input);

                        var actual = uri.RemoveBookmarkElement();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                public void RemoveBookmark_WithContent()
                    {
                        var input = "http://My.site.com/Some/New/pagemailto#page123";

                        var uri = new Uri(input);

                        var expected = new Uri("http://My.site.com/Some/New/pagemailto");

                        var actual = uri.RemoveBookmarkElement();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                public void PageBase_returnsExpected()
                    {
                        var input = "http://mysite.com/this/is/page.htm";

                        var uri = new Uri(input);

                        var expected = new Uri("http://mysite.com/this/is/");

                        var actual = uri.PageBase();

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                public void PageBaseWithForwardSlash_returnsExpected()
                    {
                        var input = "http://mysite.com/this/is/";

                        var uri = new Uri(input);

                        var expected = new Uri("http://mysite.com/this/is/");

                        var actual = uri.PageBase();

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                [Combinatorial]
                public void IsSameRootAs_returnsTrue(
                    [Values("http://www.site.com:80/This/is!#1", "https://www.site.com:80/This/is!#1")]
                    string url1,
                    [Values("http://www.site.com:80/This/is!#1", "https://www.site.com?httpPage=3")]
                    string url2)
                    {
                        var uri1 = new Uri(url1);
                        var uri2 = new Uri(url2);

                        var expected = true;

                        var actual = uri1.IsSameRootAs(uri2);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                public void IsSameRootAs_returnsFalse(
                    [Values("http://www.site.com:80/This/is!#1", "https://www.site.com:80/This/is!#1")]
                    string url1,
                    [Values("http://www.site.com:88/This/is!#1", "https://www.site.co?httpPage=3",
                        "mailto:email@email.com")]
                    string url2)
                    {
                        var uri1 = new Uri(url1);
                        var uri2 = new Uri(url2);

                        var expected = false;

                        var actual = uri1.IsSameRootAs(uri2);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                public void IsSamePageRootAs_returnsTrue(
                    [Values("http://www.site.com:80/This/is/", "https://www.site.com:80/This/is/aPage.html")]
                    string url1,
                    [Values("http://www.site.com:80/This/is/Web.php", "https://www.site.com/this/is/Somepage.htm")]
                    string url2)
                    {
                        var uri1 = new Uri(url1);
                        var uri2 = new Uri(url2);

                        var expected = true;

                        var actual = uri1.IsSamePageRootAs(uri2);

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Combinatorial]
                public void IsSamePageRootAs_returnsFalse(
                    [Values("http://www.site.com:80/This/is!#1", "https://www.site.com:80/This/is!#1")]
                    string url1,
                    [Values("http://www.site.com:88/This/is!#1", "https://www.site.co?httpPage=3",
                        "mailto:email@email.com")]
                    string url2)
                    {
                        var uri1 = new Uri(url1);
                        var uri2 = new Uri(url2);

                        var expected = false;

                        var actual = uri1.IsSamePageRootAs(uri2);

                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }