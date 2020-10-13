//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=UriTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:59 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NLC.Library.Extensions;
using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class UriTests
            {
                [Test]
                [Sequential]
                public void Depth_ReturnsExpected(
                    [Values("http://test.nel.gov.uk:8000/nlc.asmx",
                        "http://test.nel.gov.uk/topic.php?id=14&like=like")]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.Depth();

                        var expected = 1;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void Depth_withoutPort_ReturnsExpected(
                    [Values("http://test.nel.gov.uk/",
                        "http://test.nel.gov.uk/?wsdl")]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.Depth();

                        var expected = 0;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void Depth_withPort_ReturnsExpected(
                    [Values("http://test.nel.gov.uk:8000/some/more/url",
                        "https://test.nel.gov.uk/some/more/url/"
                    )]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.Depth();

                        var expected = 3;

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void FixPath_ReturnsExpected(
                    [Values("http://test.nel.gov.uk:8000/",
                        "http://test.nel.gov.uk:8000")]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.FixPath().AbsoluteUri;

                        var expected = "http://test.nel.gov.uk:8000/";

                        Assert.That(actual, Is.EqualTo(expected));
                    }


                [Test]
                public void MailTo_Depth_Returns_zero()
                    {
                        var uri = new Uri("mailto: name@rapidtables.com");

                        var actual = uri.Depth();

                        Assert.That(actual, Is.EqualTo(0));
                    }

                [Test]
                public void MailTo_Root_Returns_null()
                    {
                        var uri = new Uri("mailto: name@rapidtables.com");

                        var actual = uri.Root();

                        Assert.That(actual, Is.Null);
                    }

                [Test]
                [Sequential]
                public void Root_withoutPort_ReturnsExpected(
                    [Values("http://test.nel.gov.uk/",
                        "http://test.nel.gov.uk/some/more/url",
                        "http://test.nel.gov.uk/?wsdl")]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.Root();

                        var expected = "http://test.nel.gov.uk/";

                        Assert.That(actual, Is.EqualTo(expected));
                    }

                [Test]
                [Sequential]
                public void Root_withPort_ReturnsExpected(
                    [Values("http://test.nel.gov.uk:8000/",
                        "http://test.nel.gov.uk:8000/some/more/url")]
                    string url)
                    {
                        var uri = new Uri(url);

                        var actual = uri.Root();

                        var expected = "http://test.nel.gov.uk:8000/";

                        Assert.That(actual, Is.EqualTo(expected));
                    }
            }
    }