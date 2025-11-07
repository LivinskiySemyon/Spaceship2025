namespace Spaceship2025.Domain.Interfaces
{
    public interface IVelocityChangeable
    {
        (int dX, int dY)? Velocity { get; set; }
    }
}