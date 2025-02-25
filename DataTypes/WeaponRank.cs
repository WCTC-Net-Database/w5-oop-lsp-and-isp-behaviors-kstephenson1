using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace w5_assignment_ksteph.DataTypes
{
    [JsonConverter(typeof(JsonStringEnumConverter<WeaponRank>))]
    public enum WeaponRank
    {
        [EnumMember(Value = "E")]
        E = 0,
        [EnumMember(Value = "D")]
        D = 1,
        [EnumMember(Value = "C")]
        C = 2,
        [EnumMember(Value = "B")]
        B = 3,
        [EnumMember(Value = "A")]
        A = 4,
        [EnumMember(Value = "S")]
        S = 5,
    }
}
