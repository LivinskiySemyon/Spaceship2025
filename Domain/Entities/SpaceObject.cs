using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Entities
{
    public class SpaceObject : ICollidable
    {
        public string Id { get; }
        public (int X, int Y) Position { get; set; }
        public int Size { get; }

        public SpaceObject(string id, (int X, int Y) pos, int size)
        {
            Id = id;
            Position = pos;
            Size = size;
        }
    }
}
