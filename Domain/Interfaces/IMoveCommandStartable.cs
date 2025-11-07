using System.Collections.Generic;

namespace SpaceBattle2025.Domain.Interfaces
{
    public interface IMoveCommandStartable
    {
        IVelocityChangeable MovableObject { get; }
        (int dX, int dY) Velocity { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
