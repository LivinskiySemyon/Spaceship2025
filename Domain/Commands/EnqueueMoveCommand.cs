using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class EnqueueMoveCommand : ICommand
    {
        private readonly IMovable _ship;

        public EnqueueMoveCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            Console.WriteLine($"Move command for {_ship} enqueued.");
        }
    }
}
