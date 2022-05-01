namespace Rubiks;

// This interface (along with ISolver) allows different solving algorithms to be used with different cube
// representations.
//
// NB A proper implementation of Equals() and GetHashCode() etc is required for comparisons and dictionary keys.
// Solver implementations will depend on this. The default reference comparison won't work.
public interface ICube : IEquatable<ICube>
{
    Colour this[Face face, int row, int col] { get; }

    // More strongly typed than using the standard ICloneable interface 
    ICube Clone();

    bool IsSolved();

    void Rotate(Rotation rotation);
}