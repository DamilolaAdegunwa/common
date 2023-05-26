using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace MongoMission.Tests.Tests
{
    public class XUnitTests
    {
        [Fact]
        public async Task MethodAssertTrue()
        {
            Assert.True(true);
        }
        [Fact]
        public async Task MethodAssertFail()
        {
            Assert.Fail("this is just to test for failure! no further action is required");
        }
        [Fact]
        public async Task MethodAssertEqual()
        {
            Assert.Equal(1, 1);
        }
        [Fact]
        public async Task MethodAssertFalse()
        {
            Assert.False(false);
        }
        [Fact]
        public async Task MethodAssertSingle()
        {
            Assert.Single(new int[] { 10 });
        }
        [Fact]
        public async Task MethodAssertEmpty()
        {
            Assert.Empty(new int[] { });
        }
        [Fact]
        public async Task MethodAssertAll()
        {
            Assert.All(new int[] { 10, 20, 30, 40, 50, 60, 70 }, i => Assert.Equal(i, i));
        }
        [Fact]
        public async Task MethodAssertCollection()
        {
            Assert.Collection(new int[] { 10, 20, 30, 40, 50, 60, 70 }, i => Console.WriteLine(""));
        }
    }
}
