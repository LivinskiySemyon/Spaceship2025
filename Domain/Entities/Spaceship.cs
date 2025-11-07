using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Entities
{
    public class SpaceShip : IMovable, IRotatable
    {
        public (int X, int Y) Position { get; set; }
        public (int dX, int dY) Velocity { get; private set; }

        public double Angle { get; set; }
        public double AngularVelocity { get; private set; }

        public SpaceShip((int X, int Y) position, (int dX, int dY) velocity,
                         double angle, double angularVelocity)
        {
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
        }

        public void Move()
        {
            Position = (Position.X + Velocity.dX, Position.Y + Velocity.dY);
        }

        public void Rotate()
        {
            Angle += AngularVelocity;
        }
    }
}
