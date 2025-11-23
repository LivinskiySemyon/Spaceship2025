namespace Spaceship2025.Domain.Interfaces
{
    public interface IIoCStrategy
    {
        object Resolve(string key, object arg);
    }
}
