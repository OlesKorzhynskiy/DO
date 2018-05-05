using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Algorithm
{
    public class Node
    {
        public bool IsOut = false;
        public double GeneralPath = double.MaxValue;
        public Node PreviousNode = null;
        public List<NextNode> NextNodes = new List<NextNode>();

        public void Calculate()
        {
            // check all relative nodes
            foreach (var nextNode in NextNodes)
            {
                if (nextNode.Node.GeneralPath > GeneralPath + nextNode.RelativePath)
                {
                    nextNode.Node.GeneralPath = GeneralPath + nextNode.RelativePath;
                    nextNode.Node.PreviousNode = this;
                }
            }
            IsOut = true;
        }
    }
}
