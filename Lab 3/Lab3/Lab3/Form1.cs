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
        public MainTable Table;
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
            dataGridView_Result_U.ColumnCount = 1;
            dataGridView_Result_V.RowCount = 1;

            // дані для ініціалізації
            numericUpDown_InputData_Rows.Value = 4;
            numericUpDown_InputData_Collumns.Value = 5;

            int[][] mainArray = { new[] { 10, 7, 4, 1, 4 }, new[] { 2, 7, 10, 6, 11 }, new[] { 8, 5, 3, 2, 2 }, new[] { 11, 8, 12, 16, 13 } };
            for (int i = 0; i < dataGridView_InputData_MainArray.RowCount; i++)
                for (int j = 0; j < dataGridView_InputData_MainArray.ColumnCount; j++)
                    dataGridView_InputData_MainArray.Rows[i].Cells[j].Value = mainArray[i][j];

            int[] stocksArray = { 100, 250, 200, 300 };
            for (int i = 0; i < dataGridView_InputData_Stocks.RowCount; i++)
                dataGridView_InputData_Stocks.Rows[i].Cells[0].Value = stocksArray[i];

            int[] requiresArray = { 200, 200, 100, 100, 250 };
            for (int i = 0; i < dataGridView_InputData_Requires.ColumnCount; i++)
                dataGridView_InputData_Requires.Rows[0].Cells[i].Value = requiresArray[i];

            comboBox_ChooseMethod.SelectedIndex = 0;
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
            dataGridView_Result_V.ColumnCount = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);

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
            dataGridView_Result_U.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);

            dataGridView_Result_SuppliersHeaders.RowCount = Convert.ToInt32(numericUpDown_InputData_Rows.Value);
            for (int i = 0; i < dataGridView_Result_SuppliersHeaders.RowCount; i++)
                dataGridView_Result_SuppliersHeaders.Rows[i].Cells[0].Value = "A" + (i + 1);
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                button_Next.Enabled = true;
                button_PotentialMethod.Enabled = false;
                dataGridView_ResultFoygel_CollumnsDifferences.Hide();
                dataGridView_ResultFoygel_RowsDifferences.Hide();
                dataGridView_Result_U.Hide();
                dataGridView_Result_V.Hide();

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
                Table = new MainTable(numberOfRows, numberOfCollumns, mainArray, stocks, requires);

                tabControl.SelectedIndex = 1;
                FillDataGridBasicPlan(Table);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FillDataGridBasicPlan(MainTable table)
        {
            // write result
            label_Result.Text = "Результат - " + Table.Result.ToString();

            // write mainArray
            for (int i = 0; i < table.NumberOfRows; i++)
            {
                for (int j = 0; j < table.NumberOfCollumns; j++)
                {
                    dataGridView_Result_MainArray.Rows[i].Cells[j].Style.BackColor = Color.White;
                    dataGridView_Result_MainArray.Rows[i].Cells[j].Value = table.MainArray[i][j];
                    if (Table.ExtraValues[i][j] != -1)
                        dataGridView_Result_MainArray.Rows[i].Cells[j].Value += " (" + table.ExtraValues[i][j] + ")";
                }
            }

            // write Stocks
            for (int i = 0; i < table.NumberOfRows; i++)
                dataGridView_Result_Stocks.Rows[i].Cells[0].Value = table.Stocks[i];

            // write Requires
            for (int i = 0; i < table.NumberOfCollumns; i++)
                dataGridView_Result_Requires.Rows[0].Cells[i].Value = table.Requires[i];

            if (comboBox_ChooseMethod.SelectedItem.ToString() == "Метод Фойгеля")
            {
                dataGridView_ResultFoygel_CollumnsDifferences.Show();
                dataGridView_ResultFoygel_RowsDifferences.Show();

                // fill rows difference
                dataGridView_ResultFoygel_RowsDifferences.RowCount = Table.NumberOfRows;
                dataGridView_ResultFoygel_RowsDifferences.ColumnCount = Table.RowsDifferences.Count;
                for (int i = 0; i < Table.RowsDifferences.Count; i++)
                for (int j = 0; j < Table.RowsDifferences[i].Length; j++)
                    dataGridView_ResultFoygel_RowsDifferences.Rows[j].Cells[i].Value = Table.RowsDifferences[i][j] == -1 ? "-" : Table.RowsDifferences[i][j].ToString();

                // fill collumns difference
                dataGridView_ResultFoygel_CollumnsDifferences.RowCount = Table.CollumnsDifferences.Count;
                dataGridView_ResultFoygel_CollumnsDifferences.ColumnCount = Table.NumberOfCollumns;
                for (int i = 0; i < Table.CollumnsDifferences.Count; i++)
                {
                    for (int j = 0; j < Table.CollumnsDifferences[i].Length; j++)
                    {
                        dataGridView_ResultFoygel_CollumnsDifferences.Rows[i].Cells[j].Value = Table.CollumnsDifferences[i][j] == -1 ? "-" : Table.CollumnsDifferences[i][j].ToString();
                    }
                }
            }

            // fill potentials
            for (int i = 0; i < Table.U.Length; i++)
                dataGridView_Result_U.Rows[i].Cells[0].Value = table.U[i];
            for (int i = 0; i < Table.V.Length; i++)
                dataGridView_Result_V.Rows[0].Cells[i].Value = table.V[i];

            // fill cycle
            if (table.Cycle != null)
                foreach (var element in table.Cycle)
                {
                    dataGridView_Result_MainArray.Rows[element.Position.X].Cells[element.Position.Y].Style.BackColor = Color.Aqua;
                    dataGridView_Result_MainArray.Rows[element.Position.X].Cells[element.Position.Y].Value += element.GetSign() == -1 ? "-" : "+";
                }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseMethod.SelectedItem.ToString() == "Північно-західний метод")
                Table.NorthWestMethodMakeStep();
            else if (comboBox_ChooseMethod.SelectedItem.ToString() == "Метод мінімального елементу")
                Table.MinElementMethodMakeStep();
            else if (comboBox_ChooseMethod.SelectedItem.ToString() == "Метод Фойгеля")
                Table.FoygelMethodMakeStep();

            Table.FindResult();
            FillDataGridBasicPlan(Table);

            if (Table.IsBasicWayFound())
            {
                MessageBox.Show("Опорний план знайдено");
                button_Next.Enabled = false;
                button_PotentialMethod.Enabled = true;
                dataGridView_Result_U.Show();
                dataGridView_Result_V.Show();

                Table.InitializePotentialMethod();
                FillDataGridBasicPlan(Table);
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            button_Calculate_Click(sender, e);
        }

        private void button_PotentialMethod_Click(object sender, EventArgs e)
        {
            if (!Table.IsBasicWayFound())
            {
                MessageBox.Show("Не задано базисний план");
                return;
            }
            if (Table.PotentialMethodMakeStep())
            {
                Table.FindResult();
                FillDataGridBasicPlan(Table);
                MessageBox.Show("Оптимальний план знайдено");
                button_PotentialMethod.Enabled = false;
                return;
            }
            Table.FindResult();
            FillDataGridBasicPlan(Table);
        }
    }
}
