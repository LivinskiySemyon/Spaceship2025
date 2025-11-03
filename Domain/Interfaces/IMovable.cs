namespace SpaceBattle2025.Domain.Interfaces;

public interface IMovable
{
    (int X, int Y) Position { get; set; }
    (int dX, int dY) Velocity { get; set; }

    void Move();
}
