using Spaceship2025.Domain.IoC;
using Spaceship2025.Domain.Interfaces;

class Program
{
    static void Main()
    {
        IoCConfig.Configure();
        MovementOperationRegistration.RegisterMovement();

        var ship = new SpaceShip((0,0));

        // Universal IoC strategy invocation
        var macro = (ICommand)IoC.Resolve("Strategy.LongOperation", null)
            .Resolve("Movement", ship);

        macro.Execute();
    }
}
