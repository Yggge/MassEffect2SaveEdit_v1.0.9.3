using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Vector : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("X")]
        public float X;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("Y")]
        public float Y;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("Z")]
        public float Z;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
            stream.Serialize(ref this.Z);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",
                this.X,
                this.Y,
                this.Z);
        }
    }
}
