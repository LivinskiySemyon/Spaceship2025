using System.Runtime;
using Spacebattle2025.Domain.Interfaces;

namespace Spacebattle2025.Domain.Movement;

public class RotateCommand
{
    private readonly IRotatable _target;

    public RotateCommand(IRotatable target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
    }
    
    public void Execute()
    {
        try
        {
            _target.Angle += _target.AngularVelocity;
        }
        
        catch (NullReferenceException)
        {
            throw new InvalidOperationException("Невозможно выполнить движение — отсутствуют координаты или скорость.");
        }
    }
}