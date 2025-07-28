// Sample code
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. List<T>
        var numbers = new List<int> { 1, 2, 3 };
        numbers.Add(4);
        int first = numbers[0];
        Console.WriteLine($"First number in List: {first}");

        // 2. Dictionary<TKey, TValue>
        var ages = new Dictionary<string, int>();
        ages["Alice"] = 30;
        if (ages.TryGetValue("Alice", out int age))
        {
            Console.WriteLine($"Alice's age: {age}");
        }

        // 3. HashSet<T>
        var uniqueNumbers = new HashSet<int> { 1, 2, 2, 3 };
        Console.WriteLine($"Unique count in HashSet: {uniqueNumbers.Count}");

        // 4. Queue<T>
        var queue = new Queue<string>();
        queue.Enqueue("first");
        queue.Enqueue("second");
        string firstInQueue = queue.Dequeue();
        Console.WriteLine($"Dequeued from Queue: {firstInQueue}");

        // 5. Stack<T>
        var stack = new Stack<string>();
        stack.Push("last");
        stack.Push("new");
        string topOfStack = stack.Pop();
        Console.WriteLine($"Popped from Stack: {topOfStack}");

        // Advanced Example 1: Dictionary<string, List<string>>
        var studentsByClass = new Dictionary<string, List<string>>();
        studentsByClass["Math"] = new List<string> { "Alice", "Bob" };
        studentsByClass["Science"] = new List<string> { "Charlie" };

        Console.WriteLine("\nStudents by class:");
        foreach (var subject in studentsByClass.Keys)
        {
            Console.WriteLine($"{subject}: {string.Join(", ", studentsByClass[subject])}");
        }

        // Advanced Example 2: HashSet<T> with custom class
        var people = new HashSet<Person>();
        people.Add(new Person { Name = "Alice" });
        people.Add(new Person { Name = "Alice" }); // Duplicate ignored

        Console.WriteLine($"\nHashSet contains {people.Count} unique person(s).");

        // Advanced Example 3: Task Queue Simulation
        var tasks = new Queue<Action>();
        tasks.Enqueue(() => Console.WriteLine("Task 1 executed"));
        tasks.Enqueue(() => Console.WriteLine("Task 2 executed"));

        Console.WriteLine("\nProcessing tasks:");
        while (tasks.Count > 0)
        {
            var task = tasks.Dequeue();
            task.Invoke();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Person person && Name == person.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
