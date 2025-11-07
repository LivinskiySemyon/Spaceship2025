using System.Runtime;
using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Movement;

public class RotateCommand : ICommand
{
    private readonly IRotatable _target;

    public RotateCommand(IRotatable target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
    }
    
    public void Execute()
    {
        _target.Angle += _target.AngularVelocity;

    }
}