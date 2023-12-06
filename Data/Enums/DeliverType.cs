using System.Runtime.Serialization;

namespace EcommerseBot.Data.Enums;

public enum DeliverType
{
    [EnumMember(Value = "🏃 Olib ketish")]
    ByYourself = 1,
    [EnumMember(Value = "🚖 Yetkazib berish")]
    ByCourier 
}
