using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE040
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ME1PlotTable : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        //[UnrealFieldDisplayName("BoolVariables (read-only)")]
        public BitArray BoolVariables;
        [UnrealFieldDisplayName("BoolVariables")]
        public BitArrayWrapper BoolVariablesWrapper; // wrapper for editing bitarray

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("IntVariables")]
        public List<int> IntVariables;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("FloatVariables")]
        public List<float> FloatVariables;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.BoolVariables);
            this.BoolVariablesWrapper = new BitArrayWrapper(this.BoolVariables);
            stream.Serialize(ref this.IntVariables);
            stream.Serialize(ref this.FloatVariables);
        }

        public bool GetBoolVariable(int index)
        {
            if (index >= this.BoolVariables.Count)
            {
                return false;
            }

            return this.BoolVariables[index];
        }

        public void SetBoolVariable(int index, bool value)
        {
            if (index >= this.BoolVariables.Count)
            {
                this.BoolVariables.Length = index + 1;
            }

            this.BoolVariables[index] = value;
        }

        public int GetIntVariable(int index)
        {
            if (index >= this.IntVariables.Count)
            {
                return 0;
            }

            return this.IntVariables[index];
        }

        public void SetIntVariable(int index, int value)
        {
            while (this.IntVariables.Count <= index)
            {
                this.IntVariables.Add(0);
            }

            this.IntVariables[index] = value;
        }

        public float GetFloatVariable(int index)
        {
            if (index >= this.FloatVariables.Count)
            {
                return 0;
            }

            return this.FloatVariables[index];
        }

        public void SetFloatVariable(int index, float value)
        {
            while (this.FloatVariables.Count <= index)
            {
                this.FloatVariables.Add(0);
            }

            this.FloatVariables[index] = value;
        }
    }
}
