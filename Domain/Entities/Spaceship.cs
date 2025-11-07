using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Entities
{
    public class SpaceShip : IMovable, IRotatable, IVelocityChangeable, IAngularVelocityChangeable
    {
        public (int X, int Y) Position { get; set; }
        public (int dX, int dY) Velocity { get; private set; }
        (int dX, int dY) IMovable.Velocity => Velocity ?? throw new InvalidOperationException("Скорость не задана.");

        public double Angle { get; set; }
        public double AngularVelocity { get; private set; }
        double IRotatable.AngularVelocity => AngularVelocity ?? throw new InvalidOperationException("Угловая скорость не задана.");

        public SpaceShip((int X, int Y) position, double angle = 0)
        {
            Position = position;
            Angle = angle;
        }
    }
}
