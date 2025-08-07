namespace Payment.Workflow.Interfaces
{
    /// <summary>
    /// Defines a unit of work.
    /// </summary>
    public interface IWorkflowTask
    {
        /// <summary>
        /// Initiates execution of the task.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        bool Run() => throw new NotImplementedException();

        /// <summary>
        /// Initiates execution of the task asynchronously.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        Task<bool> RunAsync() => throw new NotImplementedException();
    }
}
