using NUnit.Framework;
using Spaceship2025.Domain.Entities;
using Spaceship2025.Domain.Collision;
using Spaceship2025.Domain.Commands;

namespace Spaceship2025.Tests
{
    public class CollisionTests
    {
        [Test]
        public void CollisionDetected_AndHandled()
        {
            var a = new SpaceObject("A", (0, 0), 5);
            var b = new SpaceObject("B", (3, 4), 5);

            var detector = new SimpleCollisionDetector();
            var handler = new TestCollisionHandler();

            bool handlerCalled = false;

            var checkCmd = new CheckCollisionCommand(a, b, detector, () =>
            {
                new CollisionCommand(a, b, handler).Execute();
                handlerCalled = true;
            });

            checkCmd.Execute();

            Assert.IsTrue(handlerCalled);
        }

        class TestCollisionHandler : ICollisionHandler
        {
            public void Handle(ICollidable a, ICollidable b) { }
        }
    }
}
