using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class CollisionCommand : ICommand
    {
        private readonly ICollidable _a;
        private readonly ICollidable _b;
        private readonly ICollisionHandler _handler;

        public CollisionCommand(ICollidable a, ICollidable b, ICollisionHandler handler)
        {
            _a = a;
            _b = b;
            _handler = handler;
        }

        public void Execute()
        {
            _handler.Handle(_a, _b);
        }
    }
}
