using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gibbed.MassEffect2.FileFormats;

namespace Gibbed.MassEffect2.SaveEdit
{
    public class AppearanceGrid : PropertyGrid
    {
        public enum Genders { Male, Female };
        public enum HMF_HairStyle { Afro, Ashley, Classy, Cute, Cyberbabe, HighBun, IconBun, LowBun, MidBun, Mohawk, Mom, PonyTail, Sexy, Short02, CustomAfro, CustomCute, CustomSexy };
        public enum HMM_HairStyle { FormalSpikes, Kaiden, Mohawk, RollinsSpike, SargeSpike01, SargeSpike02, Short01, Short02, Short03 };

        SaveFile saveFile;
        Enum hairStyle;
        Genders gender;

        public AppearanceGrid() :base() {}

        public SaveFile SaveFile
        {
            set
            {
                this.saveFile = value;
                this.SelectedObject = this.saveFile._property_ME2PlotRecord;
                //this.SelectedObjects = new object[] { this.Gender, this.HairStyle , this.saveFile.PlayerRecord.Appearance};
                var humanGender = value._property_PlayerRecord._property_IsFemale ? Genders.Female : Genders.Male;
                InitializeGrid(humanGender);
            }
        }

        // Fix this to initialize hairstyle according to savefile
        // only change when gender is changed.
        private void InitializeGrid(Genders humanGender)
        {
            if (humanGender == Genders.Female)
            {
                this.gender = Genders.Female;
                this.hairStyle = HMF_HairStyle.Classy;
            }
            else
            {
                this.gender = Genders.Male;
                this.hairStyle = HMM_HairStyle.FormalSpikes;
            }
            this.CollapseAllGridItems();
            this.Refresh();
        }

        [Category("Appearance"), DisplayName("Gender"), DefaultValue(false)]
        [Description("Choose Male or Female only.")]
        [TypeConverter(typeof(GenderConverter))]
        public Genders Gender
        {
            get { return this.gender; }
            set { InitializeGrid(value); }
        }

        [Category("Appearance"), DisplayName("Hair Style")]
        [Description("Basic Hair Style")]
        [TypeConverter(typeof(HairStyleConverter))]
        public Enum HairStyle
        {
            get { return this.hairStyle; }
            set { this.hairStyle = value; }
        }

        #region Appearance Converters
        internal class GenderConverter : BooleanConverter
        {
            StandardValuesCollection GenderValuesCollection = new StandardValuesCollection(Enum.GetValues(typeof(Genders)));

            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return GenderValuesCollection;
            }

            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value != null && value.GetType() == typeof(string))
                {
                    var retValue = Genders.Female.Equals(Enum.Parse(typeof(Genders), value.ToString()));
                    Console.WriteLine("Convert gender From {0} to {1}", value, retValue);
                    return retValue;
                }
                else
                    return base.ConvertFrom(context, culture, value);
            }

            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == null || value == null) return "";

                if (destinationType.Equals(typeof(string)))
                {
                    string retValue = null;

                    if (value.GetType().Equals(typeof(Genders)))
                    {
                        var genderValue = (Genders)value;
                        retValue = Enum.GetName(typeof(Genders), genderValue);
                    }
                    else if (value.GetType().Equals(typeof(bool)))
                    {
                        var genderValue = (bool)value ? Genders.Female : Genders.Male;
                        retValue = Enum.GetName(typeof(Genders), genderValue);
                    }

                    if (retValue != null)
                    {
                        Console.WriteLine("Converting gender {0} to {1}", value, retValue);
                        return retValue;
                    }
                    else
                        return base.ConvertTo(context, culture, value, destinationType);
                }
                else
                    return base.ConvertTo(context, culture, value, destinationType);
            }
        }
        internal class HairStyleConverter : EnumConverter
        {
            static Type hairStyleType = typeof(HMM_HairStyle);      // Default to HMM
            StandardValuesCollection defaultHairStyles;

            public HairStyleConverter()
                : base(hairStyleType)
            {
                defaultHairStyles = new StandardValuesCollection(Enum.GetValues(hairStyleType));
            }

            public static Type HairStyleType
            {
                get { return HairStyleConverter.hairStyleType; }
                set { HairStyleConverter.hairStyleType = value; }
            }

            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                if (context != null && context.Instance.GetType().Equals(typeof(AppearanceGridHelpers)))
                {
                    return true;
                }
                else
                    return base.GetPropertiesSupported(context);
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                this.defaultHairStyles = new StandardValuesCollection(Enum.GetValues(hairStyleType));
                return this.defaultHairStyles;
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                Console.WriteLine(">>>Can ConvertTo {0}", destinationType);
                if (context != null && context.Instance.GetType().Equals(typeof(AppearanceGridHelpers)))
                    return true;
                else
                    return base.CanConvertTo(context, destinationType);
            }

            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    Console.WriteLine("ConvertTo {0} to {1}", value, destinationType);
                    var retValue = Enum.GetName(hairStyleType, value);
                    return retValue;
                }
                else
                {
                    Console.WriteLine("Can't ConvertTo {0} to {1}, let base try.", value, destinationType);
                    return base.ConvertTo(context, culture, value, destinationType);
                }
            }

            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                var retValue = base.CanConvertFrom(context, sourceType);
                Console.WriteLine("Can ConvertFrom {0}: {1}", sourceType, retValue);
                return retValue;
            }

            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value != null && value.GetType() == typeof(string))
                {
                    var retValue = Enum.Parse(hairStyleType, value.ToString());
                    Console.WriteLine("ConvertFrom {0} to {1}", value, retValue.GetType());
                    return retValue;
                }
                else
                {
                    var retValue = base.ConvertFrom(context, culture, value);
                    Console.WriteLine("Converted {0} to {1}", value, retValue.GetType());
                    return retValue;
                }
            }
        }
        #endregion
    }
}
