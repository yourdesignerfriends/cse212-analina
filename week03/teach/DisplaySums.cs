public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        // TODO Problem 2 - This should print pairs of numbers in the given array

        // Create a HashSet to keep track of numbers we have already seen
        var seen = new HashSet<int>();

        // Loop through each number in the array
        foreach (var x in numbers)
        {
            // Calculate the complement needed to sum to 10
            var complement = 10 - x;

            // If the complement is already in the set, we found a valid pair
            if (seen.Contains(complement))
            {
                Console.WriteLine($"{x} {complement}");
            }
            // Add the current number to the set for future checks
            seen.Add(x);
        }
    }
}

// Explanation:
// I use a HashSet because it lets me check if a number exists in constant time, O(1). 
// I loop through the list once. For each number x, I calculate 10 - x. If that 
// complement is already in the set, then I’ve already seen the matching number, 
// so I print the pair. Then I add x to the set and continue. This avoids duplicates 
// like 3+7 and 7+3 because I only print when the complement was seen earlier. 
// Since I only loop once and all set operations are O(1), the whole solution is O(n).