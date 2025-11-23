using Spaceship2025.Domain.Interfaces;
using Spaceship2025.Domain.Commands;
using Spaceship2025.Domain.IoC;

namespace Spaceship2025.Domain.Strategies
{
    public class BuildLongOperationMacroCommandStrategy : IIoCStrategy
    {
        public object Resolve(string operationName, object target)
        {
            var steps = (IEnumerable<string>)IoC.Resolve($"{operationName}:Steps", target);

            var commands = new List<ICommand>();

            foreach (var step in steps)
            {
                var cmd = (ICommand)IoC.Resolve($"{operationName}:{step}", target);
                commands.Add(cmd);
            }

            return new MacroCommand(commands);
        }
    }
}
