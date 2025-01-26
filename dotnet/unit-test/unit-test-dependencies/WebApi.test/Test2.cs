using Xunit.Abstractions;

namespace WebApi.test
{
    public class Test2 : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public Test2(DatabaseFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine(new string('*', 30));
            _testOutputHelper.WriteLine("Test 2: Class Fixture");
            _testOutputHelper.WriteLine(new string('*', 30));
            Assert.True(true);
        }
    }
}