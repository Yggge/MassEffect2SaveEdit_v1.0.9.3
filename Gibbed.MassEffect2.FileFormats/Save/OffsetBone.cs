using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class OffsetBone : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Name")]
        public string Name;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Offset")]
        public Vector Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Offset);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Offset);
        }
    }
}
