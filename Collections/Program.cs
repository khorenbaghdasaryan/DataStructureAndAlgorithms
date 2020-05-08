using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            new Dictionarys().Start();
        }
    }
}
