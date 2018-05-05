namespace Lab5
{
    public class ArcNode
    {
        public long start { get; set; }
        public long end { get; set; }
        public double weight { get; set; }

        public ArcNode(long start, long end, double weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }
        public ArcNode Clone()
        {
            return new ArcNode(start, end, weight);
        }
    }
}
