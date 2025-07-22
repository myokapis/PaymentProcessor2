using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum DataSource
    {
        Unknown,
        Application,

        [EnumMember(Value = "MOBILE_DEVICE")]
        MobileDevice,

        Reader
    }
}
