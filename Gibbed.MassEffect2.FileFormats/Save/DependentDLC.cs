using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAB3B0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class DependentDLC : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("ModuleID")]
        public int ModuleID;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("Name")]
        public string Name;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.ModuleID);
            stream.Serialize(ref this.Name);
        }

        public override string ToString()
        {
            return String.Format("{1} ({0})",
                this.ModuleID,
                this.Name);
        }
    }
}
