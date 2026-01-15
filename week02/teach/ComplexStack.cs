public static class ComplexStack {

    //This method checks if a string has balanced parentheses, brackets, 
    // and braces and returns true only if each opening symbol has a matching 
    // closing symbol so they appear in the correct order.
    public static bool DoSomethingComplicated(string line) {
        // Here a stack is created to store the opening symbols as we find them.
        var stack = new Stack<char>();
        //Here, each character in the input string is examined.
        foreach (var item in line) {
            // If the character is an opening symbol, push it onto the stack.
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            // Else, if the character is a closing parenthesis ')'. The matching opening symbol must be ')'.
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            // Else, if the character is a closing bracket ']'. The matching opening symbol must be '['.
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            // Else, If the character is a closing brace '}' The matching opening symbol must be '{'.
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }
        // After processing the entire string, the stack should be empty. 
        // If the opposite happens, it means that some opening symbols were never closed.
        return stack.Count == 0;
    }
}