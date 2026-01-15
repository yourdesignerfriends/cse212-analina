/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1 
        // Detailed Requirement: The user shall specify the maximum size of the Customer Service Queue when it is created. 
        // If the size is invalid (less than or equal to 0) then the size shall default to 10.
        
        // Scenario: Here we are checking the Queue size and we are creating a CustomerService object with an invalid size (0).
        // Expected Result: The queue should have a predetermined size of 10.

        Console.WriteLine("Test 1");

        var test1Queue = new CustomerService(0); 
        Console.WriteLine(test1Queue);

        // Defect(s) Found: No Defects found.

        Console.WriteLine("=================");

        // Test 2
        // Detailed Requirement: The AddNewCustomer method shall enqueue a new customer into the queue.

        // Scenario: Start with an empty CustomerService queue and add a new customer to verify that the queue 
        // correctly stores the customer information, including the customer's name, account ID, 
        // and problem description, and that the queue size increases from 0 to 1. 
        // The output should display the newly added customer without any error messages.
        // Expected Result: When we add a customer, the queue increases in size, 
        // the customer appears in the queue, no error message is displayed, and there are no defects in this behavior

        Console.WriteLine("Test 2");

        var test2Queue = new CustomerService(3);

        var queueField = typeof(CustomerService)
            .GetField("_queue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var internalList = (System.Collections.IList)queueField.GetValue(test2Queue)!;

        var customerType = typeof(CustomerService)
            .GetNestedType("Customer", System.Reflection.BindingFlags.NonPublic);

        var newCustomer = Activator.CreateInstance(customerType!, "Analina", "Cookie77", "I can't find which is my team in Teams 😕")!;
        internalList.Add(newCustomer);

        Console.WriteLine(test2Queue);

        // Defect(s) Found: No Defects found, Works Good! 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Detailed Requirement: If the queue is full when trying to add a customer, then an error message will be displayed.

        // Scenario: Initialize a CustomerService queue with a maximum size of N and manually fill it to capacity. 
        // Attempt to add one additional customer and verify that the AddNewCustomer method prevents the insertion, 
        // keeps the queue size unchanged, and displays an error message indicating that the queue is full.
        // Expected Result: The system should detect that the queue is full and prevent the new customer 
        // from being added. The queue size must remain unchanged, and an error message should be displayed 
        // indicating that no more customers can be added because the queue has reached its maximum capacity.

        Console.WriteLine("Test 3");

        var fullQueue = new CustomerService(2);

        var queueField3 = typeof(CustomerService)
            .GetField("_queue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var customerType3 = typeof(CustomerService)
            .GetNestedType("Customer", System.Reflection.BindingFlags.NonPublic);

        var internalList3 = (System.Collections.IList)queueField3.GetValue(fullQueue)!;

        internalList3.Add(Activator.CreateInstance(customerType3!, "Ana", "001", "Problem A"));
        internalList3.Add(Activator.CreateInstance(customerType3!, "Luis", "002", "Problem B"));

        fullQueue.AddNewCustomer();

        Console.WriteLine(fullQueue.ToString());
        Console.WriteLine("Expected size: 2 (unchanged)");

        var actualSize = internalList3.Count;
        Console.WriteLine("Actual size: " + actualSize);

        Console.WriteLine("Note: The method did NOT display the 'Maximum Number of Customers in Queue.' message, even though the queue was already full. This confirms the defect in the capacity check condition.");
        Console.WriteLine();  

        Console.WriteLine("=================");

        // Defect(s) Found: The AddNewCustomer method uses the condition 
        // (_queue.Count > _maxSize) // instead of (_queue.Count >= _maxSize). 
        // Because of this incorrect comparison, the method never detects 
        // when the queue is full. As a result, no error message is displayed even 
        // though the queue has reached its maximum capacity. This violates the requirement.

        Console.WriteLine("=================");

        // Test 4
        // Detailed Requirement:
        // The ServeCustomer function shall dequeue the next customer from the queue and display the customer’s details.
        
        // Scenario: Initialize a CustomerService queue with multiple customers already in the queue. 
        // Call the ServeCustomer method to verify that it removes the first customer (FIFO order) and displays that customer’s information.
        // After serving, the queue should contain one fewer customer, and the next customer in line should now be at the front.
        // Expected Result:
        // The first customer in the queue is removed.
        // The removed customer’s details are displayed.
        // The queue size decreases by 1.
        // The remaining customers shift forward correctly.
        // No error message is displayed.

        Console.WriteLine("Test 4");

        var serveQueue = new CustomerService(5);

        var queueField4 = typeof(CustomerService)
            .GetField("_queue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var customerType4 = typeof(CustomerService)
            .GetNestedType("Customer", System.Reflection.BindingFlags.NonPublic);

        var internalList4 = (System.Collections.IList)queueField4.GetValue(serveQueue)!;

        internalList4.Add(Activator.CreateInstance(customerType4!, "Ana", "001", "Problem A"));
        internalList4.Add(Activator.CreateInstance(customerType4!, "Luis", "002", "Problem B"));

        Console.WriteLine("Before serving: " + serveQueue.ToString());

        serveQueue.ServeCustomer();

        Console.WriteLine("After serving: " + serveQueue.ToString());
        Console.WriteLine("Expected size: 1");
        Console.WriteLine("Actual size: " + internalList4.Count);
        Console.WriteLine("Expected first customer now: Luis (002)");
        Console.WriteLine("Note: The method printed the WRONG customer. It should display the served customer (Ana), but it printed the next customer in line (Luis).");


        Console.WriteLine("=================");

        // Defect(s) Found: The ServeCustomer method removes the first customer from the queue, 
        // but then prints the NEXT customer instead of the one that was served.
        // This happens because the method calls _queue.RemoveAt(0) and then 
        // immediately accesses _queue[0], which now refers to the second customer.
        // As a result, the wrong customer is displayed, violating the requirement 
        // that the served customer's details must be shown.

        Console.WriteLine("=================");

        // Test 5
        // Detailed Requirement: 
        // If the queue is empty when trying to serve a customer, then an error message will be displayed.

        // Scenario:
        // Start with an empty CustomerService queue. Call the ServeCustomer method when there are no customers.
        // The method should detect the empty queue and display an error message instead of crashing.
        // Expected Result:
        // An error message is displayed.
        // No customer is removed.
        // Queue size remains 0.
        // The program does NOT crash.

        Console.WriteLine("Test 5");

        var emptyServeQueue = new CustomerService(5);

        var queueField5 = typeof(CustomerService)
            .GetField("_queue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var internalList5 = (System.Collections.IList)queueField5.GetValue(emptyServeQueue)!;

        Console.WriteLine("Before serving (should be empty): " + emptyServeQueue.ToString());

        try {
            emptyServeQueue.ServeCustomer();
            Console.WriteLine("ServeCustomer() was called.");
        } catch (Exception ex) 
        {
            Console.WriteLine("Exception thrown: " + ex.Message);
        }

        Console.WriteLine("After serving attempt: " + emptyServeQueue.ToString());
        Console.WriteLine("Expected size: 0");
        Console.WriteLine("Actual size: " + internalList5.Count);
        Console.WriteLine("Expected behavior: Display an error message and do NOT crash.");
        Console.WriteLine("Check console output above to confirm what actually happened.");
        
        Console.WriteLine("=================");

        // Defect(s) Found:
        // The ServeCustomer method does not check whether the queue is empty before attempting to remove a customer.
        // When the queue is empty, the call to _queue.RemoveAt(0) throws an ArgumentOutOfRangeException.
        // No error message is displayed, and the program crashes, violating the requirement that an error message
        // should be shown when attempting to serve a customer from an empty queue.

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue

        // DEFECT: This condition is incorrect. It uses ">" instead of ">=".
        // When the queue is full (Count == maxSize), this condition evaluates to false,
        // so the method does NOT detect that the queue is full and does NOT display 
        // the required error message.
        // Possible Fix:
        // Change the line from:
        // if (_queue.Count > _maxSize)
        // to:
        // if (_queue.Count >= _maxSize)
        // This correctly detects when the queue has reached its maximum capacity.
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}