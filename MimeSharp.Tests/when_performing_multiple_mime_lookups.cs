using System;
using FluentAssertions;
using Xunit;

namespace MimeSharp.Tests
{
    public class when_performing_multiple_mime_lookups
    {
        [Fact]
        public void supports_making_multiple_lookups()
        {
            var firstResult = Mime.Lookup("test.html");
            var secondResult = Mime.Lookup("test.pdf");

            firstResult.Should().NotBeNullOrEmpty();
            secondResult.Should().NotBeNullOrEmpty();
        }
    }
}
