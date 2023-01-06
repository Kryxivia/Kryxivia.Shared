using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Kryxivia.Shared.Enums
{
    public enum DisplayTypeEnum
    {
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "boost_number")]
        BoostNumber,
        [EnumMember(Value = "boost_percentage")]
        BoostPercentage
    }
}
