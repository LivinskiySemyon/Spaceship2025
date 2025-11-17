using Spaceship2025.Domain.Interfaces;

namespace Spaceship2025.Domain.Commands
{
    public class ResolveCollisionCommand : ICommand
    {
        private readonly ICommand _check;
        private readonly ICommand _handle;

        public ResolveCollisionCommand(ICommand check, ICommand handle)
        {
            _check = check;
            _handle = handle;
        }

        public void Execute()
        {
            _check.Execute(); // вызывает обработку только если столкновение есть
        }
    }
}
