﻿using System.Collections.Generic;
using System;
using NUnit.Framework;

namespace SpotifyMyAPI.Web.Tests
{
    [TestFixture]
    public class URIExtensionTest
    {
        [Test]
        public void ApplyParameters_WithoutExistingParameters()
        {
            var expected = "http://google.com/?hello=world&nice=day";
            Uri uri = new Uri("http://google.com/");

            var parameters = new Dictionary<string, string>
            {
                { "hello", "world" },
                { "nice", "day" }
            };
            Assert.AreEqual(expected, uri.ApplyParameters(parameters).ToString());
        }

        [Test]
        public void ApplyParameters_WithExistingParameters()
        {
            var expected = "http://google.com/?existing=paramter&hello=world&nice=day";
            Uri uri = new Uri("http://google.com/?existing=paramter");

            var parameters = new Dictionary<string, string>
            {
                { "hello", "world" },
                { "nice", "day" }
            };
            Assert.AreEqual(expected, uri.ApplyParameters(parameters).ToString());
        }

        [Test]
        public void ApplyParameters_HandlesEscape()
        {
            var expected = "http://google.com/?existing=paramter&hello=%26world++";
            Uri uri = new Uri("http://google.com/?existing=paramter");

            var parameters = new Dictionary<string, string>
            {
                { "hello", "&world  " },
            };
            Assert.AreEqual(expected, uri.ApplyParameters(parameters).ToString());
        }
    }
}
