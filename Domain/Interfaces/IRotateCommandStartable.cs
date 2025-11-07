using System.Collections.Generic;

namespace Spaceship2025.Domain.Interfaces
{
    public interface IRotateCommandStartable
    {
        IAngularVelocityChangeable RotatableObject { get; }
        double AngularVelocity { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
