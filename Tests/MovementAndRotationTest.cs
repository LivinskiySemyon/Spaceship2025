using NUnit.Framework;
using SpaceBattle.Domain.Entities;
using SpaceBattle.Domain.Movement;
using SpaceBattle.Domain.Rotation;
using SpaceBattle.Domain.Interfaces;

namespace SpaceBattle.Tests
{
    public class MovementAndRotationTests
    {
        [Test]
        public void MoveCommand_ChangesPositionCorrectly()
        {
            IMovable ship = new SpaceShip((12, 5), (-7, 3), 0, 0);
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
            IRotatable ship = new SpaceShip((0, 0), (0, 0), 45, 90);
            var rotate = new RotateCommand(ship);

            rotate.Execute();

            Assert.AreEqual(135, ship.Angle);
        }
    }

    class MockBrokenMovable_NoPosition : IMovable
    {
        public (int X, int Y) Position { get => throw new NullReferenceException(); set => throw new NullReferenceException(); }
        public (int dX, int dY) Velocity => (1, 1);
        public void Move() => throw new NotImplementedException();
    }

    class MockBrokenMovable_NoVelocity : IMovable
    {
        public (int X, int Y) Position { get; set; } = (0, 0);
        public (int dX, int dY) Velocity => throw new NullReferenceException();
        public void Move() => throw new NotImplementedException();
    }
}
