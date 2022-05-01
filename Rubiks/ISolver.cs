namespace Rubiks;

// This interface (along with ICube) allows different solving algorithms to be used with different cube
// representations.
public interface ISolver
{
    public IEnumerable<Rotation> Solve(ICube cube);
}