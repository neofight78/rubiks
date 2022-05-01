using System.Collections.Generic;
using NUnit.Framework;

namespace Rubiks.Test.CubeTests;

public class IsSolvedTests
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
    public void NewCubeIsSolved(ICube cube)
    {
        Assert.IsTrue(cube.IsSolved());
    }

    [TestCaseSource(nameof(Cubes))]
    public void RotatedCubeIsNotSolved(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Back, Direction.Clockwise));

        Assert.IsFalse(cube.IsSolved());
    }
}