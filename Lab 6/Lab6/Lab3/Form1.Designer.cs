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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_InputData = new System.Windows.Forms.TabPage();
            this.panel_InputData = new System.Windows.Forms.Panel();
            this.label_Collumns = new System.Windows.Forms.Label();
            this.button_Calculate_GomoryHu = new System.Windows.Forms.Button();
            this.numericUpDown_InputData_Collumns = new System.Windows.Forms.NumericUpDown();
            this.dataGridView_InputData = new System.Windows.Forms.DataGridView();
            this.tabPage_Result = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Refresh_GomoryHu = new System.Windows.Forms.Button();
            this.dataGridView_Result_GomoryHu = new System.Windows.Forms.DataGridView();
            this.button_Next_GomoryHu = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage_InputData.SuspendLayout();
            this.panel_InputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData)).BeginInit();
            this.tabPage_Result.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_GomoryHu)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(1177, 639);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_InputData
            // 
            this.tabPage_InputData.Controls.Add(this.panel_InputData);
            this.tabPage_InputData.Location = new System.Drawing.Point(4, 29);
            this.tabPage_InputData.Name = "tabPage_InputData";
            this.tabPage_InputData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_InputData.Size = new System.Drawing.Size(1169, 606);
            this.tabPage_InputData.TabIndex = 0;
            this.tabPage_InputData.Text = "Вхідні дані";
            this.tabPage_InputData.UseVisualStyleBackColor = true;
            // 
            // panel_InputData
            // 
            this.panel_InputData.Controls.Add(this.label_Collumns);
            this.panel_InputData.Controls.Add(this.button_Calculate_GomoryHu);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Collumns);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData);
            this.panel_InputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_InputData.Location = new System.Drawing.Point(3, 3);
            this.panel_InputData.Margin = new System.Windows.Forms.Padding(2);
            this.panel_InputData.Name = "panel_InputData";
            this.panel_InputData.Size = new System.Drawing.Size(1163, 600);
            this.panel_InputData.TabIndex = 28;
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
            // button_Calculate_GomoryHu
            // 
            this.button_Calculate_GomoryHu.AutoSize = true;
            this.button_Calculate_GomoryHu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Calculate_GomoryHu.Location = new System.Drawing.Point(986, 27);
            this.button_Calculate_GomoryHu.Margin = new System.Windows.Forms.Padding(2);
            this.button_Calculate_GomoryHu.Name = "button_Calculate_GomoryHu";
            this.button_Calculate_GomoryHu.Size = new System.Drawing.Size(138, 51);
            this.button_Calculate_GomoryHu.TabIndex = 26;
            this.button_Calculate_GomoryHu.Text = "Метод Гоморі Ху";
            this.button_Calculate_GomoryHu.UseVisualStyleBackColor = true;
            this.button_Calculate_GomoryHu.Click += new System.EventHandler(this.button_Calculate_GomoryHu_Click);
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
            this.dataGridView_InputData.Size = new System.Drawing.Size(1081, 457);
            this.dataGridView_InputData.TabIndex = 0;
            // 
            // tabPage_Result
            // 
            this.tabPage_Result.Controls.Add(this.panel3);
            this.tabPage_Result.Location = new System.Drawing.Point(4, 29);
            this.tabPage_Result.Name = "tabPage_Result";
            this.tabPage_Result.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Result.Size = new System.Drawing.Size(1169, 606);
            this.tabPage_Result.TabIndex = 1;
            this.tabPage_Result.Text = "Результати";
            this.tabPage_Result.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1163, 600);
            this.panel3.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button_Refresh_GomoryHu);
            this.panel2.Controls.Add(this.dataGridView_Result_GomoryHu);
            this.panel2.Controls.Add(this.button_Next_GomoryHu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1163, 600);
            this.panel2.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "Алгоритм Гоморі Ху";
            // 
            // button_Refresh_GomoryHu
            // 
            this.button_Refresh_GomoryHu.AutoSize = true;
            this.button_Refresh_GomoryHu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh_GomoryHu.Location = new System.Drawing.Point(618, 24);
            this.button_Refresh_GomoryHu.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh_GomoryHu.Name = "button_Refresh_GomoryHu";
            this.button_Refresh_GomoryHu.Size = new System.Drawing.Size(225, 51);
            this.button_Refresh_GomoryHu.TabIndex = 27;
            this.button_Refresh_GomoryHu.Text = "Обновити дані";
            this.button_Refresh_GomoryHu.UseVisualStyleBackColor = true;
            this.button_Refresh_GomoryHu.Click += new System.EventHandler(this.button_Refresh_GomoryHu_Click);
            // 
            // dataGridView_Result_GomoryHu
            // 
            this.dataGridView_Result_GomoryHu.AllowUserToAddRows = false;
            this.dataGridView_Result_GomoryHu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result_GomoryHu.ColumnHeadersHeight = 30;
            this.dataGridView_Result_GomoryHu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Result_GomoryHu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Result_GomoryHu.Enabled = false;
            this.dataGridView_Result_GomoryHu.EnableHeadersVisualStyles = false;
            this.dataGridView_Result_GomoryHu.Location = new System.Drawing.Point(40, 103);
            this.dataGridView_Result_GomoryHu.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Result_GomoryHu.Name = "dataGridView_Result_GomoryHu";
            this.dataGridView_Result_GomoryHu.ReadOnly = true;
            this.dataGridView_Result_GomoryHu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result_GomoryHu.RowTemplate.Height = 24;
            this.dataGridView_Result_GomoryHu.Size = new System.Drawing.Size(1081, 457);
            this.dataGridView_Result_GomoryHu.TabIndex = 28;
            // 
            // button_Next_GomoryHu
            // 
            this.button_Next_GomoryHu.AutoSize = true;
            this.button_Next_GomoryHu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next_GomoryHu.Location = new System.Drawing.Point(896, 24);
            this.button_Next_GomoryHu.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next_GomoryHu.Name = "button_Next_GomoryHu";
            this.button_Next_GomoryHu.Size = new System.Drawing.Size(225, 51);
            this.button_Next_GomoryHu.TabIndex = 26;
            this.button_Next_GomoryHu.Text = "Наступний крок";
            this.button_Next_GomoryHu.UseVisualStyleBackColor = true;
            this.button_Next_GomoryHu.Click += new System.EventHandler(this.button_Next_GomoryHu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 639);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result_GomoryHu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_InputData;
        private System.Windows.Forms.DataGridView dataGridView_InputData;
        private System.Windows.Forms.Label label_Collumns;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Collumns;
        private System.Windows.Forms.Button button_Calculate_GomoryHu;
        private System.Windows.Forms.Panel panel_InputData;
        private System.Windows.Forms.TabPage tabPage_Result;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Refresh_GomoryHu;
        private System.Windows.Forms.DataGridView dataGridView_Result_GomoryHu;
        private System.Windows.Forms.Button button_Next_GomoryHu;
    }
}

