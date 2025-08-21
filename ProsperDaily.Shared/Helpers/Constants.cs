using ProsperDaily.Shared.Entities;
using System.Drawing;
using System.Reflection;

namespace ProsperDaily.Shared.Helpers;

public static class Constants
{
    // Db Configuration
    public const string DatabaseName = "ProperDaily.db3";
    public const string Admin = "Admin";
    public const string Created = "Created";
    public const string CreatedBy = "CreatedBy";
    public const string LastModified = "LastModified";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string Anonymous = "Anonymous";

    // Mapper Configuration
    public static U MapLite<T, U>(T src, U dest) where U : class, new()
    {
        List<PropertyInfo> properties = [.. typeof(U).GetProperties()];
        typeof(T).GetProperties().Where(x => !typeof(Entity).GetProperties().Any(y => y.Name == x.Name) && (x.PropertyType == typeof(string) || x.PropertyType.IsValueType)).ToList().ForEach(x =>
        {
            PropertyInfo? property = properties.FirstOrDefault(p => p.Name == x.Name);
            if (property is not null && property.CanWrite && property.GetType() == x.GetType())
            {
                property.SetValue(dest, x.GetValue(src), null);
            }
        });
        return dest;
    }

    public static U? MapLites<T, U>(T? src, U? dest) where U : class, new()
    {
        List<PropertyInfo> properties = [.. typeof(U).GetProperties()];
        typeof(T).GetProperties().Where(x => !typeof(Entity).GetProperties().Any(y => y.Name == x.Name) && (x.PropertyType == typeof(string) || x.PropertyType.IsValueType)).ToList().ForEach(x =>
        {
            PropertyInfo? property = properties.FirstOrDefault(p => p.Name == x.Name);
            if (property is not null && property.CanWrite && property.GetType() == x.GetType())
            {
                property.SetValue(dest, x.GetValue(src), null);
            }
        });
        return dest;
    }

    public static List<U> MapLite<T, U>(List<T> srcs) where U : class, new() => [.. srcs.Select(s => MapLite(s, new U { }))];

    public static List<T> MapLite<T>(List<T> srcs) where T : class, new() => [.. srcs.Select(s => MapLite(s, new T { }))];

    // Colors
    public static string ToHex(this Color color, bool includeAlpha = true) => includeAlpha ?
        $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}" :
        $"#{color.R:X2}{color.G:X2}{color.B:X2}";
}
