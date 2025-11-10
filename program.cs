using SpaceBattle.Domain.Entities;
using SpaceBattle.Domain.Commands;
using SpaceBattle.Domain.Interfaces;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var ship = new SpaceShip((0, 0), 45);
        var queue = new Queue<ICommand>();

        // Начало движения
        var startMoveCtx = new MockMoveStartContext(ship, (2, 1), queue);
        new StartMoveCommand(startMoveCtx).Execute();

        // Выполнение движения
        queue.Dequeue().Execute();
        Console.WriteLine($"Position after move: {ship.Position}");

        // Поворот
        var startRotateCtx = new MockRotateStartContext(ship, 90, queue);
        new StartRotateCommand(startRotateCtx).Execute();
        queue.Dequeue().Execute();
        Console.WriteLine($"Angle after rotate: {ship.Angle}");

        // Завершение движений
        var endMoveCtx = new MockMoveEndContext(ship, new BridgeCommand(new MoveCommand(ship)), queue);
        new EndMoveCommand(endMoveCtx).Execute();
        var endRotateCtx = new MockRotateEndContext(ship, new BridgeCommand(new RotateCommand(ship)), queue);
        new EndRotateCommand(endRotateCtx).Execute();
    }
}
