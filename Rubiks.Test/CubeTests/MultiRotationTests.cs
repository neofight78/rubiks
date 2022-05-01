using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Rubiks.Test.CubeTests;

public class MultiRotationTests
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
    public void MultiFR_UB_LD_(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Front, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Right, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Up, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Back, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Left, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Down, Direction.AntiClockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Red, cube[Face.Up, 0, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Up, 0, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Up, 0, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 1, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Up, 1, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Up, 1, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 2, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 2, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 2, 2]);

        Assert.AreEqual(Colour.Green, cube[Face.Left, 0, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 0, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 0, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 1, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 1, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 1, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Left, 2, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 2, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 2, 2]);

        Assert.AreEqual(Colour.Orange, cube[Face.Front, 0, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 0, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 0, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Front, 1, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Front, 1, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 1, 2]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 2, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 2, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 2, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Right, 0, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 0, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Right, 0, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 1, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 1, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Right, 1, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Right, 2, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Right, 2, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 2, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 0, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Back, 0, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Back, 0, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Back, 1, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Back, 1, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 1, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 2, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 2, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Back, 2, 2]);

        Assert.AreEqual(Colour.Green, cube[Face.Down, 0, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 0, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Down, 0, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 1, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Down, 1, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 1, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 2, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 2, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 2, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void MultiF_RU_BL_D(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Front, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Right, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Up, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Back, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Left, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Down, Direction.Clockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Orange, cube[Face.Up, 0, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Up, 0, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Up, 0, 2]);
        Assert.AreEqual(Colour.Green, cube[Face.Up, 1, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Up, 1, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Up, 1, 2]);
        Assert.AreEqual(Colour.Green, cube[Face.Up, 2, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Up, 2, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Up, 2, 2]);

        Assert.AreEqual(Colour.Blue, cube[Face.Left, 0, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Left, 0, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Left, 0, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Left, 1, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 1, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 1, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Left, 2, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Left, 2, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Left, 2, 2]);

        Assert.AreEqual(Colour.Orange, cube[Face.Front, 0, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Front, 0, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 0, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Front, 1, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Front, 1, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Front, 1, 2]);
        Assert.AreEqual(Colour.Green, cube[Face.Front, 2, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Front, 2, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Front, 2, 2]);

        Assert.AreEqual(Colour.Green, cube[Face.Right, 0, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Right, 0, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 0, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 1, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 1, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Right, 1, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Right, 2, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Right, 2, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Right, 2, 2]);

        Assert.AreEqual(Colour.White, cube[Face.Back, 0, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Back, 0, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Back, 0, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Back, 1, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Back, 1, 1]);
        Assert.AreEqual(Colour.White, cube[Face.Back, 1, 2]);
        Assert.AreEqual(Colour.Red, cube[Face.Back, 2, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Back, 2, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 2, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Down, 0, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Down, 0, 1]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Down, 0, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Down, 1, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Down, 1, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Down, 1, 2]);
        Assert.AreEqual(Colour.Orange, cube[Face.Down, 2, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Down, 2, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Down, 2, 2]);
    }
}