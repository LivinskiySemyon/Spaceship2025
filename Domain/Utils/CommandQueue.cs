using Spaceship2025.Collections.Generic;

namespace Spaceship2025.Domain.Utils
{
    public class CommandQueue
    {
        public Queue<ICommand> Queue { get; } = new();

        public void ExecuteAll()
        {
            while (Queue.Count > 0)
            {
                Queue.Dequeue().Execute();
            }
        }
    }
}
