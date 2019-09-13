using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEED0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class PlotCodex : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Pages")]
        public List<PlotCodexPage> Pages;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Pages);
        }
    }
}
