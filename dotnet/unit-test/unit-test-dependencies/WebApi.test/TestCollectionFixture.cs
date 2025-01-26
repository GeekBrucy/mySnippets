using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace WebApi.test
{
    public class TestCollectionFixture : IDisposable
    {
        public string Message { get; }
        public TestCollectionFixture()
        {
            Message = "From TestCollection Fixture";
        }

        public void Dispose()
        {
            // Dispose
        }
    }

    [CollectionDefinition("Test Collection")]
    public class TestCollection : ICollectionFixture<TestCollectionFixture>
    { }
}