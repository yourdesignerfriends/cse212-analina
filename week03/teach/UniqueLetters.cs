public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
        
        // Create a HashSet to store letters we have already seen
        var seen = new HashSet<char>();

        // Loop through each character in the string
        foreach (var letter in text)
        {
            // If the letter is already in the set, it's a duplicate
            if (seen.Contains(letter))
            {
                return false;
            }
            // Otherwise, add the letter to the set
            seen.Add(letter);
        }
        // If we finish the loop without finding duplicates, return true
        return true;
    }
}

// Big O EXPLANATION:         
// This solution is O(n) because I only go through the string one time. 
// For each character, I use a HashSet to check whether I’ve seen it before. 
// Both Contains and Add on a HashSet run in constant time, O(1). 
// So the total work is one loop of n characters, each doing 
// constant‑time operations. When you combine O(n) with O(1) 
// steps inside the loop, the overall performance stays O(n).
