using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab3
{
    public class DifferentialRentMethod
    {
        public int NumberOfRows;
        public int NumberOfCollumns;
        private readonly double[][] _initialMainArray;
        public double[][] MainArray;
        private readonly double[] _initialStocks;
        public double[] Stocks;
        private readonly double[] _initialRequires;
        public double[] Requires;

        public List<EngageCell> EngageCells;
        public double[] ExcessiveAmount;
        public double[] CollumnsDifferences;

        public double Result;

        public DifferentialRentMethod(int numberOfRows, int numberOfCollumns, double[][] mainArray, double[] stocks, double[] requires)
        {
            NumberOfRows = numberOfRows;
            NumberOfCollumns = numberOfCollumns;
            MainArray = mainArray;
            Stocks = stocks;
            Requires = requires;

            EngageCells = new List<EngageCell>();
            ExcessiveAmount = new double[numberOfRows];
            CollumnsDifferences = new double[numberOfCollumns];

            _initialMainArray = new double[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                _initialMainArray[i] = new double[numberOfCollumns];
                for (int j = 0; j < numberOfCollumns; j++)
                    _initialMainArray[i][j] = mainArray[i][j];
            }
            _initialStocks = new double[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
                _initialStocks[i] = Stocks[i];

            _initialRequires = new double[numberOfCollumns];
            for (int i = 0; i < numberOfCollumns; i++)
                _initialRequires[i] = Requires[i];
        }

        public bool Initialize()
        {
            // write ExcessiveAmount
            for (int i = 0; i < NumberOfRows; i++)
                ExcessiveAmount[i] = Stocks[i];

            // calculate main table
            var transposeMatrix = Transpose(MainArray);
            for (int i = 0; i < transposeMatrix.Length; i++)
            {
                // find min element in collumn
                var minElementPosition = FindMin(transposeMatrix[i]);

                var minStockOrRequire = Math.Min(Stocks[minElementPosition], Requires[i]);
                ExcessiveAmount[minElementPosition] -= Requires[i];
                Stocks[minElementPosition] -= minStockOrRequire;
                Requires[i] -= minStockOrRequire;
                EngageCells.Add(new EngageCell() { Amount = minStockOrRequire, Position = new Point(minElementPosition, i), Price = _initialMainArray[minElementPosition][i] });
            }

            FindResult();

            // check if the method ended
            if (isEnd())
                return true;

            // find differences
            for (int i = 0; i < transposeMatrix.Length; i++)
            {
                var engageCellsInThisCollumn = EngageCells.FindAll(cell => cell.Position.Y == i);
                // check ExcessiveAmount
                bool isMinus = false;
                foreach (var cell in engageCellsInThisCollumn)
                {
                    if (ExcessiveAmount[cell.Position.X] < 0)
                    {
                        isMinus = true;
                        break;
                    }
                }
                if (!isMinus)
                    CollumnsDifferences[i] = -1;
                else
                    CollumnsDifferences[i] = FindDifferenceBetweenTwoMinValues(transposeMatrix[i], engageCellsInThisCollumn, ExcessiveAmount);
            }
            return false;
        }

        public bool MakeStep()
        {
            // to each negative row add min rent
            var minRent = FindMinValue(CollumnsDifferences.Where(value => value != -1).ToArray());
            for (int i = 0; i < NumberOfRows; i++)
            {
                if (ExcessiveAmount[i] > 0)
                    continue;
                for (int j = 0; j < NumberOfCollumns; j++)
                    MainArray[i][j] += minRent;
            }

            RefreshData();

            // calculate main table
            var transposeMatrix = Transpose(MainArray);
            EngageCells.Clear();

            // find all mins elements in each collumn
            var minElementPosition = new List<List<int>>();
            for (int i = 0; i < transposeMatrix.Length; i++)
                minElementPosition.Add(FindAllMin(transposeMatrix[i]));

            while (true)
            {
                for (int i = 0; i < minElementPosition.Count; i++)
                {
                    for (int j = 0; j < minElementPosition[i].Count; j++)
                    {
                        if (OnlyOne(new Point(i, minElementPosition[i][j]), minElementPosition))
                        {
                            var minStockOrRequire = Math.Min(Stocks[minElementPosition[i][j]], Requires[i]);
                            ExcessiveAmount[minElementPosition[i][j]] -= minStockOrRequire;
                            Stocks[minElementPosition[i][j]] -= minStockOrRequire;
                            Requires[i] -= minStockOrRequire;
                            EngageCells.Add(new EngageCell()
                            {
                                Amount = minStockOrRequire,
                                Position = new Point(minElementPosition[i][j], i),
                                Price = _initialMainArray[minElementPosition[i][j]][i]
                            });
                            minElementPosition[i].Remove(minElementPosition[i][j]);
                        }
                    }
                }

                // break if each element was filled
                bool isEnd = false;
                for (int i = 0; i < minElementPosition.Count; i++)
                {
                    if (minElementPosition[i].Count != 0)
                        isEnd = true;
                }
                if (!isEnd)
                    break;
            }

            // find excesive amount
            for (int i = 0; i < NumberOfCollumns; i++)
                ExcessiveAmount[EngageCells.Where(cell => cell.Position.Y == i).First().Position.X] -= Requires[i];

            FindResult();

            // check if the method ended
            if (isEnd())
                return true;

            // find differences
            for (int i = 0; i < transposeMatrix.Length; i++)
            {
                var engageCellsInThisCollumn = EngageCells.FindAll(cell => cell.Position.Y == i);
                // check ExcessiveAmount
                bool isMinus = false;
                foreach (var cell in engageCellsInThisCollumn)
                {
                    if (ExcessiveAmount[cell.Position.X] <= 0)
                    {
                        isMinus = true;
                        break;
                    }
                }
                if (!isMinus)
                    CollumnsDifferences[i] = -1;
                else
                    CollumnsDifferences[i] = FindDifferenceBetweenTwoMinValues(transposeMatrix[i], engageCellsInThisCollumn, ExcessiveAmount);
            }
            return false;
        }

        public bool OnlyOne(Point point, List<List<int>> list)
        {
            if (list[point.X].Count == 1)
                return true;
            var rowCount = 0;
            for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list[i].Count; j++)
                rowCount += list[i][j] == point.Y ? 1 : 0;
            if (rowCount == 1)
                return true;
            return false;
        }

        public bool isEnd()
        {
            for (int i = 0; i < NumberOfRows; i++)
                if (ExcessiveAmount[i] != 0)
                    return false;
            // end
            return true;
        }

        public void FindResult()
        {
            Result = 0;
            foreach (var cell in EngageCells)
                Result += cell.Amount * _initialMainArray[cell.Position.X][cell.Position.Y];
        }

        public void RefreshData()
        {
            for (int i = 0; i < NumberOfRows; i++)
                Stocks[i] = _initialStocks[i];
            for (int j = 0; j < NumberOfCollumns; j++)
                Requires[j] = _initialRequires[j];
            // write ExcessiveAmount
            for (int i = 0; i < NumberOfRows; i++)
                ExcessiveAmount[i] = Stocks[i];
        }

        // extra functions
        private static double FindDifferenceBetweenTwoMinValues(double[] arr, List<EngageCell> engageCells, double[] excessiveAmount)
        {
            if (arr.Length < 2)
                return -1;

            double firstValue = double.MaxValue;
            double secondValue = double.MaxValue;

            // can be only one engage element
            bool isEngageElementFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (engageCells.Any(cell => cell.Position.X == i))
                {
                    if (isEngageElementFound)
                        continue;
                    isEngageElementFound = true;
                }
                else if (excessiveAmount[i] <= 0)
                    continue;

                if (arr[i] < firstValue && firstValue >= secondValue)
                    firstValue = arr[i];
                else if (arr[i] < secondValue)
                    secondValue = arr[i];
            }
            if (firstValue == double.MaxValue || secondValue == double.MaxValue)
                return -1;
            return Math.Abs(secondValue - firstValue);
        }
        public static int FindMin(double[] arr)
        {
            int index = 0;
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= value)
                {
                    value = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static List<int> FindAllMin(double[] arr)
        {
            var minValue = FindMinValue(arr);
            List<int> index = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == minValue)
                    index.Add(i);
            }
            return index;
        }

        public static double FindMinValue(double[] arr)
        {
            double value = double.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= value)
                    value = arr[i];
            }
            return value;
        }

        public static double[][] Transpose(double[][] matrix)
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