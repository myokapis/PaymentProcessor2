using MySqlConnector;
using SqlKata.Execution;

namespace Payment.Processor.Services
{
    public interface IDatabaseService
    {
        Task<MySqlConnection> Connection { get; }
        string DatabaseName { get; set; }
        Task<TResult> RunQuery<TResult>(Func<QueryFactory, Task<TResult>> queryFn);
    }
}
