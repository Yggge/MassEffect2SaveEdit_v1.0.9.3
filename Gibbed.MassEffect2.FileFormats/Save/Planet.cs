using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE400
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Planet : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("PlanetID")]
        public int PlanetID;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("Visited")]
        public bool Visited;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("Probes")]
        public List<Vector2D> Probes;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.PlanetID);
            stream.Serialize(ref this.Visited);
            stream.Serialize(ref this.Probes);
        }

        public override string ToString() {
            return String.Format("{0} = {1}",
                this.PlanetID,
                this.Visited);
        }
    }
}
