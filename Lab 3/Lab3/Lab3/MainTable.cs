using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab3
{
    public class MainTable
    {
        public int NumberOfRows;
        public int NumberOfCollumns;
        public double Result;
        public double[][] MainArray;
        public double[] Stocks;
        public double[] Requires;

        public double[][] ExtraValues;

        // NortWestMethod
        private int _beginCollumn;

        // FoygelMethod
        public List<double[]> RowsDifferences;
        public List<double[]> CollumnsDifferences;

        // PotentalMethod
        public double[] U;
        public double[] V;
        public List<CycleBuilder.CycleElement> Cycle;
        private int _zeroElementInU;

        public MainTable(int numberOfRows, int numberOfCollumns, double[][] mainArray, double[] stocks, double[] requires)
        {
            NumberOfRows = numberOfRows;
            NumberOfCollumns = numberOfCollumns;
            MainArray = mainArray;
            Stocks = stocks;
            Requires = requires;

            ExtraValues = new double[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                ExtraValues[i] = new double[numberOfCollumns];
                for (int j = 0; j < NumberOfCollumns; j++)
                    ExtraValues[i][j] = -1;
            }

            _beginCollumn = 0;

            RowsDifferences = new List<double[]>();
            CollumnsDifferences = new List<double[]>();

            U = new double[NumberOfRows];
            V = new double[numberOfCollumns];
        }

        #region Nort-west method
        public void NorthWestMethodMakeStep()
        {
            for (int i = 0; i < Stocks.Length; i++)
            {
                if (Stocks[i] == 0)
                    continue;

                for (int j = _beginCollumn; j < Requires.Length; j++)
                {
                    if (Stocks[i] < Requires[j])
                    {
                        ExtraValues[i][j] = Stocks[i];
                        Requires[j] -= Stocks[i];
                        Stocks[i] = 0;
                    }
                    else if (Stocks[i] > Requires[j])
                    {
                        ExtraValues[i][j] = Requires[j];
                        Stocks[i] -= Requires[j];
                        Requires[j] = 0;
                        _beginCollumn++;
                    }
                    else
                    {
                        ExtraValues[i][j] = Requires[j];
                        Stocks[i] = 0;
                        Requires[j] = 0;
                        _beginCollumn++;
                    }
                    return;
                }
            }
        }
        #endregion

        #region Min element method
        public void MinElementMethodMakeStep()
        {
            var minElement = FindMinNorthWestMethod();
            if (minElement.X == -1)
                return;

            if (Stocks[minElement.X] < Requires[minElement.Y])
            {
                ExtraValues[minElement.X][minElement.Y] = Stocks[minElement.X];
                Requires[minElement.Y] -= Stocks[minElement.X];
                Stocks[minElement.X] = 0;
            }
            else if (Stocks[minElement.X] > Requires[minElement.Y])
            {
                ExtraValues[minElement.X][minElement.Y] = Requires[minElement.Y];
                Stocks[minElement.X] -= Requires[minElement.Y];
                Requires[minElement.Y] = 0;
            }
            else
            {
                ExtraValues[minElement.X][minElement.Y] = Requires[minElement.Y];
                Stocks[minElement.X] = 0;
                Requires[minElement.Y] = 0;
            }
        }

        private Point FindMinNorthWestMethod()
        {
            Point index = new Point(-1, -1);
            double value = double.MaxValue;
            for (int i = 0; i < NumberOfRows; i++)
            {
                if (Stocks[i] == 0)
                    continue;
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (Requires[j] == 0)
                        continue;
                    if (MainArray[i][j] < value)
                    {
                        value = MainArray[i][j];
                        index.X = i;
                        index.Y = j;
                    }
                }
            }
            return index;
        }
        #endregion

        #region Foygel method
        public void FoygelMethodMakeStep()
        {
            var minElement = FindMinFoygelMethod();
            if (minElement.X == -1 || minElement.Y == -1)
                return;

            if (Stocks[minElement.X] < Requires[minElement.Y])
            {
                ExtraValues[minElement.X][minElement.Y] = Stocks[minElement.X];
                Requires[minElement.Y] -= Stocks[minElement.X];
                Stocks[minElement.X] = 0;
            }
            else if (Stocks[minElement.X] > Requires[minElement.Y])
            {
                ExtraValues[minElement.X][minElement.Y] = Requires[minElement.Y];
                Stocks[minElement.X] -= Requires[minElement.Y];
                Requires[minElement.Y] = 0;
            }
            else
            {
                ExtraValues[minElement.X][minElement.Y] = Requires[minElement.Y];
                Stocks[minElement.X] = 0;
                Requires[minElement.Y] = 0;
            }
        }

        private Point FindMinFoygelMethod()
        {
            Point result = new Point(-1, -1);

            // find collumns differences
            var tempArray = Transpose(MainArray);
            double[] arr = new double[NumberOfCollumns];
            for (int i = 0; i < NumberOfCollumns; i++)
            {
                if (Requires[i] == 0)
                {
                    arr[i] = -1;
                    continue;
                }
                arr[i] = FindDifferenceBetweenTwoMinValues(tempArray[i], Stocks);
            }
            CollumnsDifferences.Add(arr);
            var maxCollDifferenceIndex = FindMax(arr);
            var maxCollDifference = arr[maxCollDifferenceIndex];

            // find rows differences
            arr = new double[NumberOfRows];
            for (int i = 0; i < NumberOfRows; i++)
            {
                if (Stocks[i] == 0)
                {
                    arr[i] = -1;
                    continue;
                }
                arr[i] = FindDifferenceBetweenTwoMinValues(MainArray[i], Requires);
            }
            RowsDifferences.Add(arr);
            var maxRowDifferenceIndex = FindMax(arr);
            var maxRowDifference = arr[maxRowDifferenceIndex];



            if (maxCollDifference > maxRowDifference)
            {
                var min = FindMin(tempArray[maxCollDifferenceIndex], Stocks);
                if (min != -1)
                    result.X = min;
                result.Y = maxCollDifferenceIndex;
            }
            else
            {
                var min = FindMin(MainArray[maxRowDifferenceIndex], Requires);
                if (min != -1)
                    result.Y = min;
                result.X = maxRowDifferenceIndex;
            }
            return result;
        }

        // template Value can't be 0
        public int FindMin(double[] arr, double[] template)
        {
            int index = 0;
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < value && template[i] != 0)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }

        // template Value can't be 0
        private double FindDifferenceBetweenTwoMinValues(double[] arr, double[] template)
        {
            if (arr.Length < 2)
                return -1;
            double firstValue = double.MaxValue;
            double secondValue = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (template[i] == 0)
                    continue;
                if (arr[i] < firstValue && firstValue >= secondValue)
                    firstValue = arr[i];
                else if (arr[i] < secondValue)
                    secondValue = arr[i];
            }
            if (firstValue == double.MaxValue && secondValue == double.MaxValue)
                return -1;
            if (secondValue == double.MaxValue)
                return firstValue;
            return Math.Abs(secondValue - firstValue);
        }
        #endregion

        #region Potential method

        public void InitializePotentialMethod()
        {
            while (CountNonFreeValues() < NumberOfCollumns + NumberOfRows - 1)
                AddNonFreeValue();

            FindPotentialsInitial();
        }

        private void FindPotentialsInitial()
        {
            // find row with the most amount of non free values
            int index = 0;
            int maxCountOfnonFreeValuesInRow = 0;
            for (int i = 0; i < ExtraValues.Length; i++)
            {
                int nonFreeValuesInRow = 0;
                for (int j = 0; j < ExtraValues[i].Length; j++)
                {
                    if (ExtraValues[i][j] != -1)
                        nonFreeValuesInRow++;
                }
                if (nonFreeValuesInRow >= maxCountOfnonFreeValuesInRow)
                {
                    maxCountOfnonFreeValuesInRow = nonFreeValuesInRow;
                    index = i;
                }
            }
            _zeroElementInU = index;
            RecalculatePotentials();
        }

        public bool PotentialMethodMakeStep()
        {
            var maxDelta = FindDelta();
            if (maxDelta.X == -1)
                return true;
         
            Cycle = BuildCycle(maxDelta);
            ExtraValues[maxDelta.X][maxDelta.Y] = 0;

            // find min element
            var minElementInCycle = FindMinElementInCycle(Cycle);
            if (minElementInCycle.X == -1)
                return true;
            // sub/add values
            foreach (var element in Cycle)
            {
                if (element.Position == minElementInCycle)
                    continue;
                if (element.GetSign() == -1)
                    ExtraValues[element.Position.X][element.Position.Y] -= ExtraValues[minElementInCycle.X][minElementInCycle.Y];
                else
                    ExtraValues[element.Position.X][element.Position.Y] += ExtraValues[minElementInCycle.X][minElementInCycle.Y];
            }
            ExtraValues[minElementInCycle.X][minElementInCycle.Y] = -1;

            // find potentials
            RecalculatePotentials();

            return false;
        }

        public List<CycleBuilder.CycleElement> BuildCycle(Point maxDelta)
        {
            var enagaged = new List<CycleBuilder.EngagedElement>();
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (ExtraValues[i][j] != -1)
                        enagaged.Add(new CycleBuilder.EngagedElement(MainArray[i][j], i, j));
                }
            }
            enagaged.Add(new CycleBuilder.EngagedElement(0, maxDelta.X, maxDelta.Y));//головний елемент

            var cycle = new List<CycleBuilder.CycleElement>();
            cycle.Add(new CycleBuilder.CycleElement(maxDelta.X, maxDelta.Y, +1));//початковий елемент циклу

            CycleBuilder.Build(cycle, enagaged);

            return cycle;
        }

        public Point FindMinElementInCycle(List<CycleBuilder.CycleElement> arr)
        {
            Point index = new Point(-1, -1);
            double value = double.MaxValue;
            for (int i = 0; i < arr.Count; i++)
            {
                if (ExtraValues[arr[i].Position.X][arr[i].Position.Y] < value && arr[i].GetSign() == -1)
                {
                    value = ExtraValues[arr[i].Position.X][arr[i].Position.Y];
                    index.X = arr[i].Position.X;
                    index.Y = arr[i].Position.Y;
                }
            }
            return index;
        }

        public Point FindDelta()
        {
            double maxValue = -1;
            Point index = new Point(-1, -1);
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (ExtraValues[i][j] != -1)
                        continue;
                    double delta = U[i] + V[j] - MainArray[i][j];
                    if (delta > 0 && delta >= maxValue)
                    {
                        maxValue = delta;
                        index.X = i;
                        index.Y = j;
                    }
                }
            }

            return index;
        }

        private int CountNonFreeValues()
        {
            int result = 0;
            for (int i = 0; i < ExtraValues.Length; i++)
                for (int j = 0; j < ExtraValues[i].Length; j++)
                    if (ExtraValues[i][j] != -1)
                        result++;
            return result;
        }
        private void AddNonFreeValue()
        {
            double value = double.MaxValue;
            Point index = new Point(-1, -1);
            for (int i = 0; i < MainArray.Length; i++)
            {
                for (int j = 0; j < MainArray[i].Length; j++)
                {
                    if (ExtraValues[i][j] == -1 && MainArray[i][j] < value)
                    {
                        value = MainArray[i][j];
                        index = new Point(i, j);
                    }
                }
            }
            if (index.X != -1)
                ExtraValues[index.X][index.Y] = 0;
        }

        public void RecalculatePotentials()
        {
            // Gauss calculate
            var system = RecalculateSystem();
            var result = MethodGausa.Calculate(system);
            while (result == null)
            {
                AddNonFreeValue();
                system = RecalculateSystem();
                result = MethodGausa.Calculate(system);
            }
            for (int i = 0; i < NumberOfRows; i++)
                U[i] = result[i];
            for (int i = 0; i < NumberOfCollumns; i++)
                V[i] = result[NumberOfRows + i];
        }

        public double[][] RecalculateSystem()
        {
            int numberOfSystems = 0;
            for (int i = 0; i < NumberOfRows; i++)
            for (int j = 0; j < NumberOfCollumns; j++)
                if (ExtraValues[i][j] != -1)
                    numberOfSystems++;
            while (numberOfSystems < NumberOfRows + NumberOfCollumns - 1)
            {
                AddNonFreeValue();
                numberOfSystems++;
            }
            double[][] system = new double[numberOfSystems + 1][];
            for (int i = 0; i < system.Length; i++)
                system[i] = new double[NumberOfRows + NumberOfCollumns + 1]; // result

            int numberOfEquation = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (ExtraValues[i][j] == -1)
                        continue;

                    system[numberOfEquation][i] = 1;
                    system[numberOfEquation][NumberOfRows + j] = 1;
                    system[numberOfEquation][NumberOfRows + NumberOfCollumns] = MainArray[i][j];
                    numberOfEquation++;
                }
            }

            // one variable equate to zero
            system[numberOfSystems][_zeroElementInU] = 1;

            return system;
        }
        #endregion
        public static int FindMax(double[] arr)
        {
            int index = 0;
            double value = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > value)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }
        public bool IsBasicWayFound()
        {
            for (int i = 0; i < Stocks.Length; i++)
            {
                if (Stocks[i] > 0)
                    return false;
            }
            return true;
        }

        public void FindResult()
        {
            Result = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCollumns; j++)
                {
                    if (ExtraValues[i][j] != -1)
                        Result += MainArray[i][j] * ExtraValues[i][j];
                }
            }
        }

        public double[][] Transpose(double[][] matrix)
        {
            int w = matrix.Length;
            int h = matrix[0].Length;

            var result = new double[h][];
            for (int i = 0; i < h; i++)
                result[i] = new double[w];

            for (int i = 0; i < w; i++)
            for (int j = 0; j < h; j++)
                result[j][i] = matrix[i][j];

            return result;
        }
    }
}