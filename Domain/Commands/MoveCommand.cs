using Spacebattle2025.Domain.Interfaces;

namespace Spacebattle2025.Domain.Movement;

public class MoveCommand : ICommand
{
    private readonly IMovable _target;

    public MoveCommand(IMovable target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
    }
    
    public void Execute()
    {
        var (x, y) = _target.Position;
        var (dx, dy) = _target.Velocity;

        _target.Position = (x + dx, y + dy);
    }
}