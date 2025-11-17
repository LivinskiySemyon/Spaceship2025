namespace Spaceship2025.Domain.Interfaces
{
    public interface ICollidable
    {
        (int X, int Y) Position { get; }
        int Size { get; }
        string Id { get; }
    }
}