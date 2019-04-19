using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            5.Should().Be(2 + 3);
        }
    }
}