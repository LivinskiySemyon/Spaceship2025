using Spaceship2025.Domain.Entities;
using Spaceship2025.Domain.Collision;
using Spaceship2025.Domain.Commands;

class CollisionProgram
{
    static void Main()
    {
        var obj1 = new SpaceObject("Obj1", (0, 0), 10);
        var obj2 = new SpaceObject("Obj2", (12, 0), 10);

        var detector = new SimpleCollisionDetector();
        var handler = new DestroyCollisionHandler();

        var cmd = new CheckCollisionCommand(
            obj1, obj2, detector,
            () => new CollisionCommand(obj1, obj2, handler).Execute()
        );

        cmd.Execute();
    }
}
