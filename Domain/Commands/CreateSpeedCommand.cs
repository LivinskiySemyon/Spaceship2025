using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class CreateSpeedCommand : ICommand
    {
        private readonly IMovable _ship;

        public CreateSpeedCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.Velocity = (1, 1);
        }
    }
}
