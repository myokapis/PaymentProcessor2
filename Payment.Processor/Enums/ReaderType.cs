namespace Payment.Processor.Enums
{
    // TODO: remove any reader types that will never come through this app 
    /// <summary>
    /// An enumeration of CardFlight supported card readers.
    /// </summary>
    public enum ReaderType
    {
        UNKNOWN,
        A250,
        B200,
        B250,
        B350,
        B500,
        BTMAG,
        IDTECH,
        M010,
        NO_READER,
        RAMBLER,
        UNENCRYPTED,
        WALKER
    }
}
