using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Collision
{
    public class SimpleCollisionDetector : ICollisionDetector
    {
        public bool IsCollision(ICollidable a, ICollidable b)
        {
            var dx = a.Position.X - b.Position.X;
            var dy = a.Position.Y - b.Position.Y;
            var dist2 = dx * dx + dy * dy;
            var radiusSum = a.Size + b.Size;

            return dist2 <= radiusSum * radiusSum;
        }
    }
}
