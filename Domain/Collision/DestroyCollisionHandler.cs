using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Collision
{
    public class DestroyCollisionHandler : ICollisionHandler
    {
        public void Handle(ICollidable a, ICollidable b)
        {
            Console.WriteLine($"Objects {a.Id} and {b.Id} destroyed after collision.");
        }
    }
}
