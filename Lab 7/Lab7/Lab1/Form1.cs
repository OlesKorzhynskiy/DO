using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private Homory _homory;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown_InputData_Collumns_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_InputData_Methods.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            for (int i = 0; i < dataGridView_InputData_Methods.ColumnCount; i++)
                dataGridView_InputData_Methods.Columns[i].HeaderText = "Метод " + (i + 1);
            dataGridView_InputData_Function.RowCount = 1;
            dataGridView_InputData_Function.Rows[0].HeaderCell.Value = "F";
            dataGridView_InputData_Function.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

            foreach (DataGridViewColumn column in dataGridView_InputData_Methods.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn column in dataGridView_InputData_Function.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void numericUpDown_InputData_Rows_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_InputData_Methods.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
                dataGridView_InputData_Methods.Rows[i].HeaderCell.Value = "Тип " + (i + 1);
            dataGridView_InputData_Signs.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            dataGridView_InputData_FreeValues.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView_InputData_Signs.ColumnCount = 1;
            dataGridView_InputData_FreeValues.ColumnCount = 1;
            dataGridView_InputData_FreeValues.Columns[0].HeaderText = "b";
            dataGridView_InputData_Function.RowCount = 1;
            dataGridView_InputData_Function.Rows[0].HeaderCell.Value = "F";

            foreach (DataGridViewColumn column in dataGridView_InputData_Signs.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn column in dataGridView_InputData_FreeValues.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.DefaultCellStyle.NullValue = "<=";
            comboBoxColumn.Items.AddRange(new ArrayList { ">=", "=", "<=" }.ToArray());
            dataGridView_InputData_Signs.Columns.Add(comboBoxColumn);
            dataGridView_InputData_Signs.Columns.RemoveAt(0);

            // дані для ініціалізації
            numericUpDown_InputData_Rows.Value = 2;
            numericUpDown_InputData_Collumns.Value = 4;

            int[][] methodsArray = { new [] {2, 5, 1, 0}, new []{4, 1, 0, 1}};
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
                for (int j = 0; j < dataGridView_InputData_Methods.ColumnCount; j++)
                    dataGridView_InputData_Methods.Rows[i].Cells[j].Value = methodsArray[i][j];

            int[] freeValuesArray = {19, 16};
            for (int i = 0; i < dataGridView_InputData_FreeValues.RowCount; i++)
                dataGridView_InputData_FreeValues.Rows[i].Cells[0].Value = freeValuesArray[i];

            int[] funcitonArray = {8, 6, 0, 0};
            for (int i = 0; i < dataGridView_InputData_Function.ColumnCount; i++)
                dataGridView_InputData_Function.Rows[0].Cells[i].Value = funcitonArray[i];
        }

        public Homory ReadHomoryMethod()
        {
            int numberOfRows = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            int numberOfCollumns = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

            double[][] mainArray = new double[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
                mainArray[i] = new double[numberOfCollumns];

            for (int i = 0; i < numberOfRows; i++)
            for (int j = 0; j < numberOfCollumns; j++)
                mainArray[i][j] = Convert.ToDouble(dataGridView_InputData_Methods.Rows[i].Cells[j].Value);

            double[] function = new double[numberOfCollumns];
            for (int i = 0; i < numberOfCollumns; i++)
                function[i] = Convert.ToDouble(dataGridView_InputData_Function.Rows[0].Cells[i].Value);

            double[] freeValues = new double[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
                freeValues[i] = Convert.ToDouble(dataGridView_InputData_FreeValues.Rows[i].Cells[0].Value);

            Compare[] signs = new Compare[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                signs[i] = Convert.ToString(dataGridView_InputData_Signs.Rows[i].Cells[0].Value) == "="
                    ? Compare.Equal
                    : Convert.ToString(dataGridView_InputData_Signs.Rows[i].Cells[0].Value) == ">="
                        ? Compare.MoreEqual
                        : Compare.LessEqual;
            }

            Direction direction = radioButton_InputData_Max.Checked ? Direction.Max : Direction.Min;

            SimplexMethod simplexMethod = new SimplexMethod(numberOfRows, numberOfCollumns, mainArray, function,
                freeValues, signs, direction);

            return new Homory(simplexMethod.MakeSimplexTable());
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDataGridColor(dataGridView_Result);

                _homory = ReadHomoryMethod();
                FillDataGrid(_homory, dataGridView_Result);

                if (_homory.Table.IsEnd())
                    MessageBox.Show("Симплекс метод завершено");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void ClearDataGridColor(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                    dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
        }

        public void FillDataGrid(Homory homory, DataGridView dgv)
        {
            // simplexTable
            if (homory.IsSimplexMethod)
            {
                // головні змінні + для функції
                dgv.RowCount = homory.Table.NumberOfRows + 1;
                // mainVariables + basis variables + basis + freeValues + EstimateRelations
                dgv.ColumnCount = homory.Table.NumberOfCollumns + 3;
            }
            else
            {
                //doubleSimplexTable
                // головні змінні + для функції + EstimateRelations
                dgv.RowCount = homory.Table.NumberOfRows + 2;
                // mainVariables + basis variables + basis + freeValues
                dgv.ColumnCount = homory.Table.NumberOfCollumns + 2;
            }
            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Rows[homory.Table.MainRowForNextStep].Cells[homory.Table.MainCollumnForNextStep + 2].Style.BackColor = Color.AntiqueWhite;
            if (homory.Table.MainRow != -1)
                dgv.Rows[homory.Table.MainRow].Cells[homory.Table.MainCollumn + 2].Style.BackColor = Color.White;

            // basis
            dgv.Columns[0].HeaderText = "Базис";
            for (int i = 0; i < homory.Table.NumberOfRows; i++)
                dgv.Rows[i].Cells[0].Value = homory.Table.Basis[i] + 1;

            // freeValues
            dgv.Columns[1].HeaderText = "Вільні члени";
            for (int i = 0; i < homory.Table.NumberOfRows; i++)
                dgv.Rows[i].Cells[1].Value = Math.Round(homory.Table.FreeValues[i], 2);

            // variables
            for (int i = 0; i < homory.Table.NumberOfCollumns; i++)
            {
                dgv.Columns[i + 2].HeaderText = "X" + (i + 1);
                for (int j = 0; j < homory.Table.NumberOfRows; j++)
                    dgv.Rows[j].Cells[i + 2].Value = Math.Round(homory.Table.Variables[j][i], 2);
            }

            // function
            dgv.Rows[homory.Table.NumberOfRows].Cells[0].Value = "F";
            dgv.Rows[homory.Table.NumberOfRows].Cells[1].Value = homory.Table.FunctionResult;
            for (int i = 0; i < homory.Table.NumberOfCollumns; i++)
                dgv.Rows[homory.Table.NumberOfRows].Cells[i + 2].Value = Math.Round(homory.Table.Function[i], 2);


            // simplexTable
            if (homory.IsSimplexMethod)
            {
                // Estimate relations
                for (int i = 0; i < homory.Table.NumberOfRows; i++)
                {
                    if (homory.Table.EstimateRelations[i] < 0)
                        dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value = 1.0f / 0;
                    else 
                        dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value = Math.Round(homory.Table.EstimateRelations[i], 2);
                }
            }
            // double simplexTable
            else
            {
                // Estimate relations
                for (int i = 2; i < homory.Table.EstimateRelations.Length + 2; i++)
                {
                    if (Double.IsNaN(homory.Table.EstimateRelations[i - 2]))
                        dgv.Rows[dgv.RowCount - 1].Cells[i].Value = 1.0f / 0;
                    else
                        dgv.Rows[dgv.RowCount - 1].Cells[i].Value = Math.Round(homory.Table.EstimateRelations[i - 2], 2);
                }
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (_homory == null)
            {
                MessageBox.Show("Заповніть таблицю");
                return;
            }
            if (_homory.IsSimplexMethod)
            {
                _homory.Table.Next();
                FillDataGrid(_homory, dataGridView_Result);
                if (_homory.Table.Function[_homory.Table.MainCollumnForNextStep] >= 0)
                {
                    MessageBox.Show("Симплекс метод завершено");
                    _homory.IsSimplexMethod = false;
                    _homory.Table = ReadDoubleSimplexTableFromResult();
                }
            }
            else
            {
                // if double simplex table is over and all variables are int -> end of algorithm
                if (_homory.Table.IsEnd() && _homory.Table.IsAllVariablesInt())
                {
                    MessageBox.Show("Кінець алгоритму");
                    return;
                }


                // if double simplex table is over
                if (_homory.Table.IsEnd())
                {
                    //  add restriction
                    _homory.AddRestriction();
                }
                else
                    _homory.Table.Next();  // double simplex table next step

                if (_homory.Table.IsEnd() && _homory.Table.IsAllVariablesInt())
                    MessageBox.Show("Кінець алгоритму");

                FillDataGrid(_homory, dataGridView_Result);
            }
        }

        public DoubleSimplexTable ReadDoubleSimplexTableFromResult()
        {
            // головні змінні + для функції
            int numberOfCollumns = dataGridView_Result.ColumnCount - 3;
            // mainVariables + basis variables + basis + freeValues + EstimateRelations
            int numberOfRows = dataGridView_Result.RowCount - 1;

            // read free values
            double[] freeValues = new double[numberOfRows]; // last row for function
            for (int i = 0; i < numberOfRows; i++)
                freeValues[i] = _homory.Table.FreeValues[i];
            
            // read variables
            double[][] variables = new double[numberOfRows][];
            for (int i = 0; i < variables.Length; i++)
            {
                variables[i] = new double[numberOfCollumns];
                for (int j = 0; j < variables[i].Length; j++)
                    variables[i][j] = _homory.Table.Variables[i][j];
            }

            // read function
            double[] function = new double[numberOfCollumns];
            for (int i = 0; i < function.Length; i++)
                function[i] = _homory.Table.Function[i];

            // basis
            int[] basis = new int[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
                basis[i] = _homory.Table.Basis[i];

            DoubleSimplexTable table = new DoubleSimplexTable(numberOfRows, numberOfCollumns - numberOfRows, basis, freeValues, variables, function);
            table.FunctionResult = _homory.Table.FunctionResult;

            return table;
        }
    }
}
