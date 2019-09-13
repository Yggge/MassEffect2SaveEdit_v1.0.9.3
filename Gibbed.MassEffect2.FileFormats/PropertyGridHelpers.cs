using System;
using System.ComponentModel;

#region Gibbed.MassEffect2.FileFormats.SaveFile
namespace Gibbed.MassEffect2.FileFormats
{
	public partial class SaveFile
	{
		[Category("4. Other")]
		[DisplayName("Debug Name")]
		public System.String _property_DebugName
		{
			get { return this.DebugName; }
			set { this.DebugName = value; }
		}

		[Category("1. General")]
		[DisplayName("Time Played")]
		public Gibbed.MassEffect2.FileFormats.Save.TimePlayed _property_TimePlayed
		{
			get { return this.TimePlayed; }
			set { this.TimePlayed = value; }
		}

		[Category("4. Other")]
		[DisplayName("Disc")]
		public System.Int32 _property_Disc
		{
			get { return this.Disc; }
			set { this.Disc = value; }
		}

		[Category("1. General")]
		[DisplayName("Base Level Name")]
		public System.String _property_BaseLevelName
		{
			get { return this.BaseLevelName; }
			set { this.BaseLevelName = value; }
		}

		[Category("1. General")]
		[DisplayName("Difficulty")]
		public Gibbed.MassEffect2.FileFormats.Save.DifficultyType _property_Difficulty
		{
			get { return this.Difficulty; }
			set { this.Difficulty = value; }
		}

		[Category("3. Plot")]
		[DisplayName("End Game State")]
		public Gibbed.MassEffect2.FileFormats.Save.EndGameType _property_EndGameState
		{
			get { return this.EndGameState; }
			set { this.EndGameState = value; }
		}

		[Category("1. General")]
		[DisplayName("Time Stamp")]
		public Gibbed.MassEffect2.FileFormats.Save.SaveTimeStamp _property_TimeStamp
		{
			get { return this.TimeStamp; }
			set { this.TimeStamp = value; }
		}

		[Category("2. Squad")]
		[DisplayName("Player Position")]
		public Gibbed.MassEffect2.FileFormats.Save.Vector _property_SaveLocation
		{
			get { return this.SaveLocation; }
			set { this.SaveLocation = value; }
		}

		[Category("2. Squad")]
		[DisplayName("Player Rotation")]
		public Gibbed.MassEffect2.FileFormats.Save.Rotator _property_SaveRotation
		{
			get { return this.SaveRotation; }
			set { this.SaveRotation = value; }
		}

		[Category("1. General")]
		[DisplayName("Current Loading Tip")]
		public System.Int32 _property_CurrentLoadingTip
		{
			get { return this.CurrentLoadingTip; }
			set { this.CurrentLoadingTip = value; }
		}

