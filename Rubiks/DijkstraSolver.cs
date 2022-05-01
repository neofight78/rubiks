namespace Rubiks;

// This is a brute force solver that uses Dijkstra's Algorithm to find the quickest solution.
// It's slow for solutions that are longer than 6 steps, and it can take up to 20 steps to solve any given cube.
// In it's current form it isn't really practical for any real world scenario. However the algorithm doesn't use any
// special knowledge about solving Rubik's Cube.
//
// It could be modified with a suitable heuristic (thereby becoming the A* algorithm) to improve the speed, but this
// would require domain specific knowledge.
public class DijkstraSolver : ISolver
{
    public IEnumerable<Rotation> Solve(ICube cube)
    {
        var queue = new PriorityQueue<(ICube cube, List<Rotation> path), int>();
        queue.Enqueue((cube, new List<Rotation>()), 0);

        var distances = new Dictionary<ICube, int>
        {
            [cube] = 0
        };

        while (queue.TryDequeue(out var current, out var steps))
        {
            if (current.cube.IsSolved()) return current.path;

            if (steps > distances.GetValueOrDefault(current.cube, int.MaxValue)) continue;

            foreach (var rotation in Rotation.GetValues())
            {
                var nextCube = current.cube.Clone();
                nextCube.Rotate(rotation);

                var nextPath = new List<Rotation>(current.path) { rotation };

                if (steps + 1 >= distances.GetValueOrDefault(nextCube, int.MaxValue)) continue;

                queue.Enqueue((nextCube, nextPath), steps + 1);
                distances[nextCube] = steps + 1;
            }
        }

        throw new InvalidOperationException("No solution exists");
    }
}