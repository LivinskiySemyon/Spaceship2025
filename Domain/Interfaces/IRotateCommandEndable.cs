using System.Collections.Generic;

namespace Spaceship2025.Domain.Interfaces
{
    public interface IRotateCommandEndable
    {
        ICommand RotateCommand { get; }
        IAngularVelocityChangeable RotatableObject { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
