using System;
using System.Windows.Forms;

namespace Lab1
{
    public class DoubleSimplexTable : AbstractSimplexTable
    {
        public DoubleSimplexTable(int numberOfRows, int numberOfCollumns, int[] basis, double[] freeValues, double[][] variables, double[] function)
            :base(numberOfRows, numberOfCollumns, basis, freeValues, variables, function)
        {
            EstimateRelations = new double[NumberOfCollumns];
            MainRowForNextStep = FindMin(freeValues);
            for (int i = 0; i < NumberOfCollumns; i++)
                EstimateRelations[i] = function[i] / Variables[MainRowForNextStep][i];

            MainCollumnForNextStep = FindAbsMin(EstimateRelations);
            MainCollumn = -1;
            MainRow = -1;
        }

        public override void Next()
        {
            if (FreeValues[MainRowForNextStep] >= 0)
                return;

            base.Next();

            if (FreeValues[FindMin(FreeValues)] >= 0)
                return;
            MainRowForNextStep = FindMin(FreeValues);
            // find EstimateRelations
            for (int i = 0; i < NumberOfCollumns; i++)
                EstimateRelations[i] = Function[i] / Variables[MainRowForNextStep][i];

            MainCollumnForNextStep = FindAbsMin(EstimateRelations);
        }
    }
}