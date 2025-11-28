namespace Spaceship2025.Domain.Interfaces;

public interface IMovable
{
    (double X, double Y) Position { get; set; }
    (double dX, double dY) Velocity { get;}
}
