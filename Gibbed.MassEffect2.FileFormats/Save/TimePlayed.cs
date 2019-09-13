using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class TimePlayed : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("SecondsPlayed")]
        public float SecondsPlayed;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.SecondsPlayed);
        }

        public override string ToString()
        {
            return String.Format("{0}h {1}m {2}s",
                (int)(this.SecondsPlayed / 60.0 / 60.0),
                (int)(this.SecondsPlayed / 60.0) % 60,
                (int)(this.SecondsPlayed % 60)
                );
        }
    }
}

