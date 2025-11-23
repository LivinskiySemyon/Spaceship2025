using Spaceship2025.Domain.IoC;
using Spaceship2025.Domain.Strategies;

namespace Spaceship2025
{
    public static class IoCConfig
    {
        public static void Configure()
        {
            // Register strategies
            IoC.Register("Strategy.MacroCommandBuilder", 
                _ => new ResolveDependencyMacroCommandBuilder());

            IoC.Register("Strategy.LongOperation", 
                _ => new BuildLongOperationMacroCommandStrategy());
        }
    }
}
