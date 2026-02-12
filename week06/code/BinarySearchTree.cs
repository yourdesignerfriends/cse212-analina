using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_root is null)
        {
            _root = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST.
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        // TODO Problem 3

        // If there is no node here, then there is nothing for me to add.
        if (node is null)
            return;

        // First, I walk through my right subtree, because that is where the larger values live.
        TraverseBackward(node.Right, values);
        // Then, I add my own value to the list.
        values.Add(node.Data);
        // Finally, I walk through my left subtree, because that is where the smaller values live.
        TraverseBackward(node.Left, values);
    }

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}