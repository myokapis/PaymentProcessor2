namespace Payment.Processor.Transaction.Result
{
    // TODO: make sure this serializes correctly
    // TODO: see if we want to use enums of stick with the string characters.
    
    /// <summary>
    /// Describes the results of the processor's address and zip code matching
    /// for a transaction request.
    /// </summary>
    public class AvsResults
    {
        /// <summary>
        /// The result of the processor's address matching.
        /// </summary>
        public required string AddressResult { get; init; }

        /// <summary>
        /// The result of the processor's zip code matching.
        /// </summary>
        public required string ZipCodeResult { get; init; }
    }
}
