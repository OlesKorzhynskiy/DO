using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public DifferentialRentMethod Table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // input data
            dataGridView_InputData_Stocks.ColumnCount = 1;
            dataGridView_InputData_SuppliersHeaders.ColumnCount = 1;
            dataGridView_InputData_Requires.RowCount = 1;
            dataGridView_InputData_CustomersHeaders.RowCount = 1;

            // result
            dataGridView_Result_Stocks.ColumnCount = 1;
            dataGridView_Result_SuppliersHeaders.ColumnCount = 1;
            dataGridView_Result_Requires.RowCount = 1;
            dataGridView_Result_CustomersHeaders.RowCount = 1;
            dataGridView_Result_ExcessiveAmount.ColumnCount = 1;
            dataGridView_Result_CollumnsDifferences.RowCount = 1;

            // дані для ініціалізації
            numericUpDown_InputData_Rows.Value = 5;
            numericUpDown_InputData_Collumns.Value = 4;

            double[][] mainArray = { new[] { 6.2, 1, 4.2, 5 }, new[] { 2, 4, 5.1, 8}, new[] { 5, 8, 3, 4.0 }, new[] { 2, 4, 9, 2.0 }, new []{ 4, 2.75, 2, 1 } };
            for (int i = 0; i < dataGridView_InputData_MainArray.RowCount; i++)
                for (int j = 0; j < dataGridView_InputData_MainArray.ColumnCount; j++)
                    dataGridView_InputData_MainArray.Rows[i].Cells[j].Value = mainArray[i][j];

            int[] stocksArray = { 17, 20, 40, 20, 23 };
            for (int i = 0; i < dataGridView_InputData_Stocks.RowCount; i++)
                dataGridView_InputData_Stocks.Rows[i].Cells[0].Value = stocksArray[i];

            int[] requiresArray = { 45, 30, 25, 20 };
            for (int i = 0; i < dataGridView_InputData_Requires.ColumnCount; i++)
                dataGridView_InputData_Requires.Rows[0].Cells[i].Value = requiresArray[i];
        }

        private void numericUpDown_InputData_Collumns_ValueChanged(object sender, EventArgs e)
        {
            // input data
            dataGridView_InputData_MainArray.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            dataGridView_InputData_Requires.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

            dataGridView_InputData_CustomersHeaders.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            for (int i = 0; i < dataGridView_InputData_CustomersHeaders.ColumnCount; i++)
                dataGridView_InputData_CustomersHeaders.Rows[0].Cells[i].Value = "B" + (i + 1);

            // result
            dataGridView_Result_MainArray.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            dataGridView_Result_Requires.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            dataGridView_Result_CollumnsDifferences.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);


            dataGridView_Result_CustomersHeaders.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
            for (int i = 0; i < dataGridView_Result_CustomersHeaders.ColumnCount; i++)
                dataGridView_Result_CustomersHeaders.Rows[0].Cells[i].Value = "B" + (i + 1);
            }

        private void numericUpDown_InputData_Rows_ValueChanged(object sender, EventArgs e)
        {
            // input data
            dataGridView_InputData_MainArray.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            dataGridView_InputData_Stocks.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);

            dataGridView_InputData_SuppliersHeaders.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            for (int i = 0; i < dataGridView_InputData_SuppliersHeaders.RowCount; i++)
                dataGridView_InputData_SuppliersHeaders.Rows[i].Cells[0].Value = "A" + (i + 1);

            // result
            dataGridView_Result_MainArray.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            dataGridView_Result_Stocks.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            dataGridView_Result_ExcessiveAmount.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);

            dataGridView_Result_SuppliersHeaders.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            for (int i = 0; i < dataGridView_Result_SuppliersHeaders.RowCount; i++)
                dataGridView_Result_SuppliersHeaders.Rows[i].Cells[0].Value = "A" + (i + 1);
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                button_Next.Enabled = true;

                int numberOfRows = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
                int numberOfCollumns = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

                // read mainArray
                double[][] mainArray = new double[numberOfRows][];
                for (int i = 0; i < numberOfRows; i++)
                    mainArray[i] = new double[numberOfCollumns];

                for (int i = 0; i < numberOfRows; i++)
                for (int j = 0; j < numberOfCollumns; j++)
                    mainArray[i][j] = Convert.ToDouble(dataGridView_InputData_MainArray.Rows[i].Cells[j].Value);

                // read Stocks
                double[] stocks = new double[numberOfRows];
                for (int i = 0; i < numberOfRows; i++)
                    stocks[i] = Convert.ToDouble(dataGridView_InputData_Stocks.Rows[i].Cells[0].Value);

                // read Requires
                double[] requires = new double[numberOfCollumns];
                for (int i = 0; i < numberOfCollumns; i++)
                    requires[i] = Convert.ToDouble(dataGridView_InputData_Requires.Rows[0].Cells[i].Value);

                // initialize Table
                Table = new DifferentialRentMethod(numberOfRows, numberOfCollumns, mainArray, stocks, requires);

                tabControl.SelectedIndex = 1;
                Table.Initialize();
                FillDataGrid(Table);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            // make step
            if (Table.MakeStep())
            {
                // optimal plan found
                MessageBox.Show("Оптимальний план знайдено");
                button_Next.Enabled = false;
            }
            FillDataGrid(Table);
        }

        private void FillDataGrid(DifferentialRentMethod table)
        {
            // write result
            label_Result.Text = @"Результат - " + Table.Result;

            // write mainArray
            for (int i = 0; i < table.NumberOfRows; i++)
            {
                for (int j = 0; j < table.NumberOfCollumns; j++)
                {
                    dataGridView_Result_MainArray.Rows[i].Cells[j].Style.BackColor = Color.White;
                    dataGridView_Result_MainArray.Rows[i].Cells[j].Value = table.MainArray[i][j];

                    // write engageCell
                    var engageCell = Table.EngageCells.Find(cell => cell.Position.X == i && cell.Position.Y == j);
                    if (engageCell != null)
                        dataGridView_Result_MainArray.Rows[i].Cells[j].Value += " (" + engageCell.Amount + ")";
                }
            }

            // write Stocks
            for (int i = 0; i < table.NumberOfRows; i++)
                dataGridView_Result_Stocks.Rows[i].Cells[0].Value = table.Stocks[i];

            // write Requires
            for (int i = 0; i < table.NumberOfCollumns; i++)
                dataGridView_Result_Requires.Rows[0].Cells[i].Value = table.Requires[i];

            // write ExcessiveAmount
            for (int i = 0; i < table.NumberOfRows; i++)
                dataGridView_Result_ExcessiveAmount.Rows[i].Cells[0].Value = table.ExcessiveAmount[i];

            // write CollumnsDifferences
            for (int i = 0; i < table.NumberOfCollumns; i++)
                dataGridView_Result_CollumnsDifferences.Rows[0].Cells[i].Value = table.CollumnsDifferences[i] == -1 ? "-" : table.CollumnsDifferences[i].ToString();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            button_Calculate_Click(sender, e);
        }
    }
}
