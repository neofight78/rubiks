using System.Text;

namespace Rubiks;

// Multi-dimensional array based implementation of ICube
public class Cube : ICube
{
    private readonly Colour[,,] _faces = new Colour[6, 3, 3];

    public Cube()
    {
        foreach (var face in Enum.GetValues<Face>())
            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                this[face, row, col] = face switch
                {
                    Face.Front => Colour.Green,
                    Face.Up => Colour.White,
                    Face.Right => Colour.Red,
                    Face.Down => Colour.Yellow,
                    Face.Left => Colour.Orange,
                    Face.Back => Colour.Blue,
                    _ => throw new ArgumentOutOfRangeException(nameof(face), face, "Invalid face value")
                };
    }

    private Cube(Cube cube)
    {
        Array.Copy(cube._faces, _faces, cube._faces.Length);
    }

    public Colour this[Face face, int row, int col]
    {
        get => _faces[(int)face, row, col];
        internal set => _faces[(int)face, row, col] = value;
    }

    public ICube Clone()
    {
        return new Cube(this);
    }

    public bool Equals(ICube? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        foreach (var face in Enum.GetValues<Face>())
            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                if (this[face, row, col] != other[face, row, col])
                    return false;

        return true;
    }

    public bool IsSolved()
    {
        foreach (var face in Enum.GetValues<Face>())
        {
            var colour = this[face, 0, 0];

            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                if (this[face, row, col] != colour)
                    return false;
        }

        return true;
    }

