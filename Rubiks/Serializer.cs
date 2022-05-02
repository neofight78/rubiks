using System.Text;

namespace Rubiks;

public class Serializer : IConverter<ICube, string>
{
    public string Convert(ICube state)
    {
        var stringBuilder = new StringBuilder();

        // fix face ordering
        foreach (var face in Enum.GetValues<Face>())
            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                stringBuilder.Append(
                    state[face, row, col] switch
                    {
                        Colour.White => 'W',
                        Colour.Orange => 'O',
                        Colour.Green => 'G',
                        Colour.Red => 'R',
                        Colour.Blue => 'B',
                        Colour.Yellow => 'Y',
                        _ => throw new ArgumentOutOfRangeException(nameof(state), "cube", "Invalid cube state")
                    }
                );

        return stringBuilder.ToString();
    }
}