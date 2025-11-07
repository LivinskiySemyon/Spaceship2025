using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class EndMoveCommand : ICommand
    {
        private readonly IMoveCommandEndable _context;

        public EndMoveCommand(IMoveCommandEndable context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Execute()
        {
            _context.MovableObject.Velocity = null;

            if (_context.MoveCommand is BridgeCommand bridge)
            {
                bridge.Inject(new NullCommand());
            }
        }
    }
}
