using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveTimeStamp : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Seconds Since Midnight")]
        public int SecondsSinceMidnight;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("Day")]
        public int Day;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("Month")]
        public int Month;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Year")]
        public int Year;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.SecondsSinceMidnight);
            stream.Serialize(ref this.Day);
            stream.Serialize(ref this.Month);
            stream.Serialize(ref this.Year);
        }

        public override string ToString()
        {
            // Bioware doesn't seem to round the minutes
            return String.Format("{0}/{1}/{2} {3:D2}:{4:D2}:{5:D2}",
                this.Day,
                this.Month,
                this.Year,
                (int)(this.SecondsSinceMidnight / 60.0 / 60.0),
                (int)(this.SecondsSinceMidnight / 60.0) % 60,
                (int)(this.SecondsSinceMidnight % 60)
                );
        }
    }
}
