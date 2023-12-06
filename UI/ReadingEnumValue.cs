using System.Runtime.Serialization;

namespace EcommerseBot.UI;

public class ReadingEnumValue
{
    public string GetValue(Type enumType, object enumVal)
    {
        var memInfo = enumType.GetMember(enumVal.ToString()?? "");
        var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
        if(attr != null)
        {
            return attr.Value ?? "";
        }

        return null?? "";
    }
}
