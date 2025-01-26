using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WebApi.test
{
    [Collection("Test Collection")]
    public class Test3
    {
        private readonly TestCollectionFixture _testCollectionFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public Test3(TestCollectionFixture testCollectionFixture, ITestOutputHelper testOutputHelper)
        {
            _testCollectionFixture = testCollectionFixture;
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine(new string('*', 30));
            _testOutputHelper.WriteLine("Test 3: Collection Fixture");
            _testOutputHelper.WriteLine(new string('*', 30));
            Assert.True(true);
        }
    }
}