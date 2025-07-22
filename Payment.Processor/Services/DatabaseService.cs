using MySqlConnector;
using SqlKata.Execution;

namespace Payment.Processor.Services
{
    // TODO: flesh out this implementation.
    //       Also look for refactoring opportunities.
    public class DatabaseService : IDatabaseService
    {
        public Task<MySqlConnection> Connection => throw new NotImplementedException();

        public string DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<TResult> RunQuery<TResult>(Func<QueryFactory, Task<TResult>> queryFn)
        {
            throw new NotImplementedException();
        }
    }
}
