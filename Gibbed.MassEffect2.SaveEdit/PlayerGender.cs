using System.Collections.Generic;

namespace Gibbed.MassEffect2.SaveEdit
{
    internal class PlayerGender
    {
        public bool Type { get; set; }
        public string Name { get; set; }

        public PlayerGender(bool type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public static List<PlayerGender> GetGenders()
        {
            List<PlayerGender> genders = new List<PlayerGender>();
            genders.Add(new PlayerGender(false, "Male"));
            genders.Add(new PlayerGender(true, "Female"));
            return genders;
        }
    }
}
