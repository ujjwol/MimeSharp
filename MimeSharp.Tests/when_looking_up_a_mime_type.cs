using System;
using FluentAssertions;
using Xunit;

namespace MimeSharp.Tests
{
    public class when_looking_up_a_mime_type
    {
        [Fact]
        public void html_extension_should_have_correct_mime_type()
        {
            var result = Mime.Lookup("test.html");
            result.Should().Be("text/html");
        }

        [Fact]
        public void htm_extension_is_correctly_identified()
        {
            var result = Mime.Lookup("test.htm");
            result.Should().Be("text/html");
        }
    }
}
