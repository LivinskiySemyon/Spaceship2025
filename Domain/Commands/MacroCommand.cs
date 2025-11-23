using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class MacroCommand : ICommand
    {
        private readonly IEnumerable<ICommand> _commands;

        public MacroCommand(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            foreach (var cmd in _commands)
                cmd.Execute();
        }
    }
}
