using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands;

public class RotateCommand : ICommand
{
    private readonly IRotatable _target;

    public RotateCommand(IRotatable target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
    }
    
    public void Execute()
    {
        _target.Angle = (_target.Angle + _target.AngularVelocity % 360 + 360) % 360;
    }
}