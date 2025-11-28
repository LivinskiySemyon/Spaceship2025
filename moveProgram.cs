using SpaceBattle.Domain.Entities;
using SpaceBattle.Domain.Commands;
using SpaceBattle.Domain.Interfaces;

class moveProgram
{
    static void Main()
    {
        var ship = new Spaceship((0, 0), 0);
        ship.SetVelocity((2, 3));
        var move = new MoveCommand(ship);
        var rotate = new RotateCommand(ship);

        move.Execute();
        rotate.Execute();

        Console.WriteLine(ship.Position);
        Console.WriteLine(ship.Angle);
    }
}
