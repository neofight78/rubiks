using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Rubiks.Test.CubeTests;

public class SingleRotationTests
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
    public void FrontFaceClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Front, Direction.Clockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Orange, cube[Face.Up, 2, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Up, 2, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Up, 2, 2]);

        Assert.AreEqual(Colour.White, cube[Face.Right, 0, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Right, 1, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Right, 2, 0]);

        Assert.AreEqual(Colour.Red, cube[Face.Down, 0, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 0, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 0, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 0, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 1, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 2, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void RightFaceAntiClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Right, Direction.AntiClockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Blue, cube[Face.Up, 0, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 1, 2]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 2, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 0, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 1, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 2, 0]);

        Assert.AreEqual(Colour.Green, cube[Face.Down, 0, 2]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 1, 2]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 2, 2]);

        Assert.AreEqual(Colour.White, cube[Face.Front, 0, 2]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 1, 2]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 2, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void UpFaceClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Up, Direction.Clockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Orange, cube[Face.Back, 0, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Back, 0, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Back, 0, 2]);

        Assert.AreEqual(Colour.Blue, cube[Face.Right, 0, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 0, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 0, 2]);

        Assert.AreEqual(Colour.Red, cube[Face.Front, 0, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 0, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 0, 2]);

        Assert.AreEqual(Colour.Green, cube[Face.Left, 0, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 0, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 0, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void BackFaceAntiClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Back, Direction.AntiClockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Orange, cube[Face.Up, 0, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Up, 0, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Up, 0, 2]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 0, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 1, 0]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Left, 2, 0]);

        Assert.AreEqual(Colour.Red, cube[Face.Down, 2, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 2, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Down, 2, 2]);

        Assert.AreEqual(Colour.White, cube[Face.Right, 0, 2]);
        Assert.AreEqual(Colour.White, cube[Face.Right, 1, 2]);
        Assert.AreEqual(Colour.White, cube[Face.Right, 2, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void LeftFaceClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Left, Direction.Clockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Blue, cube[Face.Up, 0, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 1, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Up, 2, 0]);

        Assert.AreEqual(Colour.White, cube[Face.Front, 0, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 1, 0]);
        Assert.AreEqual(Colour.White, cube[Face.Front, 2, 0]);

        Assert.AreEqual(Colour.Green, cube[Face.Down, 0, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 1, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Down, 2, 0]);

        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 0, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 1, 2]);
        Assert.AreEqual(Colour.Yellow, cube[Face.Back, 2, 2]);
    }

    [TestCaseSource(nameof(Cubes))]
    public void DownFaceAntiClockwise(ICube cube)
    {
        cube.Rotate(new Rotation(Face.Down, Direction.AntiClockwise));

        Console.Write(cube.ToString());

        Assert.AreEqual(Colour.Red, cube[Face.Front, 2, 0]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 2, 1]);
        Assert.AreEqual(Colour.Red, cube[Face.Front, 2, 2]);

        Assert.AreEqual(Colour.Blue, cube[Face.Right, 2, 0]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 2, 1]);
        Assert.AreEqual(Colour.Blue, cube[Face.Right, 2, 2]);

        Assert.AreEqual(Colour.Orange, cube[Face.Back, 2, 0]);
        Assert.AreEqual(Colour.Orange, cube[Face.Back, 2, 1]);
        Assert.AreEqual(Colour.Orange, cube[Face.Back, 2, 2]);

        Assert.AreEqual(Colour.Green, cube[Face.Left, 2, 0]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 2, 1]);
        Assert.AreEqual(Colour.Green, cube[Face.Left, 2, 2]);
    }
}