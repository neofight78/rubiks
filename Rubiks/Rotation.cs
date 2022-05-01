namespace Rubiks;

public readonly struct Rotation
{
    public Rotation(Face face, Direction direction)
    {
        Face = face;
        Direction = direction;
    }

    public Face Face { get; }
    public Direction Direction { get; }

    public override string ToString()
    {
        return $"{Face} {Direction}";
    }

    public static IEnumerable<Rotation> GetValues()
    {
        return new[]
        {
            new Rotation(Face.Front, Direction.Clockwise),
            new Rotation(Face.Front, Direction.AntiClockwise),
            new Rotation(Face.Up, Direction.Clockwise),
            new Rotation(Face.Up, Direction.AntiClockwise),
            new Rotation(Face.Right, Direction.Clockwise),
            new Rotation(Face.Right, Direction.AntiClockwise),
            new Rotation(Face.Down, Direction.Clockwise),
            new Rotation(Face.Down, Direction.AntiClockwise),
            new Rotation(Face.Left, Direction.Clockwise),
            new Rotation(Face.Left, Direction.AntiClockwise),
            new Rotation(Face.Back, Direction.Clockwise),
            new Rotation(Face.Back, Direction.AntiClockwise)
        };
    }
}

public static class RotationExtensions
{
    public static string ToCommaSeperatedList(this IEnumerable<Rotation> rotations)
    {
        return string.Join(",", rotations);
    }
}