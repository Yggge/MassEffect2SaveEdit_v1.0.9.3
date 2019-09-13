﻿using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class TextureParameter : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Name")]
        public string Name;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Value")]
        public string Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Value);
        }
    }
}
