using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Here we add several items with different priorities and verify that 
    // Dequeue returns the item with the highest priority, regardless of the order 
    // in which they were added. For example, this is similar to a hospital emergency 
    // room: even if patients arrive in a certain order, the one with the most urgent 
    // condition (highest priority) must be treated first.

    // Expected Result: Imagine that Analina, Brian, and Lily are patients in an emergency room. 
    // Even if they arrived in a certain order, the doctor will always treat the patient 
    // with the most urgent condition first. So, if we enqueue Analina(1), Brian(5), and Lily(3), 
    // the first call to Dequeue() should return Brian, because he has the highest priority 
    // (the most urgent case). The order in which they were added does not matter; 
    // the highest priority item must always be removed first.

    // Defect(s) Found: The queue does not return the highest‑priority item. The loop in Dequeue() 
    // never checks the last element, so the real highest‑priority value may be ignored. 
    // The method also returns the value without removing it from the queue, 
    // leaving the internal state incorrect.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Analina", 1);
        priorityQueue.Enqueue("Lily", 3);
        // highest priority, but last in the list
        priorityQueue.Enqueue("Brian", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Brian", result);
    }

    [TestMethod]
    // Scenario: Add multiple items that share the same highest priority and verify that the queue 
    // removes the one that arrived first. This is similar to an emergency room where two patients 
    // have the same level of urgency: if their conditions are equally critical, 
    // the doctor treats the one who arrived earlier.

    // Expected Result: If we enqueue Ana(5), Brian(5), and Lily(3), both Ana and Brian share the 
    // highest priority. Since Ana arrived first, the first call to Dequeue() should return Ana. 
    // FIFO must be respected when priorities are tied.

    // Defect(s) Found: When two items share the same highest priority, the queue does not follow FIFO. 
    // Instead of returning the item that arrived first, the Dequeue() method selects the wrong one. 
    // This happens because the loop does not evaluate all elements correctly, so the arrival order is 
    // not preserved when priorities are tied.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Ana", 5);
        priorityQueue.Enqueue("Brian", 5);
        priorityQueue.Enqueue("Lily", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Ana", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: If the queue is empty and someone tries to remove an element, 
    // the program should stop and show a specific error message saying 
    // "The queue is empty." instead of returning a value.

    // Expected Result: If someone calls Dequeue() when the queue is empty, the program 
    // should not return any value. Instead, it must throw an 
    // InvalidOperationException with the message: The queue is empty. 
    // This confirms that the queue handles empty state errors correctly.

    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("I expected the code to stop and throw an InvalidOperationException instead of returning a value.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}