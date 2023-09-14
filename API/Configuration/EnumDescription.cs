using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescriptionFromValue<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        Type enumType = enumValue.GetType();
        FieldInfo fieldInfo = enumType.GetField(enumValue.ToString());

        if (fieldInfo != null)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }

        return enumValue.ToString();
    }
}