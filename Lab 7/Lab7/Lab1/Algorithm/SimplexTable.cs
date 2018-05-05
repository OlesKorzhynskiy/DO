using System;
using System.CodeDom;
using System.Windows.Forms;

namespace Lab1
{
    public class SimplexTable : AbstractSimplexTable
    {
        public SimplexTable(int numberOfRows, int numberOfCollumns, int[] basis, double[] freeValues, double[][] variables, double[] function)
            :base (numberOfRows, numberOfCollumns, basis, freeValues, variables, function)
        {
            EstimateRelations = new double[numberOfRows];
            MainCollumnForNextStep = FindMin(function);
            for (int i = 0; i < numberOfRows; i++)
                EstimateRelations[i] = freeValues[i] / Variables[i][MainCollumnForNextStep];

            MainRowForNextStep = FindPositiveMin(EstimateRelations);
            MainCollumn = -1;
            MainRow = -1;
        }

        public override void Next()
        {
            if (Function[MainCollumnForNextStep] >= 0)
                return;

            base.Next();

            if (Function[FindMin(Function)] >= 0)
                return;
            // find EstimateRelations
            MainCollumnForNextStep = FindMin(Function);
            for (int i = 0; i < NumberOfRows; i++)
                EstimateRelations[i] = FreeValues[i] / Variables[i][MainCollumnForNextStep];

            MainRowForNextStep = FindPositiveMin(EstimateRelations);
        }

        public override bool IsEnd()
        {
            if (Function[MainCollumnForNextStep] >= 0)
                return true;
            return false;
        }
    }
}