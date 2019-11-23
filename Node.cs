using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSC
{
    class Node
    {
        public long key;
        public string data;
        public Node left, right;
        public Node parent;

        public Node(long key)
        {
            this.key = key;
            this.data = key.ToString();
            this.left = null;
            this.right = null;
        }

        public Node(long key,string data)
        {
            this.key = key;
            this.data = data;
            this.right = null;
            this.left = null;
        }

    }
}
