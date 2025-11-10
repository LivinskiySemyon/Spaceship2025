using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class StartRotateCommand : ICommand
    {
        private readonly IRotateCommandStartable _context;

        public StartRotateCommand(IRotateCommandStartable context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Execute()
        {
            _context.RotatableObject.AngularVelocity = _context.AngularVelocity;
            var rotate = new RotateCommand((IRotatable)_context.RotatableObject);
            var bridge = new BridgeCommand(rotate);
            _context.CommandQueue.Enqueue(bridge);
        }
    }
}
