using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE5B0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ME2PlotTable : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        //[UnrealFieldDisplayName("BoolVariables (read-only)")]
        public BitArray BoolVariables;
        [UnrealFieldDisplayName("BoolVariables")]
        public BitArrayWrapper BoolVariablesWrapper; // wrapper for editing bitarray

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("IntVariables")]
        [UnrealFieldDescription("Raw integer variables. NuTitan's offsets translate into the integer array as (offset/4)+3.\nNote: many of these are already in use (e.g. 3 is Renegade Points) so modify at your own risk.")]
        public List<int> IntVariables;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("FloatVariables")]
        public List<float> FloatVariables;

        [UnrealFieldOffset(0x24)]
        [UnrealFieldCategory("MissionProgress")]
        [UnrealFieldDisplayName("QuestProgressCounter")]
        public int QuestProgressCounter;

        [UnrealFieldOffset(0x28)]
        [UnrealFieldCategory("MissionProgress")]
        [UnrealFieldDisplayName("QuestProgress")]
        public List<PlotQuest> QuestProgress;

        [UnrealFieldOffset(0x34)]
        [UnrealFieldCategory("MissionProgress")]
        [UnrealFieldDisplayName("QuestIDs")]
        public List<int> QuestIDs;

        [UnrealFieldOffset(0x40)]
        [UnrealFieldCategory("MissionProgress")]
        [UnrealFieldDisplayName("CodexEntries")]
        public List<PlotCodex> CodexEntries;

        [UnrealFieldOffset(0x4C)]
        [UnrealFieldCategory("MissionProgress")]
        [UnrealFieldDisplayName("QuestProgressCounter")]
        public List<int> CodexIDs;

        public void Serialize(IUnrealStream stream) {
            stream.Serialize(ref this.BoolVariables);
            this.BoolVariablesWrapper = new BitArrayWrapper(this.BoolVariables);
            stream.Serialize(ref this.IntVariables);
            stream.Serialize(ref this.FloatVariables);
            stream.Serialize(ref this.QuestProgressCounter);
            stream.Serialize(ref this.QuestProgress);
            stream.Serialize(ref this.QuestIDs);
            stream.Serialize(ref this.CodexEntries);
            stream.Serialize(ref this.CodexIDs);
        }

        public bool GetBoolVariable(int index) {
            if (index >= this.BoolVariables.Count) {
                return false;
            }

            return this.BoolVariables[index];
        }

        public void SetBoolVariable(int index, bool value) {
            if (index >= this.BoolVariables.Count) {
                this.BoolVariables.Length = index + 1;
            }

            this.BoolVariables[index] = value;
        }

        public int GetIntVariable(int index) {
            if (index >= this.IntVariables.Count) {
                return 0;
            }

            return this.IntVariables[index];
        }

        public void SetIntVariable(int index, int value) {
            if (index >= this.IntVariables.Count) {
                this.IntVariables.Capacity = index + 1;
            }

            this.IntVariables[index] = value;
        }

        public float GetFloatVariable(int index) {
            if (index >= this.FloatVariables.Count) {
                return 0;
            }

            return this.FloatVariables[index];
        }

        public void SetFloatVariable(int index, float value) {
            if (index >= this.IntVariables.Count) {
                this.IntVariables.Capacity = index + 1;
            }

            this.FloatVariables[index] = value;
        }

        #region Points Earned
        [Category("Points Earned")]
        [DisplayName("Paragon Points")]
        public int _helper_ParagonPoints {
            get { return this.GetIntVariable(2); }
            set { this.SetIntVariable(2, value); }
        }

        [Category("Points Earned")]
        [DisplayName("Renegade Points")]
        public int _helper_RenegadePoints {
            get { return this.GetIntVariable(3); }
            set { this.SetIntVariable(3, value); }
        }
        #endregion
        #region Health Upgrades
        [Category("Health Upgrades")]
        [DisplayName("Medi-Gel Capacity")]
        [Description("Medi-Gel Capacity. (Microscanner) Range[0,5]")]
        public int _helper_Tec_MediGel {
            get { return GetIntVariable(67); }
            set { SetIntVariable(67, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Trauma Module")]
        [Description("Set to 1 to unlock Trauma Module. (Medical VI)")]
        public int _helper_Tec_MediGelR1 {
            get { return GetIntVariable(464); }
            set { SetIntVariable(464, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Emergency Shielding")]
        [Description("Set to 1 to unlock Emergency Shielding. (Shield Harmonics)")]
        public int _helper_Tec_MediGelR2 {
            get { return GetIntVariable(465); }
            set { SetIntVariable(465, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Heavy Skin Weave")]
        [Description("Heavy Skin Weave. (Lattice Shunting) Range[0,5]")]
        public int _helper_Tec_ShepardHealth {
            get { return GetIntVariable(73); }
            set { SetIntVariable(73, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Heavy Bone Weave")]
        [Description("Set to 1 to unlock Heavy Bone Weave. (Skeletal Lattice)")]
        public int _helper_Tec_ShepardR1 {
            get { return GetIntVariable(466); }
            set { SetIntVariable(466, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Heavy Muscle Weave")]
        [Description("Set to 1 to unlock Heavy Muscle Weave. (Microfiber Weave)")]
        public int _helper_Tec_ShepardR2 {
            get { return GetIntVariable(467); }
            set { SetIntVariable(467, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Damage Protection")]
        [Description("Damage Protection. (Ablative VI) Range [0,5]")]
        public int _helper_Tec_Shield {
            get { return GetIntVariable(434); }
            set { SetIntVariable(434, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Redundant Field Generator")]
        [Description("Set to 1 to unlock Redundant Field Generator. (Burst Regeneration)")]
        public int _helper_Tec_ShieldR1 {
            get { return GetIntVariable(468); }
            set { SetIntVariable(468, value); }
        }

        [Category("Health Upgrades")]
        [DisplayName("Hard Shields")]
        [Description("Set to 1 to unlock Hard Shields (Nanocrystal Shield)")]
        public int _helper_Tec_ShieldR2 {
            get { return GetIntVariable(469); }
            set { SetIntVariable(469, value); }
        }
        #endregion
        #region Weapons
        #region Bonus
        [Category("Weapons - Bonus")]
        [DisplayName("Bonus Assault Rifle Training")]
        [Description("Set to 1 to unlock Collector Ship Bonus Assault Rifle Training")]
        public int _helper_Wpn_BonusAssaultRifle {
            get { return this.GetIntVariable(147); }
            set { this.SetIntVariable(147, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("Bonus ShotGun Training")]
        [Description("Set to 1 to unlock Collector Ship Bonus Shotgun Training")]
        public int _helper_Wpn_BonusShotgun {
            get { return this.GetIntVariable(150); }
            set { this.SetIntVariable(150, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("Bonus Sniper Rifle Training")]
        [Description("Set to 1 to unlock Collector Ship Bonus Sniper Rifle Training")]
        public int _helper_Wpn_BonusSniperRifle {
            get { return this.GetIntVariable(148); }
            set { this.SetIntVariable(148, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("Revenant")]
        [Description("Set to 2 to access M-76 Revenant")]
        public int _helper_Wpn_SuperAssaultRifle {
            get { return this.GetIntVariable(438); }
            set { this.SetIntVariable(438, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("Claymore")]
        [Description("Set to 2 to access M-300 Claymore")]
        public int _helper_Wpn_SuperShotgun {
            get { return this.GetIntVariable(439); }
            set { this.SetIntVariable(439, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("Widow")]
        [Description("Set to 2 to access M-98 Widow")]
        public int _helper__helper_Widow {
            get { return this.GetIntVariable(440); }
            set { this.SetIntVariable(440, value); }
        }

        [Category("Weapons - Bonus")]
        [DisplayName("SuperWeapon??")]
        [Description("I don't know what this is. Set to 2? to access Super Weapon?")]
        public int _helper_Wpn_SuperWeapon {
            get { return this.GetIntVariable(437); }
            set { this.SetIntVariable(437, value); }
        }
        #endregion
        #region Normal
        [Category("Weapons - Normal")]
        [DisplayName("AssaultRifle2")]
        [Description("Set to 1 to access M-15 Vindicator(?)")]
        public int _helper_Wpn_AssaultRifle2 {
            get { return this.GetIntVariable(152); }
            set { this.SetIntVariable(152, value); }
        }

        [Category("Weapons - Normal")]
        [DisplayName("AutoPistol2")]
        [Description("Set to 1 to access M-9 Tempest(?)")]
        public int _helper_Wpn_AutoPisol2 {
            get { return this.GetIntVariable(124); }
            set { this.SetIntVariable(124, value); }
        }

        [Category("Weapons - Normal")]
        [DisplayName("Geth Pulse Rifle")]
        [Description("Set to 1 to access Geth Pulse Rifle")]
        public int _helper_Wpn_GethPulseRifle {
            get { return this.GetIntVariable(495); }
            set { this.SetIntVariable(495, value); }
        }

        [Category("Weapons - Normal")]
        [DisplayName("HeavyPistol2")]
        [Description("Set to 1 to access M-6 Carnifex(?)")]
        public int _helper_Wpn_HeavyPistol2 {
            get { return this.GetIntVariable(149); }
            set { this.SetIntVariable(149, value); }
        }

        [Category("Weapons - Normal")]
        [DisplayName("Shotgun2")]
        [Description("Set to 1 to access M-27 Scimitar(?)")]
        public int _helper_Wpn_Shotgun2 {
            get { return this.GetIntVariable(88); }
            set { this.SetIntVariable(88, value); }
        }

        [Category("Weapons - Normal")]
        [DisplayName("SniperRifle2")]
        [Description("Set to 1 to access M-97 Viper(?)")]
        public int _helper_Wpn_SniperRifle2 {
            get { return this.GetIntVariable(177); }
            set { this.SetIntVariable(177, value); }
        }
        #endregion
        #region Heavy
        [Category("Weapons - Heavy")]
        [DisplayName("M-622 Avalanche")]
        [Description("Set to 1 to access M-622 Avalanche")]
        public int _helper_Wpn_CryoBlaster {
            get { return this.GetIntVariable(461); }
            set { this.SetIntVariable(461, value); }
        }

        [Category("Weapons - Heavy")]
        [DisplayName("M-100 Grenade Launcher")]
        [Description("Set to 1 to access M-100 Grenade Launcher")]
        public int _helper_Wpn_GrenadeLauncher {
            get { return this.GetIntVariable(151); }
            set { this.SetIntVariable(151, value); }
        }

        [Category("Weapons - Heavy")]
        [DisplayName("M-920 Cain")]
        [Description("Set to 1 to access M-920 Cain")]
        public int _helper_Wpn_NukeLauncher {
            get { return this.GetIntVariable(496); }
            set { this.SetIntVariable(496, value); }
        }

        [Category("Weapons - Heavy")]
        [DisplayName("Collector Particle Beam")]
        [Description("Set to 1 to access Collector Particle Beam")]
        public int _helper_Wpn_ParticleBeam {
            get { return this.GetIntVariable(123); }
            set { this.SetIntVariable(123, value); }
        }

        [Category("Weapons - Heavy")]
        [DisplayName("ML-77 Missile Launcher")]
        [Description("Set to 1 to access ML-77 Missile Launcher")]
        public int _helper_Wpn_MissleLauncher {
            get { return this.GetIntVariable(460); }
            set { this.SetIntVariable(460, value); }
        }
        #endregion
        #endregion
        #region Weapons Upgrades
        [Category("Weapon Upgrades")]
        [DisplayName("Assault Rifle DMG")]
        [Description("Assault Rifle Damage. (Kinetic Pulsar) Range [0,5]")]
        public int _helper_Tec_AssaultRifle {
            get { return this.GetIntVariable(68); }
            set { this.SetIntVariable(68, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Assault Rifle Penetration")]
        [Description("Set to 1 to unlock Assault Rifle Penetration. (Tungsten Jacket)")]
        public int _helper_Tec_AssaultRifleR1 {
            get { return this.GetIntVariable(453); }
            set { this.SetIntVariable(453, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Assault Rifle Accuracy")]
        [Description("Set to 1 to unlock Assault Rifle Accuracy. (Targeting VI)")]
        public int _helper_Tec_AssaultRifleR2 {
            get { return this.GetIntVariable(451); }
            set { this.SetIntVariable(451, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("SMG Damage")]
        [Description("Submachine Gun Damage. (Microfield Pulsar) Range [0,5]")]
        public int _helper_Tec_AutoPistol {
            get { return this.GetIntVariable(426); }
            set { this.SetIntVariable(426, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("SMG Shield Piercing")]
        [Description("Set to 1 to unlock SMG Shield Piercing (Phasic Jacketing)")]
        public int _helper_Tec_AutoPistolR1 {
            get { return this.GetIntVariable(456); }
            set { this.SetIntVariable(456, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("SMG Extra Rounds")]
        [Description("Set to 1 to unlock SMG Extra Rounds. (Heat Sink Capacity)")]
        public int _helper_Tec_AutoPistolR2 {
            get { return this.GetIntVariable(457); }
            set { this.SetIntVariable(457, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Heavy Pistol Damage")]
        [Description("Heavy Pistol Damage. (Titan Pulsar) Range [0,5]")]
        public int _helper_Tec_HeavyPistol {
            get { return this.GetIntVariable(69); }
            set { this.SetIntVariable(69, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Heavy Pistol Penetration")]
        [Description("Set to 1 to unlock Armor Piercing Rounds. (Sabot Jacketing)")]
        public int _helper_Tec_HeavyPistolR1 {
            get { return this.GetIntVariable(462); }
            set { this.SetIntVariable(462, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Heavy Pistol Critical")]
        [Description("Set to 1 to unlock Heavy Pistol Critical. (Smart Rounds)")]
        public int _helper_Tec_HeavyPistolR2 {
            get { return this.GetIntVariable(463); }
            set { this.SetIntVariable(463, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Shotgun Damage")]
        [Description("Shotgun Damage. (Synchronized Pulsar) Range [0,5]")]
        public int _helper_Tec_Shotgun {
            get { return this.GetIntVariable(71); }
            set { this.SetIntVariable(71, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Shotgun Shield Piercing")]
        [Description("Set to 1 to unlock Shotgun Shield Piercing. (Microphasic Pulse)")]
        public int _helper_Tec_ShotgunR1 {
            get { return this.GetIntVariable(470); }
            set { this.SetIntVariable(470, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Shotgun Extra Rounds")]
        [Description("Set to 1 to unlock Shotgun Extra Rounds. (Thermal Sink)")]
        public int _helper_Tec_ShotgunR2 {
            get { return this.GetIntVariable(471); }
            set { this.SetIntVariable(471, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Sniper Rifle Damage")]
        [Description("Sniper Rifle Damage. (Scrum Pulsar) Range [0,5]")]
        public int _helper_Tec_SniperRifle {
            get { return this.GetIntVariable(72); }
            set { this.SetIntVariable(72, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Sniper Rifle Penetration")]
        [Description("Set to 1 to unlock Sniper Rifle Penetration. (Tungsten Sabot Jacket)")]
        public int _helper_Tec_SniperRifleR1 {
            get { return this.GetIntVariable(474); }
            set { this.SetIntVariable(474, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Sniper Headshot Damage")]
        [Description("Set to 1 to unlock Sniper Headshot Damage. (Combat Scanner)")]
        public int _helper_Tec_SniperRifleR2 {
            get { return this.GetIntVariable(475); }
            set { this.SetIntVariable(475, value); }
        }

        [Category("Weapon Upgrades")]
        [DisplayName("Heavy Weapon Ammo")]
        [Description("Heavy Weapon Ammo Upgrade. (Microfusion Array) Range[0,5]")]
        public int _helper_Tec_HeavyAmmo {
            get { return this.GetIntVariable(428); }
            set { this.SetIntVariable(428, value); }
        }

        #endregion
        #region Biotics
        [Category("Biotics")]
        [DisplayName("Biotic Damage")]
        [Description("Biotic Damage. (Hyper-Amp) Range [0,5]")]
        public int _helper_Tec_BioticUpgrade {
            get { return this.GetIntVariable(103); }
            set { this.SetIntVariable(103, value); }
        }

        [Category("Biotics")]
        [DisplayName("Biotic Duration")]
        [Description("Set to 1 to unlock Biotic Duration. (Neural Mask)")]
        public int _helper_Tec_BioticR1 {
            get { return this.GetIntVariable(458); }
            set { this.SetIntVariable(458, value); }
        }

        [Category("Biotics")]
        [DisplayName("Biotic Cooldown")]
        [Description("Set to 1 to unlock Biotic Cooldown. (Smart Amplifier)")]
        public int _helper_Tec_BioticR2 {
            get { return this.GetIntVariable(459); }
            set { this.SetIntVariable(459, value); }
        }
        #endregion
        #region Tech
        [Category("Tech")]
        [DisplayName("Tech Damage")]
        [Description("Tech Damage Upgrade. (Multicore Amplifier) Range [0,5]")]
        public int _helper_Tec_TechUpgrade {
            get { return this.GetIntVariable(75); }
            set { this.SetIntVariable(75, value); }
        }

        [Category("Tech")]
        [DisplayName("Tech Duration")]
        [Description("Set to 1 to unclock Tech Duration. (Custom Heuristics)")]
        public int _helper_Tec_TechR1 {
            get { return this.GetIntVariable(472); }
            set { this.SetIntVariable(472, value); }
        }

        [Category("Tech")]
        [DisplayName("Tech Cooldown")]
        [Description("Set to 1 to unlock Tech Cooldown. (Hyrdra Module)")]
        public int _helper_Tec_TechR2 {
            get { return this.GetIntVariable(473); }
            set { this.SetIntVariable(473, value); }
        }

        [Category("Tech")]
        [DisplayName("Calcified Endoskeleton")]
        [Description("Set to 1 to unlock Calcified Endoskeleton. (Bovine Fortitude)")]
        public int _helper_Tec_BovineFortitude {
            get { return this.GetIntVariable(448); }
            set { this.SetIntVariable(448, value); }
        }

        [Category("Tech")]
        [DisplayName("Quarian Shield Capacitor")]
        [Description("Set to 1 to unlock the Quarian Shield Capacitor. (Cyclonic Array)")]
        public int _helper_Tec_QuarianShields {
            get { return this.GetIntVariable(433); }
            set { this.SetIntVariable(433, value); }
        }
        #endregion
        #region Team Special
        [Category("Team Special")]
        [DisplayName("Krogan Shotgun")]
        [Description("Set to 2 to unlock Krogan Shotgun. [Custom Claymore Shotgun. Grunt only]")]
        public int _helper_Tec_GruntShotgun {
            get { return this.GetIntVariable(427); }
            set { this.SetIntVariable(427, value); }
        }

        [Category("Team Special")]
        [DisplayName("Krogan Vitality")]
        [Description("Set to 2 to unlock Krogan Vitality at 2/2. [Microfiber Weave. Grunt only]")]
        public int _helper_Tec_GruntUpgrade {
            get { return this.GetIntVariable(101); }
            set { this.SetIntVariable(101, value); }
        }

        [Category("Team Special")]
        [DisplayName("Subject Zero Biotic Boost")]
        [Description("Set to 1 to unlock Subject Zero Biotic Boost. [Multicore implants. Jack only]")]
        public int _helper_Tec_JackUpgrade {
            get { return this.GetIntVariable(429); }
            set { this.SetIntVariable(429, value); }
        }

        [Category("Team Special")]
        [DisplayName("Geth Sniper Rifle")]
        [Description("Set to 2 to unlock Geth Sniper Rifle. [Custom Widow Rifle. Legion only]")]
        public int _helper_Tec_LegionSniper {
            get { return this.GetIntVariable(116); }
            set { this.SetIntVariable(116, value); }
        }

        [Category("Team Special")]
        [DisplayName("Geth Shield")]
        [Description("Set to 2 to unlock Geth Shield strength at 2/2. [Cyclonic Particles. Legion only]")]
        public int _helper_Tec_LegionUpgrade {
            get { return this.GetIntVariable(121); }
            set { this.SetIntVariable(121, value); }
        }

        [Category("Team Special")]
        [DisplayName("Mordin's Omni-Tool")]
        [Description("Set to 1 to unlock Mordin Omni-Tool. [Mordin only]")]
        public int _helper_Tec_MordinUpgrade {
            get { return this.GetIntVariable(432); }
            set { this.SetIntVariable(432, value); }
        }
        #endregion
    }
}
