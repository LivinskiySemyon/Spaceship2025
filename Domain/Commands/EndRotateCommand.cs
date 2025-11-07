using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class EndRotateCommand : ICommand
    {
        private readonly IRotateCommandEndable _context;

        public EndRotateCommand(IRotateCommandEndable context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Execute()
        {
            _context.RotatableObject.AngularVelocity = null;

            if (_context.RotateCommand is BridgeCommand bridge)
            {
                bridge.Inject(new NullCommand());
            }
        }
    }
}
