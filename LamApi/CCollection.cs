using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

namespace LamApi
{
    /// <summary>
    /// Class to perform various data collection examples
    /// </summary>
    public class CCollection
    {

        public void DoArray()
        {
            Console.WriteLine("DoArray");
            int[] myArray = new int[3];
            myArray[0] = 1;
            myArray[1] = 2;
            myArray[2] = 3;
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i].ToString());
            }
        } // end DoArray


        public void DoArrayList()
        {
            Console.WriteLine("DoArrayList");
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add("A");
            myArrayList.Add(1);
            myArrayList.Add(true);
            foreach (var element in myArrayList)
            {
                Console.WriteLine(element);
            }
        } // end DoArrayList


        enum MyColor
        {
            red,    // 0
            blue,   // 1
            green,  // 2
        };
        public void DoEnum()
        {
            MyColor r = MyColor.red;
            if (r == MyColor.red)
            {
                Console.WriteLine("color is red");
            }
            else
            {
                Console.WriteLine("color is not red");
            }
        } // end DoEnum


        public void DoList()
        {
            Console.WriteLine("DoList");
            List<int> myList = new List<int>();
            myList.Add(11);
            myList.Add(22);
            myList.Add(33);
            foreach (int element in myList)
            {
                Console.WriteLine(element.ToString());
            }
        } // end DoList


        public void DoLinkedList()
        {
            Console.WriteLine("DoLinkedList");
            LinkedList<string> myLinkedList = new LinkedList<string>();
            myLinkedList.AddLast("A");
            myLinkedList.AddLast("B");
            myLinkedList.AddLast("C");
            foreach (var element in myLinkedList)
            {
                Console.WriteLine(element.ToString());
            }
        }  // end DoLinkedList


        public void DoStack()
        {
            Console.WriteLine("DoStack");
            Stack<int> myStack = new Stack<int>();
            myStack.Push(11);
            myStack.Push(22);
            myStack.Push(33);
            foreach (int element in myStack)
            {
                Console.WriteLine(element.ToString());
            }
        } // end DoStack


        public void DoQueue()
        {
            Console.WriteLine("DoQueue");
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(11);
            myQueue.Enqueue(22);
            myQueue.Enqueue(33);
            foreach (int element in myQueue)
            {
                Console.WriteLine(element.ToString());
            }
        } // end DoQueue


        public void DoDictionary()
        {
            Console.WriteLine("DoDictionary");
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict.Add(1, "A");
            myDict.Add(2, "B");
            myDict.Add(3, "C");
            foreach (KeyValuePair<int, string> kvp in myDict)
            {
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
            }
        } // end DoDictionary


        public void DoHashTable()
        {
            Console.WriteLine("DoHashTable");
            Hashtable myHashTable = new Hashtable();
            myHashTable.Add(1, "A");
            myHashTable.Add(2, "B");
            myHashTable.Add(3, "C");
            foreach (KeyValuePair<int, string> kvp in myHashTable)
            {
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
            }
            foreach (int key in myHashTable.Keys)
            {
                Console.WriteLine(key);
            }
            foreach (string value in myHashTable.Values)
            {
                Console.WriteLine(value);
            }
        } // end DoHashTable


        public void DoRandom()
        {
            int seed = System.DateTime.Now.Second;
            Random randGen = new Random(seed);

            int randomNumber = randGen.Next(1, 7);

            Console.WriteLine("Random number of 1 to 6 is " + randomNumber.ToString());

        }
    } // end class CCollection
}
