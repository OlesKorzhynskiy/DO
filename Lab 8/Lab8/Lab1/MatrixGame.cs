using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab1
{
    public class MatrixGame
    {
        public List<List<double>> Array;
        public double LowerPriceOfGame;
        public double UpperPriceOfGame;

        public MatrixGame(List<List<double>> array)
        {
            Array = array;

            LowerPriceOfGame = MaxMin(Array);
            UpperPriceOfGame = MinMax(Transpose(Array));
        }

        public bool MakeStep()
        {
            if (Array == null)
                return false;

            if (LowerPriceOfGame == UpperPriceOfGame)
                throw new Exception("the end");

            // check collumns
            var array = Transpose(Array);
            // main row
            for (int i = 0; i < array.Count; i++)
            {
                // others rows
                for (int j = 0; j < array.Count; j++)
                {
                    if (i == j)
                        continue;

                    // collumns
                    bool hasAdventage = true;
                    for (int k = 0; k < array[i].Count; k++)
                    {
                        if (array[i][k] < array[j][k])
                            hasAdventage = false;
                    }
                    // має перевагу
                    if (hasAdventage)
                    {
                        array.RemoveAt(i);
                        Array = Transpose(array);
                        return false;
                    }
                }
            }

            // check rows
            // main row
            for (int i = 0; i < Array.Count; i++)
            {
                // others rows
                for (int j = 0; j < Array.Count; j++)
                {
                    if (i == j)
                        continue;

                    // collumns
                    bool hasAdventage = true;
                    for (int k = 0; k < Array[i].Count; k++)
                    {
                        if (Array[i][k] > Array[j][k])
                            hasAdventage = false;
                    }
                    // має перевагу
                    if (hasAdventage)
                    {
                        Array.RemoveAt(i);
                        return false;
                    }
                }
            }

            return true;
        }

        public double MinMax(List<List<double>> array)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < array.Count; i++)
            {
                result.Add(FindMaxValue(array[i]));
            }
            return FindMinValue(result);
        }

        public double MaxMin(List<List<double>> array)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < array.Count; i++)
            {
                result.Add(FindMinValue(array[i]));
            }
            return FindMaxValue(result);
        }

        public static List<List<double>> Transpose(List<List<double>> matrix)
        {
            if (matrix.Count == 0)
                return null;

            for (int i = 0; i < matrix.Count; i++)
                if (matrix[i].Count != matrix.First().Count)
                    throw new Exception("Matrix has to be NxM");

            List<List<double>> list = new List<List<double>>();
            for (int i = 0; i < matrix.First().Count; i++)
            {
                list.Add(new List<double>());
                for (int j = 0; j < matrix.Count; j++)
                    list[i].Add(matrix[j][i]);
            }

            return list;
        }

        public static double FindMinValue(List<double> arr)
        {
            double value = double.MaxValue;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] < value)
                    value = arr[i];
            }
            return value;
        }

        public static double FindMaxValue(List<double> arr)
        {
            double value = double.MinValue;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > value)
                    value = arr[i];
            }
            return value;
        }
    }
}