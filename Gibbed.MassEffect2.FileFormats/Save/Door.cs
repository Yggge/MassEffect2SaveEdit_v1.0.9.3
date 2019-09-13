using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAB140
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Door : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("DoorGUID")]
        public Guid DoorGUID;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("CurrentState")]
        public byte CurrentState;

        [UnrealFieldOffset(0x10)]
        [UnrealFieldDisplayName("OldState")]
        public byte OldState;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.DoorGUID);
            stream.Serialize(ref this.CurrentState);
            stream.Serialize(ref this.OldState);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}, {2}",
                this.DoorGUID,
                this.CurrentState,
                this.OldState);
        }
    }
}
