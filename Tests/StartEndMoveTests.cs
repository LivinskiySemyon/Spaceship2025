using NUnit.Framework;
using System.Collections.Generic;
using SpaceBattle.Domain.Interfaces;
using SpaceBattle.Domain.Commands;
using SpaceBattle.Domain.Entities;

namespace SpaceBattle.Tests
{
    public class StartEndMoveTests
    {
        [Test]
        public void StartMoveCommand_AddsMoveCommandToQueue()
        {
            var ship = new SpaceShip((0, 0));
            var queue = new Queue<ICommand>();

            var context = new MockMoveStartContext(ship, (1, 2), queue);
            var cmd = new StartMoveCommand(context);

            cmd.Execute();

            Assert.That(queue.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<BridgeCommand>(queue.Peek());
        }

        [Test]
        public void EndMoveCommand_DisablesCommand()
        {
            var ship = new SpaceShip((0, 0));
            var move = new BridgeCommand(new MoveCommand(ship));
            var queue = new Queue<ICommand>();

            var context = new MockMoveEndContext(ship, move, queue);
            var cmd = new EndMoveCommand(context);

            cmd.Execute();

            Assert.DoesNotThrow(() => move.Execute());
        }
    }

    public class MockMoveStartContext : IMoveCommandStartable
    {
        public IVelocityChangeable MovableObject { get; }
        public (int dX, int dY) Velocity { get; }
        public Queue<ICommand> CommandQueue { get; }

        public MockMoveStartContext(IVelocityChangeable obj, (int, int) vel, Queue<ICommand> q)
        {
            MovableObject = obj;
            Velocity = vel;
            CommandQueue = q;
        }
    }

    public class MockMoveEndContext : IMoveCommandEndable
    {
        public ICommand MoveCommand { get; }
        public IVelocityChangeable MovableObject { get; }
        public Queue<ICommand> CommandQueue { get; }

        public MockMoveEndContext(IVelocityChangeable obj, ICommand cmd, Queue<ICommand> q)
        {
            MovableObject = obj;
            MoveCommand = cmd;
            CommandQueue = q;
        }
    }
}
