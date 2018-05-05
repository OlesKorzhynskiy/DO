using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Node : IComparable<Node>
    {
        public List<Dot> dotsSet{ get; set; }
        public int ID;
        public List<ArcNode> Arcs { get; set; }
        public Node(List<Dot> dotsSet, List<ArcNode> Arcs)
        {
            this.dotsSet = dotsSet;
            this.Arcs = Arcs;
            GenerateID();
        }

        public void GenerateID()
        {
            int d = 1;
            ID = 0;
            foreach (Dot dot in dotsSet)
            {
                ID += dot.number * d;
                d *= 10;
            }
        }

        public Node Clone()
        {
            List<Dot> dots = new List<Dot>();
            foreach(Dot dot in dotsSet)
            {
                dots.Add(dot);
            }
            List<ArcNode> arcs = new List<ArcNode>();
            foreach(ArcNode arc in this.Arcs)
            {
                arcs.Add(arc.Clone());
            }
            return new Node(dots, arcs);
        }

        public void removeOutDotRelation()
        {
            foreach(Dot dot in this.dotsSet)
            {
                List<ArcDot> toRemove = new List<ArcDot>();
                foreach (ArcDot arc in dot.Arcs)
                {
                    if(this.dotsSet.Find(d=>d.number== arc.end)==null)
                    {
                        toRemove.Add(arc);
                    }
                }
                dot.Arcs.RemoveAll((e=>toRemove.Contains(e)));
            }
        }
        public void setRelation(Node second,double cut)
        {
            Arcs.Add(new ArcNode(this.ID, second.ID, cut));
            second.Arcs.Add(new ArcNode(second.ID, this.ID, cut));
        }
        public void setRelation(Node second)
        {
            Arcs.Add(new ArcNode(this.ID, second.ID,0));
            second.Arcs.Add(new ArcNode(second.ID, this.ID, 0));
            foreach (Dot dot1 in this.dotsSet)
            {
                foreach(Dot dot2 in second.dotsSet)
                {
                    var a = dot1.Arcs.Find(e => e.end.Equals(dot2.number));//get the cut between node
                    if(a!=null)
                    {
                        Arcs.Last().weight += a.weight;
                        second.Arcs.Last().weight += a.weight;
                    }
                }
            }
        }
        public String toString()
        {
            String res = "";
            foreach(Dot dot in this.dotsSet)
            {
                res += dot.number + ", ";
            }
            res = res.Substring(0, res.Length-2);
            return res;
        }

        public int CompareTo(Node other)
        {
            return this.ID > other.ID ? 1 : this.ID < other.ID ? -1 : 0;
        }
    }
}
