using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0C50
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class KismetBool : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("BoolGUID")]
        public Guid BoolGUID;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Value")]
        public bool Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.BoolGUID);
            stream.Serialize(ref this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.BoolGUID,
                this.Value);
        }
    }
}
