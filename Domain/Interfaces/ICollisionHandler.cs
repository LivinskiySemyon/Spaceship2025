namespace Spaceship2025.Domain.Interfaces
{
    public interface ICollisionHandler
    {
        void Handle(ICollidable a, ICollidable b);
    }
}