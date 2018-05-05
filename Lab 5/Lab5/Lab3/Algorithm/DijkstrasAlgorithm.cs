using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab3.Algorithm
{
    public class DijkstrasAlgorithm
    {
        public List<Node> Nodes;
        public Node NextNodeToCalculate;

        public DijkstrasAlgorithm(List<Node> nodes)
        {
            Nodes = nodes;

            // take first node
            if (Nodes.Count != 0)
            {
                NextNodeToCalculate = Nodes.First();
                NextNodeToCalculate.GeneralPath = 0;
            }
        }

        public bool MakeStep()
        {
            if (NextNodeToCalculate is null) // end
                return true;

            // calculate node
            NextNodeToCalculate.Calculate();

            // find next
            NextNodeToCalculate = FindNextNodeToCalculate();

            if (NextNodeToCalculate is null) // end
                return true;

            return false;
        }

        public Node FindNextNodeToCalculate()
        {
            //Node nextNodeToCalculate = null;

            //// search between relative nodes
            //if (NextNodeToCalculate.NextNodes.Count != 0)
            //{
            //    // all nodes, which wasn't calculated before
            //    var nodes = NextNodeToCalculate.NextNodes.Select(nextNode => nextNode.Node).Where(node => node.IsOut == false).ToList();

            //    // node with min path
            //    if (nodes.Count() != 0)
            //        nextNodeToCalculate = nodes.Aggregate((minNode, currentNode) => currentNode.GeneralPath < minNode.GeneralPath ? currentNode : minNode);
            //}

            //if (nextNodeToCalculate != null && nextNodeToCalculate != Nodes.Last())
            //    return nextNodeToCalculate;

            // search between all nodes without last
            var nextNodesToCalculate = Nodes.FindAll(node => node.IsOut == false);

            if (nextNodesToCalculate.Count != 0)
                return nextNodesToCalculate.Aggregate((minNode, currentNode) => currentNode.GeneralPath < minNode.GeneralPath ? currentNode : minNode);

            // all nodes were calculated
            return null;
        }
    }
}