﻿using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class MorphFeature : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Feature")]
        public string Feature;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Offset")]
        public float Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Feature);
            stream.Serialize(ref this.Offset);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Feature,
                this.Offset);
        }
    }
}
