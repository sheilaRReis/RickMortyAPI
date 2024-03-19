using System.Text;

namespace Rick_MortyAPI.Helper
{
    internal static class BuildFilterUrlHelpers
    {
        public static string BuildFilterUrl(this string baseUrl, params (string, string)[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
                return baseUrl;

            var builder = new StringBuilder(baseUrl);

            foreach (var (key, value) in parameters)
            {
                if (!string.IsNullOrEmpty(value))
                    builder.Append($"{(builder.ToString().Contains("?") ? "&" : "?")}{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");
            }

            return builder.ToString();
        }
    }
}
