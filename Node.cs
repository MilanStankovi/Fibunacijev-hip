using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__19376_lab4
{
    internal class Node
    {
        public int n {get; set;}
        public int degree {get; set;}
        public Node parent {get; set;}

        public Node child {get; set;}

        public Node left {get; set;}

        public Node right {get; set;}

        public bool mark {get; set;}

        public Node(int value)
        {
            n = value;
            parent = null;
            child = null;
            left = this;
            right = this;
            mark = false;
            degree = 0;
        }
    }
}
