namespace Spaceship2025.Domain.Interfaces
{
    public interface ICollisionDetector
    {
        bool IsCollision(ICollidable a, ICollidable b);
    }
}
