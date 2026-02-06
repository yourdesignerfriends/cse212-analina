using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        // Step 1: Identify the base case, In recursion, we always need 
        // a stopping point. For this problem, if n <= 0, there 
        // are no more squares left to add. So we simply return 0.
        if (n <= 0)
        {
            return 0;
        }
        // Step 2: Here I'm defining the smaller problem. In recursion, 
        // every call needs to work on a smaller version of the same problem.
        int currentSquare = n * n;
        int smallerProblem = SumSquaresRecursive(n - 1);
        // Step 3: Now I combine the results. 
        return currentSquare + smallerProblem;
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // Step 1: If the word I'm building has already reached the target length, then this permutation 
        // is complete. I add it to the results and stop here.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        // Step 2: Otherwise, I still need to keep building the permutation. I go through each letter and decide whether 
        // I can use it next.
        foreach (char letter in letters)
        {
            // I only add this letter if it hasn't been used yet in the current word. This keeps each permutation clean 
            // and without repeated letters.
            if (!word.Contains(letter))
            {
                // Step 3: Add the letter to the word and continue the recursion. Each recursive call builds the word one letter at a time.
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases Thanks for giving us these base cases already!
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;
        // TODO Start Problem 3
        // Step 1: If this is the very first call, I need to create the dictionary. 
        // All recursive calls will share this same dictionary.
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        // Step 2: Before doing any work, I check if I already solved this 's' If the 
        // dictionary has the answer, I simply return it. This avoids repeating the same expensive calculations.
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        // Solve using recursion
        // Step 3: If the value is not in the dictionary, I compute it using recursion. The number of ways to climb 's' 
        // stairs is the sum of: ways to climb from s-1, s-2, and s-3. I make sure to pass the 
        // same dictionary to all recursive calls.
        decimal ways = 
            CountWaysToClimb(s - 1, remember) + 
            CountWaysToClimb(s - 2, remember) + 
            CountWaysToClimb(s - 3, remember);     
        // Step 4: I store the result in the dictionary so that if I ever need CountWaysToClimb(s) again, I can return it instantly.
        remember[s] = ways;
        // Return the final computed value.
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        // Step 1: I look for the first '*' in the pattern. If there isn't one, then this pattern is already complete.
        int index = pattern.IndexOf('*');
        // Step 2: If no wildcard was found, this is a full binary string. I can add it to the results and stop exploring this path.
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        // Step 3: If I did find a '*', I replace it with '0' first and explore that option through recursion.
        string withZero = pattern[..index] + "0" + pattern[(index + 1)..];
        WildcardBinary(withZero, results);
        // Step 4: Then I replace the same '*' with '1' and explore that path as well.
        string withOne = pattern[..index] + "1" + pattern[(index + 1)..];
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path
        // Thanks for the tip, it made the syntax much clearer for me.

        // TODO Start Problem 5
        // ADD CODE HERE

        // Before moving forward, I make sure this step actually makes sense: 
        // - It's inside the maze boundaries 
        // - It's not a wall 
        // - It's not a square I've already visited in this same path 
        // If any of those fail, I simply stop exploring this direction.
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }
        
        // I add the current position to the path so it becomes part of the journey.
        currPath.Add((x, y));

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.

        // If this square is the end of the maze, then the path I'm holding is a complete solution. I save it and 
        // step back so the recursion can keep searching for other possibilities.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // From here, I explore all four possible directions. Each recursive call is like asking: What if I try going this way?
        // right
        SolveMaze(results, maze, x + 1, y, currPath);
        // down
        SolveMaze(results, maze, x, y + 1, currPath);
        // left
        SolveMaze(results, maze, x - 1, y, currPath);
        // up
        SolveMaze(results, maze, x, y - 1, currPath);

        // If I reach this point, it means I've already tried every direction from this square. Time to remove it from the path and go back.
        currPath.RemoveAt(currPath.Count - 1);
    }
}