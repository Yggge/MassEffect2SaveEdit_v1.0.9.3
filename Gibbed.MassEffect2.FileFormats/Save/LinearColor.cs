using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(LinearColorExpandableObjectConverter))]
    public partial class LinearColor : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("R")]
        public float R;

        [UnrealFieldOffset(0x04)]
        [UnrealFieldDisplayName("G")]
        public float G;

        [UnrealFieldOffset(0x08)]
        [UnrealFieldDisplayName("B")]
        public float B;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Alpha")]
        public float A;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.R);
            stream.Serialize(ref this.G);
            stream.Serialize(ref this.B);
            stream.Serialize(ref this.A);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}",
                this.R,
                this.G,
                this.B,
                this.A);
        }

        // Converter to control the expansion sort order of the colors.
        public class LinearColorExpandableObjectConverter : ExpandableObjectConverter {
            string[] sortOrder = { "_property_R", "_property_G", "_property_B", "_property_A" };

            // Override the default alphabetic sort order for expansion
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
                return base.GetProperties(context, value, attributes).Sort(sortOrder);
            }
        }
    }

}
