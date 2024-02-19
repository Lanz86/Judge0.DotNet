using System.Text;

namespace Judge0.DotNet.Extensions
{
    public static class Base64Extensions
    {
        public static string? ToBase64(this string? value) 
        {
            if(value is null) return null;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
        
        public static string? FromBase64(this string? value)
        {
            if (value is null)
                return null;
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}
