using System.Collections.Generic;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE380
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class GalaxyMap : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Planets")]
        public List<Planet> Planets;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Planets);
        }
    }
}
