namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_InputData = new System.Windows.Forms.TabPage();
            this.panel_InputData = new System.Windows.Forms.Panel();
            this.button_CalculateFloyd = new System.Windows.Forms.Button();
            this.label_Collumns = new System.Windows.Forms.Label();
            this.button_CalculateDijkstra = new System.Windows.Forms.Button();
            this.numericUpDown_InputData_Collumns = new System.Windows.Forms.NumericUpDown();
            this.dataGridView_InputData = new System.Windows.Forms.DataGridView();
            this.tabPage_Result = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Result_Floyd_CameFrom = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Refresh_Floyd = new System.Windows.Forms.Button();
            this.dataGridView_Result_Floyd_Path = new System.Windows.Forms.DataGridView();
            this.button_Next_Floyd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Refresh_Dijkstra = new System.Windows.Forms.Button();
            this.dataGridView_Result_Dijkstra = new System.Windows.Forms.DataGridView();
            this.button_Next_Dijkstra = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage_InputData.SuspendLayout();
            this.panel_InputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData)).BeginInit();
            this.tabPage_Result.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Floyd_CameFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Floyd_Path)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Dijkstra)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_InputData);
            this.tabControl.Controls.Add(this.tabPage_Result);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1177, 821);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_InputData
            // 
            this.tabPage_InputData.Controls.Add(this.panel_InputData);
            this.tabPage_InputData.Location = new System.Drawing.Point(4, 29);
            this.tabPage_InputData.Name = "tabPage_InputData";
            this.tabPage_InputData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_InputData.Size = new System.Drawing.Size(1169, 788);
            this.tabPage_InputData.TabIndex = 0;
            this.tabPage_InputData.Text = "Вхідні дані";
            this.tabPage_InputData.UseVisualStyleBackColor = true;
            // 
            // panel_InputData
            // 
            this.panel_InputData.Controls.Add(this.button_CalculateFloyd);
            this.panel_InputData.Controls.Add(this.label_Collumns);
            this.panel_InputData.Controls.Add(this.button_CalculateDijkstra);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Collumns);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData);
            this.panel_InputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_InputData.Location = new System.Drawing.Point(3, 3);
            this.panel_InputData.Margin = new System.Windows.Forms.Padding(2);
            this.panel_InputData.Name = "panel_InputData";
            this.panel_InputData.Size = new System.Drawing.Size(1163, 782);
            this.panel_InputData.TabIndex = 28;
            // 
            // button_CalculateFloyd
            // 
            this.button_CalculateFloyd.AutoSize = true;
            this.button_CalculateFloyd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CalculateFloyd.Location = new System.Drawing.Point(829, 27);
            this.button_CalculateFloyd.Margin = new System.Windows.Forms.Padding(2);
            this.button_CalculateFloyd.Name = "button_CalculateFloyd";
            this.button_CalculateFloyd.Size = new System.Drawing.Size(135, 51);
            this.button_CalculateFloyd.TabIndex = 27;
            this.button_CalculateFloyd.Text = "Метод Флойда";
            this.button_CalculateFloyd.UseVisualStyleBackColor = true;
            this.button_CalculateFloyd.Click += new System.EventHandler(this.button_CalculateFloyd_Click);
            // 
            // label_Collumns
            // 
            this.label_Collumns.AutoSize = true;
            this.label_Collumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Collumns.Location = new System.Drawing.Point(37, 42);
            this.label_Collumns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Collumns.Name = "label_Collumns";
            this.label_Collumns.Size = new System.Drawing.Size(130, 20);
            this.label_Collumns.TabIndex = 2;
            this.label_Collumns.Text = "кількість вузлів:";
            // 
            // button_CalculateDijkstra
            // 
            this.button_CalculateDijkstra.AutoSize = true;
            this.button_CalculateDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CalculateDijkstra.Location = new System.Drawing.Point(986, 27);
            this.button_CalculateDijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.button_CalculateDijkstra.Name = "button_CalculateDijkstra";
            this.button_CalculateDijkstra.Size = new System.Drawing.Size(135, 51);
            this.button_CalculateDijkstra.TabIndex = 26;
            this.button_CalculateDijkstra.Text = "Метод Дейкстри";
            this.button_CalculateDijkstra.UseVisualStyleBackColor = true;
            this.button_CalculateDijkstra.Click += new System.EventHandler(this.button_CalculateDijkstra_Click);
            // 
            // numericUpDown_InputData_Collumns
            // 
            this.numericUpDown_InputData_Collumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_InputData_Collumns.Location = new System.Drawing.Point(223, 40);
            this.numericUpDown_InputData_Collumns.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_InputData_Collumns.Name = "numericUpDown_InputData_Collumns";
            this.numericUpDown_InputData_Collumns.Size = new System.Drawing.Size(44, 26);
            this.numericUpDown_InputData_Collumns.TabIndex = 6;
            this.numericUpDown_InputData_Collumns.ValueChanged += new System.EventHandler(this.numericUpDown_InputData_Collumns_ValueChanged);
            // 
            // dataGridView_InputData
            // 
            this.dataGridView_InputData.AllowUserToAddRows = false;
            this.dataGridView_InputData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData.ColumnHeadersHeight = 30;
            this.dataGridView_InputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_InputData.Location = new System.Drawing.Point(40, 103);
            this.dataGridView_InputData.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_InputData.Name = "dataGridView_InputData";
            this.dataGridView_InputData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_InputData.RowTemplate.Height = 24;
            this.dataGridView_InputData.Size = new System.Drawing.Size(1081, 635);
            this.dataGridView_InputData.TabIndex = 0;
            // 
            // tabPage_Result
            // 
            this.tabPage_Result.Controls.Add(this.panel3);
            this.tabPage_Result.Location = new System.Drawing.Point(4, 29);
            this.tabPage_Result.Name = "tabPage_Result";
            this.tabPage_Result.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Result.Size = new System.Drawing.Size(1169, 788);
            this.tabPage_Result.TabIndex = 1;
            this.tabPage_Result.Text = "Результати";
            this.tabPage_Result.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1163, 782);
            this.panel3.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_Result_Floyd_CameFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button_Refresh_Floyd);
            this.panel2.Controls.Add(this.dataGridView_Result_Floyd_Path);
            this.panel2.Controls.Add(this.button_Next_Floyd);
            this.panel2.Location = new System.Drawing.Point(5, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 578);
            this.panel2.TabIndex = 30;
            // 
            // dataGridView_Result_Floyd_CameFrom
            // 
            this.dataGridView_Result_Floyd_CameFrom.AllowUserToAddRows = false;
            this.dataGridView_Result_Floyd_CameFrom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result_Floyd_CameFrom.ColumnHeadersHeight = 30;
            this.dataGridView_Result_Floyd_CameFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Result_Floyd_CameFrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Result_Floyd_CameFrom.Enabled = false;
            this.dataGridView_Result_Floyd_CameFrom.EnableHeadersVisualStyles = false;
            this.dataGridView_Result_Floyd_CameFrom.Location = new System.Drawing.Point(619, 67);
            this.dataGridView_Result_Floyd_CameFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Result_Floyd_CameFrom.Name = "dataGridView_Result_Floyd_CameFrom";
            this.dataGridView_Result_Floyd_CameFrom.ReadOnly = true;
            this.dataGridView_Result_Floyd_CameFrom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result_Floyd_CameFrom.RowTemplate.Height = 24;
            this.dataGridView_Result_Floyd_CameFrom.Size = new System.Drawing.Size(500, 500);
            this.dataGridView_Result_Floyd_CameFrom.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(34, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "Алгоритм Флойда";
            // 
            // button_Refresh_Floyd
            // 
            this.button_Refresh_Floyd.AutoSize = true;
            this.button_Refresh_Floyd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh_Floyd.Location = new System.Drawing.Point(619, 0);
            this.button_Refresh_Floyd.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh_Floyd.Name = "button_Refresh_Floyd";
            this.button_Refresh_Floyd.Size = new System.Drawing.Size(225, 51);
            this.button_Refresh_Floyd.TabIndex = 27;
            this.button_Refresh_Floyd.Text = "Обновити дані";
            this.button_Refresh_Floyd.UseVisualStyleBackColor = true;
            this.button_Refresh_Floyd.Click += new System.EventHandler(this.button_Refresh_Floyd_Click);
            // 
            // dataGridView_Result_Floyd_Path
            // 
            this.dataGridView_Result_Floyd_Path.AllowUserToAddRows = false;
            this.dataGridView_Result_Floyd_Path.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result_Floyd_Path.ColumnHeadersHeight = 30;
            this.dataGridView_Result_Floyd_Path.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Result_Floyd_Path.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Result_Floyd_Path.Enabled = false;
            this.dataGridView_Result_Floyd_Path.EnableHeadersVisualStyles = false;
            this.dataGridView_Result_Floyd_Path.Location = new System.Drawing.Point(38, 67);
            this.dataGridView_Result_Floyd_Path.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Result_Floyd_Path.Name = "dataGridView_Result_Floyd_Path";
            this.dataGridView_Result_Floyd_Path.ReadOnly = true;
            this.dataGridView_Result_Floyd_Path.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result_Floyd_Path.RowTemplate.Height = 24;
            this.dataGridView_Result_Floyd_Path.Size = new System.Drawing.Size(500, 500);
            this.dataGridView_Result_Floyd_Path.TabIndex = 28;
            // 
            // button_Next_Floyd
            // 
            this.button_Next_Floyd.AutoSize = true;
            this.button_Next_Floyd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next_Floyd.Location = new System.Drawing.Point(894, 0);
            this.button_Next_Floyd.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next_Floyd.Name = "button_Next_Floyd";
            this.button_Next_Floyd.Size = new System.Drawing.Size(225, 51);
            this.button_Next_Floyd.TabIndex = 26;
            this.button_Next_Floyd.Text = "Наступний крок";
            this.button_Next_Floyd.UseVisualStyleBackColor = true;
            this.button_Next_Floyd.Click += new System.EventHandler(this.button_Next_Floyd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_Refresh_Dijkstra);
            this.panel1.Controls.Add(this.dataGridView_Result_Dijkstra);
            this.panel1.Controls.Add(this.button_Next_Dijkstra);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 187);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Алгоритм Дейкстри";
            // 
            // button_Refresh_Dijkstra
            // 
            this.button_Refresh_Dijkstra.AutoSize = true;
            this.button_Refresh_Dijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh_Dijkstra.Location = new System.Drawing.Point(619, 23);
            this.button_Refresh_Dijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh_Dijkstra.Name = "button_Refresh_Dijkstra";
            this.button_Refresh_Dijkstra.Size = new System.Drawing.Size(225, 51);
            this.button_Refresh_Dijkstra.TabIndex = 27;
            this.button_Refresh_Dijkstra.Text = "Обновити дані";
            this.button_Refresh_Dijkstra.UseVisualStyleBackColor = true;
            this.button_Refresh_Dijkstra.Click += new System.EventHandler(this.button_Refresh_Dijkstra_Click);
            // 
            // dataGridView_Result_Dijkstra
            // 
            this.dataGridView_Result_Dijkstra.AllowUserToAddRows = false;
            this.dataGridView_Result_Dijkstra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result_Dijkstra.ColumnHeadersHeight = 30;
            this.dataGridView_Result_Dijkstra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Result_Dijkstra.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Result_Dijkstra.Enabled = false;
            this.dataGridView_Result_Dijkstra.EnableHeadersVisualStyles = false;
            this.dataGridView_Result_Dijkstra.Location = new System.Drawing.Point(38, 90);
            this.dataGridView_Result_Dijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Result_Dijkstra.Name = "dataGridView_Result_Dijkstra";
            this.dataGridView_Result_Dijkstra.ReadOnly = true;
            this.dataGridView_Result_Dijkstra.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result_Dijkstra.RowTemplate.Height = 24;
            this.dataGridView_Result_Dijkstra.Size = new System.Drawing.Size(1081, 80);
            this.dataGridView_Result_Dijkstra.TabIndex = 28;
            // 
            // button_Next_Dijkstra
            // 
            this.button_Next_Dijkstra.AutoSize = true;
            this.button_Next_Dijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next_Dijkstra.Location = new System.Drawing.Point(894, 23);
            this.button_Next_Dijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next_Dijkstra.Name = "button_Next_Dijkstra";
            this.button_Next_Dijkstra.Size = new System.Drawing.Size(225, 51);
            this.button_Next_Dijkstra.TabIndex = 26;
            this.button_Next_Dijkstra.Text = "Наступний крок";
            this.button_Next_Dijkstra.UseVisualStyleBackColor = true;
            this.button_Next_Dijkstra.Click += new System.EventHandler(this.button_Next_Dijkstra_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 821);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Лабораторна робота №5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage_InputData.ResumeLayout(false);
            this.panel_InputData.ResumeLayout(false);
            this.panel_InputData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData)).EndInit();
            this.tabPage_Result.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Floyd_CameFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Floyd_Path)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_Dijkstra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_InputData;
        private System.Windows.Forms.DataGridView dataGridView_InputData;
        private System.Windows.Forms.Label label_Collumns;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Collumns;
        private System.Windows.Forms.Button button_CalculateDijkstra;
        private System.Windows.Forms.Panel panel_InputData;
        private System.Windows.Forms.TabPage tabPage_Result;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Next_Dijkstra;
        private System.Windows.Forms.Button button_Refresh_Dijkstra;
        private System.Windows.Forms.DataGridView dataGridView_Result_Dijkstra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_Result_Floyd_CameFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Refresh_Floyd;
        private System.Windows.Forms.DataGridView dataGridView_Result_Floyd_Path;
        private System.Windows.Forms.Button button_Next_Floyd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CalculateFloyd;
    }
}

