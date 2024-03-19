using System;

namespace Rick_MortyAPI.Helper
{
    public static class MapperHelpers
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            if (Enum.TryParse(value, true, out T result))
                return result;
            else
                throw new ArgumentException($"Invalid value '{value}' for enum type {typeof(T)}");
        }

        public static Uri ToUri(this string value)
        {
            if (Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri result))
                return result;
            else
                throw new ArgumentException($"Invalid URI format: {value}");
        }

        public static DateTime ToDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
                return result;
            else
                throw new ArgumentException($"Invalid DateTime format: {value}");
        }
    }
}
