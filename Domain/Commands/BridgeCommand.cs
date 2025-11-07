using SpaceBattle.Domain.Interfaces;

namespace SpaceBattle.Domain.Commands
{
    public class BridgeCommand : ICommand
    {
        private ICommand _internalCommand;

        public BridgeCommand(ICommand internalCommand)
        {
            _internalCommand = internalCommand ?? throw new ArgumentNullException(nameof(internalCommand));
        }

        public void Inject(ICommand newCommand)
        {
            _internalCommand = newCommand ?? throw new ArgumentNullException(nameof(newCommand));
        }

        public void Execute() => _internalCommand.Execute();
    }

    public class NullCommand : ICommand
    {
        public void Execute(){}
    }
}
