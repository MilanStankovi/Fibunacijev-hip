using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__19376_lab4
{
    internal class Program
    {
        public static FibonacciHeap RandGenHeap(int n, int k, int a, int b)
        {
            FibonacciHeap H = FibonacciHeap.MAKE_FIB_HEAP();
            Random random = new Random();

            for(int i=1;i<= n; i++)
            {
                int value = random.Next(a,b);
                FibonacciHeap.FIB_HEAP_INSERT(H,new Node(value));

                if((i % k) == 0)
                {
                    FibonacciHeap.FIB_HEAP_EXTRACT_MIN(H);
                }
            }
            return H;
        }

        public static void PrintHeap(FibonacciHeap H)
        {
            if (H.min == null)
            {
                Console.WriteLine("Heap is empty.");
                return;
            }

            Node start = H.min;
            Console.WriteLine("Heap elements:");
            do
            {
                Console.Write(start.n + " ");
                start = start.right;
            } while (start != H.min);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int a, b, n, k;
            /*Console.WriteLine("Uneti 2 broja koja prestavljaju opseg brojeva");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Uneti N");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Uneti k");
            k = Convert.ToInt32(Console.ReadLine());*/
            a = 5;
            b = 1000;
            n = 10;
            k = 5;

            FibonacciHeap H1 = RandGenHeap(n, k, a, b);
            Console.WriteLine("Heap 1:");
            PrintHeap(H1);
            FibonacciHeap H2 = RandGenHeap(n, k, a, b);
            Console.WriteLine("Heap 2:");
            PrintHeap(H2);
            FibonacciHeap H3 = RandGenHeap(n, k, a, b);
            Console.WriteLine("Heap 3:");
            PrintHeap(H3);
            FibonacciHeap H4 = RandGenHeap(n, k, a, b);
            Console.WriteLine("Heap 4:");
            PrintHeap(H4);
            FibonacciHeap unia = FibonacciHeap.FIB_HEAP_UNION(H1, H2);
             unia = FibonacciHeap.FIB_HEAP_UNION(unia, H3);
             unia = FibonacciHeap.FIB_HEAP_UNION(unia, H4);
            Console.WriteLine("Union Heap:");
            PrintHeap(unia);
            List<int> sortList = new List<int>();
            Node min;
            while ((min = FibonacciHeap.FIB_HEAP_EXTRACT_MIN(unia)) != null)
            {
                sortList.Add(min.n);
            }

            sortList.Sort((x,y) => y.CompareTo(x));

            Console.WriteLine("Uređeni niz u opadajućem redosledu:");
            foreach (int num in sortList)
            {
                Console.WriteLine(num);
            }
        }
    }
}
