using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands;

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