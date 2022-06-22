using System;
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

            Assert.NotNull(firstResult);
            Assert.NotEmpty(firstResult);

            Assert.NotNull(secondResult);
            Assert.NotEmpty(secondResult);

        }
    }
}
