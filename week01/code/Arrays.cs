public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // The first thing I will do is create a new array of doubles with the given length. 
        // Secondly, I will use a loop to fill each position of the array. 
        // Thirdly, for each index i, calculate the multiple: number * (i + 1). 
        // Finally, store that value in the array at index i and, once the loop is finished, return the filled array.

        var result = new double[length];

        for (var i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Plan:
        // First, get the total number of elements in the list. Then calculate the split index as count - amount,
        // which marks where the rotation begins. Next, take the last 'amount elements as the right part and the
        // remaining elements as the left part using GetRange. Clear the original list, then add the right part
        // followed by the left part to rebuild the list in its rotated order.

        // Visual idea:
        // Before: [1 2 3 4 5 6 7 8 9]
        // Rotate 3 [7 8 9 | 1 2 3 4 5 6]

        int count = data.Count;
        int splitIndex = count - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);

    }
}
