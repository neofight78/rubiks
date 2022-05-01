using System.Collections.Generic;
using NUnit.Framework;

namespace Rubiks.Test.CubeTests;

// A proper implementation of Equals() and GetHashCode() etc is required for comparisons and dictionary keys.
// Solver implementations will depend on this. The default reference comparison won't work.
public class EqualityTests
{
    // List of cube implementations to test (currently only one)
    //
    // NB. This code is repeated for each test class so that a fresh instance is used for each test.
    // Putting this in a separate class will result in the cube instance being reused by some test runners thereby
    // causing the tests to fail.
    private static IEnumerable<ICube> Cubes()
    {
        return new ICube[] { new Cube() };
    }

    [TestCaseSource(nameof(Cubes))]
    public void TwoSolvedCubesAreEqual(ICube a)
    {
        var b = a.Clone();

        Assert.AreEqual(a, b);
        Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
    }

    [TestCaseSource(nameof(Cubes))]
    public void TwoRotatedCubesAreEqual(ICube a)
    {
        var b = a.Clone();

        a.Rotate(new Rotation(Face.Back, Direction.Clockwise));
        b.Rotate(new Rotation(Face.Back, Direction.Clockwise));

        Assert.AreEqual(a, b);
        Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
    }
    
    [TestCaseSource(nameof(Cubes))]
    public void TwoDifferentCubesAreNotEqual(ICube a)
    {
        var b = a.Clone();

        a.Rotate(new Rotation(Face.Back, Direction.Clockwise));

        Assert.AreNotEqual(a, b);
        Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
    }
}