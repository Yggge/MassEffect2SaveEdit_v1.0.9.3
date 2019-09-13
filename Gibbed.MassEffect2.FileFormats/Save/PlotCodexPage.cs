using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEF40
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class PlotCodexPage : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Page")]
        public int Page;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("New")]
        public bool New;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Page);
            stream.Serialize(ref this.New);
        }

        public override string ToString() {
            return String.Format("{0} = {1}",
                this.Page,
                this.New);
        }
    }
}
