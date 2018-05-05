using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class GraphNode
    {
        public List<Node> nodes { get; set; }

        public GraphNode(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public GraphNode Clone()
        {
            List<Node> allDots = new List<Node>();
            foreach (Node dotset in nodes)
            {
                allDots.Add(dotset.Clone());
            }

            return new GraphNode(allDots);
        }
    }
}
