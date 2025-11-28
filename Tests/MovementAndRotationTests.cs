using NUnit.Framework;
using Spaceship2025.Domain.Entities;
using Spaceship2025.Domain.Commands;
using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Tests
{
    public class MovementAndRotationTests
    {
        [Test]
        public void MoveCommand_ChangesPositionCorrectly()
        {
            var ship = new Spaceship((12, 5));
            ship.SetVelocity((-7, 3));

            var move = new MoveCommand(ship);
            move.Execute();

            Assert.AreEqual((5, 8), ship.Position);
        }

        [Test]
        public void MoveCommand_ThrowsIfPositionIsUnavailable()
        {
            var broken = new MockBrokenMovable_NoPosition();
            var cmd = new MoveCommand(broken);
            Assert.Throws<InvalidOperationException>(() => cmd.Execute());
        }

        [Test]
        public void MoveCommand_ThrowsIfVelocityIsUnavailable()
        {
            var broken = new MockBrokenMovable_NoVelocity();
            var cmd = new MoveCommand(broken);
            Assert.Throws<InvalidOperationException>(() => cmd.Execute());
        }

        [Test]
        public void RotateCommand_ChangesAngleCorrectly()
        {
            var ship = new Spaceship((0, 0), 45);
            ship.SetAngularVelocity(90);

            var rotate = new RotateCommand(ship);
            rotate.Execute();

            Assert.AreEqual(135, ship.Angle);
        }
    }

    class MockBrokenMovable_NoPosition : IMovable
    {
        public (double X, double Y) Position
        {
            get => throw new NullReferenceException();
            set => throw new NullReferenceException();
        }

        public (double dX, double dY) Velocity => (1, 1);
    }
    class MockBrokenMovable_NoVelocity : IMovable
    {
        public (double X, double Y) Position { get; set; } = (0, 0);
        public (double dX, double dY) Velocity => throw new NullReferenceException();
    }
}
