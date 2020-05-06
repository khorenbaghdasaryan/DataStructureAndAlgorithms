using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{

    class Stacks
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                      AVERAGE                              |                Worst                           |
        //                   Access     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //Stacks<T>          O(n)       O(n)       O(1)             O(1)       |  O(n)       O(n)       O(1)       O(1)         |           O(n)
        //   

        //This feature makes it LIFO data structure.LIFO stands
        //for Last-in-first-out. Here, the element which is placed
        //(inserted or added) last, is accessed first.In stack terminology,
        //insertion operation is called PUSH operation and removal operation
        //is called POP operation.
        public void CreateSteack()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("One");
            numbers.Push("Two");
            numbers.Push("Three");
            numbers.Push("Four");
            numbers.Push("Five");

            // A stack can be enumerated without disturbing its contents.
            foreach (string number in numbers)         
                Console.WriteLine(number);

            Console.WriteLine($"\nPopping '{numbers.Pop()}'");
            Console.WriteLine($"Peek at next item to destack: {numbers.Peek()}");
            Console.WriteLine($"Popping '{numbers.Pop()}'");

            // Create a copy of the stack, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\n Contents of the first copy:");
            foreach (string number in stack2)
                Console.WriteLine(number);

            // Create an array twice the size of the stack and copy the
            // elements of the stack, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using the constructor that accepts an
            // IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
                Console.WriteLine(number);

            Console.WriteLine($"\nstack2.Contains(\"four\") = {stack2.Contains("four")}");

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine($"\nnstack2.Count = {stack2.Count}");
        }
    }

    class Queues
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                      AVERAGE                              |                Worst                           |
        //                   Access     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //Queue<T>           O(n)       O(n)       O(1)             O(1)       |  O(n)       O(n)       O(1)       O(1)         |           O(n)
        public void CreateQueue()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            foreach (string number in numbers)
                Console.WriteLine(number);

            Console.WriteLine($"\nDequeuing '{numbers.Dequeue()}'");
            Console.WriteLine($"Peek at next item to dequeue: {numbers.Dequeue()}");
            Console.WriteLine($"Dequeuing '{numbers.Dequeue()}'");

            // Create a copy of the queue, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in numbers)
                Console.WriteLine(number);

            // Create an array twice the size of the queue and copy the
            // elements of the queue, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            foreach (string number in array2)
                Console.WriteLine(number);

            // Create a second queue, using the constructor that accepts an
            // IEnumerable(Of T).
            Queue<string> queueCopy2 = new Queue<string>(array2);
            foreach (string number in numbers)
                Console.WriteLine(number);

            Console.WriteLine($"\nqueueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");
            Console.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Console.WriteLine($"\nqueueCopy.Count = {queueCopy.Count}");
        }
    }

    class LinearSearches
    {
        public int linearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }
    }
    class Hashtables
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                      AVERAGE                              |                Worst                           |
        //                   Access     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //Hashtable          N/A        O(1)       O(1)             O(1)       |  N/A        O(n)       O(n)       O(n)         |           O(n)
        //                                         AddLast  O(1)               |                                                |
        //                                         AddAfter O(1)               |                                                |
        public void CreateHashtable()
        {
            // Create a new hash table.
            Hashtable openWith = new Hashtable();

            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is
            // already in the hash table.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is the default property, so you
            // can omit its name when accessing elements.
            Console.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

            // The default Item property can be used to change the value
            // associated with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

            // If a key does not exist, setting the default Item property
            // for that key adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // ContainsKey can be used to test keys before inserting
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine($"Value added for key = \"ht\": {openWith["ht"]}.");
            }

            // When you use foreach to enumerate hash table elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (DictionaryEntry de in openWith)
                Console.WriteLine($"Key = {de.Key}, Value = {de.Value}");

            // To get the values alone, use the Values property.
            ICollection valueColl = openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for hash table values.
            Console.WriteLine();
            foreach (string s in valueColl)
                Console.WriteLine($"Value = {s}");

            // To get the keys alone, use the Keys property.
            ICollection keyColl = openWith.Keys;

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for hash table keys.
            Console.WriteLine();
            foreach (string s in keyColl)
                Console.WriteLine($"Key = {s}");

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");

            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
                Console.WriteLine("Key \"doc\" is not found.");


        }
    }
    class LinkedLists
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                      AVERAGE                              |                Worst                           |
        //                   Access     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //LinkedList<T>      O(n)       O(n)       O(1)             O(1)       |  O(n)       O(n)       O(1)       O(1)         |           O(n)
        //                                         AddLast  O(1)               |                                                |
        //                                         AddAfter O(1)               |                                                |

        //LinkedList<T> Represents a doubly linked list.
        //LinkedListNode<T> Represents a node in a LinkedList<T>. This class cannot be inherited.

        public void CreateLinkedList()
        {
           
            // Create the link list.
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Console.WriteLine($"sentence.Contains(\"jumps\") = {sentence.Contains("jumps")}");
            Display(sentence, "The linked list values:");
            

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Test 4: Move last node to be first node:");

            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.
            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                sentence.AddBefore(current, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
            }
            Console.WriteLine();

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the inked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string item in sArray)
            {
                Console.WriteLine(item);
            }

            // Release all the nodes.
            sentence.Clear();
            Console.WriteLine();
            Console.WriteLine($"Test 17: Clear linked list. Contains 'jumps' = {sentence.Contains("jumps")}");
        }

        private void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine($"Node '{node.Value}' is not in the list.\n");
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

        private void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Hashtables().CreateHashtable();
        }
    }
}
