namespace Rubiks;

public class Deserializer : IConverter<string, Cube>
{
    // Deserializes string into cube
    // NB There is no validation done here for the sake of brevity.
    // However, production ready code would need to include it.
    public Cube Convert(string state)
    {
        var cube = new Cube();
        var i = 0;

        foreach (var face in Enum.GetValues<Face>())
            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                cube[face, row, col] = state[i++] switch
                {
                    'W' => Colour.White,
                    'O' => Colour.Orange,
                    'G' => Colour.Green,
                    'R' => Colour.Red,
                    'B' => Colour.Blue,
                    'Y' => Colour.Yellow,
                    _ => throw new ArgumentOutOfRangeException(nameof(state), "Invalid cube state")
                };

        return cube;
    }
}