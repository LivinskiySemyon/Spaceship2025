using System.Collections.Generic;

namespace SpaceBattle.Domain.Interfaces
{
    public interface IMoveCommandEndable
    {
        ICommand MoveCommand { get; }
        IVelocityChangeable MovableObject { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
