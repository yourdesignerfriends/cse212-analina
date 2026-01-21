public class DuplicateCounter
{
    //Count how many duplicates are in a collection of data.

    public static void Run()
    {
        int[] data = [
            50, 9, 24, 100, 7, 75, 93, 24, 17, 16, 97, 6, 18, 81, 48, 37, 49, 33, 60, 3, 99, 32, 88, 29, 65, 20, 35, 33,
            15, 81, 31, 93, 17, 5, 5, 79, 12, 91, 18, 31, 12, 94, 39, 98, 10, 72, 20, 79, 100, 27, 46, 28, 50, 1, 7, 14,
            78, 100, 55, 26, 48, 33, 96, 77, 69, 8, 33, 36, 42, 98, 42, 32, 49, 65, 1, 82, 30, 74, 73, 89, 23, 76, 25,
            4, 76, 7, 72, 86, 71, 29, 18, 98, 84, 20, 24, 18, 11, 33, 39, 96, 1, 97, 65, 41, 62, 48, 59, 51, 17, 89, 6,
            29, 98, 49, 37, 72, 63, 49, 12, 79, 27, 23, 23, 13, 90, 47, 11, 66, 41, 97, 2, 60, 1, 21, 38, 100, 98, 2,
            18, 75, 86, 52, 63, 58, 26, 80, 62, 82, 63, 94, 33, 76, 7, 11, 49, 2, 34, 3, 10, 27, 71, 60, 4, 94, 100, 95,
            46, 15, 21, 40, 35, 98, 89, 25, 46, 54, 24, 75, 92, 69, 37, 63, 71, 70, 90, 91, 82, 81, 4, 10, 82, 1, 32, 8,
            13, 47, 8, 52, 30, 54, 4, 79, 7, 90, 81, 33, 65, 89, 84, 83, 46, 95, 82, 6, 93, 5, 22, 67, 8, 79, 3, 55, 79,
            6, 54, 10, 22, 16, 40, 67, 50, 58, 37, 35, 7, 44, 10, 31, 45, 93, 12, 55, 67, 48, 32, 43, 57, 58, 37, 76,
            85, 47, 80, 18, 32, 59, 98, 92, 53, 98, 29, 61, 82, 42, 78, 97, 23, 94, 38, 20, 73, 11, 99, 94, 92, 82, 82,
            65
        ];

        Console.WriteLine($"Number of items in the collection: {data.Length}");
        Console.WriteLine($"Number of duplicates : {CountDuplicates(data)}");
    }

    private static int CountDuplicates(int[] data)
    {
        // Add code here.
        // In this part, I create a HashSet called ‘unique’. This set stores all the 
        // values that appear for the first time. Since a HashSet does not allow duplicates, 
        // each number is added only once
        var unique = new HashSet<int>();

        //Then I create an integer counter called ‘duplicates’. 
        //This counter increases each time we find a repeated number.

        var duplicates = 0;

        // The next step is to iterate through each number in the ‘data’ array. 
        // In each iteration, ‘x’ represents one number from the array.

        foreach (var x in data)
        {
            // Inside the loop, I check if the number ‘x’ is already in the ‘unique’ set.
            // If it is, it means we have seen this number before, so we increase the 
            // ‘duplicates’ counter by one. If it is not in the set, we add it to the 
            // ‘unique’ set for future reference.

            if (unique.Contains(x))
            {
                duplicates++;
            }
            else
            {
                unique.Add(x);
            }
        }
        return duplicates;
    }
}