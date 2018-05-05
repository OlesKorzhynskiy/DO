using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab5;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private int _numberOfNodes;

        public int NumberOfNodes
        {
            get => _numberOfNodes;
            set
            {
                _numberOfNodes = value;
                dataGridView_InputData.ColumnCount = value;
                dataGridView_InputData.RowCount = value;

                dataGridView_Result_GomoryHu.ColumnCount = 1;
                dataGridView_Result_GomoryHu.RowCount = 1;

                for (int i = 0; i < value; i++)
                {
                    dataGridView_InputData.Rows[i].HeaderCell.Value = @"Вузол " + (i + 1);
                    dataGridView_InputData.Columns[i].HeaderText = @"Вузол " + (i + 1);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialize data
            numericUpDown_InputData_Collumns.Value = 7;
            double[][] arr = new double[][]
            {
                new double[] {0, 14, 0, 0, 0, 0, 16},
                new double[] {14, 0, 8, 0, 7, 0, 0},
                new double[] {0, 8, 0, 4, 0, 0, 0},
                new double[] {0, 0, 4, 0, 8, 3, 4},
                new double[] {0, 7, 0, 8, 0, 0, 10},
                new double[] {0, 0, 0, 3, 0, 0, 9},
                new double[] {0, 0, 0, 4, 10, 9, 0}
            };

            for (int i = 0; i < NumberOfNodes; i++)
            for (int j = 0; j < NumberOfNodes; j++)
                dataGridView_InputData.Rows[i].Cells[j].Value = arr[i][j];
        }

        private void numericUpDown_InputData_Collumns_ValueChanged(object sender, EventArgs e)
        {
            NumberOfNodes = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
        }



        // GomoryHu Algorithm

        public List<GomoryHuMethod.Step> steps = new List<GomoryHuMethod.Step>();
        public int Iter = 0;

        private void button_Refresh_GomoryHu_Click(object sender, EventArgs e)
        {
            button_Next_GomoryHu.Enabled = true;
            button_Calculate_GomoryHu_Click(sender, e);
        }

        private void button_Next_GomoryHu_Click(object sender, EventArgs e)
        {
            clearDG(dataGridView_Result_GomoryHu);
            if (steps != null)
            {
                if (Iter < steps.Count() - 1)
                {
                    Iter++;
                    steps.ElementAt(Iter).Show(dataGridView_Result_GomoryHu);
                }
                else
                {
                    button_Next_GomoryHu.Enabled = false;
                }
            }
        }

        private void button_Calculate_GomoryHu_Click(object sender, EventArgs e)
        {
            clearDG(dataGridView_Result_GomoryHu);
            // read arcs
            List<ArcDot> arcs = new List<ArcDot>();
            for (int i = 0; i < dataGridView_InputData.RowCount; i++)
            {
                for (int j = 0; j < dataGridView_InputData.ColumnCount; j++)
                {
                    if (i == j) continue;
                    else if (!String.IsNullOrEmpty(dataGridView_InputData.Rows[i].Cells[j].Value.ToString()))
                    {
                        try
                        {
                            double value = Double.Parse(dataGridView_InputData.Rows[i].Cells[j].Value.ToString());
                            arcs.Add(new ArcDot(i + 1, j + 1, value));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильні дані в матриці");
                        }
                    }
                }
            }

            // create dots
            List<Dot> dots = new List<Dot>();
            for (int i = 0; i < dataGridView_InputData.RowCount; i++)
            {
                var arcsDot = arcs.FindAll(a => a.start == (i + 1));
                dots.Add(new Dot(i + 1, arcsDot));
            }
            
            // create gomory hu method
            GomoryHuMethod gomory = new GomoryHuMethod(dots);

            steps = gomory.Calculate();
            steps.First().Show(dataGridView_Result_GomoryHu);
            Iter = 0;

            tabControl.SelectedTab = tabControl.TabPages["tabPage_Result"];
        }

        private void clearDG(DataGridView DG)
        {
            for (int i = 0; i < DG.RowCount; i++)
            {
                for (int j = 0; j < DG.ColumnCount; j++)
                {
                    DG.Rows[i].Cells[i].Value = "".ToString();
                }
            }
        }
    }
}
