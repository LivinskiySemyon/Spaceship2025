using NUnit.Framework;
using System.Collections.Generic;
using SpaceBattle.Domain.Interfaces;
using SpaceBattle.Domain.Commands;
using SpaceBattle.Domain.Entities;

namespace SpaceBattle.Tests
{
    public class StartEndRotateTests
    {
        [Test]
        public void StartRotateCommand_AddsRotateCommandToQueue()
        {
            var ship = new SpaceShip((0, 0), 45);
            var queue = new Queue<ICommand>();
            var context = new MockRotateStartContext(ship, 90, queue);

            var cmd = new StartRotateCommand(context);
            cmd.Execute();

            Assert.That(queue.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<BridgeCommand>(queue.Peek());
        }

        [Test]
        public void EndRotateCommand_DisablesBridge()
        {
            var ship = new SpaceShip((0, 0), 45);
            var rotate = new BridgeCommand(new RotateCommand(ship));
            var queue = new Queue<ICommand>();
            var context = new MockRotateEndContext(ship, rotate, queue);

            var cmd = new EndRotateCommand(context);
            cmd.Execute();

            Assert.DoesNotThrow(() => rotate.Execute());
        }
    }

    public class MockRotateStartContext : IRotateCommandStartable
    {
        public IAngularVelocityChangeable RotatableObject { get; }
        public double AngularVelocity { get; }
        public Queue<ICommand> CommandQueue { get; }

        public MockRotateStartContext(IAngularVelocityChangeable obj, double vel, Queue<ICommand> q)
        {
            RotatableObject = obj;
            AngularVelocity = vel;
            CommandQueue = q;
        }
    }

    public class MockRotateEndContext : IRotateCommandEndable
    {
        public ICommand RotateCommand { get; }
        public IAngularVelocityChangeable RotatableObject { get; }
        public Queue<ICommand> CommandQueue { get; }

        public MockRotateEndContext(IAngularVelocityChangeable obj, ICommand cmd, Queue<ICommand> q)
        {
            RotatableObject = obj;
            RotateCommand = cmd;
            CommandQueue = q;
        }
    }
}
