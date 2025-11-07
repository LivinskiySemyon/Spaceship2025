using System.Collections.Generic;

namespace SpaceBattle.Domain.Interfaces
{
    public interface IRotateCommandEndable
    {
        ICommand RotateCommand { get; }
        IAngularVelocityChangeable RotatableObject { get; }
        Queue<ICommand> CommandQueue { get; }
    }
}
