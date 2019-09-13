using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using Gibbed.Helpers;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace Gibbed.MassEffect2.FileFormats
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveFile
    {
        public uint Version; // ME2 1.0 (release) has saves of version 29 (0x1D)
        public uint Checksum; // CRC32 of save data (from start) to before CRC32 value

        [UnrealFieldOffset(0x054)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Debug Name")]
        public string DebugName;

        [UnrealFieldOffset(0x07C)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Time Played")]
        public Save.TimePlayed TimePlayed;

        [UnrealFieldOffset(0x090)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Disc")]
        public int Disc;

        [UnrealFieldOffset(0x094)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Base Level Name")]
        public string BaseLevelName;

        [UnrealFieldOffset(0x0A0)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Difficulty")]
        public Save.DifficultyType Difficulty;

        [UnrealFieldOffset(0x0A4)]
        [UnrealFieldCategory("3. Plot")]
        [UnrealFieldDisplayName("End Game State")]
        public Save.EndGameType EndGameState;

        [UnrealFieldOffset(0x080)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Time Stamp")]
        public Save.SaveTimeStamp TimeStamp;

        [UnrealFieldOffset(0x0A8)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Player Position")]
        public Save.Vector SaveLocation;

        [UnrealFieldOffset(0x0B4)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Player Rotation")]
        public Save.Rotator SaveRotation;

        [UnrealFieldOffset(0x344)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Current Loading Tip")]
        public int CurrentLoadingTip;

        [UnrealFieldOffset(0x0C0)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Levels")]
        public List<Save.Level> LevelRecords;

        [UnrealFieldOffset(0x0CC)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Streaming")]
        public List<Save.StreamingState> StreamingRecords;

        [UnrealFieldOffset(0x0D8)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Kismet")]
        public List<Save.KismetBool> KismetRecords;

        [UnrealFieldOffset(0x0E4)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Doors")]
        public List<Save.Door> DoorRecords;

        [UnrealFieldOffset(0x0F0)]
        [UnrealFieldCategory("4. Other")]
        [UnrealFieldDisplayName("Pawns")]
        public List<Guid> PawnRecords;

        [UnrealFieldOffset(0x0FC)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Player")]
        public Save.Player PlayerRecord;

        [UnrealFieldOffset(0x2B0)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Henchmen")]
        public List<Save.Henchman> HenchmanRecords;

        [UnrealFieldOffset(0x2C8)]
        [UnrealFieldCategory("3. Plot")]
        [UnrealFieldDisplayName("ME2 Plot Table")]
        public Save.ME2PlotTable ME2PlotRecord;

        [UnrealFieldOffset(0x320)]
        [UnrealFieldCategory("3. Plot")]
        [UnrealFieldDisplayName("ME1 Plot Table")]
        public Save.ME1PlotTable ME1PlotRecord;

        [UnrealFieldOffset(0x2BC)]
        [UnrealFieldCategory("3. Plot")]
        [UnrealFieldDisplayName("Galaxy Map")]
        public Save.GalaxyMap GalaxyMapRecord;

        [UnrealFieldOffset(0x03C)]
        [UnrealFieldCategory("1. General")]
        [UnrealFieldDisplayName("Dependent DLC")]
        public List<Save.DependentDLC> DependentDLC;

        protected void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.DebugName);
            stream.Serialize(ref this.TimePlayed);
            stream.Serialize(ref this.Disc);
            stream.Serialize(ref this.BaseLevelName);
            stream.SerializeEnum(ref this.Difficulty);
            stream.SerializeEnum(ref this.EndGameState);
            stream.Serialize(ref this.TimeStamp);
            stream.Serialize(ref this.SaveLocation);
            stream.Serialize(ref this.SaveRotation);
            stream.Serialize(ref this.CurrentLoadingTip);
            stream.Serialize(ref this.LevelRecords);
            stream.Serialize(ref this.StreamingRecords);
            stream.Serialize(ref this.KismetRecords);
            stream.Serialize(ref this.DoorRecords);
            stream.Serialize(ref this.PawnRecords);
            stream.Serialize(ref this.PlayerRecord);
            stream.Serialize(ref this.HenchmanRecords);
            stream.Serialize(ref this.ME2PlotRecord);
            stream.Serialize(ref this.ME1PlotRecord);
            stream.Serialize(ref this.GalaxyMapRecord);
            stream.Serialize(ref this.DependentDLC);
        }

        /*
         * Load the Save from the input stream with given Endian-ness. 
         */
        public static SaveFile Load(Stream input)
        {
            SaveFile save = new SaveFile();
            save.Version = input.ReadValueU32();

            if (save.Version > 1024)
            {
                // Test is version is byte swapped from expected order
                byte[] data = BitConverter.GetBytes(save.Version);
                Array.Reverse(data);
                uint swapVersion = BitConverter.ToUInt32(data, 0);
                if (swapVersion == 29) // we seem to have wrong endian stream
                {
                    throw new FormatException("byte order swapped");
                }
            }

            if (save.Version != 29)
            {
                throw new FormatException("unsupported save version");
            }

            UnrealStream stream = new UnrealStream(input, true, save.Version);
            save.Serialize(stream);

            // sanity check, cos if we read a strange crc it'll break anyway
            if (input.Position != input.Length - 4)
            {
                throw new FormatException("bad checksum position");
            }
            save.Checksum = input.ReadValueU32();

            // did we consume the entire save file?
            if (input.Position != input.Length)
            {
                throw new FormatException("did not consume entire file");
            }

            return save;
        }

        public void Save(Stream output)
        {
            MemoryStream memory = new MemoryStream();
            UnrealStream stream = new UnrealStream(memory, false, this.Version);

            memory.WriteValueU32(this.Version);
            this.Serialize(stream);

            if (this.Version != 29)
            {
                throw new FormatException("unsupported save version");
            }

            // generate checksum
            memory.Position = 0;
            uint checksum = 0;
            byte[] checksumData = new byte[1024];
            while (memory.Position < memory.Length)
            {
                int read = memory.Read(checksumData, 0, 1024);
                checksum = CRC32.Compute(checksumData, 0, read, checksum);
            }

            this.Checksum = checksum;
            memory.WriteValueU32(checksum);

            // write from memory
            memory.Position = 0;
            byte[] data = new byte[1024];
            while (memory.Position < memory.Length)
            {
                int read = memory.Read(data, 0, 1024);
                output.Write(data, 0, read);
            }
        }

        public static void CompareObjects(object obj1, object obj2, string name, Type[] validTypes, HashSet<object> processed, System.Text.StringBuilder sb) {
            if (processed.Contains(obj1) || processed.Contains(obj2) || (obj1 == null && obj2 == null)) {
                return;
            }
            if (obj1 == null || obj2 == null) {
                sb.AppendFormat("{0}: [NULL] {1} != {2}\n", name, (obj1 == null) ? "NULL" : obj1, (obj2 == null) ? "NULL" : obj2);
                return;
            }
            Type type1 = obj1.GetType();
            Type type2 = obj2.GetType();
            if (type1 != type2) {
                sb.AppendFormat("{0}: [TYPE] {1} != {2}\n", name, type1, type2);
                return;
            }
            if (validTypes.Contains(type1)) {
                if (obj1.GetHashCode() != obj2.GetHashCode()) {
                    sb.AppendFormat("{0}: [VALUE] {1} != {2}\n", name, obj1, obj2);
                    return;
                }
                return; // values are equal
            } else {
                processed.Add(obj1);
                processed.Add(obj2);
                FieldInfo[] fields = type1.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fields.Length; ++i) {
                    FieldInfo field = fields[i];
                    object value1 = field.GetValue(obj1);
                    object value2 = field.GetValue(obj2);
                    if (value1 is ICollection) {
                        ICollection collection1 = value1 as ICollection;
                        ICollection collection2 = value2 as ICollection;
                        if (collection1.Count != collection2.Count) {
                            sb.AppendFormat("{0}: [COUNT] {1} != {2}\n", name + "/" + field.Name, collection1.Count, collection2.Count);
                        }
                        int count = Math.Max(collection1.Count, collection2.Count);
                        IEnumerator enumerator1 = collection1.GetEnumerator();
                        IEnumerator enumerator2 = collection2.GetEnumerator();
                        for (int j = 0; j < count; ++j) {
                            CompareObjects(enumerator1.MoveNext() ? enumerator1.Current : null, enumerator2.MoveNext() ? enumerator2.Current : null, name + "/" + field.Name + "/" + j, validTypes, processed, sb);
                        }
                    } else {
                        CompareObjects(value1, value2, name + "/" + field.Name, validTypes, processed, sb);
                    }
                }
            }
        }

        private const string HeadMorphMagic = "GIBBEDMASSEFFECT2HEADMORPH";

        public void SaveHeadMorph(Stream output, byte type) {
            MemoryStream memory = new MemoryStream();
            UnrealStream stream = new UnrealStream(memory, false, this.Version);

            memory.WriteStringASCII(HeadMorphMagic);
            memory.WriteValueU8(1); // headmorph version (0 = original gibbed, 1 = used since r1b8)
            memory.WriteValueU8(type); // type (0 = complete headmorph, 1 = face shape only, 2 = makeup only)
            memory.WriteValueU32(this.Version);
            
            if (type == 0) {
                stream.Serialize(ref this.PlayerRecord.FaceCode);
                stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead);
            } else if (type == 1) {
                stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.LOD0Vertices);
            } else if (type == 2) {
                stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.ScalarParameters);
                stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.VectorParameters);
            } else {
                throw new FormatException("invalid type");
            }

            // write from memory
            memory.Position = 0;
            byte[] data = new byte[1024];
            while (memory.Position < memory.Length) {
                int read = memory.Read(data, 0, 1024);
                output.Write(data, 0, read);
            }
        }

        public void LoadHeadMorph(Stream input, bool ignoreSaveVersion) {
            string loadedMagic = input.ReadStringASCII((uint)HeadMorphMagic.Length);
            if (loadedMagic != HeadMorphMagic)
            {
                throw new FormatException("no valid headmorph file");
            }

            byte loadedHeadMorphVersion = input.ReadValueU8();
            byte loadedType = 0;
            if (loadedHeadMorphVersion == 0) { // version used by original gibbed

            } else if (loadedHeadMorphVersion == 1) { // version used since r1b8
                loadedType = input.ReadValueU8();
            } else {
                throw new FormatException("unsupported headmorph version");
            }

            uint loadedSaveVersion = input.ReadValueU32();
            if (loadedSaveVersion > 1024)
            {
                // test if version is byte swapped from expected order
                byte[] data = BitConverter.GetBytes(loadedSaveVersion);
                Array.Reverse(data);
                uint swapVersion = BitConverter.ToUInt32(data, 0);
                if (swapVersion == 29) // we seem to have wrong endian stream
                {
                    throw new FormatException("byte order swapped");
                }
            }

            if (loadedSaveVersion != this.Version && !ignoreSaveVersion)
            {
                throw new FormatException("unsupported save version");
            }

            UnrealStream stream = new FileFormats.UnrealStream(input, true, this.Version);

            if(loadedHeadMorphVersion == 0) {
                this.PlayerRecord.FaceCode = "";
                stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead);
                this.PlayerRecord.Appearance.HasMorphHead = true;
            } else if (loadedHeadMorphVersion == 1) {
                if (loadedType == 0) {
                    stream.Serialize(ref this.PlayerRecord.FaceCode);
                    stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead);
                    this.PlayerRecord.Appearance.HasMorphHead = true;
                } else if (loadedType == 1) {
                    if (this.PlayerRecord.Appearance.HasMorphHead && this.PlayerRecord.Appearance.MorphHead != null) {
                        this.PlayerRecord.FaceCode = "";
                        stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.LOD0Vertices);
                    } else {
                        throw new FormatException("no custom headmorph present");
                    }
                } else if (loadedType == 2) {
                    if (this.PlayerRecord.Appearance.HasMorphHead && this.PlayerRecord.Appearance.MorphHead != null) {
                        // keep the old skintone
                        Save.VectorParameter oldSkinTone = this.PlayerRecord.Appearance.MorphHead.VectorParameters.Find(
                            delegate(Save.VectorParameter vp) {
                                return vp.Name == "SkinTone";
                            });
                        this.PlayerRecord.FaceCode = "";
                        stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.ScalarParameters);
                        stream.Serialize(ref this.PlayerRecord.Appearance.MorphHead.VectorParameters);
                        // set the old skintone
                        int newSkinToneIndex = this.PlayerRecord.Appearance.MorphHead.VectorParameters.FindIndex(
                            delegate(Save.VectorParameter vp) {
                                return vp.Name == "SkinTone";
                            });
                        this.PlayerRecord.Appearance.MorphHead.VectorParameters[newSkinToneIndex] = oldSkinTone;
                    } else {
                        throw new FormatException("no custom headmorph present");
                    }
                } else {
                    throw new FormatException("unsupported headmorph type");
                }
            }

            // did we consume the entire save file?
            if (input.Position != input.Length) {
                throw new FormatException("did not consume entire file");
            }
        }

        public void DeleteHeadMorph() {
            this.PlayerRecord.FaceCode = "";
            this.PlayerRecord.Appearance.MorphHead = null;
            this.PlayerRecord.Appearance.HasMorphHead = false;
        }
    }
}
