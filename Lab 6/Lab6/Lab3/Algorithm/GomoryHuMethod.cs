using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab5
{
    public class GomoryHuMethod 
    {
        public List<Dot> source { get; set; }
        public GraphNode result { get; set; }
        public List<Step> steps { get; set; }
        private int size;

        public GomoryHuMethod(List<Dot> source)
        {
            this.source = source;
            this.steps = new List<Step>();
            size = source.Count;
        }
        public class Step
        {
            private GraphNode stepResult { get; set; }
            public Step(GraphNode step)
            {
                this.stepResult = step;
                this.stepResult.nodes.Sort();
            }
            private List<ArcNode> fullPath = new List<ArcNode>();
            public void Show(DataGridView cutMatrix)
            {
                int rowCount = stepResult.nodes.Count();
                int colCount = rowCount;

                cutMatrix.RowCount = rowCount;
                cutMatrix.ColumnCount = colCount;

                int i;
                for (i=0;i<rowCount;i++)
                {
                    cutMatrix.Rows[i].Cells[i].Value = 0;
                }
                i = 0;
                foreach (Node node in stepResult.nodes)
                {
                    cutMatrix.Rows[i].HeaderCell.Value = node.toString();
                    cutMatrix.Columns[i].HeaderCell.Value = node.toString();
                    i++;
                }
                for (i = 0; i < stepResult.nodes.Count; i++)
                {
                    for (int j = 0; j < stepResult.nodes.Count; j++)
                    {
                        if (j<=i) continue;
                        fullPath.Clear();
                        if(getPath(stepResult.nodes.ElementAt(i), stepResult.nodes.ElementAt(j)))
                        {
                            cutMatrix.Rows[i].Cells[j].Value = getMinWeight().ToString();
                            cutMatrix.Rows[j].Cells[i].Value = cutMatrix.Rows[i].Cells[j].Value;
                        }
                    }
                }
            }
            
            private bool getPath(Node start, Node end)
            {
                if (start == null) return false;
                Node current = start;
                foreach(ArcNode arc in start.Arcs)
                {
                    if (fullPath.Count == 0 || !arc.end.Equals(fullPath.Last().start))
                    {
                        fullPath.Add(arc);
                        if (arc.end.Equals(end.ID))
                        {
                            return true;
                        }
                        else
                        {
                            if(!getPath(stepResult.nodes.Find(n => n.ID == fullPath.Last().end), end))
                            {
                                fullPath.Remove(fullPath.Last());
                                continue;
                            }
                            else {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            private double getMinWeight()
            {
                double res = double.MaxValue;
                foreach(ArcNode arc in fullPath)
                {
                    if(arc.weight< res)
                    {
                        res = arc.weight;
                    }
                }
                return res;
            }
        }

        public List<Step> Calculate ()
        {
            List<Dot> d = new List<Dot>();
            foreach (Dot dot in source)
            {
                d.Add(dot);
            }

            result = new GraphNode(new List<Node>() { new Node(d,new List<ArcNode>())});// first all!!!
            SnapShot();

            while(!allFixed(result))
            {
                ArcDot currentArc = null;
                Node currentNode = null;
                foreach(Node set in result.nodes)
                {
                    if(!isNodeFixed(set))
                    {
                        currentNode = set;
                        //abstract arc
                        currentArc = new ArcDot(getMinDotNumber(currentNode),getMaxDotNumber(currentNode),0);
                    } 
                }
                //we got two dots and arc between them
                //now we are looking for minimum cut (it corresponds to the maximum flow)
                
                List<Dot> first = null; // X
                List<Dot> second = null; //!X
                List<Dot> temp = new List<Dot>();//get all except two dots (node) witch are belonged to maxArc
                foreach (Dot dot in source)
                {
                    if(dot.number != currentArc.start
                        && dot.number != currentArc.end)
                    {
                        temp.Add(dot);
                    }
                }
                int numberOfCoteges = (int)Math.Pow(2, temp.Count);
                double minCut = Double.MaxValue;

                for (int i = 0; i <= numberOfCoteges; i++)//search min cut
                {
                    List<Dot> temp1 = new List<Dot>() { source.Find(d1=>d1.number == currentArc.start) }; // X
                    List<Dot> temp2 = new List<Dot>() { source.Find(d1 => d1.number == currentArc.end) }; //!X
                    int ptr = 1;
                    foreach(Dot dot in temp)
                    {
                        if((i&ptr)!=0)
                        {
                            temp1.Add(dot);//to X
                        }
                        else
                        {
                            temp2.Add(dot);//to !X
                        }
                        ptr *= 2;
                    } 
                    double minCutTemp = getCut(temp1,temp2);
                    if(minCutTemp<minCut)
                    {
                        minCut = minCutTemp;
                        first = temp1;
                        second = temp2;
                    }
                }
                Node firstNode = new Node(first,new List<ArcNode>());
                Node secondNode = new Node(second, new List<ArcNode>());
                //replace current node by two new nodes
                var endDot = source.Find(d1 => d1.number == currentArc.end);
                if(endDot != null)
                    endDot.Fixed = true;
                var startDot = source.Find(d1 => d1.number == currentArc.start);
                if (startDot != null)
                    startDot.Fixed = true;
                
                Difference(firstNode, secondNode, currentNode);
                
                setRelationship(firstNode, secondNode, currentNode);
                result.nodes.Add(firstNode);
                result.nodes.Add(secondNode);
                firstNode.setRelation(secondNode, minCut);
                result.nodes.Remove(currentNode);
                SnapShot();
            }
            return steps;
        }

        private double getCut(List<Dot> one, List<Dot> two)
        {
            //one is X and two is !X
            double res = 0;
            Node first = new Node(one, new List<ArcNode>());
            Node second = new Node(two, new List<ArcNode>());
            first.setRelation(second);
            return first.Arcs.Last().weight;
        }

        private int getMinDotNumber(Node node)
        {
            int result = node.dotsSet.First().number;
            foreach(Dot dot in node.dotsSet)
            {
                if(dot.number<result && !dot.Fixed)// not fixed
                {
                    result = dot.number;
                }
            }
            return result;
        }

        private int getMaxDotNumber(Node node)
        {
            int result = node.dotsSet.First().number;
            foreach (Dot dot in node.dotsSet)
            {
                if (dot.number > result)//fixed or not
                {
                    result = dot.number;
                }
            }
            return result;
        }

        private bool allFixed(GraphNode graph)
        {
            foreach (Node set in graph.nodes)
            {
                if (!isNodeFixed(set)) return false;
            }
            return true;
        }

        private bool isNodeFixed(Node node)
        {
            foreach (Dot dot in node.dotsSet)
            {
                if (dot.Fixed == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void SnapShot()
        {
            steps.Add(new Step(result.Clone()));
        }

        private void Difference(Node one, Node two, Node container)
        {
            List<Dot> toRemove = new List<Dot>();
            foreach(Dot dot in one.dotsSet)
            {
                if(container.dotsSet.Find(d=>d.number == dot.number)==null)
                {
                    toRemove.Add(dot);
                }
            }
            one.dotsSet.RemoveAll(d=>toRemove.Contains(toRemove.Find(e=>e.number == d.number)));
            toRemove.Clear();
            foreach (Dot dot in two.dotsSet)
            {
                if (container.dotsSet.Find(d => d.number == dot.number) == null)
                {
                    toRemove.Add(dot);
                }
            }
            two.dotsSet.RemoveAll(d => toRemove.Contains(toRemove.Find(e => e.number == d.number)));
            one.GenerateID();
            two.GenerateID();
        }

        private void setRelationship(Node one, Node two, Node container)
        {
            one.GenerateID();
            two.GenerateID();

            foreach(Node node in result.nodes)
            {
                var arc = node.Arcs.Find(a => a.end.Equals(container.ID));
                if(arc!=null)
                {
                    if(biggerRelation(one,two,node))//tide with first
                    {
                        //arc.end = one;
                        ArcNode arc1 = new ArcNode(node.ID, one.ID, arc.weight);
                        node.Arcs.Add(arc1);
                        node.Arcs.Remove(arc);
                        one.Arcs.Add(new ArcNode(arc1.end, arc1.start, arc1.weight));
                    }
                    else// with second
                    {
                        // arc.end = two;
                        ArcNode arc1 = new ArcNode(node.ID, two.ID, arc.weight);
                        node.Arcs.Add(arc1);
                        node.Arcs.Remove(arc);
                        two.Arcs.Add(new ArcNode(arc1.end, arc1.start, arc1.weight));
                    }
                }
            }
        }

        private bool biggerRelation(Node one, Node two,Node related)
        {
            return getSum(one, related) > getSum(two, related) ? true : false;
        }

        private double getSum(Node one, Node two)
        {
            double res = 0;
            foreach(Dot dot in one.dotsSet)
            {
                foreach(Dot dot1 in two.dotsSet)
                {
                    var arc = dot.Arcs.Find(a => a.end == dot1.number);
                    if (arc != null)
                    {
                        res += arc.weight;
                    }
                }
            }
            return res;
        }
        
    }
}
