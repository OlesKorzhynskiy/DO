using System;

namespace Lab1
{
    public class Homory
    {
        public AbstractSimplexTable Table;
        public bool IsSimplexMethod = true;

        public Homory(SimplexTable table)
        {
            Table = table;
        }

        public void AddRestriction()
        {
            int indexOfRow = FindIndexOfMaxFractionInArr(Table.FreeValues);

            // add row and collumn
            Table.NumberOfCollumns += 1;
            Table.NumberOfRows += 1;

            // rewrite old variables
            double[][] newVariables = new double[Table.NumberOfRows][];
            for (int i = 0; i < newVariables.Length; i++)
                newVariables[i] = new double[Table.NumberOfCollumns];

            for (int i = 0; i < Table.NumberOfRows - 1; i++)
                for (int j = 0; j < Table.NumberOfCollumns - 1; j++)
                    newVariables[i][j] = Table.Variables[i][j];

            // add new row
            double[] lastRow = new double[Table.NumberOfCollumns];
            for (int i = 0; i < Table.NumberOfCollumns - 1; i++)
                lastRow[i] = -TakeFraction(Table.Variables[indexOfRow][i]);
            lastRow[Table.NumberOfCollumns - 1] = 1;
            for (int i = 0; i < Table.NumberOfCollumns; i++)
                newVariables[Table.NumberOfRows - 1][i] = lastRow[i];
            Table.Variables = newVariables;

            // change freeValues
            double[] freeValues = new double[Table.NumberOfRows];
            for (int i = 0; i < freeValues.Length - 1; i++)
                freeValues[i] = Table.FreeValues[i];
            freeValues[freeValues.Length - 1] = -TakeFraction(Table.FreeValues[indexOfRow]);
            Table.FreeValues = freeValues;

            // change basis
            int[] basis = new int[Table.NumberOfRows];
            for (int i = 0; i < Table.NumberOfRows - 1; i++)
                basis[i] = Table.Basis[i];
            basis[Table.NumberOfRows - 1] = Table.NumberOfRows - 1;
            Table.Basis = basis;

            // change function 
            double[] function = new double[Table.NumberOfCollumns];
            for (int i = 0; i < Table.NumberOfCollumns - 1; i++)
                function[i] = Table.Function[i];
            Table.Function = function;
            var functionResult = Table.FunctionResult;

            Table = new DoubleSimplexTable(Table.NumberOfRows, Table.NumberOfCollumns - Table.NumberOfRows, basis, freeValues, newVariables, function);
            Table.FunctionResult = functionResult;
        }

        private double TakeFraction(double value)
        {
            if (value >= 0)
                return value - Math.Floor(value);
            else
                return Math.Ceiling(Math.Abs(value)) - Math.Abs(value);
        }

        public int FindIndexOfMaxFractionInArr(double[] arr)
        {
            double value = double.MinValue;
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (TakeFraction(Math.Round(arr[i], 2)) > value)
                {
                    value = TakeFraction(arr[i]);
                    index = i;
                }
            }
            return index;
        }
    }
}