using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Rubiks.Test.SolverTests;

// Comment out below attribute to check these tests work
[Ignore("These tests run slowly (~1min on my machine.)")]
public class SolveTests
{
    // List of cube / solver combinations to test (currently only one)
    private static IEnumerable<object[]> CubeSolvers()
    {
        return new[] { new object[] { new Cube(), new DijkstraSolver() } };
    }

    [TestCaseSource(nameof(CubeSolvers))]
    public void SolveFR_UB_LD_(ICube cube, ISolver solver)
    {
        cube.Rotate(new Rotation(Face.Front, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Right, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Up, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Back, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Left, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Down, Direction.AntiClockwise));

        var solution = solver.Solve(cube);

        Console.WriteLine(solution.ToCommaSeperatedList());

        Assert.AreEqual(new[]
            {
                new Rotation(Face.Down, Direction.Clockwise),
                new Rotation(Face.Left, Direction.AntiClockwise),
                new Rotation(Face.Back, Direction.Clockwise),
                new Rotation(Face.Up, Direction.AntiClockwise),
                new Rotation(Face.Right, Direction.Clockwise),
                new Rotation(Face.Front, Direction.AntiClockwise)
            },
            solution);
    }

    [TestCaseSource(nameof(CubeSolvers))]
    public void SolveF_RU_BL_D(ICube cube, ISolver solver)
    {
        cube.Rotate(new Rotation(Face.Front, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Right, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Up, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Back, Direction.Clockwise));
        cube.Rotate(new Rotation(Face.Left, Direction.AntiClockwise));
        cube.Rotate(new Rotation(Face.Down, Direction.Clockwise));

        var solution = solver.Solve(cube);

        Console.WriteLine(solution.ToCommaSeperatedList());

        Assert.AreEqual(new[]
            {
                new Rotation(Face.Down, Direction.AntiClockwise),
                new Rotation(Face.Left, Direction.Clockwise),
                new Rotation(Face.Back, Direction.AntiClockwise),
                new Rotation(Face.Up, Direction.Clockwise),
                new Rotation(Face.Right, Direction.AntiClockwise),
                new Rotation(Face.Front, Direction.Clockwise)
            },
            solution);
    }
}