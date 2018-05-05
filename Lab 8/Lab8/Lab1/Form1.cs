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
        private SimplexTable _table;
        private MatrixGame _matrixGame;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown_InputData_Collumns_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_InputData_Methods.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

            foreach (DataGridViewColumn column in dataGridView_InputData_Methods.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void numericUpDown_InputData_Rows_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_InputData_Methods.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // дані для ініціалізації
            numericUpDown_InputData_Rows.Value = 3;
            numericUpDown_InputData_Collumns.Value = 4;

            int[][] methodsArray = { new [] {6, 7, 8, 1}, new []{6, 2, 6, 9}, new []{4, 1, 3, 2} };
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
                for (int j = 0; j < dataGridView_InputData_Methods.ColumnCount; j++)
                    dataGridView_InputData_Methods.Rows[i].Cells[j].Value = methodsArray[i][j];
        }

        // algorithm
        private void button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_matrixGame == null)
                    _matrixGame = ReadMatrixGame();

                if (_matrixGame.MakeStep())
                {
                    button_Calculate.Enabled = false;
                    button_Next.Enabled = true;
                }
                WriteMatrixGame(_matrixGame);
            }
            catch (Exception exception)
            {
                ShowResult();
            }
        }

        private void WriteMatrixGame(MatrixGame matrixGame)
        {
            dataGridView_InputData_Methods.RowCount = matrixGame.Array.Count;
            dataGridView_InputData_Methods.ColumnCount = matrixGame.Array.First().Count;
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
            {
                for (int j = 0; j < dataGridView_InputData_Methods.ColumnCount; j++)
                    dataGridView_InputData_Methods.Rows[i].Cells[j].Value = matrixGame.Array[i][j];
            }
        }

        private void ShowResult()
        {
            double[] aresultVariables = new double[_matrixGame.Array.First().Count];
            for (int i = 0; i < aresultVariables.Length; i++)
            {
                if (i < _table.Basis.Length && Array.IndexOf(_table.Basis, i) != -1)
                aresultVariables[i] = _table.FreeValues[Array.IndexOf(_table.Basis, i)];
            }
            double Q = 1 / aresultVariables.Sum();

            double[] aresult = new double[aresultVariables.Length];
            for (int i = 0; i < aresult.Length; i++)
                aresult[i] = aresultVariables[i] * Q;

            label_A.Text = "A: ( ";
            for (int i = 0; i < aresult.Length; i++)
                label_A.Text += String.Format("{0:0.00}", aresult[i]) + "; ";
            label_A.Text += ")";

            double[] bresultVariables = new double[_table.Function.Length - aresultVariables.Length];
            for (int i = aresultVariables.Length; i < _table.Function.Length; i++)
                bresultVariables[i - aresultVariables.Length] = _table.Function[i];

            double F = 1 / bresultVariables.Sum();

            double[] bresult = new double[bresultVariables.Length];
            for (int i = 0; i < bresult.Length; i++)
                bresult[i] = bresultVariables[i] * F;

            label_B.Text = "A: (";
            for (int i = 0; i < bresult.Length; i++)
                label_B.Text += String.Format("{0:0.00}", bresult[i]) + "; ";
            label_B.Text += ")";
        }

        private MatrixGame ReadMatrixGame()
        {
            List<List<double>> list = new List<List<double>>();
            for (int i = 0; i < dataGridView_InputData_Methods.RowCount; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < dataGridView_InputData_Methods.ColumnCount; j++)
                    row.Add(Convert.ToDouble(dataGridView_InputData_Methods.Rows[i].Cells[j].Value));
                list.Add(row);
            }

            return new MatrixGame(list);
        }

        private void ReadSimplexMethod()
        {
            ClearDataGridColor(dataGridView_Result);

            int numberOfRows = dataGridView_InputData_Methods.RowCount;
            int numberOfCollumns = dataGridView_InputData_Methods.ColumnCount;

            double[][] mainArray = new double[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                mainArray[i] = new double[numberOfCollumns];
                for (int j = 0; j < numberOfCollumns; j++)
                    mainArray[i][j] = Convert.ToDouble(dataGridView_InputData_Methods.Rows[i].Cells[j].Value);
            }

            double[] function = new double[numberOfCollumns];
            for (int i = 0; i < numberOfCollumns; i++)
                function[i] = 1;

            double[] freeValues = new double[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
                freeValues[i] = 1;

            Compare[] signs = new Compare[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                signs[i] = Compare.LessEqual;
            }

            Direction direction = Direction.Max;

            SimplexMethod simplexMethod = new SimplexMethod(numberOfRows, numberOfCollumns, mainArray, function,
                freeValues, signs, direction);

            _table = simplexMethod.MakeSimplexTable();

            FillDataGrid(_table, dataGridView_Result);

            if (_table.Function[_table.MainCollumnForNextStep] >= 0)
                MessageBox.Show("Оптимальний план знайдено.\nЗначення функції - " + _table.FunctionResult + ".");
        }

        public void FillDataGrid(AbstractSimplexTable table, DataGridView dgv)
        {
            // головні змінні + для функції
            dgv.RowCount = table.NumberOfRows + 1;
            // mainVariables + basis variables + basis + freeValues + EstimateRelations
            dgv.ColumnCount = table.NumberOfCollumns + 3;

            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Rows[table.MainRowForNextStep].Cells[table.MainCollumnForNextStep + 2].Style.BackColor =
                Color.AntiqueWhite;
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

            // function
            dgv.Rows[table.NumberOfRows].Cells[0].Value = "F";
            dgv.Rows[table.NumberOfRows].Cells[1].Value = table.FunctionResult;
            for (int i = 0; i < table.NumberOfCollumns; i++)
                dgv.Rows[table.NumberOfRows].Cells[i + 2].Value = String.Format("{0:0.00}", table.Function[i]);

            // Estimate relations
            for (int i = 0; i < table.NumberOfRows; i++)
            {
                if (table.EstimateRelations[i] < 0)
                    dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value = 1.0f / 0;
                else
                    dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value =
                        String.Format("{0:0.00}", table.EstimateRelations[i]);
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (_table == null)
            {
                ReadSimplexMethod();
                FillDataGrid(_table, dataGridView_Result);
                return;
            }

            _table.Next();
            FillDataGrid(_table, dataGridView_Result);

            if (_table.Function[_table.MainCollumnForNextStep] >= 0)
            {
                ShowResult();
                button_Next.Enabled = false;
            }
        }


        // extras functions
        public void ClearDataGridColor(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            _matrixGame = null;
            _table = null;

            dataGridView_InputData_Methods.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            dataGridView_InputData_Methods.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

            button_Calculate.Enabled = true;
        }
    }
}
