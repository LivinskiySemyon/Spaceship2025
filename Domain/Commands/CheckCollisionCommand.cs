using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class CheckCollisionCommand : ICommand
    {
        private readonly ICollidable _a;
        private readonly ICollidable _b;
        private readonly ICollisionDetector _detector;
        private readonly Action _onCollision;

        public CheckCollisionCommand(
            ICollidable a,
            ICollidable b,
            ICollisionDetector detector,
            Action onCollision)
        {
            _a = a;
            _b = b;
            _detector = detector;
            _onCollision = onCollision;
        }

        public void Execute()
        {
            if (_detector.IsCollision(_a, _b))
                _onCollision();
        }
    }
}
