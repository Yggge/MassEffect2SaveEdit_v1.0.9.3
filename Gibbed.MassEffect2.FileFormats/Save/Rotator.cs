using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Rotator : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Pitch")]
        public int Pitch;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("Yaw")]
        public int Yaw;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("Roll")]
        public int Roll;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Pitch);
            stream.Serialize(ref this.Yaw);
            stream.Serialize(ref this.Roll);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",
                this.Pitch,
                this.Yaw,
                this.Roll);
        }
    }
}
