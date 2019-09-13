using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0CC0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Level : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Name")]
        public string LevelName;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Unknown1 (ShouldBeVisible or ShouldBeLoaded)")]
        public bool Unknown1; // possibly ShouldBeVisible or ShouldBeLoaded

        [UnrealFieldOffset(0x10)]
        [UnrealFieldDisplayName("Unknown2 (ShouldBeVisible or ShouldBeLoaded)")]
        public bool Unknown2; // possibly ShouldBeVisible or ShouldBeLoaded

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.LevelName);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}, {2}",
                this.LevelName,
                this.Unknown1,
                this.Unknown2);
        }
    }
}
