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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ChooseMethod = new System.Windows.Forms.ComboBox();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.dataGridView_InputData_Signs = new System.Windows.Forms.DataGridView();
            this.label_Rows = new System.Windows.Forms.Label();
            this.label_Collumns = new System.Windows.Forms.Label();
            this.numericUpDown_InputData_Rows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_InputData_Collumns = new System.Windows.Forms.NumericUpDown();
            this.radioButton_InputData_Min = new System.Windows.Forms.RadioButton();
            this.radioButton_InputData_Max = new System.Windows.Forms.RadioButton();
            this.dataGridView_InputData_Function = new System.Windows.Forms.DataGridView();
            this.dataGridView_InputData_FreeValues = new System.Windows.Forms.DataGridView();
            this.label_InputData = new System.Windows.Forms.Label();
            this.panel_Result = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Next = new System.Windows.Forms.Button();
            this.dataGridView_Result = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Methods)).BeginInit();
            this.panel_InputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Signs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Function)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_FreeValues)).BeginInit();
            this.panel_Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_InputData_Methods
            // 
            this.dataGridView_InputData_Methods.AllowUserToAddRows = false;
            this.dataGridView_InputData_Methods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData_Methods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_InputData_Methods.Location = new System.Drawing.Point(5, 107);
            this.dataGridView_InputData_Methods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_InputData_Methods.Name = "dataGridView_InputData_Methods";
            this.dataGridView_InputData_Methods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_InputData_Methods.RowTemplate.Height = 24;
            this.dataGridView_InputData_Methods.Size = new System.Drawing.Size(512, 245);
            this.dataGridView_InputData_Methods.TabIndex = 0;
            // 
            // panel_InputData
            // 
            this.panel_InputData.Controls.Add(this.label1);
            this.panel_InputData.Controls.Add(this.comboBox_ChooseMethod);
            this.panel_InputData.Controls.Add(this.button_Calculate);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData_Signs);
            this.panel_InputData.Controls.Add(this.label_Rows);
            this.panel_InputData.Controls.Add(this.label_Collumns);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Rows);
            this.panel_InputData.Controls.Add(this.numericUpDown_InputData_Collumns);
            this.panel_InputData.Controls.Add(this.radioButton_InputData_Min);
            this.panel_InputData.Controls.Add(this.radioButton_InputData_Max);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData_Function);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData_FreeValues);
            this.panel_InputData.Controls.Add(this.dataGridView_InputData_Methods);
            this.panel_InputData.Location = new System.Drawing.Point(12, 46);
            this.panel_InputData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_InputData.Name = "panel_InputData";
            this.panel_InputData.Size = new System.Drawing.Size(772, 400);
            this.panel_InputData.TabIndex = 1;
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
            // comboBox_ChooseMethod
            // 
            this.comboBox_ChooseMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ChooseMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_ChooseMethod.Items.AddRange(new object[] {
            "Симплекс-метод",
            "Двоїстий симплекс-метод"});
            this.comboBox_ChooseMethod.Location = new System.Drawing.Point(332, 12);
            this.comboBox_ChooseMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_ChooseMethod.Name = "comboBox_ChooseMethod";
            this.comboBox_ChooseMethod.Size = new System.Drawing.Size(264, 28);
            this.comboBox_ChooseMethod.TabIndex = 9;
            // 
            // button_Calculate
            // 
            this.button_Calculate.AutoSize = true;
            this.button_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Calculate.Location = new System.Drawing.Point(607, 10);
            this.button_Calculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(136, 43);
            this.button_Calculate.TabIndex = 2;
            this.button_Calculate.Text = "Обчислити";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // dataGridView_InputData_Signs
            // 
            this.dataGridView_InputData_Signs.AllowUserToAddRows = false;
            this.dataGridView_InputData_Signs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData_Signs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_InputData_Signs.Location = new System.Drawing.Point(523, 107);
            this.dataGridView_InputData_Signs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_InputData_Signs.Name = "dataGridView_InputData_Signs";
            this.dataGridView_InputData_Signs.RowHeadersVisible = false;
            this.dataGridView_InputData_Signs.RowTemplate.Height = 24;
            this.dataGridView_InputData_Signs.Size = new System.Drawing.Size(101, 245);
            this.dataGridView_InputData_Signs.TabIndex = 1;
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
            // radioButton_InputData_Min
            // 
            this.radioButton_InputData_Min.AutoSize = true;
            this.radioButton_InputData_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_InputData_Min.Location = new System.Drawing.Point(631, 358);
            this.radioButton_InputData_Min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_InputData_Min.Name = "radioButton_InputData_Min";
            this.radioButton_InputData_Min.Size = new System.Drawing.Size(65, 29);
            this.radioButton_InputData_Min.TabIndex = 5;
            this.radioButton_InputData_Min.Text = "Min";
            this.radioButton_InputData_Min.UseVisualStyleBackColor = true;
            // 
            // radioButton_InputData_Max
            // 
            this.radioButton_InputData_Max.AutoSize = true;
            this.radioButton_InputData_Max.Checked = true;
            this.radioButton_InputData_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_InputData_Max.Location = new System.Drawing.Point(523, 358);
            this.radioButton_InputData_Max.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_InputData_Max.Name = "radioButton_InputData_Max";
            this.radioButton_InputData_Max.Size = new System.Drawing.Size(71, 29);
            this.radioButton_InputData_Max.TabIndex = 4;
            this.radioButton_InputData_Max.TabStop = true;
            this.radioButton_InputData_Max.Text = "Max";
            this.radioButton_InputData_Max.UseVisualStyleBackColor = true;
            // 
            // dataGridView_InputData_Function
            // 
            this.dataGridView_InputData_Function.AllowUserToAddRows = false;
            this.dataGridView_InputData_Function.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData_Function.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_InputData_Function.ColumnHeadersVisible = false;
            this.dataGridView_InputData_Function.Location = new System.Drawing.Point(5, 358);
            this.dataGridView_InputData_Function.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_InputData_Function.Name = "dataGridView_InputData_Function";
            this.dataGridView_InputData_Function.RowTemplate.Height = 24;
            this.dataGridView_InputData_Function.Size = new System.Drawing.Size(512, 30);
            this.dataGridView_InputData_Function.TabIndex = 3;
            // 
            // dataGridView_InputData_FreeValues
            // 
            this.dataGridView_InputData_FreeValues.AllowUserToAddRows = false;
            this.dataGridView_InputData_FreeValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_InputData_FreeValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_InputData_FreeValues.Location = new System.Drawing.Point(631, 107);
            this.dataGridView_InputData_FreeValues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_InputData_FreeValues.Name = "dataGridView_InputData_FreeValues";
            this.dataGridView_InputData_FreeValues.RowHeadersVisible = false;
            this.dataGridView_InputData_FreeValues.RowTemplate.Height = 24;
            this.dataGridView_InputData_FreeValues.Size = new System.Drawing.Size(101, 245);
            this.dataGridView_InputData_FreeValues.TabIndex = 2;
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
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next.Location = new System.Drawing.Point(378, 3);
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
            this.dataGridView_Result.Location = new System.Drawing.Point(13, 50);
            this.dataGridView_Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Result.Name = "dataGridView_Result";
            this.dataGridView_Result.ReadOnly = true;
            this.dataGridView_Result.RowHeadersVisible = false;
            this.dataGridView_Result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Result.RowTemplate.Height = 24;
            this.dataGridView_Result.Size = new System.Drawing.Size(588, 337);
            this.dataGridView_Result.TabIndex = 9;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Signs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InputData_Collumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_Function)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_InputData_FreeValues)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_InputData_Function;
        private System.Windows.Forms.DataGridView dataGridView_InputData_FreeValues;
        private System.Windows.Forms.DataGridView dataGridView_InputData_Signs;
        private System.Windows.Forms.RadioButton radioButton_InputData_Min;
        private System.Windows.Forms.RadioButton radioButton_InputData_Max;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Label label_Collumns;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Rows;
        private System.Windows.Forms.NumericUpDown numericUpDown_InputData_Collumns;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.Panel panel_Result;
        private System.Windows.Forms.DataGridView dataGridView_Result;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.ComboBox comboBox_ChooseMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

