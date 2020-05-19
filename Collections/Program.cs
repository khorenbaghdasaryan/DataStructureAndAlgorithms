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
using System.Linq;
using System.Collections.Immutable;
using System.Diagnostics;

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
        //BitArray                                                      |                                                |          
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
            Console.WriteLine($"   Initial:         {myBV1.ToString()}");
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
    class BlockingCollections
    {
        class BlockingCollectionDemo
        {
            static async Task Start()
            {
                await AddTakeDemo.BC_AddTakeCompleteAdding();
                TryTakeDemo.BC_TryTake();
                FromToAnyDemo.BC_FromToAny();
                await ConsumingEnumerableDemo.BC_GetConsumingEnumerable();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        class AddTakeDemo
        {
            // Demonstrates:
            //      BlockingCollection<T>.Add()
            //      BlockingCollection<T>.Take()
            //      BlockingCollection<T>.CompleteAdding()
            public static async Task BC_AddTakeCompleteAdding()
            {
                using (BlockingCollection<int> bc = new BlockingCollection<int>())
                {
                    // Spin up a Task to populate the BlockingCollection
                    using (Task t1 = Task.Run(() =>
                    {
                        bc.Add(1);
                        bc.Add(2);
                        bc.Add(3);
                        bc.CompleteAdding();
                    }))
                    {
                        // Spin up a Task to consume the BlockingCollection
                        using (Task t2 = Task.Run(() =>
                        {
                            try
                            {
                                // Consume consume the BlockingCollection
                                while (true) Console.WriteLine(bc.Take());
                            }
                            catch (InvalidOperationException)
                            {
                                // An InvalidOperationException means that Take() was called on a completed collection
                                Console.WriteLine("That's All!");
                            }
                        }))
                        {
                            await Task.WhenAll(t1, t2);
                        }
                    }
                }
            }
        }
        class TryTakeDemo
        {
            // Demonstrates:
            //      BlockingCollection<T>.Add()
            //      BlockingCollection<T>.CompleteAdding()
            //      BlockingCollection<T>.TryTake()
            //      BlockingCollection<T>.IsCompleted
            public static void BC_TryTake()
            {
                // Construct and fill our BlockingCollection
                using (BlockingCollection<int> bc = new BlockingCollection<int>())
                {
                    int NUMITEMS = 10000;
                    for (int i = 0; i < NUMITEMS; i++) bc.Add(i);
                    bc.CompleteAdding();
                    int outerSum = 0;

                    // Delegate for consuming the BlockingCollection and adding up all items
                    Action action = () =>
                    {
                        int localItem;
                        int localSum = 0;

                        while (bc.TryTake(out localItem)) localSum += localItem;
                        Interlocked.Add(ref outerSum, localSum);
                    };

                    // Launch three parallel actions to consume the BlockingCollection
                    Parallel.Invoke(action, action, action);

                    Console.WriteLine("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, ((NUMITEMS * (NUMITEMS - 1)) / 2));
                    Console.WriteLine("bc.IsCompleted = {0} (should be true)", bc.IsCompleted);
                }
            }
        }
        class FromToAnyDemo
        {
            // Demonstrates:
            //      Bounded BlockingCollection<T>
            //      BlockingCollection<T>.TryAddToAny()
            //      BlockingCollection<T>.TryTakeFromAny()
            public static void BC_FromToAny()
            {
                BlockingCollection<int>[] bcs = new BlockingCollection<int>[2];
                bcs[0] = new BlockingCollection<int>(5); // collection bounded to 5 items
                bcs[1] = new BlockingCollection<int>(5); // collection bounded to 5 items

                // Should be able to add 10 items w/o blocking
                int numFailures = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (BlockingCollection<int>.TryAddToAny(bcs, i) == -1) numFailures++;
                }
                Console.WriteLine("TryAddToAny: {0} failures (should be 0)", numFailures);

                // Should be able to retrieve 10 items
                int numItems = 0;
                int item;
                while (BlockingCollection<int>.TryTakeFromAny(bcs, out item) != -1) numItems++;
                Console.WriteLine("TryTakeFromAny: retrieved {0} items (should be 10)", numItems);
            }
        }
        class ConsumingEnumerableDemo
        {
            // Demonstrates:
            //      BlockingCollection<T>.Add()
            //      BlockingCollection<T>.CompleteAdding()
            //      BlockingCollection<T>.GetConsumingEnumerable()
            public static async Task BC_GetConsumingEnumerable()
            {
                using (BlockingCollection<int> bc = new BlockingCollection<int>())
                {
                    // Kick off a producer task
                    await Task.Run(async () =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            bc.Add(i);
                            await Task.Delay(100); // sleep 100 ms between adds
                        }

                        // Need to do this to keep foreach below from hanging
                        bc.CompleteAdding();
                    });

                    // Now consume the blocking collection with foreach.
                    // Use bc.GetConsumingEnumerable() instead of just bc because the
                    // former will block waiting for completion and the latter will
                    // simply take a snapshot of the current state of the underlying collection.
                    foreach (var item in bc.GetConsumingEnumerable())
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }//fast when bounding and blocking semantics are required
    class ConcurrentBags
    {
        // In mixed producer-consumer scenarios, ConcurrentBag<T> is generally
        // much faster and more scalable than any other concurrent collection 
        // type for both large and small workloads.
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
    } //provides fast multi-threaded insertion for unordered data, fast when mixed producer-consumer scenarios
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
    class ConcurrentStack
    {
        // Demonstrates:
        //      ConcurrentStack<T>.Push();
        //      ConcurrentStack<T>.TryPeek();
        //      ConcurrentStack<T>.TryPop();
        //      ConcurrentStack<T>.Clear();
        //      ConcurrentStack<T>.IsEmpty;
        public async Task StartAsync()
        {
            int items = 10000;

            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            // Create an action to push items onto the stack
            Action pusher = () =>
            {
                for (int i = 0; i < items; i++)
                {
                    stack.Push(i);
                }
            };

            // Run the action once
            pusher();

            if (stack.TryPeek(out int result))
            {
                Console.WriteLine($"TryPeek() saw {result} on top of the stack.");
            }
            else
            {
                Console.WriteLine("Could not peek most recently added number.");
            }

            // Empty the stack
            stack.Clear();

            if (stack.IsEmpty)
            {
                Console.WriteLine("Cleared the stack.");
            }

            // Create an action to push and pop items
            Action pushAndPop = () =>
            {
                Console.WriteLine($"Task started on {Task.CurrentId}");

                int item;
                for (int i = 0; i < items; i++)
                    stack.Push(i);
                for (int i = 0; i < items; i++)
                    stack.TryPop(out item);

                Console.WriteLine($"Task ended on {Task.CurrentId}");
            };

            // Spin up five concurrent tasks of the action
            var tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Factory.StartNew(pushAndPop);

            // Wait for all the tasks to finish up
            await Task.WhenAll(tasks);

            if (!stack.IsEmpty)
            {
                Console.WriteLine("Did not take all the items off the stack");
            }
        }

        // Demonstrates:
        //      ConcurrentStack<T>.PushRange();
        //      ConcurrentStack<T>.TryPopRange();
        public async Task StartAsync2()
        {
            int numParallelTasks = 4;
            int numItems = 1000;
            var stack = new ConcurrentStack<int>();

            // Push a range of values onto the stack concurrently
            await Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(i => Task.Factory.StartNew((state) =>
            {
                // state = i * numItems
                int index = (int)state;
                int[] array = new int[numItems];
                for (int j = 0; j < numItems; j++)
                {
                    array[j] = index + j;
                }

                Console.WriteLine($"Pushing an array of ints from " +
                    $"{array[0]} to {array[numItems - 1]}");
                stack.PushRange(array);
            }, i * numItems, CancellationToken.None, TaskCreationOptions.DenyChildAttach,
               TaskScheduler.Default)).ToArray());

            int numTotalElements = 4 * numItems;
            int[] resultBuffer = new int[numTotalElements];
            await Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(i => Task.Factory.StartNew(obj =>
            {
                int index = (int)obj;
                int result = stack.TryPopRange(resultBuffer, index, numItems);

                Console.WriteLine($"TryPopRange expected {numItems}, got {result}.");
            }, i * numItems, CancellationToken.None, TaskCreationOptions.LongRunning,
               TaskScheduler.Default)).ToArray());

            for (int i = 0; i < numParallelTasks; i++)
            {
                // Create a sequence we expect to see from the stack taking the last number of the range we inserted
                var expected = Enumerable.Range(resultBuffer[i * numItems + numItems - 1], numItems);

                // Take the range we inserted, reverse it, and compare to the expected sequence
                var areEqual = expected.SequenceEqual(resultBuffer.Skip(i * numItems).Take(numItems).Reverse());
                if (areEqual)
                    Console.WriteLine($"Expected a range of {expected.First()} " +
                        $"to {expected.Last()}. Got {resultBuffer[i * numItems + numItems - 1]} " +
                        $"to {resultBuffer[i * numItems]}");
                else
                    Console.WriteLine($"Unexpected consecutive ranges.");
            }
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
            Console.WriteLine($"   International Sort: {myCompIntl.Compare(str1, str2)}");

            // Uses the Comparer based on the culture identifier 0x040A (Spanish - Spain, traditional sort).
            Comparer myCompTrad = new Comparer(new CultureInfo(0x040A, false));
        }
    }
    class Dictionarys
    {
        //                                                                         Time Complexities                                                              |   Space Complexities
        //Collection                                        AVERAGE                                      |                Worst                                   |
        //                            Access                  Search     Insert     Deletion     Add     |  Access     Search     Insert     Deletion     Add     |
        //Dictionary<TKey, TValue>    O(1) amortized by key   O(n)       O(1)       O(1)         O(1)    |  O(n)       O(n)       O(n)       O(n)         O(n)    |       O(n)   
        //                            O(n) amortized                     amortized  amortized
        //
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
    }// provides faster lookup than the SortedDictionary<TKey,TValue>
    class HashSets
    {
        //                                                          Time Complexities                                                              |   Space Complexities
        //Collection                         AVERAGE                                      |                Worst                                   |
        //             Access                  Search     Insert     Deletion     Add     |  Access     Search     Insert     Deletion     Add     |
        //HashSet<>    O(1) amortized by key   O(n)       O(1)       O(1)         O(1)    |  O(n)       O(n)       O(n)       O(n)         O(n)    |       O(n)   
        //             O(n) amortized                     amortized  amortized
        //
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
        public void Start()
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
    }// sorts its elements by their hash codes
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
                Console.WriteLine($"   {de.Key,-25} {de.Value}");
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
    class ImmutableArrays
    {
        // Operation 	ImmutableArray<T>  	ImmutableList<T>  	Comments
        //              Complexity          Complexity
        // Item         O(1)                O(log n)            Directly index into the underlying array
        // Add()        O(n)                O(log n)            Requires creating a new array
    }
    class ImmutableLists
    {
        // Operation 	ImmutableArray<T>  	ImmutableList<T>  	Comments
        //              Complexity          Complexity
        // Item         O(1)                O(log n)            Directly index into the underlying array
        // Add()        O(n)                O(log n)            Requires creating a new array
    }
    class ImmutableQueues
    {
        public void Start()
        {
            ImmutableQueue<int> immutableQueue = ImmutableQueue.Create<int>(1);
            foreach (var item in immutableQueue)
                Console.WriteLine(item);            
        }
    }
    class ImmutableStacks
    {
        public void Start()
        {
            ImmutableStack<int> immutableStack = ImmutableStack.Create<int>(1);
            foreach (var item in immutableStack)
                Console.WriteLine(item);
        }
    }
    class ImmutableHashSets
    {

    }
    class ImmutableDictionarys
    {

    }
    class ImmutableSortedSets
    {

    }
    class ImmutableSortedDictionarys
    {

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
    class KeyedCollections
    {
        public class SimpleOrder : KeyedCollection<int, OrderItem>
        {

            // This is the only method that absolutely must be overridden,
            // because without it the KeyedCollection cannot extract the
            // keys from the items. The input parameter type is the
            // second generic type argument, in this case OrderItem, and
            // the return value type is the first generic type argument,
            // in this case int.
            //
            protected override int GetKeyForItem(OrderItem item)
            {
                // In this example, the key is the part number.
                return item.PartNumber;
            }
        }
        // This class represents a simple line item in an order. All the
        // values are immutable except quantity.
        //
        public class OrderItem
        {
            public readonly int PartNumber;
            public readonly string Description;
            public readonly double UnitPrice;

            private int _quantity = 0;

            public OrderItem(int partNumber, string description,
                int quantity, double unitPrice)
            {
                this.PartNumber = partNumber;
                this.Description = description;
                this.Quantity = quantity;
                this.UnitPrice = unitPrice;
            }
            public int Quantity
            {
                get { return _quantity; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Quantity cannot be negative.");

                    _quantity = value;
                }
            }
            public override string ToString()
            {
                return String.Format(
                    "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}",
                    PartNumber, _quantity, Description, UnitPrice,
                    UnitPrice * _quantity);
            }
        }
        public void Start()
        {
            SimpleOrder weekly = new SimpleOrder();

            // The Add method, inherited from Collection, takes OrderItem.
            //
            weekly.Add(new OrderItem(110072674, "Widget", 400, 45.17));
            weekly.Add(new OrderItem(110072675, "Sprocket", 27, 5.3));
            weekly.Add(new OrderItem(101030411, "Motor", 10, 237.5));
            weekly.Add(new OrderItem(110072684, "Gear", 175, 5.17));

            Display(weekly);

            Console.WriteLine($"\nContains(101030411): {weekly.Contains(101030411)}");

            // The default Item property of KeyedCollection takes a key.
            //
            Console.WriteLine($"\nweekly[101030411].Description: {weekly[101030411].Description}");

            // The Remove method of KeyedCollection takes a key.
            //
            Console.WriteLine("\nRemove(101030411)");
            weekly.Remove(101030411);
            Display(weekly);

            // The Insert method, inherited from Collection, takes an
            // index and an OrderItem.
            //
            Console.WriteLine("\nInsert(2, New OrderItem(...))");
            weekly.Insert(2, new OrderItem(111033401, "Nut", 10, .5));
            Display(weekly);

            // The default Item property is overloaded. One overload comes
            // from KeyedCollection<int, OrderItem>; that overload
            // is read-only, and takes Integer because it retrieves by key.
            // The other overload comes from Collection<OrderItem>, the
            // base class of KeyedCollection<int, OrderItem>; it
            // retrieves by index, so it also takes an Integer. The compiler
            // uses the most-derived overload, from KeyedCollection, so the
            // only way to access SimpleOrder by index is to cast it to
            // Collection<OrderItem>. Otherwise the index is interpreted
            // as a key, and KeyNotFoundException is thrown.
            //

            Collection<OrderItem> coweekly = weekly;
            Console.WriteLine($"\ncoweekly[2].Description: {coweekly[2].Description}" );

            Console.WriteLine("\ncoweekly[2] = new OrderItem(...)");
            coweekly[2] = new OrderItem(127700026, "Crank", 27, 5.98);

            OrderItem temp = coweekly[2];

            // The IndexOf method inherited from Collection<OrderItem>
            // takes an OrderItem instead of a key
            //
            Console.WriteLine($"\nIndexOf(temp): {weekly.IndexOf(temp)}" );

            // The inherited Remove method also takes an OrderItem.
            //
            Console.WriteLine("\nRemove(temp)");
            weekly.Remove(temp);
            Display(weekly);

            Console.WriteLine("\nRemoveAt(0)");
            weekly.RemoveAt(0);
            Display(weekly);

            static void Display(SimpleOrder order)
            {
                Console.WriteLine();
                foreach (OrderItem item in order)
                    Console.WriteLine(item);
            }
        }
    }// One value with embedded key
    class Lists
    {
        // Simple business object. A PartId is used to identify the type of part
        // but the part name can change.
        public class Part : IEquatable<Part>
        {
            public string PartName { get; set; }

            public int PartId { get; set; }

            public override string ToString()
            {
                return "ID: " + PartId + "   Name: " + PartName;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) 
                    return false;
                Part objAsPart = obj as Part;
                if (objAsPart == null) 
                    return false;
                else 
                    return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return PartId;
            }
            public bool Equals(Part other)
            {
                if (other == null) 
                    return false;
                return (this.PartId.Equals(other.PartId));
            }
            // Should also override == and != operators.
        }
        public void Start()
        {
            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
                Console.WriteLine(aPart);

            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine($"\nContains(\"1734\"): {parts.Contains(new Part { PartId = 1734, PartName = "" })}");

            // Insert a new item at position 2.
            Console.WriteLine("\nInsert(2, \"1834\")");
            parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });

            //Console.WriteLine();
            foreach (Part aPart in parts)
                Console.WriteLine(aPart);

            Console.WriteLine($"\nParts[3]: {parts[3]}");

            Console.WriteLine("\nRemove(\"1534\")");
            parts.Remove(new Part() { PartId = 1534, PartName = "cogs" });

            Console.WriteLine();

            foreach (Part aPart in parts)
                Console.WriteLine(aPart);

            Console.WriteLine("\nRemoveAt(3)");
            // This will remove the part at index 3.
            parts.RemoveAt(3);

            Console.WriteLine();
            foreach (Part aPart in parts)
                Console.WriteLine(aPart);
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
    class LinkedLists
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                                           AVERAGE                         |                Worst                           |
        //                   Access                     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //LinkedList<T>      O(n)                       O(n)       O(1)             O(1)       |  O(n)       O(n)       O(1)       O(1)         |    O(n)
        //                   O(1)-to a node                        AddLast  O(1)               |                                                |
        //                        itself or its adjacencies        AddAfter O(1)               |                                                |
        //                                                                                     |                                                |

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
    }//is faster than Hashtable for small collections (10 items or fewer)
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
            Console.WriteLine($"Index 1 contains the value {myCol[1]}.");
            Console.WriteLine($"Key \"red\" has the value {myCol["red"]}.");
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
                Console.WriteLine($"   {s,-10} {myCol[s]}");
            Console.WriteLine();
        }
        public static void PrintKeysAndValues2(NameValueCollection myCol)
        {
            Console.WriteLine("   [INDEX] KEY        VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   [{i}]     {myCol.GetKey(i),-10} { myCol.Get(i)}");
            Console.WriteLine();
        }
    }// One key and multiple values
    class OrderedDictionarys
    {
        public void Start()
        {
            // Creates and initializes a OrderedDictionary.
            OrderedDictionary myOrderedDictionary = new OrderedDictionary();
            myOrderedDictionary.Add("testKey1", "testValue1");
            myOrderedDictionary.Add("testKey2", "testValue2");
            myOrderedDictionary.Add("keyToDelete", "valueToDelete");
            myOrderedDictionary.Add("testKey3", "testValue3");

            ICollection keyCollection = myOrderedDictionary.Keys;
            ICollection valueCollection = myOrderedDictionary.Values;

            // Display the contents using the key and value collections
            DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);

            // Modifying the OrderedDictionary
            if (!myOrderedDictionary.IsReadOnly)
            {
                // Insert a new key to the beginning of the OrderedDictionary
                myOrderedDictionary.Insert(0, "insertedKey1", "insertedValue1");

                // Modify the value of the entry with the key "testKey2"
                myOrderedDictionary["testKey2"] = "modifiedValue";

                // Remove the last entry from the OrderedDictionary: "testKey3"
                myOrderedDictionary.RemoveAt(myOrderedDictionary.Count - 1);

                // Remove the "keyToDelete" entry, if it exists
                if (myOrderedDictionary.Contains("keyToDelete"))
                    myOrderedDictionary.Remove("keyToDelete");
            }

            Console.WriteLine($"{Environment.NewLine} Displaying the entries of a modified OrderedDictionary.");
            DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);

            // Clear the OrderedDictionary and add new values
            myOrderedDictionary.Clear();
            myOrderedDictionary.Add("newKey1", "newValue1");
            myOrderedDictionary.Add("newKey2", "newValue2");
            myOrderedDictionary.Add("newKey3", "newValue3");

            // Display the contents of the "new" Dictionary using an enumerator
            IDictionaryEnumerator myEnumerator = myOrderedDictionary.GetEnumerator();
            Console.WriteLine($"{Environment.NewLine} Displaying the entries of a \"new\" OrderedDictionary.");
            DisplayEnumerator(myEnumerator);

            Console.ReadLine();
        }

        // Displays the contents of the OrderedDictionary from its keys and values
        public void DisplayContents(
            ICollection keyCollection, ICollection valueCollection, int dictionarySize)
        {
            String[] myKeys = new String[dictionarySize];
            String[] myValues = new String[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            // Displays the contents of the OrderedDictionary
            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < dictionarySize; i++)
            {
                Console.WriteLine($"   {i,-5} {myKeys[i],-25} {myValues[i]}");
            }
            Console.WriteLine();
        }

        // Displays the contents of the OrderedDictionary using its enumerator
        public void DisplayEnumerator(IDictionaryEnumerator myEnumerator)
        {
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
                Console.WriteLine($"   {myEnumerator.Key,-25} {myEnumerator.Value}");
        }
    }//fast
    class ParallelCollection
    {
        BlockingCollection<char> bc;
        public void Producer()
        {
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                bc.Add(ch);
                Console.WriteLine("Producing " + ch);
            }
        }

        public void Consumer()
        {
            for (int i = 0; i < 26; i++)
                Console.WriteLine("Consuming " + bc.Take());
        }

        public void Start()
        {
            bc = new BlockingCollection<char>(11);
            Parallel.Invoke(Producer, Consumer);
            bc.Dispose();
        }
    }
    class Queues
    {
        //                                                             Time Complexities                                        |   Space Complexities
        //Collection                      AVERAGE                              |                Worst                           |
        //                   Access     Search     Insert           Deletion   |  Access     Search     Insert     Deletion     |
        //Queue<T>           O(n)       O(n)       O(1)             O(1)       |  O(n)       O(n)       O(1)       O(1)         |           O(n)
        //                   O(1)-to the object at the top
        //  // Mutable 	        Amortized 	Worst Case 	  Immutable 	                Complexity
        // Queue<T>.Enqueue 	O(1) 	    O(n) 	      ImmutableQueue<T>.Enqueue 	O(1)
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

        public void SamplesQueue()
        {
            Queue myQ = new Queue();
            myQ.Enqueue("Hello");
            myQ.Enqueue("World");
            myQ.Enqueue("!");

            // Displays the properties and values of the Queue.
            Console.WriteLine("myQ");
            Console.WriteLine("\tCount:    {0}", myQ.Count);
            Console.Write("\tValues:");
            PrintValues(myQ);
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
            Console.WriteLine();
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
    class Stacks
    {
        //                                                         Time Complexities                                         |   Space Complexities
        //Collection                      AVERAGE                           |                Worst                           |
        //                   Access     Search     Insert        Deletion   |  Access     Search     Insert     Deletion     |
        //Stacks<T>          O(n)       O(n)       O(1)          O(1)       |  O(n)       O(n)       O(1)       O(1)         |           O(n)
        //                   O(1)-to the object at the top
        // Mutable 	        Amortized 	Worst Case 	  Immutable 	            Complexity
        // Stack<T>.Push 	O(1) 	    O(n) 	      ImmutableStack<T>.Push 	O(1)
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

        public void SamplesStack()
        {
            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
            Console.WriteLine();
        }
    }
    class SortedDictionarys
    {
        // Represents a collection of key/value pairs that are sorted on the key.

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
    }// SortedList(TKey, TValue) uses less memory than SortedDictionary(TKey, TValue), SortedList(TKey, TValue) uses less memory than SortedDictionary(TKey, TValue)
    class SortedSets
    {
        //                                                                  Time Complexities                                                    |   Space Complexities
        //Collection                      AVERAGE                                  |                Worst                                        |
        //                   Access     Search     Insert     Deletion     Add     |  Access     Search     Insert     Deletion     Add          |
        //HashSet<T>         O(n)       O(n)       O(1)       O(1)         O(1)    |  O(n)       O(n)       O(1)       O(1)         O(n)         |        O(n)
        //
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
    class SortedLists
    {
        //                                                                  Time Complexities                                                                                                                 |   Space Complexities
        //Collection                                                              AVERAGE                                                       |                Worst                                        |
        //                   Access                     Search     Insert               Deletion            Add                                 |  Access     Search     Insert     Deletion     Add          |
        //SortedList<T>      O(1) access by index       O(log n)   O(n)                 O(n)                O(n)       O(n) unsorted data       |                                                             |        
        //                   O(log n) access by key                O(log n) at the end  O(log n)at the end
        //                   O(log n) if the key is 
        //                            in the list 
        //                   O(log n) read/write
        //                   O(n) if the key is 
        //                       not in the list  
        //
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
        public void StratGeneric()
        {
            // Create a new sorted list of strings, with string
            // keys.
            SortedList<string, string> openWith = new SortedList<string, string>();

            // Add some elements to the list. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is
            // already in the list.
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
            // not in the list.
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
            // be in the list, TryGetValue can be a more efficient
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

            // When you use foreach to enumerate list elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            IList<string> ilistValues = openWith.Values;

            // The elements of the list are strongly typed with the
            // type that was specified for the SorteList values.
            Console.WriteLine();
            foreach (string s in ilistValues)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // The Values property is an efficient way to retrieve
            // values by index.
            Console.WriteLine("\nIndexed retrieval using the Values " +
                "property: Values[2] = {0}", openWith.Values[2]);

            // To get the keys alone, use the Keys property.
            IList<string> ilistKeys = openWith.Keys;

            // The elements of the list are strongly typed with the
            // type that was specified for the SortedList keys.
            Console.WriteLine();
            foreach (string s in ilistKeys)
            {
                Console.WriteLine($"Key = {s}");
            }

            // The Keys property is an efficient way to retrieve
            // keys by index.
            Console.WriteLine("\nIndexed retrieval using the Keys " +
                $"property: Keys[2] = {openWith.Keys[2]}" );

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }// sort their elements by the key, consumes less memory,If the list is populated all at once from sorted data, SortedList(TKey, TValue) is faster than SortedDictionary(TKey, TValue).
    class StringCollections
    {
        // Elements in this collection can be accessed using an integer index.
        // Indexes in this collection are zero-based.
        public void Start()
        {
            // Create and initializes a new StringCollection.
            StringCollection myCol = new StringCollection();

            // Add a range of elements from an array to the end of the StringCollection.
            String[] myArr = new String[] { "RED", "orange", "yellow", "RED", "green",
                "blue", "RED", "indigo", "violet", "RED" };
            myCol.AddRange(myArr);

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintValues1(myCol);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IEnumerator:");
            PrintValues2(myCol);

            // Display the contents of the collection using the Count and Item properties.
            Console.WriteLine("Displays the elements using the Count and Item properties:");
            PrintValues3(myCol);

            // Add one element to the end of the StringCollection and insert another at index 3.
            myCol.Add("* white");
            myCol.Insert(3, "* gray");

            Console.WriteLine("After adding \"* white\" to the end and inserting \"* gray\" at index 3:");
            PrintValues1(myCol);

            // Remove one element from the StringCollection.
            myCol.Remove("yellow");

            Console.WriteLine("After removing \"yellow\":");
            PrintValues1(myCol);

            // Remove all occurrences of a value from the StringCollection.
            int i = myCol.IndexOf("RED");
            while (i > -1)
            {
                myCol.RemoveAt(i);
                i = myCol.IndexOf("RED");
            }

            // Verify that all occurrences of "RED" are gone.
            if (myCol.Contains("RED"))
                Console.WriteLine("*** The collection still contains \"RED\".");

            Console.WriteLine("After removing all occurrences of \"RED\":");
            PrintValues1(myCol);

            // Copy the collection to a new array starting at index 0.
            String[] myArr2 = new String[myCol.Count];
            myCol.CopyTo(myArr2, 0);

            Console.WriteLine("The new array contains:");
            for (i = 0; i < myArr2.Length; i++)
                Console.WriteLine($"   [{i}] {myArr2[i]}" );
            Console.WriteLine();

            // Clears the entire collection.
            myCol.Clear();

            Console.WriteLine("After clearing the collection:");
            PrintValues1(myCol);
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintValues1(StringCollection myCol)
        {
            foreach (Object obj in myCol)
                Console.WriteLine($"   {obj}" );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintValues2(StringCollection myCol)
        {
            StringEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine($"   {myEnumerator.Current}" );
            Console.WriteLine();
        }

        // Uses the Count and Item properties.
        public void PrintValues3(StringCollection myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   {myCol[i]}" );
            Console.WriteLine();
        }
    }
    class StringDictionarys
    {
        //A key cannot be null, but a value can.
        public void Start()
        {
            // Creates and initializes a new StringDictionary.
            StringDictionary myCol = new StringDictionary();
            myCol.Add("red", "rojo");
            myCol.Add("green", "verde");
            myCol.Add("blue", "azul");

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintKeysAndValues1(myCol);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IEnumerator:");
            PrintKeysAndValues2(myCol);

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
            PrintKeysAndValues3(myCol);

            // Copies the StringDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo(myArr, 0);

            // Displays the values in the array.
            Console.WriteLine("Displays the elements in the array:");
            Console.WriteLine("   KEY        VALUE");
            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine($"   {myArr[i].Key,-10} {myArr[i].Value}" );
            Console.WriteLine();

            // Searches for a key and deletes it.
            if (myCol.ContainsKey("green"))
                myCol.Remove("green");
            Console.WriteLine("The collection contains the following elements after removing \"green\":");
            PrintKeysAndValues1(myCol);

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues1(myCol);
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintKeysAndValues1(StringDictionary myCol)
        {
            Console.WriteLine("   KEY                       VALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine($"   {de.Key,-25} {de.Value}" );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public void PrintKeysAndValues2(StringDictionary myCol)
        {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            DictionaryEntry de;
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
            {
                de = (DictionaryEntry)myEnumerator.Current;
                Console.WriteLine($"   {de.Key,-25} {de.Value}" );
            }
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public void PrintKeysAndValues3(StringDictionary myCol)
        {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo(myKeys, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine($"   {i,-5} {myKeys[i],-25} {myCol[myKeys[i]]}" );
            Console.WriteLine();
        }
    }// sort their elements by the key, offers better performance 

    ////class Dictionarys2
    //{
    //    public void Start()
    //    {
    //        // Create a new dictionary of strings, with string keys.
    //        //
    //        Dictionary<string, string> openWith = new Dictionary<string, string>();

    //        // Add some elements to the dictionary. There are no
    //        // duplicate keys, but some of the values are duplicates.
    //        openWith.Add("txt", "notepad.exe");
    //        openWith.Add("bmp", "paint.exe");
    //        openWith.Add("dib", "paint.exe");
    //        openWith.Add("rtf", "wordpad.exe");

    //        // The Add method throws an exception if the new key is
    //        // already in the dictionary.
    //        try
    //        {
    //            openWith.Add("txt", "winword.exe");
    //        }
    //        catch (ArgumentException)
    //        {
    //            Console.WriteLine("An element with Key = \"txt\" already exists.");
    //        }

    //        // The Item property is another name for the indexer, so you
    //        // can omit its name when accessing elements.
    //        Console.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

    //        // The indexer can be used to change the value associated
    //        // with a key.
    //        openWith["rtf"] = "winword.exe";
    //        Console.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

    //        // If a key does not exist, setting the indexer for that key
    //        // adds a new key/value pair.
    //        openWith["doc"] = "winword.exe";

    //        // The indexer throws an exception if the requested key is
    //        // not in the dictionary.
    //        try
    //        {
    //            Console.WriteLine("For key = \"tif\", value = {0}.",
    //                openWith["tif"]);
    //        }
    //        catch (KeyNotFoundException)
    //        {
    //            Console.WriteLine("Key = \"tif\" is not found.");
    //        }

    //        // When a program often has to try keys that turn out not to
    //        // be in the dictionary, TryGetValue can be a more efficient
    //        // way to retrieve values.
    //        string value = "";
    //        if (openWith.TryGetValue("tif", out value))
    //        {
    //            Console.WriteLine("For key = \"tif\", value = {0}.", value);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Key = \"tif\" is not found.");
    //        }

    //        // ContainsKey can be used to test keys before inserting
    //        // them.
    //        if (!openWith.ContainsKey("ht"))
    //        {
    //            openWith.Add("ht", "hypertrm.exe");
    //            Console.WriteLine($"Value added for key = \"ht\": {openWith["ht"]}");
    //        }

    //        // When you use foreach to enumerate dictionary elements,
    //        // the elements are retrieved as KeyValuePair objects.
    //        Console.WriteLine();
    //        foreach (KeyValuePair<string, string> kvp in openWith)
    //            Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");

    //        // To get the values alone, use the Values property.
    //        Dictionary<string, string>.ValueCollection valueColl = openWith.Values;

    //        // The elements of the ValueCollection are strongly typed
    //        // with the type that was specified for dictionary values.
    //        Console.WriteLine();
    //        foreach (string s in valueColl)
    //            Console.WriteLine($"Value = {s}");

    //        // To get the keys alone, use the Keys property.
    //        Dictionary<string, string>.KeyCollection keyColl = openWith.Keys;

    //        // The elements of the KeyCollection are strongly typed
    //        // with the type that was specified for dictionary keys.
    //        Console.WriteLine();
    //        foreach (string s in keyColl)
    //            Console.WriteLine($"Key = {s}");

    //        // Use the Remove method to remove a key/value pair.
    //        Console.WriteLine("\nRemove(\"doc\")");
    //        openWith.Remove("doc");

    //        if (!openWith.ContainsKey("doc"))
    //            Console.WriteLine("Key \"doc\" is not found.");
    //    }
    //}
    class SearchAlgorithms
    {
        public  int BinarySearch(int[] list, int key)
        {
            int min = 0;
            int max = list.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == list[mid])
                {
                    return ++mid;
                }
                else if (key < list[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        public  int LinearSearch(int[] list, int data)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (data == list[i]) return i;
            }

            return -1;
        }
        public  int InterpolationSearch(int[] list, int data)
        {
            int lo = 0;
            int mid = -1;
            int hi = list.Length - 1;
            int index = -1;

            while (lo <= hi)
            {
                mid = (int)(lo + (((double)(hi - lo) / (list[hi] - list[lo])) * (data - list[lo])));

                if (list[mid] == data)
                {
                    index = mid;
                    break;
                }
                else
                {
                    if (list[mid] < data)
                        lo = mid + 1;
                    else
                        hi = mid - 1;
                }
            }

            return index;
        }
        public  int JumpSearch(int[] arr, int x)
        {
            int n = arr.Length;

            // Finding block size to be jumped 
            int step = (int)Math.Floor(Math.Sqrt(n));

            // Finding the block where element is 
            // present (if it is present) 
            int prev = 0;
            while (arr[Math.Min(step, n) - 1] < x)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            // Doing a linear search for x in block 
            // beginning with prev. 
            while (arr[prev] < x)
            {
                prev++;

                // If we reached next block or end of 
                // array, element is not present. 
                if (prev == Math.Min(step, n))
                    return -1;
            }

            // If element is found 
            if (arr[prev] == x)
                return prev;

            return -1;
        }
        ////public int ExponentialSearch(int[] arr, int index)
        //{
        //    int arrLength = arr.Length;

        //    // If x is present at  
        //    // first location itself 
        //    if (arr[0] == index)
        //        return 0;

        //    // Find range for binary search  
        //    // by repeated doubling 
        //    int i = 1;
        //    while (i < arrLength && arr[i] <= index)
        //        i = i * 2;

        //    return BinarySearch();
        //}
    }
    class SortAlgorithms
    {
        public int[] BubbleSort(int[] inputArray)
        {
            int index;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int write = 0; write < inputArray.Length; write++)
            {
                for (int sort = 0; sort < inputArray.Length - 1; sort++)
                {
                    if (inputArray[sort] > inputArray[sort + 1])
                    {
                        index = inputArray[sort + 1];
                        inputArray[sort + 1] = inputArray[sort];
                        inputArray[sort] = index;
                    }
                }
            }
            
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] InsertionSort(int[] inputArray)
        {
            int index = 0, size = inputArray.Length;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < size; i++)
            {
                int val = inputArray[i];
                for (int j = i - 1; j >= 0 && index != 1;)
                {
                    if (val < inputArray[j])
                    {
                        inputArray[j + 1] = inputArray[j];
                        j--;
                        inputArray[j + 1] = val;
                    }
                    else index = 1;
                }
            }
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] InsertionSort2(int[] inputArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int n = inputArray.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = inputArray[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && inputArray[j] > key)
                {
                    inputArray[j + 1] = inputArray[j];
                    j = j - 1;
                }
                inputArray[j + 1] = key;
            }
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] SelectionSort(int[] inputArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int length = inputArray.Length;
            for (int i = 0; i < length - 1; ++i)
            {
                int smallest = i;
                for (int j = i + 1; j < length; j++)
                    if (inputArray[j] < inputArray[smallest])
                        smallest = j;

                int temp = inputArray[smallest];
                inputArray[smallest] = inputArray[i];
                inputArray[i] = temp;
            }
            for (int i = 0; i < length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] MergeSort(int[] inputArray)
        {
            int[] left;
            int[] right;
            int[] result = new int[inputArray.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (inputArray.Length <= 1)
                return inputArray;
            // The exact midpoint of our array  
            int midPoint = inputArray.Length / 2;
            //Will represent our 'left' array
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (inputArray.Length % 2 == 0)
                right = new int[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = inputArray[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to  midpont
            for (int i = midPoint; i < inputArray.Length; i++)
            {
                right[x] = inputArray[i];
                x++;
            }
            //Recursively sort the left array
            left = MergeSort(left);
            //Recursively sort the right array
            right = MergeSort(right);
            //Merge our two sorted arrays
            result = Merge(left, right);
            return result;

            //This method will be responsible for combining our two sorted arrays into one giant array
            int[] Merge(int[] left, int[] right)
            {
                int resultLength = right.Length + left.Length;
                int[] result = new int[resultLength];
                //
                int indexLeft = 0, indexRight = 0, indexResult = 0;
                //while either array still has an element
                while (indexLeft < left.Length || indexRight < right.Length)
                {
                    //if both arrays have elements  
                    if (indexLeft < left.Length && indexRight < right.Length)
                    {
                        //If item on left array is less than item on right array, add that item to the result array 
                        if (left[indexLeft] <= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        // else the item in the right array wll be added to the results array
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                    //if only the left array still has elements, add all its items to the results array
                    else if (indexLeft < left.Length)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    //if only the right array still has elements, add all its items to the results array
                    else if (indexRight < right.Length)
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
               
                return result;
            }
            
        }    
        //With worst-case time complexity being Ο(n log n), it is one of the most respected algorithms.
        public int[] ShellSort(int[] inputArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int n = inputArray.Length;

            // Start with a big gap, then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have been gap 
                    // sorted save a[i] in temp and make a hole at 
                    // position i 
                    int temp = inputArray[i];

                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && inputArray[j - gap] > temp; j -= gap)
                        inputArray[j] = inputArray[j - gap];

                    // put temp (the original a[i]) in its correct 
                    // location 
                    inputArray[j] = temp;
                }
            }
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] QuickSort(int[] inputArray)
        {
            /* The main function that implements QuickSort() 
            arr[] --> Array to be sorted, 
            low --> Starting index, 
            high --> Ending index */
            Stopwatch stopwatch = Stopwatch.StartNew();
            void sort(int[] inputArray, int low, int high)
            {
                //int low = 0, high = inputArray.Length - 1;
                if (low < high)
                {

                    /* pi is partitioning index, arr[pi] is  
                    now at right place */
                    int pi = partition(inputArray, low, high);

                    // Recursively sort elements before 
                    // partition and after partition 
                    sort(inputArray, low, pi - 1);
                    sort(inputArray, pi + 1, high);
                }
            }
            
            /* This function takes last element as pivot, 
            places the pivot element at its correct 
            position in sorted array, and places all 
            smaller (smaller than pivot) to left of 
            pivot and all greater elements to right 
            of pivot */
            int partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];

                // index of smaller element 
                int i = (low - 1);
                for (int j = low; j < high; j++)
                {
                    // If current element is smaller  
                    // than the pivot 
                    if (arr[j] < pivot)
                    {
                        i++;
                        // swap arr[i] and arr[j] 
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                // swap arr[i+1] and arr[high] (or pivot) 
                int temp1 = arr[i + 1];
                arr[i + 1] = arr[high];
                arr[high] = temp1;

                return i + 1;
            }
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return inputArray;
        }
        public int[] BucketSort(int[] inputArray)
        {
            int minValue = inputArray[0];
            int maxValue = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] > maxValue)
                    maxValue = inputArray[i];
                if (inputArray[i] < minValue)
                    minValue = inputArray[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                bucket[inputArray[i] - minValue].Add(inputArray[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        inputArray[k] = bucket[i][j];
                        k++;
                    }
                }
            }
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            return inputArray;
        }
        public int[] RadixSort(int[] inputArray)
        {
            int length = inputArray.Length;

            int m = GetMax(inputArray, length);

            // Do counting sort for every digit. Note that instead  
            // of passing digit number, exp is passed. exp is 10^i  
            // where i is current digit number  
            for (int exp = 1; m / exp > 0; exp *= 10)
                CountSort(inputArray, length, exp);

            int GetMax(int[] inputArray, int length)
            {
                int max = inputArray[0];
                for (int i = 1; i < length; i++)
                    if (inputArray[i] > max)
                        max = inputArray[i];
                return max;
            }

            // A function to do counting sort of arr[] according to  
            // the digit represented by exp.  
            void CountSort(int[] arr, int n, int exp)
            {
                int[] output = new int[n]; // output array  
                int i;
                int[] count = new int[10];

                //initializing all elements of count to 0 
                for (i = 0; i < 10; i++)
                    count[i] = 0;

                // Store count of occurrences in count[]  
                for (i = 0; i < n; i++)
                    count[(arr[i] / exp) % 10]++;

                // Change count[i] so that count[i] now contains actual  
                //  position of this digit in output[]  
                for (i = 1; i < 10; i++)
                    count[i] += count[i - 1];

                // Build the output array  
                for (i = n - 1; i >= 0; i--)
                {
                    output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                    count[(arr[i] / exp) % 10]--;
                }

                // Copy the output array to arr[], so that arr[] now  
                // contains sorted numbers according to current digit  
                for (i = 0; i < n; i++)
                    arr[i] = output[i];
            }

            for (int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
                return inputArray;
        }
        public int[] CountingSort(int[] inputArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] sortedArray = new int[inputArray.Length];

            // find smallest and largest value
            int minVal = inputArray[0];
            int maxVal = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < minVal) 
                    minVal = inputArray[i];
                else if (inputArray[i] > maxVal) 
                    maxVal = inputArray[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < inputArray.Length; i++)
                counts[inputArray[i] - minVal]++;

            // recalculate
            counts[0]--;

            for (int i = 1; i < counts.Length; i++)
                counts[i] = counts[i] + counts[i - 1];

            // Sort the array
            for (int i = inputArray.Length - 1; i >= 0; i--)
                sortedArray[counts[inputArray[i] - minVal]--] = inputArray[i];

            Console.WriteLine();
            foreach (int aa in sortedArray)
                Console.Write(aa + " ");
            Console.WriteLine(stopwatch.Elapsed);
            return sortedArray;
        }

    }

    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            
        }
    }
}
