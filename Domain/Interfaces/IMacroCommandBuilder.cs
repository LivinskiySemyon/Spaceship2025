namespace Spaceship2025.Domain.Interfaces
{
    public interface IMacroCommandBuilder
    {
        ICommand Build(string operationName, object target);
    }
}
