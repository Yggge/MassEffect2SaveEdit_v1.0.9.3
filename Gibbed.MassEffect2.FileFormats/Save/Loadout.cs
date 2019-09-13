﻿using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Loadout : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Unknown #1")]
        public string Unknown0;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Unknown #2")]
        public string Unknown1;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("Unknown #3")]
        public string Unknown2;

        [UnrealFieldOffset(0x24)]
        [UnrealFieldDisplayName("Unknown #4")]
        public string Unknown3;

        [UnrealFieldOffset(0x30)]
        [UnrealFieldDisplayName("Unknown #5")]
        public string Unknown4;

        [UnrealFieldOffset(0x3C)]
        [UnrealFieldDisplayName("Unknown #6")]
        public string Unknown5;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
            stream.Serialize(ref this.Unknown3);
            stream.Serialize(ref this.Unknown4);
            stream.Serialize(ref this.Unknown5);
        }
    }
}
