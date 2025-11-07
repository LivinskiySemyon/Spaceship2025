using System.Collections.Generic;

namespace SpaceBattle.Domain.Interfaces
{
    public interface IRotateCommandStartable
    {
        IAngularVelocityChangeable RotatableObject { get; }
        double AngularVelocity { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
