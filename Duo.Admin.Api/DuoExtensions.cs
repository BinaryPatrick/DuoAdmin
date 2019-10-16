using System;
using System.ComponentModel;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Unf.Core.Duo.Adapters;
using Unf.Core.Duo.Models;

namespace Unf.Core.Duo
{
    public static class DuoExtensions
    {
        public static IServiceCollection AddDuoServices(this IServiceCollection services, Action<DuoOptions> options)
        {
            services.Configure(options);
            services.AddScoped<IDuoAdapter, DuoAdapter>();
            return services;
        }

        internal static string ToBase64(this string value) => value.ToBase64(new UTF8Encoding());

        internal static string FromBase64(this string value) => value.FromBase64(new UTF8Encoding());

        internal static string ToBase64(this string value, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        internal static string FromBase64(this string value, Encoding encoding)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return encoding.GetString(bytes);
        }

        internal static bool TryParse<T>(this string valueStr, out T result) where T : struct
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    result = (T)converter.ConvertFromString(valueStr);
                    return true;
                }
                catch { }
            }
            result = default;
            return false;
        }
    }
}
