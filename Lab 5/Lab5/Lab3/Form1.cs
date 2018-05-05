using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3.Algorithm;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public DijkstrasAlgorithm DijkstrasAlgorithm;
        public FloydAlgorithm FloydAlgorithm;

        private int _numberOfNodes;

        public int NumberOfNodes
        {
            get => _numberOfNodes;
            set
            {
                dataGridView_Result_Dijkstra.RowCount = 2;
                dataGridView_Result_Dijkstra.Rows[0].HeaderCell.Value = @"d(x)";
                dataGridView_Result_Dijkstra.Rows[1].HeaderCell.Value = @"x";

                _numberOfNodes = value;
                dataGridView_InputData.ColumnCount = value;
                dataGridView_InputData.RowCount = value;

                dataGridView_Result_Dijkstra.ColumnCount = value;

                dataGridView_Result_Floyd_Path.ColumnCount = value;
                dataGridView_Result_Floyd_Path.RowCount = value;
                dataGridView_Result_Floyd_CameFrom.ColumnCount = value;
                dataGridView_Result_Floyd_CameFrom.RowCount = value;

                for (int i = 0; i < value; i++)
                {
                    dataGridView_InputData.Rows[i].HeaderCell.Value = @"Вузол " + (i + 1);
                    dataGridView_InputData.Columns[i].HeaderText = @"Вузол " + (i + 1);

                    dataGridView_Result_Dijkstra.Columns[i].HeaderText = @"Вузол " + (i + 1);

                    dataGridView_Result_Floyd_Path.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    dataGridView_Result_Floyd_Path.Columns[i].HeaderText = (i + 1).ToString();

                    dataGridView_Result_Floyd_CameFrom.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    dataGridView_Result_Floyd_CameFrom.Columns[i].HeaderText = (i + 1).ToString();
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
            numericUpDown_InputData_Collumns.Value = 11;
            double[][] arr = new double[][]
            {
                new double[] {0, 6, 3, 2, 8, 0, 0, 0, 0, 0, 0},
                new double[] {0, 0, 2, 0, 0, 0, 0, 8, 0, 0, 0},
                new double[] {0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0},
                new double[] {0, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0},
                new double[] {0, 0, 0, 0, 0, 14, 0, 0, 5, 0, 0},
                new double[] {0, 0, 0, 0, 0, 6, 11, 0, 0, 0, 0},
                new double[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0, 0, 12, 0, 0, 6, 0, 0, 0, 0, 0},
                new double[] {0, 0, 0, 0, 0, 11, 4, 0, 0, 2, 0},
                new double[] {0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 5},
                new double[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            for (int i = 0; i < NumberOfNodes; i++)
            for (int j = 0; j < NumberOfNodes; j++)
                dataGridView_InputData.Rows[i].Cells[j].Value = arr[i][j];
        }

        private void numericUpDown_InputData_Collumns_ValueChanged(object sender, EventArgs e)
        {
            NumberOfNodes = Convert.ToInt32(numericUpDown_InputData_Collumns.Value);
        }

        private void ReadDijkstrasAlgorithm()
        {
            var nodes = new List<Node>();
            for (int i = 0; i < NumberOfNodes; i++)
                nodes.Add(new Node());

            for (int i = 0; i < NumberOfNodes; i++)
            {
                for (int j = 0; j < NumberOfNodes; j++)
                {
                    if (dataGridView_InputData.Rows[i].Cells[j].Value != null && dataGridView_InputData.Rows[i].Cells[j].Value.ToString() != "0" && dataGridView_InputData.Rows[i].Cells[j].Value.ToString() != "")
                        nodes[i].NextNodes.Add(new NextNode() {Node = nodes[j], RelativePath = Convert.ToDouble(dataGridView_InputData.Rows[i].Cells[j].Value)});   
                }
            }

            DijkstrasAlgorithm = new DijkstrasAlgorithm(nodes);
        }
        private void WriteDijkstrasAlgorithm()
        {
            for (int i = 0; i < NumberOfNodes; i++)
            {
                // set color of header
                if (DijkstrasAlgorithm.Nodes[i].IsOut)
                    dataGridView_Result_Dijkstra.Columns[i].HeaderCell.Style.BackColor = Color.BlueViolet;
                else
                    dataGridView_Result_Dijkstra.Columns[i].HeaderCell.Style.BackColor = Color.White;

                dataGridView_Result_Dijkstra.Rows[0].Cells[i].Value = DijkstrasAlgorithm.Nodes[i].GeneralPath.ToString() != double.MaxValue.ToString() ? DijkstrasAlgorithm.Nodes[i].GeneralPath : 1.0f / 0;
                dataGridView_Result_Dijkstra.Rows[1].Cells[i].Value = DijkstrasAlgorithm.Nodes.IndexOf(DijkstrasAlgorithm.Nodes[i].PreviousNode) + 1;
            }
        }

        private void button_CalculateDijkstra_Click(object sender, EventArgs e)
        {
            ReadDijkstrasAlgorithm();
            WriteDijkstrasAlgorithm();
            tabControl.SelectedTab = tabControl.TabPages["tabPage_Result"];
        }

        private void button_Next_Dijkstra_Click(object sender, EventArgs e)
        {
            if (DijkstrasAlgorithm == null)
                button_CalculateDijkstra_Click(sender, e);
            
            if (DijkstrasAlgorithm.MakeStep())
                MessageBox.Show("Алгоритм Дейкстри закінчився");

            WriteDijkstrasAlgorithm();
        }

        private void button_Refresh_Dijkstra_Click(object sender, EventArgs e)
        {
            button_CalculateDijkstra_Click(sender, e);
        }


        // Floyd Algorithm
        private void ReadFloydAlgorithm()
        {
            double[][] arr = new double[NumberOfNodes][];
            for (int i = 0; i < NumberOfNodes; i++)
            {
                arr[i] = new double[NumberOfNodes];
                for (int j = 0; j < NumberOfNodes; j++)
                {
                    if (dataGridView_InputData.Rows[i].Cells[j].Value != null && dataGridView_InputData.Rows[i].Cells[j].Value.ToString() != "0" && dataGridView_InputData.Rows[i].Cells[j].Value.ToString() != "")
                        arr[i][j] = Convert.ToDouble(dataGridView_InputData.Rows[i].Cells[j].Value);
                    else
                        arr[i][j] = 0;
                }
            }

            FloydAlgorithm = new FloydAlgorithm(arr);
        }
        private void WriteFloydAlgorithm()
        {
            for (int i = 0; i < NumberOfNodes; i++)
            {
                for (int j = 0; j < NumberOfNodes; j++)
                {
                    // set color
                    if (FloydAlgorithm.Step == i || FloydAlgorithm.Step == j)
                        dataGridView_Result_Floyd_Path.Rows[i].Cells[j].Style.BackColor = Color.BlueViolet;
                    else
                        dataGridView_Result_Floyd_Path.Rows[i].Cells[j].Style.BackColor = Color.White;

                    // set values
                    if (i == j)
                        dataGridView_Result_Floyd_Path.Rows[i].Cells[j].Value = 0;
                    else 
                        dataGridView_Result_Floyd_Path.Rows[i].Cells[j].Value = FloydAlgorithm.Paths[i][j] != 0 ? FloydAlgorithm.Paths[i][j] : 1.0f / 0;
                    dataGridView_Result_Floyd_CameFrom.Rows[i].Cells[j].Value = FloydAlgorithm.ComeFrom[i][j] + 1; // start from 1
                }
            }
        }
        private void button_CalculateFloyd_Click(object sender, EventArgs e)
        {
            ReadFloydAlgorithm();
            WriteFloydAlgorithm();
            tabControl.SelectedTab = tabControl.TabPages["tabPage_Result"];
        }

        private void button_Refresh_Floyd_Click(object sender, EventArgs e)
        {
            button_CalculateFloyd_Click(sender, e);
        }

        private void button_Next_Floyd_Click(object sender, EventArgs e)
        {
            if (FloydAlgorithm == null)
                button_CalculateFloyd_Click(sender, e);

            if (FloydAlgorithm.MakeStep())
                MessageBox.Show("Алгоритм Флойда закінчився");

            WriteFloydAlgorithm();
        }
    }
}
