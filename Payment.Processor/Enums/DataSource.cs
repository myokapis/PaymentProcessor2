using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    /// <summary>
    /// An enumeration of transaction data sources.
    /// </summary>
    public enum DataSource
    {
        Unknown,
        Application,

        [EnumMember(Value = "MOBILE_DEVICE")]
        MobileDevice,

        Reader
    }
}
