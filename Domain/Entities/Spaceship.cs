using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Entities
{
    public class Spaceship : IMovable, IRotatable
    {
        public (double X, double Y) Position { get; set; }
        public (double dX, double dY) Velocity { get; private set; }

        public double Angle { get; set; }
        public double AngularVelocity { get; private set; }

        public Spaceship((double X, double Y) position, double angle = 0)
        {
            Position = position;
            Angle = (angle % 360 + 360) % 360;
        }

        public void SetVelocity((double dX, double dY) velocity)
        {
            Velocity = velocity;
        }

        public void SetAngularVelocity(double angularVelocity)
        {
            AngularVelocity = angularVelocity;
        }
    }
}
