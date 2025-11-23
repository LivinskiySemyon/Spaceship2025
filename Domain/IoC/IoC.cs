using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.IoC
{
    public static class IoC
    {
        private static readonly Dictionary<string, Func<object, object>> Dependencies = new Dictionary<string, Func<object, object>>();

        public static void Register(string key, Func<object, object> dependency)
        {
            Dependencies[key] = dependency;
        }

        public static object Resolve(string key, object arg)
        {
            if (!Dependencies.ContainsKey(key))
                throw new InvalidOperationException($"Dependency '{key}' not found.");

            return Dependencies[key](arg);
        }
    }
}
