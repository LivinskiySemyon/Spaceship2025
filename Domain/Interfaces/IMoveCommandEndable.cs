using System.Collections.Generic;

namespace Spaceship2025.Domain.Interfaces
{
    public interface IMoveCommandEndable
    {
        ICommand MoveCommand { get; }
        IVelocityChangeable MovableObject { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