    // Rotates a face of the cube
    public void Rotate(Rotation rotation)
    {
        // Inner tiles - the tiles on the face itself that are affected by the rotation (central tile doesn't change)
        Rotate(rotation.Direction, GetInnerTiles(rotation.Face));

        // Outer tiles - the tiles on the neighbouring faces that are affected by the rotation
        Rotate(rotation.Direction, GetOuterTiles(rotation.Face));
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Cube);
    }

    public override int GetHashCode()
    {
        // overflow is normal / intended here
        unchecked
        {
            var hash = 17;

            foreach (var face in Enum.GetValues<Face>())
                for (var row = 0; row < 3; row++)
                for (var col = 0; col < 3; col++)
                    hash = hash * 23 + this[face, row, col].GetHashCode();

            return hash;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        // Following line is added as some IDEs trim leading whitespace from test output, thus messing up the layout
        builder.Append("Rubik's Cube:\n");

        var layout = new Face?[,]
        {
            { null, Face.Up, null, null },
            { Face.Left, Face.Front, Face.Right, Face.Back },
            { null, Face.Down, null, null }
        };

        for (var row = 0; row < 3; row++)
        for (var line = 0; line < 5; line++)
        {
            for (var col = 0; col < 4; col++)
                if (layout[row, col] is { } face)
                    switch (line)
                    {
                        case 0:
                        case 4:
                            builder.Append("-----");
                            break;
                        default:
                            // ReSharper disable once PassStringInterpolation
                            builder.AppendFormat("|{0}{1}{2}|",
                                this[face, line - 1, 0].ToString()[..1],
                                this[face, line - 1, 1].ToString()[..1],
                                this[face, line - 1, 2].ToString()[..1]);
                            break;
                    }
                else
                    builder.Append("     ");

            builder.Append('\n');
        }

        return builder.ToString();
    }

    // Inner tiles - the tiles on the face itself that are affected by the rotation (in Clockwise order)
    private static (Face face, int row, int col)[] GetInnerTiles(Face face)
    {
        return new (Face face, int row, int col)[]
        {
            (face, 0, 0),
            (face, 0, 1),
            (face, 0, 2),
            (face, 1, 2),
            (face, 2, 2),
            (face, 2, 1),
            (face, 2, 0),
            (face, 1, 0)
        };
    }

    // Outer tiles - the tiles on the neighbouring faces that are affected by the rotation (in Clockwise order)
    private static (Face face, int row, int col)[] GetOuterTiles(Face face)
    {
        return face switch
        {
            Face.Front => new (Face face, int row, int col)[]
            {
                (Face.Up, 2, 0),
                (Face.Up, 2, 1),
                (Face.Up, 2, 2),
                (Face.Right, 0, 0),
                (Face.Right, 1, 0),
                (Face.Right, 2, 0),
                (Face.Down, 0, 2),
                (Face.Down, 0, 1),
                (Face.Down, 0, 0),
                (Face.Left, 2, 2),
                (Face.Left, 1, 2),
                (Face.Left, 0, 2)
            },
            Face.Right => new (Face face, int row, int col)[]
            {
                (Face.Up, 2, 2),
                (Face.Up, 1, 2),
                (Face.Up, 0, 2),
                (Face.Back, 0, 0),
                (Face.Back, 1, 0),
                (Face.Back, 2, 0),
                (Face.Down, 2, 2),
                (Face.Down, 1, 2),
                (Face.Down, 0, 2),
                (Face.Front, 2, 2),
                (Face.Front, 1, 2),
                (Face.Front, 0, 2)
            },
            Face.Up => new (Face face, int row, int col)[]
            {
                (Face.Back, 0, 2),
                (Face.Back, 0, 1),
                (Face.Back, 0, 0),
                (Face.Right, 0, 2),
                (Face.Right, 0, 1),
                (Face.Right, 0, 0),
                (Face.Front, 0, 2),
                (Face.Front, 0, 1),
                (Face.Front, 0, 0),
                (Face.Left, 0, 2),
                (Face.Left, 0, 1),
                (Face.Left, 0, 0)
            },
            Face.Back => new (Face face, int row, int col)[]
            {
                (Face.Up, 0, 2),
                (Face.Up, 0, 1),
                (Face.Up, 0, 0),
                (Face.Left, 0, 0),
                (Face.Left, 1, 0),
                (Face.Left, 2, 0),
                (Face.Down, 2, 0),
                (Face.Down, 2, 1),
                (Face.Down, 2, 2),
                (Face.Right, 2, 2),
                (Face.Right, 1, 2),
                (Face.Right, 0, 2)
            },
            Face.Left => new (Face face, int row, int col)[]
            {
                (Face.Up, 0, 0),
                (Face.Up, 1, 0),
                (Face.Up, 2, 0),
                (Face.Front, 0, 0),
                (Face.Front, 1, 0),
                (Face.Front, 2, 0),
                (Face.Down, 0, 0),
                (Face.Down, 1, 0),
                (Face.Down, 2, 0),
                (Face.Back, 2, 2),
                (Face.Back, 1, 2),
                (Face.Back, 0, 2)
            },
            Face.Down => new (Face face, int row, int col)[]
            {
                (Face.Front, 2, 0),
                (Face.Front, 2, 1),
                (Face.Front, 2, 2),
                (Face.Right, 2, 0),
                (Face.Right, 2, 1),
                (Face.Right, 2, 2),
                (Face.Back, 2, 0),
                (Face.Back, 2, 1),
                (Face.Back, 2, 2),
                (Face.Left, 2, 0),
                (Face.Left, 2, 1),
                (Face.Left, 2, 2)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(face), face, "Invalid face value")
        };
    }

    // Rotates set of tiles on the cube (needs to be called twice with different sets to fully rotate a face correctly)
    private void Rotate(Direction direction, (Face face, int row, int col)[] tiles)
    {
        var total = tiles.Length;
        var perSide = total / 4;

        var rotated = (direction switch
        {
            Direction.Clockwise => Rotate(tiles, total - perSide),
            Direction.AntiClockwise => Rotate(tiles, perSide),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction value")
        }).Select(t => this[t.face, t.row, t.col]).ToArray();

        for (var i = 0; i < total; i++) this[tiles[i].face, tiles[i].row, tiles[i].col] = rotated[i];
    }

    // Rotates supplied list of tiles (cube is left unaffected)
    private static IEnumerable<(Face face, int row, int col)> Rotate(
        IReadOnlyCollection<(Face face, int row, int col)> tiles,
        int magnitude)
    {
        return tiles.Skip(magnitude).Take(tiles.Count - magnitude).Concat(tiles.Take(magnitude));
    }
}