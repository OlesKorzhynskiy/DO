namespace Lab1
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
            this.dataGridView_InputData_Methods = new System.Windows.Forms.DataGridView();
            this.panel_InputData = new System.Windows.Forms.Panel();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.label_Rows = new System.Windows.Forms.Label();
            this.label_Collumns = new System.Windows.Forms.Label();
            this.numericUpDown_InputData_Rows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_InputData_Collumns = new System.Windows.Forms.NumericUpDown();
            this.label_InputData = new System.Windows.Forms.Label();
            this.panel_Result = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Next = new System.Windows.Forms.Button();
            this.dataGridView_Result = new System.Windows.Forms.DataGridView();
            this.label_A = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Methods)).BeginInit();
            this.panel_InputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).BeginInit();
            this.panel_Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_InputData_Methods
            // 
            this.dataGridView_InputData_Methods.AllowUserToAddRows = false;
            this.dataGridView_InputData_Methods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData_Methods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_InputData_Methods.ColumnHeadersVisible = false;
            this.dataGridView_InputData_Methods.Location = new System.Drawing.Point(19, 107);
            this.dataGridView_InputData_Methods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_InputData_Methods.Name = "dataGridView_InputData_Methods";
            this.dataGridView_InputData_Methods.RowHeadersVisible = false;
            this.dataGridView_InputData_Methods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_InputData_Methods.RowTemplate.Height = 24;
            this.dataGridView_InputData_Methods.Size = new System.Drawing.Size(739, 281);
            this.dataGridView_InputData_Methods.TabIndex = 0;
            // 
            // panel_InputData
            // 
            this.panel_InputData.Controls.Add(this.button_Refresh);
            this.panel_InputData.Controls.Add(this.label1);
            this.panel_InputData.Controls.Add(this.button_Calculate);
            this.panel_InputData.Controls.Add(this.label_Rows);
            this.panel_InputData.Controls.Add(this.label_Collumns);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Rows);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Collumns);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData_Methods);
            this.panel_InputData.Location = new System.Drawing.Point(12, 46);
            this.panel_InputData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_InputData.Name = "panel_InputData";
            this.panel_InputData.Size = new System.Drawing.Size(772, 400);
            this.panel_InputData.TabIndex = 1;
            // 
            // button_Refresh
            // 
            this.button_Refresh.AutoSize = true;
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh.Location = new System.Drawing.Point(449, 12);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(137, 43);
            this.button_Refresh.TabIndex = 11;
            this.button_Refresh.Text = "Оновити";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "таблиця умов:";
            // 
            // button_Calculate
            // 
            this.button_Calculate.AutoSize = true;
            this.button_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Calculate.Location = new System.Drawing.Point(607, 12);
            this.button_Calculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(168, 43);
            this.button_Calculate.TabIndex = 2;
            this.button_Calculate.Text = "Обчислити";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Rows.Location = new System.Drawing.Point(13, 50);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(163, 25);
            this.label_Rows.TabIndex = 8;
            this.label_Rows.Text = "кількість рядків:";
            // 
            // label_Collumns
            // 
            this.label_Collumns.AutoSize = true;
            this.label_Collumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Collumns.Location = new System.Drawing.Point(13, 12);
            this.label_Collumns.Name = "label_Collumns";
            this.label_Collumns.Size = new System.Drawing.Size(205, 25);
            this.label_Collumns.TabIndex = 2;
            this.label_Collumns.Text = "кількість стовпчиків:";
            // 
            // numericUpDown_InputData_Rows
            // 
            this.numericUpDown_InputData_Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_InputData_Rows.Location = new System.Drawing.Point(249, 44);
            this.numericUpDown_InputData_Rows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_InputData_Rows.Name = "numericUpDown_InputData_Rows";
            this.numericUpDown_InputData_Rows.Size = new System.Drawing.Size(59, 30);
            this.numericUpDown_InputData_Rows.TabIndex = 7;
            this.numericUpDown_InputData_Rows.ValueChanged += new System.EventHandler(this.numericUpDown_InputData_Rows_ValueChanged);
            // 
            // numericUpDown_InputData_Collumns
            // 
            this.numericUpDown_InputData_Collumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_InputData_Collumns.Location = new System.Drawing.Point(249, 10);
            this.numericUpDown_InputData_Collumns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_InputData_Collumns.Name = "numericUpDown_InputData_Collumns";
            this.numericUpDown_InputData_Collumns.Size = new System.Drawing.Size(59, 30);
            this.numericUpDown_InputData_Collumns.TabIndex = 6;
            this.numericUpDown_InputData_Collumns.ValueChanged += new System.EventHandler(this.numericUpDown_InputData_Collumns_ValueChanged);
            // 
            // label_InputData
            // 
            this.label_InputData.AutoSize = true;
            this.label_InputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_InputData.Location = new System.Drawing.Point(12, 9);
            this.label_InputData.Name = "label_InputData";
            this.label_InputData.Size = new System.Drawing.Size(113, 25);
            this.label_InputData.TabIndex = 1;
            this.label_InputData.Text = "Вхідні дані:";
            // 
            // panel_Result
            // 
            this.panel_Result.Controls.Add(this.label_B);
            this.panel_Result.Controls.Add(this.label_A);
            this.panel_Result.Controls.Add(this.label2);
            this.panel_Result.Controls.Add(this.button_Next);
            this.panel_Result.Controls.Add(this.dataGridView_Result);
            this.panel_Result.Location = new System.Drawing.Point(803, 46);
            this.panel_Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Result.Name = "panel_Result";
            this.panel_Result.Size = new System.Drawing.Size(615, 400);
            this.panel_Result.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "симплекс таблиця:";
            // 
            // button_Next
            // 
            this.button_Next.AutoSize = true;
            this.button_Next.Enabled = false;
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next.Location = new System.Drawing.Point(379, 2);
            this.button_Next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(223, 43);
            this.button_Next.TabIndex = 9;
            this.button_Next.Text = "Наступний крок";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // dataGridView_Result
            // 
            this.dataGridView_Result.AllowUserToAddRows = false;
            this.dataGridView_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Result.Location = new System.Drawing.Point(13, 107);
            this.dataGridView_Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Result.Name = "dataGridView_Result";
            this.dataGridView_Result.ReadOnly = true;
            this.dataGridView_Result.RowHeadersVisible = false;
            this.dataGridView_Result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result.RowTemplate.Height = 24;
            this.dataGridView_Result.Size = new System.Drawing.Size(588, 281);
            this.dataGridView_Result.TabIndex = 9;
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_A.Location = new System.Drawing.Point(8, 70);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(32, 25);
            this.label_A.TabIndex = 12;
            this.label_A.Text = "A:";
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_B.Location = new System.Drawing.Point(325, 70);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(31, 25);
            this.label_B.TabIndex = 13;
            this.label_B.Text = "B:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 455);
            this.Controls.Add(this.panel_Result);
            this.Controls.Add(this.label_InputData);
            this.Controls.Add(this.panel_InputData);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Lab 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Methods)).EndInit();
            this.panel_InputData.ResumeLayout(false);
            this.panel_InputData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).EndInit();
            this.panel_Result.ResumeLayout(false);
            this.panel_Result.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_InputData_Methods;
        private System.Windows.Forms.Panel panel_InputData;
        private System.Windows.Forms.Label label_InputData;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Label label_Collumns;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Rows;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Collumns;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.Panel panel_Result;
        private System.Windows.Forms.DataGridView dataGridView_Result;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_A;
    }
}

