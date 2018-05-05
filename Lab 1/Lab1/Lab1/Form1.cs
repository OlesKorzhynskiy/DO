using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private AbstractSimplexTable _table;

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
            numericUpDown_InputData_Rows.Value = 3;
            numericUpDown_InputData_Collumns.Value = 4;

            int[][] methodsArray = { new [] {1, 0, 2, 1}, new []{0, 1, 3, 2}, new []{4, 2, 0, 4}};
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
                for (int j = 0; j < dataGridView_InputData_Methods.ColumnCount; j++)
                    dataGridView_InputData_Methods.Rows[i].Cells[j].Value = methodsArray[i][j];

            int[] freeValuesArray = {180, 210, 800};
            for (int i = 0; i < dataGridView_InputData_FreeValues.RowCount; i++)
                dataGridView_InputData_FreeValues.Rows[i].Cells[0].Value = freeValuesArray[i];

            int[] funcitonArray = {9, 6, 4, 7};
            for (int i = 0; i < dataGridView_InputData_Function.ColumnCount; i++)
                dataGridView_InputData_Function.Rows[0].Cells[i].Value = funcitonArray[i];

            comboBox_ChooseMethod.SelectedIndex = 0;
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDataGrid(dataGridView_Result);

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


                if (comboBox_ChooseMethod.SelectedIndex == 0)
                    _table = simplexMethod.MakeSimplexTable();
                else
                    _table = simplexMethod.MakeDoubleSimplexTable();
                FillDataGrid(_table, dataGridView_Result);

                if (comboBox_ChooseMethod.SelectedIndex == 0 && _table.Function[_table.MainCollumnForNextStep] >= 0)
                    MessageBox.Show("Оптимальний план знайдено.\nЗначення функції - " + _table.FunctionResult + ".");
                if (comboBox_ChooseMethod.SelectedIndex == 1 && _table.FreeValues[_table.MainRowForNextStep] >= 0)
                    MessageBox.Show("Оптимальний план знайдено.\nЗначення функції - " + _table.FunctionResult + ".");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void ClearDataGrid(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                    dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
        }

        public void FillDataGrid(AbstractSimplexTable table, DataGridView dgv)
        {
            // simplexTable
            if (comboBox_ChooseMethod.SelectedIndex == 0)
            {
                // головні змінні + для функції
                dgv.RowCount = table.NumberOfRows + 1;
                // mainVariables + basis variables + basis + freeValues + EstimateRelations
                dgv.ColumnCount = table.NumberOfCollumns + 3;
            }
            else
            {
                //doubleSimplexTable
                // головні змінні + для функції + EstimateRelations
                dgv.RowCount = table.NumberOfRows + 2;
                // mainVariables + basis variables + basis + freeValues
                dgv.ColumnCount = table.NumberOfCollumns + 2;
            }
            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Rows[table.MainRowForNextStep].Cells[table.MainCollumnForNextStep + 2].Style.BackColor = Color.AntiqueWhite;
            if (table.MainRow != -1)
                dgv.Rows[table.MainRow].Cells[table.MainCollumn + 2].Style.BackColor = Color.White;

            // basis
            dgv.Columns[0].HeaderText = "Базис";
            for (int i = 0; i < table.NumberOfRows; i++)
                dgv.Rows[i].Cells[0].Value = "X" + (table.Basis[i] + 1);

            // freeValues
            dgv.Columns[1].HeaderText = "Вільні члени";
            for (int i = 0; i < table.NumberOfRows; i++)
                dgv.Rows[i].Cells[1].Value = String.Format("{0:0.00}", table.FreeValues[i]);

            // variables
            for (int i = 0; i < table.NumberOfCollumns; i++)
            {
                dgv.Columns[i + 2].HeaderText = "X" + (i + 1);
                for (int j = 0; j < table.NumberOfRows; j++)
                    dgv.Rows[j].Cells[i + 2].Value = String.Format("{0:0.00}", table.Variables[j][i]);
            }
            // variables
            for (int i = 0; i < table.NumberOfCollumns; i++)
            {
                dgv.Columns[i + 2].HeaderText = "X" + (i + 1);
                for (int j = 0; j < table.NumberOfRows; j++)
                    dgv.Rows[j].Cells[i + 2].Value = String.Format("{0:0.00}", table.Variables[j][i]);
            }

            // function
            dgv.Rows[table.NumberOfRows].Cells[0].Value = "F";
            dgv.Rows[table.NumberOfRows].Cells[1].Value = table.FunctionResult;
            for (int i = 0; i < table.NumberOfCollumns; i++)
                dgv.Rows[table.NumberOfRows].Cells[i + 2].Value = String.Format("{0:0.00}", table.Function[i]);


            // simplexTable
            if (comboBox_ChooseMethod.SelectedIndex == 0)
            {
                // Estimate relations
                for (int i = 0; i < table.NumberOfRows; i++)
                {
                    if (table.EstimateRelations[i] < 0)
                        dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value = 1.0f / 0;
                    else 
                        dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value = String.Format("{0:0.00}", table.EstimateRelations[i]);
                }
            }
            // double simplexTable
            else
            {
                // Estimate relations
                for (int i = 2; i < table.EstimateRelations.Length + 2; i++)
                {
                    if (Double.IsNaN(table.EstimateRelations[i - 2]))
                        dgv.Rows[dgv.RowCount - 1].Cells[i].Value = 1.0f / 0;
                    else
                        dgv.Rows[dgv.RowCount - 1].Cells[i].Value = String.Format("{0:0.00}", table.EstimateRelations[i - 2]);
                }
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (_table != null && comboBox_ChooseMethod.SelectedIndex == 0)
            {
                _table.Next();
                FillDataGrid(_table, dataGridView_Result);
                if (_table.Function[_table.MainCollumnForNextStep] >= 0)
                    MessageBox.Show("Оптимальний план знайдено.\nЗначення функції - " + _table.FunctionResult + ".");
            }
            if (_table != null && comboBox_ChooseMethod.SelectedIndex == 1)
            {
                _table.Next();
                FillDataGrid(_table, dataGridView_Result);
                if (_table.FreeValues[_table.MainRowForNextStep] >= 0)
                    MessageBox.Show("Оптимальний план знайдено.\nЗначення функції - " + _table.FunctionResult + ".");
            }
        }
    }
}
