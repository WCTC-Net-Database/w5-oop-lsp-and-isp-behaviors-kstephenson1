using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace w5_assignment_ksteph.DataTypes
{
    [JsonConverter(typeof(JsonNumberEnumConverter<WeaponType>))]
    public enum WeaponType
    {
        None = 0,
        Sword = 1,
        Axe = 2,
        Lance = 3,
        Bow = 4,
        Elemental = 5,
        Dark = 6,
        Light = 7,
        Heal = 8
    }
}
