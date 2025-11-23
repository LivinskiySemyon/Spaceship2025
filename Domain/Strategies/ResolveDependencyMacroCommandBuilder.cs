using Spaceship2025.Domain.Interfaces;
using Spaceship2025.Domain.Commands;
using Spaceship2025.Domain.IoC;

namespace Spaceship2025.Domain.Strategies
{
    public class ResolveDependencyMacroCommandBuilder : IMacroCommandBuilder
    {
        public ICommand Build(string operationName, object target)
        {
            var stepNames = (IEnumerable<string>)IoC.Resolve($"{operationName}:Steps", target);

            var commands = stepNames
                .Select(step => (ICommand)IoC.Resolve($"{operationName}:{step}", target))
                .ToList();

            return new MacroCommand(commands);
        }
    }
}
