using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class StartMoveCommand : ICommand
    {
        private readonly IMoveCommandStartable _context;

        public StartMoveCommand(IMoveCommandStartable context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Execute()
        {
            _context.MovableObject.Velocity = _context.Velocity;
            var move = new MoveCommand((IMovable)_context.MovableObject);
            var bridge = new BridgeCommand(move);
            _context.CommandQueue.Enqueue(bridge);
        }
    }
}
