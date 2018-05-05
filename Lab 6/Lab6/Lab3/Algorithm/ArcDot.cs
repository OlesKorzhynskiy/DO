namespace Lab5
{
    public class ArcDot
    {
        public int start { get; set; }
        public int end { get; set; }
        public double weight { get; set; }

        public ArcDot(int start, int end, double weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }
    }
}