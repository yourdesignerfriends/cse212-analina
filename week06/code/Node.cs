public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // First, I check if the value is the same as mine. If it is, 
        // then this number already lives in the tree. Since I am building a sorted set, 
        // I simply stop here because I do not want to add duplicates.
        if (value == Data)
            return;
            
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // First, I check if the value matches mine. If it does, then I have 
        // found exactly what we were looking for.
        if (value == Data)
            return true;

        // If the value is smaller than mine, 
        // I know the answer must be somewhere in my left subtree.
        if (value < Data)
        {
            // If I do not have a left child, then the value simply is not here
            if (Left is null)
                return false;
            // Otherwise, I let my left child continue the search.
            return Left.Contains(value);
        }
        else
        {
            // If the value is greater than mine, it must be in my right subtree
            if (Right is null)
                return false;
            // If I do have a right child, I pass the search along to them.
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}