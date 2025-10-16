using System.Collections;

public static class Recursion
{
    // #############################
    // Problem 1: Recursive Squares Sum
    // #############################
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // #############################
    // Problem 2: Permutations Choose
    // #############################
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if the word length equals the desired size, store the permutation
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: try each letter that isn’t already in the current word
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    // #############################
    // Problem 3: Climbing Stairs 
    // #############################
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // #############################
    // Problem 4: Wildcard Binary Patterns
    // #############################
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no more wildcards → add final pattern
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace * with 0 and recurse
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern[(index + 1)..], results);

        // Replace * with 1 and recurse
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern[(index + 1)..], results);
    }

    // #############################
    // Problem 5: Maze Solver
    // #############################
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add the current position
        currPath.Add((x, y));

        // If this position is the end, record the path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Move directions: right, left, down, up
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack: remove last step before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}
