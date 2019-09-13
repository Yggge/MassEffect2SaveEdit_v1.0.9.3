using System.ComponentModel;
using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0C10
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class HotKey : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("PawnName")]
        public string PawnName;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("PowerId")]
        public int PowerID;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.PawnName);
            stream.Serialize(ref this.PowerID);
        }

        public override string ToString() {
            return String.Format("{0} = {1}",
                this.PawnName,
                this.PowerID);
        }
    }
}
