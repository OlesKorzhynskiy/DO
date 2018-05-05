using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace Lab1
{
    public class SimplexMethod
    {
        // for main Array
        private readonly int _numberOfRows;
        private readonly int _numberOfCollumns;
        private readonly double[][] _mainArray;

        private readonly Compare[] _signs;
        private readonly double[] _freeValues;
        private readonly double[] _function;
        private readonly Direction _direction; 


        public SimplexMethod(int numberOfRows, int numberOfCollumns, double[][] mainArray, double[] function,
            double[] freeValues, Compare[] signs, Direction direction)
        {
            _numberOfRows = numberOfRows;
            _numberOfCollumns = numberOfCollumns;
            _mainArray = mainArray;
            _function = function;
            _freeValues = freeValues;
            _signs = signs;
            _direction = direction;
        }

        private double[][] FindExtensionSystem()
        {
            double[][] result = new double[_numberOfRows][];
            for (int i = 0; i < _numberOfRows; i++)
                result[i] = new double[_numberOfCollumns + _numberOfRows];

            // заповнюємо даними з головної таблиці
            for (int i = 0; i < _numberOfRows; i++)
                for (int j = 0; j < _numberOfCollumns; j++)
                    result[i][j] = _mainArray[i][j];

            // в залежності від знаку додаємо чи віднімаємо x
            for (int i = 0; i < _numberOfRows; i++)
            {
                if (_signs[i] == Compare.MoreEqual)
                    result[i][_numberOfCollumns + i] = -1;
                else
                    result[i][_numberOfCollumns + i] = 1;
            }

            // якщо min, то множимо функцію на -1
            if (_direction == Direction.Max)
                for (int i = 0; i < _numberOfCollumns; i++)
                    _function[i] *= -1;

            // якщо базис = -1, то множимо цілий рядок і вільний член на -1
            for (int i = 0; i < _numberOfRows; i++)
            {
                if (result[i][_numberOfCollumns + i] == -1)
                {
                    for (int j = 0; j < _numberOfCollumns + _numberOfRows; j++)
                        result[i][j] *= -1;
                    _freeValues[i] *= -1;
                }
            }

            return result;
        }

        public SimplexTable MakeSimplexTable()
        {
            double[][] array = FindExtensionSystem();
            
            // перевірка, чи всі вільні члени >= 0
            for (int i = 0; i < _numberOfRows; i++)
            {
                if (_freeValues[i] < 0)
                    throw new Exception("Вільні члени не можуть бути меншими за 0 в канонічній формі");
            }

            int[] basis = new int[_numberOfRows];
            for (int i = 0; i < _numberOfRows; i++)
                basis[i] = i + _numberOfCollumns;

            double[] function = new double[_numberOfRows + _numberOfCollumns];
            for (int i = 0; i < _numberOfCollumns; i++)
                function[i] = _function[i];
            return new SimplexTable(_numberOfRows, _numberOfCollumns, basis, _freeValues, array, function); 
        }

        public DoubleSimplexTable MakeDoubleSimplexTable()
        {
            double[][] array = FindExtensionSystem();

            // перевірка, чи всі значення функції >= 0
            for (int i = 0; i < _numberOfCollumns; i++)
            {
                if (_function[i] < 0)
                    throw new Exception("Значення функції не можуть бути меншими за 0 в канонічній формі");
            }

            int[] basis = new int[_numberOfRows];
            for (int i = 0; i < _numberOfRows; i++)
                basis[i] = i + _numberOfCollumns;

            double[] function = new double[_numberOfRows + _numberOfCollumns];
            for (int i = 0; i < _numberOfCollumns; i++)
                function[i] = _function[i];
            return new DoubleSimplexTable(_numberOfRows, _numberOfCollumns, basis, _freeValues, array, function);
        }
    }
}