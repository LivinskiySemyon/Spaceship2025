using Spaceship2025.Domain.IoC;
using Spaceship2025.Domain.Commands;
using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025
{
    public static class MovementOperationRegistration
    {
        public static void RegisterMovement()
        {
            IoC.Register("Movement:Steps", 
                _ => new List<string> { "CreateSpeed", "EnqueueMove" });

            IoC.Register("Movement:CreateSpeed", target =>
            {
                var ship = (IMovable)target;
                return new CreateSpeedCommand(ship);
            });

            IoC.Register("Movement:EnqueueMove", target =>
            {
                var ship = (IMovable)target;
                return new EnqueueMoveCommand(ship);
            });
        }
    }
}
