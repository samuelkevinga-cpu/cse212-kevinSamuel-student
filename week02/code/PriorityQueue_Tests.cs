using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (1), B (5), C (3). Dequeue three times.
    // Expected Result: B, C, A
    // Defect(s) Found: Dequeue did not remove the item from the queue, so B was returned every time.
    // The loop also skipped the last item in the queue (index < Count - 1).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (2), B (5), C (5), D (1). Dequeue four times.
    // Expected Result: B, C, A, D (items with the same priority come out in FIFO order)
    // Defect(s) Found: The comparison used >= so the last item with the highest priority was
    // removed instead of the one closest to the front.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (1), B (2), C (9). The highest priority is at the back.
    // Expected Result: C
    // Defect(s) Found: The loop stopped before the last item, so C was never checked and B was returned.
    public void TestPriorityQueue_HighestAtBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. This test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var e = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", e.Message);
    }
}