		[Category("4. Other")]
		[DisplayName("Levels")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Level> _property_LevelRecords
		{
			get { return this.LevelRecords; }
			set { this.LevelRecords = value; }
		}

		[Category("4. Other")]
		[DisplayName("Streaming")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.StreamingState> _property_StreamingRecords
		{
			get { return this.StreamingRecords; }
			set { this.StreamingRecords = value; }
		}

		[Category("4. Other")]
		[DisplayName("Kismet")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.KismetBool> _property_KismetRecords
		{
			get { return this.KismetRecords; }
			set { this.KismetRecords = value; }
		}

		[Category("4. Other")]
		[DisplayName("Doors")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Door> _property_DoorRecords
		{
			get { return this.DoorRecords; }
			set { this.DoorRecords = value; }
		}

		[Category("4. Other")]
		[DisplayName("Pawns")]
		public System.Collections.Generic.List<System.Guid> _property_PawnRecords
		{
			get { return this.PawnRecords; }
			set { this.PawnRecords = value; }
		}

		[Category("2. Squad")]
		[DisplayName("Player")]
		public Gibbed.MassEffect2.FileFormats.Save.Player _property_PlayerRecord
		{
			get { return this.PlayerRecord; }
			set { this.PlayerRecord = value; }
		}

		[Category("2. Squad")]
		[DisplayName("Henchmen")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Henchman> _property_HenchmanRecords
		{
			get { return this.HenchmanRecords; }
			set { this.HenchmanRecords = value; }
		}

		[Category("3. Plot")]
		[DisplayName("ME2 Plot Table")]
		public Gibbed.MassEffect2.FileFormats.Save.ME2PlotTable _property_ME2PlotRecord
		{
			get { return this.ME2PlotRecord; }
			set { this.ME2PlotRecord = value; }
		}

		[Category("3. Plot")]
		[DisplayName("ME1 Plot Table")]
		public Gibbed.MassEffect2.FileFormats.Save.ME1PlotTable _property_ME1PlotRecord
		{
			get { return this.ME1PlotRecord; }
			set { this.ME1PlotRecord = value; }
		}

		[Category("3. Plot")]
		[DisplayName("Galaxy Map")]
		public Gibbed.MassEffect2.FileFormats.Save.GalaxyMap _property_GalaxyMapRecord
		{
			get { return this.GalaxyMapRecord; }
			set { this.GalaxyMapRecord = value; }
		}

		[Category("1. General")]
		[DisplayName("Dependent DLC")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.DependentDLC> _property_DependentDLC
		{
			get { return this.DependentDLC; }
			set { this.DependentDLC = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Appearance
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Appearance
	{
		[DisplayName("Combat Appearance")]
		public Gibbed.MassEffect2.FileFormats.Save.PlayerAppearanceType _property_CombatAppearance
		{
			get { return this.CombatAppearance; }
			set { this.CombatAppearance = value; }
		}

		[DisplayName("Casual ID")]
		public System.Int32 _property_CasualID
		{
			get { return this.CasualID; }
			set { this.CasualID = value; }
		}

		[DisplayName("Full Body ID")]
		public System.Int32 _property_FullBodyID
		{
			get { return this.FullBodyID; }
			set { this.FullBodyID = value; }
		}

		[DisplayName("Torso ID")]
		public System.Int32 _property_TorsoID
		{
			get { return this.TorsoID; }
			set { this.TorsoID = value; }
		}

		[DisplayName("Shoulder ID")]
		public System.Int32 _property_ShoulderID
		{
			get { return this.ShoulderID; }
			set { this.ShoulderID = value; }
		}

		[DisplayName("Arm ID")]
		public System.Int32 _property_ArmID
		{
			get { return this.ArmID; }
			set { this.ArmID = value; }
		}

		[DisplayName("Leg ID")]
		public System.Int32 _property_LegID
		{
			get { return this.LegID; }
			set { this.LegID = value; }
		}

		[DisplayName("Spec ID")]
		public System.Int32 _property_SpecID
		{
			get { return this.SpecID; }
			set { this.SpecID = value; }
		}

		[DisplayName("Tint #1 ID")]
		public System.Int32 _property_Tint1ID
		{
			get { return this.Tint1ID; }
			set { this.Tint1ID = value; }
		}

		[DisplayName("Tint #2 ID")]
		public System.Int32 _property_Tint2ID
		{
			get { return this.Tint2ID; }
			set { this.Tint2ID = value; }
		}

		[DisplayName("Tint #3 ID")]
		public System.Int32 _property_Tint3ID
		{
			get { return this.Tint3ID; }
			set { this.Tint3ID = value; }
		}

		[DisplayName("Pattern ID")]
		public System.Int32 _property_PatternID
		{
			get { return this.PatternID; }
			set { this.PatternID = value; }
		}

		[DisplayName("Pattern Color ID")]
		public System.Int32 _property_PatternColorID
		{
			get { return this.PatternColorID; }
			set { this.PatternColorID = value; }
		}

		[DisplayName("Helmet ID")]
		public System.Int32 _property_HelmetID
		{
			get { return this.HelmetID; }
			set { this.HelmetID = value; }
		}

		[DisplayName("Has Morph Head")]
		public System.Boolean _property_HasMorphHead
		{
			get { return this.HasMorphHead; }
			set { this.HasMorphHead = value; }
		}

		[DisplayName("Morph Head")]
		public Gibbed.MassEffect2.FileFormats.Save.MorphHead _property_MorphHead
		{
			get { return this.MorphHead; }
			set { this.MorphHead = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.DependentDLC
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class DependentDLC
	{
		[DisplayName("ModuleID")]
		public System.Int32 _property_ModuleID
		{
			get { return this.ModuleID; }
			set { this.ModuleID = value; }
		}

		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Door
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Door
	{
		[DisplayName("DoorGUID")]
		public System.Guid _property_DoorGUID
		{
			get { return this.DoorGUID; }
			set { this.DoorGUID = value; }
		}

		[DisplayName("CurrentState")]
		public System.Byte _property_CurrentState
		{
			get { return this.CurrentState; }
			set { this.CurrentState = value; }
		}

		[DisplayName("OldState")]
		public System.Byte _property_OldState
		{
			get { return this.OldState; }
			set { this.OldState = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.GalaxyMap
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class GalaxyMap
	{
		[DisplayName("Planets")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Planet> _property_Planets
		{
			get { return this.Planets; }
			set { this.Planets = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Henchman
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Henchman
	{
		[DisplayName("Tag")]
		public System.String _property_Tag
		{
			get { return this.Tag; }
			set { this.Tag = value; }
		}

		[DisplayName("Powers")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Power> _property_Powers
		{
			get { return this.Powers; }
			set { this.Powers = value; }
		}

		[DisplayName("Level")]
		public System.Int32 _property_CharacterLevel
		{
			get { return this.CharacterLevel; }
			set { this.CharacterLevel = value; }
		}

		[DisplayName("Talent Points")]
		public System.Int32 _property_TalentPoints
		{
			get { return this.TalentPoints; }
			set { this.TalentPoints = value; }
		}

		[DisplayName("Loadout")]
		public Gibbed.MassEffect2.FileFormats.Save.Loadout _property_LoadoutWeapons
		{
			get { return this.LoadoutWeapons; }
			set { this.LoadoutWeapons = value; }
		}

		[DisplayName("Mapped Power")]
		public System.String _property_MappedPower
		{
			get { return this.MappedPower; }
			set { this.MappedPower = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.HotKey
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class HotKey
	{
		[DisplayName("PawnName")]
		public System.String _property_PawnName
		{
			get { return this.PawnName; }
			set { this.PawnName = value; }
		}

		[DisplayName("PowerId")]
		public System.Int32 _property_PowerID
		{
			get { return this.PowerID; }
			set { this.PowerID = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.KismetBool
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class KismetBool
	{
		[DisplayName("BoolGUID")]
		public System.Guid _property_BoolGUID
		{
			get { return this.BoolGUID; }
			set { this.BoolGUID = value; }
		}

		[DisplayName("Value")]
		public System.Boolean _property_Value
		{
			get { return this.Value; }
			set { this.Value = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Level
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Level
	{
		[DisplayName("Name")]
		public System.String _property_LevelName
		{
			get { return this.LevelName; }
			set { this.LevelName = value; }
		}

		[DisplayName("Unknown1 (ShouldBeVisible or ShouldBeLoaded)")]
		public System.Boolean _property_Unknown1
		{
			get { return this.Unknown1; }
			set { this.Unknown1 = value; }
		}

		[DisplayName("Unknown2 (ShouldBeVisible or ShouldBeLoaded)")]
		public System.Boolean _property_Unknown2
		{
			get { return this.Unknown2; }
			set { this.Unknown2 = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.LinearColor
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class LinearColor
	{
		[DisplayName("R")]
		public System.Single _property_R
		{
			get { return this.R; }
			set { this.R = value; }
		}

		[DisplayName("G")]
		public System.Single _property_G
		{
			get { return this.G; }
			set { this.G = value; }
		}

		[DisplayName("B")]
		public System.Single _property_B
		{
			get { return this.B; }
			set { this.B = value; }
		}

		[DisplayName("Alpha")]
		public System.Single _property_A
		{
			get { return this.A; }
			set { this.A = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Loadout
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Loadout
	{
		[DisplayName("Unknown #1")]
		public System.String _property_Unknown0
		{
			get { return this.Unknown0; }
			set { this.Unknown0 = value; }
		}

		[DisplayName("Unknown #2")]
		public System.String _property_Unknown1
		{
			get { return this.Unknown1; }
			set { this.Unknown1 = value; }
		}

		[DisplayName("Unknown #3")]
		public System.String _property_Unknown2
		{
			get { return this.Unknown2; }
			set { this.Unknown2 = value; }
		}

		[DisplayName("Unknown #4")]
		public System.String _property_Unknown3
		{
			get { return this.Unknown3; }
			set { this.Unknown3 = value; }
		}

		[DisplayName("Unknown #5")]
		public System.String _property_Unknown4
		{
			get { return this.Unknown4; }
			set { this.Unknown4 = value; }
		}

		[DisplayName("Unknown #6")]
		public System.String _property_Unknown5
		{
			get { return this.Unknown5; }
			set { this.Unknown5 = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.ME1PlotTable
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class ME1PlotTable
	{
		[DisplayName("BoolVariables")]
		public Gibbed.MassEffect2.FileFormats.BitArrayWrapper _property_BoolVariablesWrapper
		{
			get { return this.BoolVariablesWrapper; }
			set { this.BoolVariablesWrapper = value; }
		}

		[DisplayName("IntVariables")]
		public System.Collections.Generic.List<System.Int32> _property_IntVariables
		{
			get { return this.IntVariables; }
			set { this.IntVariables = value; }
		}

		[DisplayName("FloatVariables")]
		public System.Collections.Generic.List<System.Single> _property_FloatVariables
		{
			get { return this.FloatVariables; }
			set { this.FloatVariables = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.ME2PlotTable
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class ME2PlotTable
	{
		[DisplayName("BoolVariables")]
		public Gibbed.MassEffect2.FileFormats.BitArrayWrapper _property_BoolVariablesWrapper
		{
			get { return this.BoolVariablesWrapper; }
			set { this.BoolVariablesWrapper = value; }
		}

		[DisplayName("IntVariables")]
		[Description("Raw integer variables. NuTitan's offsets translate into the integer array as (offset/4)+3.\nNote: many of these are already in use (e.g. 3 is Renegade Points) so modify at your own risk.")]
		public System.Collections.Generic.List<System.Int32> _property_IntVariables
		{
			get { return this.IntVariables; }
			set { this.IntVariables = value; }
		}

		[DisplayName("FloatVariables")]
		public System.Collections.Generic.List<System.Single> _property_FloatVariables
		{
			get { return this.FloatVariables; }
			set { this.FloatVariables = value; }
		}

		[Category("MissionProgress")]
		[DisplayName("QuestProgressCounter")]
		public System.Int32 _property_QuestProgressCounter
		{
			get { return this.QuestProgressCounter; }
			set { this.QuestProgressCounter = value; }
		}

		[Category("MissionProgress")]
		[DisplayName("QuestProgress")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.PlotQuest> _property_QuestProgress
		{
			get { return this.QuestProgress; }
			set { this.QuestProgress = value; }
		}

		[Category("MissionProgress")]
		[DisplayName("QuestIDs")]
		public System.Collections.Generic.List<System.Int32> _property_QuestIDs
		{
			get { return this.QuestIDs; }
			set { this.QuestIDs = value; }
		}

		[Category("MissionProgress")]
		[DisplayName("CodexEntries")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.PlotCodex> _property_CodexEntries
		{
			get { return this.CodexEntries; }
			set { this.CodexEntries = value; }
		}

		[Category("MissionProgress")]
		[DisplayName("QuestProgressCounter")]
		public System.Collections.Generic.List<System.Int32> _property_CodexIDs
		{
			get { return this.CodexIDs; }
			set { this.CodexIDs = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.MorphFeature
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class MorphFeature
	{
		[DisplayName("Feature")]
		public System.String _property_Feature
		{
			get { return this.Feature; }
			set { this.Feature = value; }
		}

		[DisplayName("Offset")]
		public System.Single _property_Offset
		{
			get { return this.Offset; }
			set { this.Offset = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.MorphHead
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class MorphHead
	{
		[DisplayName("Hair Mesh")]
		public System.String _property_HairMesh
		{
			get { return this.HairMesh; }
			set { this.HairMesh = value; }
		}

		[DisplayName("Accessory Meshes")]
		[Editor(@"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		public System.Collections.Generic.List<System.String> _property_AccessoryMeshes
		{
			get { return this.AccessoryMeshes; }
			set { this.AccessoryMeshes = value; }
		}

		[DisplayName("Morph Features")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.MorphFeature> _property_MorphFeatures
		{
			get { return this.MorphFeatures; }
			set { this.MorphFeatures = value; }
		}

		[DisplayName("Offset Bones")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.OffsetBone> _property_OffsetBones
		{
			get { return this.OffsetBones; }
			set { this.OffsetBones = value; }
		}

		[DisplayName("LOD0 Vertices")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Vector> _property_LOD0Vertices
		{
			get { return this.LOD0Vertices; }
			set { this.LOD0Vertices = value; }
		}

		[DisplayName("LOD1 Vertices")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Vector> _property_LOD1Vertices
		{
			get { return this.LOD1Vertices; }
			set { this.LOD1Vertices = value; }
		}

		[DisplayName("LOD2 Vertices")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Vector> _property_LOD2Vertices
		{
			get { return this.LOD2Vertices; }
			set { this.LOD2Vertices = value; }
		}

		[DisplayName("LOD3 Vertices")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Vector> _property_LOD3Vertices
		{
			get { return this.LOD3Vertices; }
			set { this.LOD3Vertices = value; }
		}

		[DisplayName("Scalar Parameters")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.ScalarParameter> _property_ScalarParameters
		{
			get { return this.ScalarParameters; }
			set { this.ScalarParameters = value; }
		}

		[DisplayName("Vector Parameters")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.VectorParameter> _property_VectorParameters
		{
			get { return this.VectorParameters; }
			set { this.VectorParameters = value; }
		}

		[DisplayName("Texture Parameters")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.TextureParameter> _property_TextureParameters
		{
			get { return this.TextureParameters; }
			set { this.TextureParameters = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.OffsetBone
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class OffsetBone
	{
		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

		[DisplayName("Offset")]
		public Gibbed.MassEffect2.FileFormats.Save.Vector _property_Offset
		{
			get { return this.Offset; }
			set { this.Offset = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Planet
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Planet
	{
		[DisplayName("PlanetID")]
		public System.Int32 _property_PlanetID
		{
			get { return this.PlanetID; }
			set { this.PlanetID = value; }
		}

		[DisplayName("Visited")]
		public System.Boolean _property_Visited
		{
			get { return this.Visited; }
			set { this.Visited = value; }
		}

		[DisplayName("Probes")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Vector2D> _property_Probes
		{
			get { return this.Probes; }
			set { this.Probes = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Player
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Player
	{
		[Category("Player")]
		[DisplayName("Gender")]
		[Description("Gender attribute (Male/Female)")]
		public System.Boolean _property_IsFemale
		{
			get { return this.IsFemale; }
			set { this.IsFemale = value; }
		}

		[Category("Statistics")]
		[DisplayName("Class Name")]
		public System.String _property_PlayerClassName
		{
			get { return this.PlayerClassName; }
			set { this.PlayerClassName = value; }
		}

		[Category("Statistics")]
		[DisplayName("Class Friendly Name")]
		[Description("String ID of the player's class.")]
		public System.Int32 _property_ClassFriendlyName
		{
			get { return this.ClassFriendlyName; }
			set { this.ClassFriendlyName = value; }
		}

		[Category("Statistics")]
		[DisplayName("Level")]
		public System.Int32 _property_Level
		{
			get { return this.Level; }
			set { this.Level = value; }
		}

		[Category("Statistics")]
		[DisplayName("Current XP")]
		public System.Single _property_CurrentXP
		{
			get { return this.CurrentXP; }
			set { this.CurrentXP = value; }
		}

		[Category("Player")]
		[DisplayName("First Name")]
		public System.String _property_FirstName
		{
			get { return this.FirstName; }
			set { this.FirstName = value; }
		}

		[Category("Player")]
		[DisplayName("Last Name")]
		[Description("String ID of last name. Not actually used.")]
		public System.Int32 _property_LastName
		{
			get { return this.LastName; }
			set { this.LastName = value; }
		}

		[Category("Statistics")]
		[DisplayName("Origin")]
		public Gibbed.MassEffect2.FileFormats.Save.OriginType _property_Origin
		{
			get { return this.Origin; }
			set { this.Origin = value; }
		}

		[Category("Statistics")]
		[DisplayName("Notoriety")]
		public Gibbed.MassEffect2.FileFormats.Save.NotorietyType _property_Notoriety
		{
			get { return this.Notoriety; }
			set { this.Notoriety = value; }
		}

		[Category("Statistics")]
		[DisplayName("Talent Points")]
		public System.Int32 _property_TalentPoints
		{
			get { return this.TalentPoints; }
			set { this.TalentPoints = value; }
		}

		[Category("Powers")]
		[DisplayName("Mapped Power #1")]
		public System.String _property_MappedPower1
		{
			get { return this.MappedPower1; }
			set { this.MappedPower1 = value; }
		}

		[Category("Powers")]
		[DisplayName("Mapped Power #2")]
		public System.String _property_MappedPower2
		{
			get { return this.MappedPower2; }
			set { this.MappedPower2 = value; }
		}

		[Category("Powers")]
		[DisplayName("Mapped Power #3")]
		public System.String _property_MappedPower3
		{
			get { return this.MappedPower3; }
			set { this.MappedPower3 = value; }
		}

		[Category("Player")]
		[DisplayName("Appearance")]
		public Gibbed.MassEffect2.FileFormats.Save.Appearance _property_Appearance
		{
			get { return this.Appearance; }
			set { this.Appearance = value; }
		}

		[Category("Powers")]
		[DisplayName("Powers")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Power> _property_Powers
		{
			get { return this.Powers; }
			set { this.Powers = value; }
		}

		[Category("Inventory")]
		[DisplayName("Weapons")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.Weapon> _property_Weapons
		{
			get { return this.Weapons; }
			set { this.Weapons = value; }
		}

		[Category("Inventory")]
		[DisplayName("Loadout")]
		public Gibbed.MassEffect2.FileFormats.Save.Loadout _property_LoadoutWeapons
		{
			get { return this.LoadoutWeapons; }
			set { this.LoadoutWeapons = value; }
		}

		[Category("Other")]
		[DisplayName("HotKeys")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.HotKey> _property_HotKeys
		{
			get { return this.HotKeys; }
			set { this.HotKeys = value; }
		}

		[Category("Resources")]
		[DisplayName("Credits")]
		public System.Int32 _property_Credits
		{
			get { return this.Credits; }
			set { this.Credits = value; }
		}

		[Category("Resources")]
		[DisplayName("Medigel")]
		public System.Int32 _property_Medigel
		{
			get { return this.Medigel; }
			set { this.Medigel = value; }
		}

		[Category("Resources")]
		[DisplayName("Element Zero")]
		public System.Int32 _property_Eezo
		{
			get { return this.Eezo; }
			set { this.Eezo = value; }
		}

		[Category("Resources")]
		[DisplayName("Iridium")]
		public System.Int32 _property_Iridium
		{
			get { return this.Iridium; }
			set { this.Iridium = value; }
		}

		[Category("Resources")]
		[DisplayName("Palladium")]
		public System.Int32 _property_Palladium
		{
			get { return this.Palladium; }
			set { this.Palladium = value; }
		}

		[Category("Resources")]
		[DisplayName("Platinum")]
		public System.Int32 _property_Platinum
		{
			get { return this.Platinum; }
			set { this.Platinum = value; }
		}

		[Category("Resources")]
		[DisplayName("Probes")]
		public System.Int32 _property_Probes
		{
			get { return this.Probes; }
			set { this.Probes = value; }
		}

		[Category("Resources")]
		[DisplayName("Current Fuel")]
		public System.Single _property_CurrentFuel
		{
			get { return this.CurrentFuel; }
			set { this.CurrentFuel = value; }
		}

		[Category("Player")]
		[DisplayName("Face Code")]
		public System.String _property_FaceCode
		{
			get { return this.FaceCode; }
			set { this.FaceCode = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.PlotCodex
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class PlotCodex
	{
		[DisplayName("Pages")]
		public System.Collections.Generic.List<Gibbed.MassEffect2.FileFormats.Save.PlotCodexPage> _property_Pages
		{
			get { return this.Pages; }
			set { this.Pages = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.PlotCodexPage
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class PlotCodexPage
	{
		[DisplayName("Page")]
		public System.Int32 _property_Page
		{
			get { return this.Page; }
			set { this.Page = value; }
		}

		[DisplayName("New")]
		public System.Boolean _property_New
		{
			get { return this.New; }
			set { this.New = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.PlotQuest
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class PlotQuest
	{
		[DisplayName("QuestCounter")]
		public System.UInt32 _property_QuestCounter
		{
			get { return this.QuestCounter; }
			set { this.QuestCounter = value; }
		}

		[DisplayName("QuestUpdated")]
		public System.Boolean _property_QuestUpdated
		{
			get { return this.QuestUpdated; }
			set { this.QuestUpdated = value; }
		}

		[DisplayName("History")]
		public System.Collections.Generic.List<System.Int32> _property_History
		{
			get { return this.History; }
			set { this.History = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Power
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Power
	{
		[DisplayName("Name")]
		public System.String _property_PowerName
		{
			get { return this.PowerName; }
			set { this.PowerName = value; }
		}

		[DisplayName("Current Rank")]
		public System.Single _property_CurrentRank
		{
			get { return this.CurrentRank; }
			set { this.CurrentRank = value; }
		}

		[DisplayName("Class Name")]
		public System.String _property_PowerClassName
		{
			get { return this.PowerClassName; }
			set { this.PowerClassName = value; }
		}

		[DisplayName("Wheel Display Index")]
		public System.Int32 _property_WheelDisplayIndex
		{
			get { return this.WheelDisplayIndex; }
			set { this.WheelDisplayIndex = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Rotator
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Rotator
	{
		[DisplayName("Pitch")]
		public System.Int32 _property_Pitch
		{
			get { return this.Pitch; }
			set { this.Pitch = value; }
		}

		[DisplayName("Yaw")]
		public System.Int32 _property_Yaw
		{
			get { return this.Yaw; }
			set { this.Yaw = value; }
		}

		[DisplayName("Roll")]
		public System.Int32 _property_Roll
		{
			get { return this.Roll; }
			set { this.Roll = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.SaveTimeStamp
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class SaveTimeStamp
	{
		[DisplayName("Seconds Since Midnight")]
		public System.Int32 _property_SecondsSinceMidnight
		{
			get { return this.SecondsSinceMidnight; }
			set { this.SecondsSinceMidnight = value; }
		}

		[DisplayName("Day")]
		public System.Int32 _property_Day
		{
			get { return this.Day; }
			set { this.Day = value; }
		}

		[DisplayName("Month")]
		public System.Int32 _property_Month
		{
			get { return this.Month; }
			set { this.Month = value; }
		}

		[DisplayName("Year")]
		public System.Int32 _property_Year
		{
			get { return this.Year; }
			set { this.Year = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.ScalarParameter
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class ScalarParameter
	{
		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

		[DisplayName("Value")]
		public System.Single _property_Value
		{
			get { return this.Value; }
			set { this.Value = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.StreamingState
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class StreamingState
	{
		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

		[DisplayName("Active")]
		public System.Boolean _property_Active
		{
			get { return this.Active; }
			set { this.Active = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.TextureParameter
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class TextureParameter
	{
		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

		[DisplayName("Value")]
		public System.String _property_Value
		{
			get { return this.Value; }
			set { this.Value = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.TimePlayed
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class TimePlayed
	{
		[DisplayName("SecondsPlayed")]
		public System.Single _property_SecondsPlayed
		{
			get { return this.SecondsPlayed; }
			set { this.SecondsPlayed = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Vector
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Vector
	{
		[DisplayName("X")]
		public System.Single _property_X
		{
			get { return this.X; }
			set { this.X = value; }
		}

		[DisplayName("Y")]
		public System.Single _property_Y
		{
			get { return this.Y; }
			set { this.Y = value; }
		}

		[DisplayName("Z")]
		public System.Single _property_Z
		{
			get { return this.Z; }
			set { this.Z = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Vector2D
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Vector2D
	{
		[DisplayName("X")]
		public System.Single _property_X
		{
			get { return this.X; }
			set { this.X = value; }
		}

		[DisplayName("Y")]
		public System.Single _property_Y
		{
			get { return this.Y; }
			set { this.Y = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.VectorParameter
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class VectorParameter
	{
		[DisplayName("Name")]
		public System.String _property_Name
		{
			get { return this.Name; }
			set { this.Name = value; }
		}

		[DisplayName("Value")]
		public Gibbed.MassEffect2.FileFormats.Save.LinearColor _property_Value
		{
			get { return this.Value; }
			set { this.Value = value; }
		}

	}
}
#endregion
#region Gibbed.MassEffect2.FileFormats.Save.Weapon
namespace Gibbed.MassEffect2.FileFormats.Save
{
	public partial class Weapon
	{
		[DisplayName("Class Name")]
		public System.String _property_WeaponClassName
		{
			get { return this.WeaponClassName; }
			set { this.WeaponClassName = value; }
		}

		[DisplayName("Ammo Used Count")]
		public System.Int32 _property_AmmoUsedCount
		{
			get { return this.AmmoUsedCount; }
			set { this.AmmoUsedCount = value; }
		}

		[DisplayName("Ammo Total")]
		public System.Int32 _property_TotalAmmo
		{
			get { return this.TotalAmmo; }
			set { this.TotalAmmo = value; }
		}

		[DisplayName("Current Weapon")]
		public System.Boolean _property_CurrentWeapon
		{
			get { return this.CurrentWeapon; }
			set { this.CurrentWeapon = value; }
		}

		[DisplayName("Last Weapon")]
		public System.Boolean _property_LastWeapon
		{
			get { return this.LastWeapon; }
			set { this.LastWeapon = value; }
		}

		[DisplayName("Ammo Power Name")]
		public System.String _property_AmmoPowerName
		{
			get { return this.AmmoPowerName; }
			set { this.AmmoPowerName = value; }
		}

	}
}
#endregion
