using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__19376_lab4
{
    internal class FibonacciHeap
    {
        public int N;

        public Node min;

        static public FibonacciHeap MAKE_FIB_HEAP()
        {
            return new FibonacciHeap { min = null, N = 0 };
        }
        static public void FIB_HEAP_INSERT(FibonacciHeap H,Node x)
        {
            
            if (H.min != null)
            {
                x.left = H.min.left;
                x.right = H.min;
                H.min.left.right = x;
                H.min.left = x;

                if (x.n < H.min.n)
                {
                    H.min = x;
                }
            }
            else
            {
                H.min = x;
            }
            H.N++;
        }
        static public FibonacciHeap FIB_HEAP_UNION(FibonacciHeap H1,FibonacciHeap H2)
        {
            if (H1 == null)
            {
                return H2;
            }
            if (H2 == null)
            {
                return H1;
            }
            FibonacciHeap H = MAKE_FIB_HEAP();
            H.min = H1.min;
            if (H1.min != null && H2.min != null)
            {
                Node H1Right = H1.min.right;
                Node H2Left = H2.min.left;

                H1.min.right = H2.min;
                H2.min.left = H1.min;

                H1Right.left = H2Left;
                H2Left.right = H1Right;
                if (H2.min.n < H1.min.n)
                {
                    H.min = H2.min;
                }
            }
                H.N = H1.N + H2.N;
            return H;
        }

        static void FIB_HEAP_LINK(FibonacciHeap H, Node y, Node x)
        {
            y.left.right = y.right;
            y.right.left = y.left;

            y.parent = x;
            if (x.child == null)
            {
                x.child = y;
                y.left = y;
                y.right = y;
            }
            else
            {
                y.left = x.child.left;
                y.right = x.child;
                x.child.left.right = y;
                x.child.left = y;
            }

            x.degree++;
            y.mark = false;
        }

        static public void CONSOLIDATE(FibonacciHeap H)
        {

            int D = (int)Math.Floor(Math.Log(H.N) / Math.Log(2)) + 1;
            Node[] A = new Node[D];

            for (int i = 0; i < D; i++)
            {
                A[i] = null;
            }


            Node w = H.min;

            if (w != null)
            {
                do
                {
                    Node x = w;
                    int d = x.degree;
                    while (A[d] != null)
                    {
                        Node y = A[d];
                        if (x.n > y.n)
                        {
                            Node tmp = x;
                            x = y;
                            y = tmp;
                        }
                        FIB_HEAP_LINK(H, y, x);
                        A[d] = null;
                        d++;
                    }
                    
                    A[d] = x;
                    w = w.right;
                } while (w != H.min);
        }

            H.min = null;
            for (int i=0;i<D;i++)
            {
                if (A[i] != null)
                {
                    if (H.min == null)
                    {
                        H.min = A[i];
                        A[i].left = A[i];
                        A[i].right = A[i];
                    }
                    else
                    {
                        A[i].left = H.min.left;
                        A[i].right = H.min;
                        H.min.left.right = A[i];
                        H.min.left = A[i];
                        if (A[i].n < H.min.n)
                            H.min = A[i];
                    }
                }
            }

        }
        public static Node FIB_HEAP_EXTRACT_MIN(FibonacciHeap H)
        {
            Node z = H.min;
            if (z != null)
            {
                if(z.child != null)
                {
                    Node x = z.child;
                    do
                    {
                        Node next = x.right;

                        x.left.right = x.right;
                        x.right.left = x.left;

                        x.left = H.min.left;
                        x.right = H.min;
                        H.min.left.right = x;
                        H.min.left = x;

                        x.parent = null;
                        x = next;
                    }while(x != z.child);
                }

                    z.left.right = z.right;
                    z.right.left = z.left;

                if(z == z.right)
                {
                    H.min = null;
                }
                else
                {
                    H.min = z.right;
                    //CONSOLIDATE(H);
                }
                H.N--;
            }
            return z;
        }

       

    }
}
