using System;
using Xunit;

namespace MimeSharp.Tests
{
    public class when_looking_up_a_mime_type
    {
        [Fact]
        public void html_extension_should_have_correct_mime_type()
        {
            var result = Mime.Lookup("test.html");
            Assert.Equal("text/html", result);
        }

        [Fact]
        public void htm_extension_is_correctly_identified()
        {
            var result = Mime.Lookup("test.htm");
            Assert.Equal("text/html", result);
        }
    }
}
