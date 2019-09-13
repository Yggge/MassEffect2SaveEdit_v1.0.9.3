using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEDD0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class PlotQuest : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("QuestCounter")]
        public uint QuestCounter;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("QuestUpdated")]
        public bool QuestUpdated;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("History")]
        public List<int> History;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.QuestCounter);
            stream.Serialize(ref this.QuestUpdated);
            stream.Serialize(ref this.History);
        }

        public override string ToString() {
            return String.Format("{0} = {1}",
                this.QuestCounter,
                this.QuestUpdated);
        }
    }
}
