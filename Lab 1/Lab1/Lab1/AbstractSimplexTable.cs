using System;
using System.Windows.Forms;

namespace Lab1
{
    public class AbstractSimplexTable
    {
        public int NumberOfRows;   // for main variables
        public int NumberOfCollumns; // for main variablse
        public int[] Basis;
        public double[] FreeValues;
        public double[][] Variables;
        public double[] Function;
        public double FunctionResult;

        public double[] EstimateRelations;
        public int MainCollumn, MainRow;
        public int MainCollumnForNextStep, MainRowForNextStep;

        public AbstractSimplexTable(int numberOfRows, int numberOfCollumns, int[] basis, double[] freeValues, double[][] variables, double[] function)
        {
            NumberOfRows = numberOfRows;
            // + basic variables
            NumberOfCollumns = numberOfCollumns + numberOfRows;
            Basis = basis;
            FreeValues = freeValues;
            Variables = variables;
            Function = function;
            FunctionResult = 0;
        }

        public virtual void Next()
        {
            MainCollumn = MainCollumnForNextStep;
            MainRow = MainRowForNextStep;

            Basis[MainRow] = MainCollumn;

            // c
            // function, functionResult, freeVariables, and rest variables
            FunctionResult -= Function[MainCollumn] * FreeValues[MainRow] / Variables[MainRow][MainCollumn];

            for (int i = 0; i < NumberOfCollumns; i++)
            {
                if (i != MainCollumn)
                    Function[i] -= Function[MainCollumn] * Variables[MainRow][i] / Variables[MainRow][MainCollumn];
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                if (i != MainRow)
                    FreeValues[i] -= Variables[i][MainCollumn] * FreeValues[MainRow] / Variables[MainRow][MainCollumn];
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                if (i == MainRow)
                    continue;
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (j == MainCollumn)
                        continue;
                    Variables[i][j] -= Variables[i][MainCollumn] * Variables[MainRow][j] / Variables[MainRow][MainCollumn];
                }
            }

            // a
            for (int i = 0; i < NumberOfRows; i++)
            {
                if (i != MainRow)
                    Variables[i][MainCollumn] = 0;
            }
            Function[MainCollumn] = 0;

            // b
            double value = Variables[MainRow][MainCollumn];
            for (int i = 0; i < NumberOfCollumns; i++)
                Variables[MainRow][i] /= value;
            FreeValues[MainRow] /= value;
        }

        public static int FindAbsMin(double[] arr)
        {
            int index = 0;
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) < Math.Abs(value) && arr[i] != 0)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int FindPositiveMin(double[] arr)
        {
            int index = 0;
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= value && arr[i] >= 0)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int FindMin(double[] arr)
        {
            int index = 0;
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < value)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }
    }
}