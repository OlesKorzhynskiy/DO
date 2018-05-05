using System;

namespace Lab3.Algorithm
{
    public class FloydAlgorithm
    {
        public int NumberOfNodes;
        public double[][] Paths; // 0 - path doesn't exist
        public double[][] ComeFrom;
        public int Step;

        public FloydAlgorithm(double[][] arr)
        {
            NumberOfNodes = arr.GetLength(0);
            Step = 0;

            Paths = arr;
            ComeFrom = new double[NumberOfNodes][];
            for (int i = 0; i < NumberOfNodes; i++)
            {
                ComeFrom[i] = new double[NumberOfNodes];
                for (int j = 0; j < NumberOfNodes; j++)
                {
                    if (i == j)
                        continue;
                    ComeFrom[i][j] = j;
                }
            }
        }

        public bool MakeStep()
        {
            if (Step == NumberOfNodes) // end
                return true;

            for (int i = 0; i < NumberOfNodes; i++)
            {
                // miss 
                if (Paths[i][Step] == 0)
                    continue;

                for (int j = 0; j < NumberOfNodes; j++)
                {
                    // miss
                    if (Paths[Step][j] == 0)
                        continue;

                    if (i == j)
                        continue;

                    // check
                    if (Paths[i][j] > Paths[i][Step] + Paths[Step][j] || Paths[i][j] == 0)
                    {
                        Paths[i][j] = Paths[i][Step] + Paths[Step][j];
                        ComeFrom[i][j] = Step;
                    }
                }
            }

            Step++;

            if (Step == NumberOfNodes) // end
                return true;

            return false;
        }
    }
}