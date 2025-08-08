using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{

    /// <summary>
    /// An enumeration of CardFlight payment platforms.
    /// </summary>
    public enum Platform
    {
        Unknown,
        Android,
        iOS,

        [EnumMember(Value = "scheduled_payment")]
        ScheduledPayment,

        // NOTE: valid value that we should not see in this app
        Terminal,

        [EnumMember(Value = "virtual_terminal")]
        VirtualTerminal
    }
}
