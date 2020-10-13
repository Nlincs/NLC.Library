//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=ConstantsTests.cs company="North Lincolnshire Council">
//  Solution : -  Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 03/07/2020 17:11
//  Altered - 06/07/2020 12:54 - Stephen Ellwood
// 
//  Project : - Library.tests
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace NLC.Library.Tests
    {
        [TestFixture]
        public class ConstantsTests
            {
                [Test]
                public void TestMethod1()
                    {
                        Assert.That(Constants.Back, Is.EqualTo('\b'));
                        Assert.That(Constants.Cr, Is.EqualTo('\r'));
                        Assert.That(Constants.CrLf, Is.EqualTo("\r\n"));
                        Assert.That(Constants.FormFeed, Is.EqualTo('\f'));
                        Assert.That(Constants.Lf, Is.EqualTo('\n'));
                        Assert.That(Constants.NewLine, Is.EqualTo("\r\n"));
                        Assert.That(Constants.NullChar, Is.EqualTo('\0'));
                        Assert.That(Constants.Quote, Is.EqualTo('"'));
                        Assert.That(Constants.Tab, Is.EqualTo('\t'));
                        Assert.That(Constants.VbCr, Is.EqualTo('\r'));
                        Assert.That(Constants.VbCrLf, Is.EqualTo("\r\n"));
                        Assert.That(Constants.VbLf, Is.EqualTo('\n'));
                        Assert.That(Constants.VerticalTab, Is.EqualTo('\v'));
                    }
            }
    }