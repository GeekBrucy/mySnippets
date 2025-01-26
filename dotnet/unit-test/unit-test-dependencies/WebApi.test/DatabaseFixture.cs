namespace WebApi.test
{
    public class DatabaseFixture : IDisposable
    {
        public string Connstr { get; }
        public DatabaseFixture()
        {
            Connstr = "From DatabaseFixture";
        }

        public void Dispose()
        {
            // clean up
        }
    }
}