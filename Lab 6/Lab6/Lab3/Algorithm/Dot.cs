using System.Collections.Generic;

namespace Lab5
{
    public class Dot
    {
        public int number { get; set;}
        public bool Fixed = false;
        public List<ArcDot> Arcs { get; set; }
        public Dot(int number,List<ArcDot> arcs)
        {
            this.number = number;
            this.Arcs = arcs;
        } 
    }
}
