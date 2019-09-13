﻿using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAADB0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class StreamingState : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Name")]
        public string Name;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Active")]
        public bool Active;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Active);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Active);
        }
    }
}
