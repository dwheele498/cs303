using BTSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTC
{
    class RBNode : Node
    {
        public bool isRed;
        public new RBNode left, right;
        public new RBNode parent;

        public RBNode(long key) : base(key)
        {
            
        }

        public RBNode(long key, string data) : base(key,data)
        {
            
        }
    }
}
