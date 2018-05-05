using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public static class MethodGausa
    {
        public static double[] Calculate(double[][] system)
        {
            double[] result = new double[system.Length];

            while (!IncludeOnlyZeroValues(system))
            {
                var found = false;
                for (int i = 0; i < system.Length; i++)
                {
                    var indexOfSingleElement = FindSingleElement(system[i]);
                    if (indexOfSingleElement == -1)
                        continue;

                    found = true;

                    // indexOfSingleElement is known variable
                    result[indexOfSingleElement] = system[i][system[i].Length - 1];
                    system[i][indexOfSingleElement] = 0;
                    // refresh all variables
                    for (int j = 0; j < system.Length; j++)
                    {
                        if (system[j][indexOfSingleElement] != 0)
                        {
                            system[j][indexOfSingleElement] = 0;
                            system[j][system[j].Length - 1] -= result[indexOfSingleElement];
                        }
                    }
                }
                if (!found)
                    return null;
            }
            return result;
        }

        public static bool IncludeOnlyZeroValues(double[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr[i].Length - 1; j++) // the last collumn is for free values
                    if (arr[i][j] != 0)
                        return false;
            return true;
        }

        public static int FindSingleElement(double[] arr)
        {
            int index = -1;
            for (int i = 0; i < arr.Length - 1; i++) // the last collumn is for free values
            {
                if (arr[i] != 0)
                {
                    if (index != -1)
                        return -1;
                    index = i;
                }
            }
            return index;
        }
    }
}