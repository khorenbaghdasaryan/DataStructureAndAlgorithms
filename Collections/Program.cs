using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Collection
{
    class ArrayLists
    {
        //                                                      Time Complexities                                         |   Space Complexities
        //Collection                      AVERAGE                        |                Worst                           |
        //                   Access     Search     Insert     Deletion   |  Access     Search     Insert     Deletion     |
        //Stacks<T>          O(1)       O(n)       O(n)       O(1)       |  O(1)       O(n)       O(n)       O(n)         |          O(n)
        //   

        public void CreateArrayList()
        {
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");

            // Displays the properties and values of the ArrayList.
            Console.WriteLine("myAL");
            Console.WriteLine($" Count: {myAL.Count} ");
            Console.WriteLine($" Capacity: {myAL.Capacity} ");
            Console.WriteLine(" Values:");
            PrintValues(myAL);
        }
        private void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write($"   {obj}" );
            Console.WriteLine();
        }
    }
    class BitArrays
    {
        //                                                      Time Complexities                                         |   Space Complexities
        //Collection                      AVERAGE                        |                Worst                           |
        //                   Access     Search     Insert     Deletion   |  Access     Search     Insert     Deletion     |
        //Stacks<T>                                                      |                                                |          
        //   
        //The BitArray class is a collection class in which the capacity is always the same as the count.Elements are added to a BitArray by increasing
        //the Length property; elements are deleted by decreasing the Length property.The size of a BitArray is controlled by the client; indexing past
        //the end of the BitArray throws an ArgumentException.The BitArray class provides methods that are not found in other collections, including those
        //that allow multiple elements to be modified at once using a filter, such as And, Or, Xor , Not, and SetAll.
        //
        public void CreateBitArray()
        {
            BitArray myBA1 = new BitArray(5);

            BitArray myBA2 = new BitArray(5, true);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            BitArray myBA3 = new BitArray(myBytes);

            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray myBA4 = new BitArray(myBools);

            int[] myInts = new int[5] { 6, 7, 8, 9, 10 };
            BitArray myBA5 = new BitArray(myInts);

            //Displays the properties and values of the BitArrays.
            Console.WriteLine("myBA1");
            Console.WriteLine("   Count:    {0}", myBA1.Count);
            Console.WriteLine("   Length:   {0}", myBA1.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA1, 8);

            Console.WriteLine("myBA2");
            Console.WriteLine("   Count:    {0}", myBA2.Count);
            Console.WriteLine("   Length:   {0}", myBA2.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA2, 8);

            Console.WriteLine("myBA3");
            Console.WriteLine("   Count:    {0}", myBA3.Count);
            Console.WriteLine("   Length:   {0}", myBA3.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA3, 8);

            Console.WriteLine("myBA4");
            Console.WriteLine("   Count:    {0}", myBA4.Count);
            Console.WriteLine("   Length:   {0}", myBA4.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA4, 8);

            Console.WriteLine("myBA5");
            Console.WriteLine("   Count:    {0}", myBA5.Count);
            Console.WriteLine("   Length:   {0}", myBA5.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA5, 8);
        }

        private void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }
    }
    class Dictionarys
    {
        public void Start()
        {
            // Create a new dictionary of strings, with string keys.
            Dictionary<string, string> openWith = new Dictionary<string, string>();

            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is
            // already in the dictionary.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you
            // can omit its name when accessing elements.
            Console.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}");

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the dictionary.
            try
            {
                Console.WriteLine($"For key = \"tif\", value = {openWith["tif"]}.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient
            // way to retrieve values.
            string value = "";
            if(openWith.TryGetValue("tif", out value))
                Console.WriteLine($"For key = \"tif\", value = {value}.");
            else
                Console.WriteLine("Key = \"tif\" is not found.");

            // ContainsKey can be used to test keys before inserting
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine($"Value added for key = \"ht\": {openWith["ht"]}");
            }

            // When you use foreach to enumerate dictionary elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();

            foreach (KeyValuePair<string, string> kvp in openWith)
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");

            // To get the values alone, use the Values property.
            Dictionary<string, string>.ValueCollection valueColl = openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for dictionary values.
            Console.WriteLine();

            foreach (string s in valueColl)
                Console.WriteLine($"Value = {s}");

            // To get the keys alone, use the Keys property.
            Dictionary<string, string>.KeyCollection keyColl = openWith.Keys;

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for dictionary keys.
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
    class SortedDictionarys
    {
        public void Start()
        {
            // Create a new sorted dictionary of strings, with string
            SortedDictionary<string, string> openWith = new SortedDictionary<string, string>();

            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.

            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // already in the dictionary.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you
            // can omit its name when accessing elements.
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the dictionary.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }

            // When you use foreach to enumerate dictionary elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            SortedDictionary<string, string>.ValueCollection valueColl =
                openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for dictionary values.
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // To get the keys alone, use the Keys property.
            SortedDictionary<string, string>.KeyCollection keyColl =
                openWith.Keys;

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for dictionary keys.
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }
    class SortedSets
    {
        public void Start()
        {
            try
            {
                // Get a list of the files to use for the sorted set.
                IEnumerable<string> files1 =
                    Directory.EnumerateFiles(@"\\archives\2007\media",
                    "*", SearchOption.AllDirectories);

                // Create a sorted set using the ByFileExtension comparer.
                var mediaFiles1 = new SortedSet<string>(new ByFileExtension());

                // Note that there is a SortedSet constructor that takes an IEnumerable,
                // but to remove the path information they must be added individually.
                foreach (string f in files1)
                {
                    mediaFiles1.Add(f.Substring(f.LastIndexOf(@"\") + 1));
                }

                // Remove elements that have non-media extensions.
                // See the 'IsDoc' method.
                Console.WriteLine("Remove docs from the set...");
                Console.WriteLine($"\tCount before: {mediaFiles1.Count}");
                mediaFiles1.RemoveWhere(IsDoc);
                Console.WriteLine($"\tCount after: {mediaFiles1.Count}");

                Console.WriteLine();

                // List all the avi files.
                SortedSet<string> aviFiles = mediaFiles1.GetViewBetween("avi", "avj");

                Console.WriteLine("AVI files:");
                foreach (string avi in aviFiles)
                {
                    Console.WriteLine($"\t{avi}");
                }

                Console.WriteLine();

                // Create another sorted set.
                IEnumerable<string> files2 =
                    Directory.EnumerateFiles(@"\\archives\2008\media",
                        "*", SearchOption.AllDirectories);

                var mediaFiles2 = new SortedSet<string>(new ByFileExtension());

                foreach (string f in files2)
                {
                    mediaFiles2.Add(f.Substring(f.LastIndexOf(@"\") + 1));
                }

                // Remove elements in mediaFiles1 that are also in mediaFiles2.
                Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...");
                Console.WriteLine($"\tCount before: {mediaFiles1.Count}");
                mediaFiles1.ExceptWith(mediaFiles2);
                Console.WriteLine($"\tCount after: {mediaFiles1.Count}");

                Console.WriteLine();

                Console.WriteLine("List of mediaFiles1:");
                foreach (string f in mediaFiles1)
                {
                    Console.WriteLine($"\t{f}");
                }

                // Create a set of the sets.
                IEqualityComparer<SortedSet<string>> comparer =
                    SortedSet<string>.CreateSetComparer();

                var allMedia = new HashSet<SortedSet<string>>(comparer);
                allMedia.Add(mediaFiles1);
                allMedia.Add(mediaFiles2);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }

            catch (UnauthorizedAccessException AuthEx)
            {
                Console.WriteLine(AuthEx.Message);
            }
        }

        // Defines a predicate delegate to use
        // for the SortedSet.RemoveWhere method.
        private static bool IsDoc(string s)
        {
            s = s.ToLower();
            return (s.EndsWith(".txt") ||
                s.EndsWith(".xls") ||
                s.EndsWith(".xlsx") ||
                s.EndsWith(".pdf") ||
                s.EndsWith(".doc") ||
                s.EndsWith(".docx"));
        }
    }
    class ConcurrentBags
    {
        public void Start()
        {
            ConcurrentBag<int> cd = new ConcurrentBag<int>();
            List<Task> bagAddTasks = new List<Task>();

            for (int i = 0; i < 500; i++)
            {
                var numberToAdd = i;
                bagAddTasks.Add(Task.Run(() => cd.Add(numberToAdd)));
            }

            // Wait for all tasks to complete
            Task.WaitAll(bagAddTasks.ToArray());

            // Consume the items in the bag
            List<Task> bagConsumeTasks = new List<Task>();
            int itemsInBag = 0;
            while (!cd.IsEmpty)
            {
                bagConsumeTasks.Add(Task.Run(() =>
                {
                    int item;
                    if (cd.TryTake(out item))
                    {
                        Console.WriteLine(item);
                        itemsInBag++;
                    }
                }));
            }
            Task.WaitAll(bagConsumeTasks.ToArray());

            Console.WriteLine($"There were {itemsInBag} items in the bag");

            // Checks the bag for an item
            // The bag should be empty and this should not print anything
            int unexpectedItem;
            if (cd.TryPeek(out unexpectedItem))
                Console.WriteLine("Found an item in the bag when it should be empty");
        }
    }
    class ConcurrentDictionarys
    {
        //For very large ConcurrentDictionary<TKey, TValue> objects, you can increase 
        //the maximum array size to 2 gigabytes (GB) on a 64-bit system by setting 
        //the<gcAllowVeryLargeObjects> configuration element to true in the run-time environment.
        // Demonstrates:
        //      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity)
        //      ConcurrentDictionary<TKey, TValue>[TKey]
        public void Start()
        {
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101;

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises.
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) 
                cd[i] = i * i;

            Console.WriteLine($"The square of 23 is {cd[23]} (should be {23 * 23})");
        }
    }
    class ConcurrentQueues
    {
        // Represents a thread-safe first in-first out (FIFO) collection.
        // Demonstrates:
        // ConcurrentQueue<T>.Enqueue()
        // ConcurrentQueue<T>.TryPeek()
        // ConcurrentQueue<T>.TryDequeue()
        public void Start()
        {
            // Construct a ConcurrentQueue.
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();


            // Populate the queue.
            for (int i = 0; i < 10000; i++)
                cq.Enqueue(i);

            // Peek at the first element.
            int result;
            if (!cq.TryPeek(out result))
                Console.WriteLine($"CQ: TryPeek failed when it should have succeeded");
            else if (result != 0)
                Console.WriteLine($"CQ: Expected TryPeek result of 0, got {result}");

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue)) localSum += localValue;
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine($"outerSum = {outerSum}, should be 49995000");
        }
    }
    class ByFileExtension : IComparer<string>
    {
        // Defines a comparer to create a sorted set
        // that is sorted by the file extensions.
        string xExt, yExt;

        CaseInsensitiveComparer caseiComp = new CaseInsensitiveComparer();

        public int Compare(string x, string y)
        {
            // Parse the extension from the file name.
            xExt = x.Substring(x.LastIndexOf(".") + 1);
            yExt = y.Substring(y.LastIndexOf(".") + 1);

            // Compare the file extensions.
            int vExt = caseiComp.Compare(xExt, yExt);
            if (vExt != 0)
                return vExt;
            else
                // The extension is the same,
                // so compare the filenames.
                return caseiComp.Compare(x, y);
        }
    }
    class SortedLists
    {
        public void Start()
        {
            // Creates and initializes a new SortedList.
            SortedList mySL = new SortedList();
            mySL.Add("Third", "!");
            mySL.Add("Second", "World");
            mySL.Add("First", "Hello");

            // Displays the properties and values of the SortedList.
            Console.WriteLine("mySL");
            Console.WriteLine($"  Count:    {mySL.Count}");
            Console.WriteLine($"  Capacity: {mySL.Capacity}");
            Console.WriteLine("  Keys and Values:");
            PrintKeysAndValues(mySL);
        }

        private void PrintKeysAndValues(SortedList mySL)
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < mySL.Count; i++)
                Console.WriteLine($"\t{mySL.GetKey(i)}:\t{mySL.GetByIndex(i)}");
            Console.WriteLine();
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
    class HashSets
    {
        public void Start()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write($"evenNumbers contains {evenNumbers.Count} elements: ");
            DisplaySet(evenNumbers);


            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);

            Console.WriteLine();
        }
        private void DisplaySet(HashSet<int> collection)
        {
            Console.Write("{");
            foreach (int i in collection)         
                Console.Write(" {0}", i);         
            Console.WriteLine(" }");
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

        [Obsolete]
        public void CaseInsensitiveComparer()
        {
            // Create a Hashtable using the default hash code provider and the default comparer.
            Hashtable myHT1 = new Hashtable();
            myHT1.Add("FIRST", "Hello");
            myHT1.Add("SECOND", "World");
            myHT1.Add("THIRD", "!");

            // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
            // based on the culture of the current thread.
            Hashtable myHT2 = new Hashtable(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
            myHT2.Add("FIRST", "Hello");
            myHT2.Add("SECOND", "World");
            myHT2.Add("THIRD", "!");

            // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
            // based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
            CultureInfo myCulture = new CultureInfo("tr-TR");
            Hashtable myHT3 = new Hashtable(new CaseInsensitiveHashCodeProvider(myCulture), new CaseInsensitiveComparer(myCulture));


            // Search for a key in each hashtable.
            Console.WriteLine($"first is in myHT1: {myHT1.ContainsKey("first")} ");
            Console.WriteLine($"first is in myHT2: {myHT2.ContainsKey("first")} ");
            Console.WriteLine("first is in myHT3: {0}", myHT3.ContainsKey("first"));
        }

        public void CollectionsUtils()
        {
            Hashtable population1 = CollectionsUtil.CreateCaseInsensitiveHashtable();

            population1["Trapperville"] = 15;
            population1["Doggerton"] = 230;
            population1["New Hollow"] = 1234;
            population1["McHenry"] = 185;

            // Select cities from the table using mixed case.
            Console.WriteLine("Case insensitive hashtable results:\n");
            Console.WriteLine($"{"Trapperville"}'s population is: { population1["trapperville"]}");
            Console.WriteLine($"{"Doggerton"}'s population is: {population1["DOGGERTON"]}");
            Console.WriteLine($"{"New Hollow"}'s population is: {population1["New hoLLow"]}");
            Console.WriteLine($"{"McHenry"}'s population is: {population1["MchenrY"]}");

            SortedList population2 = CollectionsUtil.CreateCaseInsensitiveSortedList();

            foreach (string city in population1.Keys)
                population2.Add(city, population1[city]);

            //Select cities from the sorted list using mixed case.
            Console.WriteLine("\nCase insensitive sorted list results:\n");
            Console.WriteLine($"{"Trapperville"}'s population is: {population2["trapPeRVille"]}");
            Console.WriteLine($"{"Doggerton"}'s population is: {population2["dOGGeRtON"]}");
            Console.WriteLine($"{"New Hollow"}'s population is: {population2["nEW hOLLOW"]}");
            Console.WriteLine($"{"McHenry"}'s population is: {population2["nEW hOLLOW"]}");




        }
    }
    class Int16Collection : CollectionBase
    {
        public Int16 this[int index]
        {
            get
            {
                return ((Int16)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(Int16 value)
        {
            return (List.Add(value));
        }

        public int IndexOf(Int16 value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, Int16 value)
        {
            List.Insert(index, value);
        }

        public void Remove(Int16 value)
        {
            List.Remove(value);
        }

        public bool Contains(Int16 value)
        {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(System.Int16))
                throw new ArgumentException("value must be of type Int16.", "value");
        }

        public void Start()
        {
            // Create and initialize a new CollectionBase.
            Int16Collection myI16 = new Int16Collection();

            // Add elements to the collection.
            myI16.Add((Int16)1);
            myI16.Add((Int16)2);
            myI16.Add((Int16)3);
            myI16.Add((Int16)5);
            myI16.Add((Int16)7);

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Contents of the collection (using foreach):");
            PrintValues1(myI16);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Contents of the collection (using enumerator):");
            PrintValues2(myI16);

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine("Initial contents of the collection (using Count and Item):");
            PrintIndexAndValues(myI16);

            // Search the collection with Contains and IndexOf.
            Console.WriteLine("Contains 3: {0}", myI16.Contains(3));
            Console.WriteLine("2 is at index {0}.", myI16.IndexOf(2));
            Console.WriteLine();

            // Insert an element into the collection at index 3.
            myI16.Insert(3, (Int16)13);
            Console.WriteLine("Contents of the collection after inserting at index 3:");
            PrintIndexAndValues(myI16);

            // Get and set an element using the index.
            myI16[4] = 123;
            Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:");
            PrintIndexAndValues(myI16);

            // Remove an element from the collection.
            myI16.Remove((Int16)2);

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine("Contents of the collection after removing the element 2:");
            PrintIndexAndValues(myI16);
        }

        // Uses the Count property and the Item property.
        public static void PrintIndexAndValues(Int16Collection myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine("   [{0}]:   {1}", i, myCol[i]);
            Console.WriteLine();
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues1(Int16Collection myCol)
        {
            foreach (Int16 i16 in myCol)
                Console.WriteLine("   {0}", i16);
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues2(Int16Collection myCol)
        {
            System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine("   {0}", myEnumerator.Current);
            Console.WriteLine();
        }
    }
    class Comparers
    {
        public void Start()
        {
            // Creates the strings to compare.
            String str1 = "llegar";
            String str2 = "lugar";

            Console.WriteLine($"Comparing \"{str1}\" and \"{str2}\" ...");

            // Uses the DefaultInvariant Comparer.
            Console.WriteLine($"   Invariant Comparer: {Comparer.DefaultInvariant.Compare(str1, str2)}");

            // Uses the Comparer based on the culture "es-ES" (Spanish - Spain, international sort).
            Comparer myCompIntl = new Comparer(new CultureInfo("es-ES", false));
            Console.WriteLine($"   International Sort: {myCompIntl.Compare( str1, str2)}");

            // Uses the Comparer based on the culture identifier 0x040A (Spanish - Spain, traditional sort).
            Comparer myCompTrad = new Comparer(new CultureInfo(0x040A, false));
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
    class Collections
    {
        public void Start()
        {
            Collection<string> dinosaurs = new Collection<string>();
            
            dinosaurs.Add("Psitticosaurus");
            dinosaurs.Add("Caudipteryx");
            dinosaurs.Add("Compsognathus");
            dinosaurs.Add("Muttaburrasaurus");

            Console.WriteLine($"{dinosaurs.Count} dinosaurs:");
            Display(dinosaurs);

            Console.WriteLine($"\nIndexOf(\"Muttaburrasaurus\"): {dinosaurs.IndexOf("Muttaburrasaurus")} ");

            Console.WriteLine($"\nContains(\"Caudipteryx\"): {dinosaurs.Contains("Caudipteryx")} ");

            Console.WriteLine($"\nInsert(2, \"Nanotyrannus\")");
            dinosaurs.Insert(2, "Nanotyrannus");
            Display(dinosaurs);

            Console.WriteLine($"\ndinosaurs[2]: {dinosaurs[2]}");
            Console.WriteLine("\ndinosaurs[2] = \"Microraptor\"");
            dinosaurs[2] = "Microraptor";
            Display(dinosaurs);

            Console.WriteLine("\nRemove(\"Microraptor\")");
            dinosaurs.Remove("Microraptor");
            Display(dinosaurs);

            Console.WriteLine("\nRemoveAt(0)");
            dinosaurs.RemoveAt(0);
            Display(dinosaurs);

            Console.WriteLine("\ndinosaurs.Clear()");
            dinosaurs.Clear();
            Console.WriteLine("Count: {0}", dinosaurs.Count);
        }

        private void Display(Collection<string> dinosaurs)
        {
            Console.WriteLine();
            foreach (string item in dinosaurs)
                Console.WriteLine(item);
        }
    }
    class ReadOnlyCollection
    {
       public void Start()
        {
            List<string> dinosaurs = new List<string>();

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            ReadOnlyCollection<string> readOnlyDinosaurs = new ReadOnlyCollection<string>(dinosaurs);

            Console.WriteLine();
            foreach (string dinosaur in readOnlyDinosaurs)
                Console.WriteLine(dinosaur);


            Console.WriteLine($"\nCount: {readOnlyDinosaurs.Count}");
            Console.WriteLine($"\nContains(\"Deinonychus\"): {readOnlyDinosaurs.Contains("Deinonychus")}");
            Console.WriteLine($"\nreadOnlyDinosaurs[3]: {readOnlyDinosaurs[3]}");
            Console.WriteLine($"\nIndexOf(\"Compsognathus\"): {readOnlyDinosaurs.IndexOf("Compsognathus")}");
            Console.WriteLine("\nInsert into the wrapped List:");
            Console.WriteLine("Insert(2, \"Oviraptor\")");
            dinosaurs.Insert(2, "Oviraptor");

            Console.WriteLine();
            foreach (string dinosaur in readOnlyDinosaurs)
                Console.WriteLine(dinosaur);

            string[] dinoArray = new string[readOnlyDinosaurs.Count + 2];
            readOnlyDinosaurs.CopyTo(dinoArray, 1);

            Console.WriteLine($"\nCopied array has {dinoArray.Length} elements:");

            foreach (string dinosaur in dinoArray)
                Console.WriteLine($"\"{dinosaur}\"");
        }
    }
    class BitVector32s
    {
        public void Start()
        {
            // Creates and initializes a BitVector32 with all bit flags set to FALSE.
            BitVector32 myBV1 = new BitVector32(0);

            // Creates masks to isolate each of the first five bit flags.
            int myBit1 = BitVector32.CreateMask();
            int myBit2 = BitVector32.CreateMask(myBit1);
            int myBit3 = BitVector32.CreateMask(myBit2);
            int myBit4 = BitVector32.CreateMask(myBit3);
            int myBit5 = BitVector32.CreateMask(myBit4);

            // Sets the alternating bits to TRUE.
            Console.WriteLine("Setting alternating bits to TRUE:");
            Console.WriteLine($"   Initial:         {myBV1.ToString()}" );
            myBV1[myBit1] = true;
            Console.WriteLine($"   myBit3 = TRUE:   {myBV1.ToString()}");
            myBV1[myBit3] = true;
            Console.WriteLine($"   myBit3 = TRUE:   {myBV1.ToString()}");
            myBV1[myBit5] = true;
            Console.WriteLine($"   myBit5 = TRUE:   {myBV1.ToString()}");

            BitVector32 myBV2 = new BitVector32(0);

            // mySect3, which uses exactly one bit, can also be used as a bit flag.
            BitVector32.Section mySect1 = BitVector32.CreateSection(6);
            BitVector32.Section mySect2 = BitVector32.CreateSection(3, mySect1);
            BitVector32.Section mySect3 = BitVector32.CreateSection(1, mySect2);
            BitVector32.Section mySect4 = BitVector32.CreateSection(15, mySect3);

            // Displays the values of the sections.
            Console.WriteLine("Initial values:");
            Console.WriteLine($"\tmySect1: { myBV2[mySect1]}");
            Console.WriteLine($"\tmySect2: { myBV2[mySect2]}");
            Console.WriteLine($"\tmySect3: { myBV2[mySect3]}");
            Console.WriteLine($"\tmySect4: { myBV2[mySect4]}");

            // Sets each section to a new value and displays the value of the BitVector32 at each step.
            Console.WriteLine("Changing the values of each section:");
            Console.WriteLine($"\tInitial:    \t{myBV2.ToString()}");
            myBV2[mySect1] = 5;
            Console.WriteLine($"\tmySect1 = 5:\t{myBV2.ToString()}");
            myBV2[mySect2] = 3;
            Console.WriteLine($"\tmySect2 = 3:\t{myBV2.ToString()}");
            myBV2[mySect3] = 1;
            Console.WriteLine($"\tmySect3 = 1:\t{myBV2.ToString()}");
            myBV2[mySect4] = 9;
            Console.WriteLine($"\tmySect4 = 9:\t{myBV2.ToString()}");

            // Displays the values of the sections.
            Console.WriteLine("New values:");
            Console.WriteLine($"\tmySect1: {myBV2[mySect1]}");
            Console.WriteLine($"\tmySect2: {myBV2[mySect2]}");
            Console.WriteLine($"\tmySect3: {myBV2[mySect3]}");
            Console.WriteLine($"\tmySect4: {myBV2[mySect4]}");

        }
    }
    class HybridDictionarys
    {
        public void Start()
        {
            // Creates and initializes a new HybridDictionary.
            HybridDictionary myCol = new HybridDictionary();

            myCol.Add("Braeburn Apples", "1.49");
            myCol.Add("Fuji Apples", "1.29");
            myCol.Add("Gala Apples", "1.49");
            myCol.Add("Golden Delicious Apples", "1.29");
            myCol.Add("Granny Smith Apples", "0.89");
            myCol.Add("Red Delicious Apples", "0.99");
            myCol.Add("Plantain Bananas", "1.49");
            myCol.Add("Yellow Bananas", "0.79");
            myCol.Add("Strawberries", "3.33");
            myCol.Add("Cranberries", "5.98");
            myCol.Add("Navel Oranges", "1.29");
            myCol.Add("Grapes", "1.99");
            myCol.Add("Honeydew Melon", "0.59");
            myCol.Add("Seedless Watermelon", "0.49");
            myCol.Add("Pineapple", "1.49");
            myCol.Add("Nectarine", "1.99");
            myCol.Add("Plums", "1.69");
            myCol.Add("Peaches", "1.99");

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintKeysAndValues1(myCol);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IDictionaryEnumerator:");
            PrintKeysAndValues2(myCol);

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
            PrintKeysAndValues3(myCol);

            // Copies the HybridDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo(myArr, 0);

            // Displays the values in the array.
            Console.WriteLine("Displays the elements in the array:");
            Console.WriteLine("   KEY                       VALUE");
            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine($"   {myArr[i].Key,-25} {myArr[i].Value}");
            Console.WriteLine();

            // Searches for a key.
            if (myCol.Contains("Kiwis"))
                Console.WriteLine("The collection contains the key \"Kiwis\".");
            else
                Console.WriteLine("The collection does not contain the key \"Kiwis\".");
            Console.WriteLine();

            // Deletes a key.
            myCol.Remove("Plums");
            Console.WriteLine("The collection contains the following elements after removing \"Plums\":");
            PrintKeysAndValues1(myCol);

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues1(myCol);
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues1(IDictionary myCol)
        {
            Console.WriteLine("   KEY                       VALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine($"   {de.Key,-25} {de.Value}" );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues2(IDictionary myCol)
        {
            IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
                Console.WriteLine($"   {myEnumerator.Key,-25} {myEnumerator.Value}");
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public static void PrintKeysAndValues3(HybridDictionary myCol)
        {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo(myKeys, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   {i,-5} {myKeys[i],-25} {myCol[myKeys[i]]}");
            Console.WriteLine();
        }
    }
    class ListDictionarys
    {
        //This is a simple implementation of IDictionary using a singly linked list.
        //It is smaller and faster than a Hashtable if the number of elements is 10 or less.
        //This should not be used if performance is important for large numbers of elements.
        //Members, such as Item[Object], Add, Remove, and Contains are O(n) operations, where n is Count.0
        public void Start()
        {
            // Creates and initializes a new ListDictionary.
            ListDictionary myCol = new ListDictionary();
            myCol.Add("Braeburn Apples", "1.49");
            myCol.Add("Fuji Apples", "1.29");
            myCol.Add("Gala Apples", "1.49");
            myCol.Add("Golden Delicious Apples", "1.29");
            myCol.Add("Granny Smith Apples", "0.89");
            myCol.Add("Red Delicious Apples", "0.99");

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintKeysAndValues1(myCol);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IDictionaryEnumerator:");
            PrintKeysAndValues2(myCol);

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
            PrintKeysAndValues3(myCol);

            // Copies the ListDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo(myArr, 0);

            // Displays the values in the array.
            Console.WriteLine("Displays the elements in the array:");
            Console.WriteLine("   KEY                       VALUE");
            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine($"   {myArr[i].Key,-25} {myArr[i].Value}" );
            Console.WriteLine();

            // Searches for a key.
            if (myCol.Contains("Kiwis"))
                Console.WriteLine("The collection contains the key \"Kiwis\".");
            else
                Console.WriteLine("The collection does not contain the key \"Kiwis\".");
            Console.WriteLine();

            // Deletes a key.
            myCol.Remove("Plums");
            Console.WriteLine("The collection contains the following elements after removing \"Plums\":");
            PrintKeysAndValues1(myCol);

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues1(myCol);
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintKeysAndValues1(IDictionary myCol)
        {
            Console.WriteLine("   KEY                       VALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine($"   {de.Key,-25} {de.Value}");
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintKeysAndValues2(IDictionary myCol)
        {
            IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
                Console.WriteLine($"   {myEnumerator.Key,-25} {myEnumerator.Value}");
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public static void PrintKeysAndValues3(ListDictionary myCol)
        {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo(myKeys, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   {i,-5} {myKeys[i],-25} {myCol[myKeys[i]]}");
            Console.WriteLine();
        }
    }

    class NameValueCollections
    {
        // Represents a collection of associated String keys and String values that 
        // can be accessed either with the key or with the index.
        public void Start()
        {
            // Creates and initializes a new NameValueCollection.
            NameValueCollection myCol = new NameValueCollection();
            myCol.Add("red", "rojo");
            myCol.Add("green", "verde");
            myCol.Add("blue", "azul");
            myCol.Add("red", "rouge");

            // Displays the values in the NameValueCollection in two different ways.
            Console.WriteLine("Displays the elements using the AllKeys property and the Item (indexer) property:");
            PrintKeysAndValues(myCol);
            Console.WriteLine("Displays the elements using GetKey and Get:");
            PrintKeysAndValues2(myCol);

            // Gets a value either by index or by key.
            Console.WriteLine($"Index 1 contains the value {myCol[1]}." );
            Console.WriteLine($"Key \"red\" has the value {myCol["red"]}." );
            Console.WriteLine();

            // Copies the values to a string array and displays the string array.
            String[] myStrArr = new String[myCol.Count];
            myCol.CopyTo(myStrArr, 0);
            Console.WriteLine("The string array contains:");
            foreach (String s in myStrArr)
                Console.WriteLine($"   {s}");
            Console.WriteLine();

            // Searches for a key and deletes it.
            myCol.Remove("green");
            Console.WriteLine("The collection contains the following elements after removing \"green\":");
            PrintKeysAndValues(myCol);

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues(myCol);
        }
        public static void PrintKeysAndValues(NameValueCollection myCol)
        {
            Console.WriteLine("   KEY        VALUE");
            foreach (String s in myCol.AllKeys)
                Console.WriteLine($"   {s,-10} {myCol[s]}" );
            Console.WriteLine();
        }
        public static void PrintKeysAndValues2(NameValueCollection myCol)
        {
            Console.WriteLine("   [INDEX] KEY        VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   [{i}]     {myCol.GetKey(i),-10} { myCol.Get(i)}");
            Console.WriteLine();
        }
    }
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            new NameValueCollections().Start();
        }
    }
}
