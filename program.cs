using SpaceBattle.Domain.Entities;
using SpaceBattle.Domain.Movement;
using SpaceBattle.Domain.Rotation;

namespace SpaceBattle
{
    class Program
    {
        static void Main()
        {
            var ship = new SpaceShip((12, 5), (-7, 3), 45, 90);

            var move = new MoveCommand(ship);
            move.Execute();
            Console.WriteLine($"New position: {ship.Position}");

            var rotate = new RotateCommand(ship);
            rotate.Execute();
            Console.WriteLine($"New angle: {ship.Angle}°");
        }
    }
}
