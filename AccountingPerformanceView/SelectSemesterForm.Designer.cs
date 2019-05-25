namespace AccountingPerformanceView
{
    partial class SelectSemesterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbSemesters = new System.Windows.Forms.ComboBox();
            this.btnToReport = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Семестр:";
            // 
            // cbSemesters
            // 
            this.cbSemesters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemesters.FormattingEnabled = true;
            this.cbSemesters.Location = new System.Drawing.Point(127, 18);
            this.cbSemesters.Name = "cbSemesters";
            this.cbSemesters.Size = new System.Drawing.Size(109, 23);
            this.cbSemesters.TabIndex = 3;
            // 
            // btnToReport
            // 
            this.btnToReport.Enabled = false;
            this.btnToReport.Location = new System.Drawing.Point(12, 58);
            this.btnToReport.Name = "btnToReport";
            this.btnToReport.Size = new System.Drawing.Size(109, 25);
            this.btnToReport.TabIndex = 4;
            this.btnToReport.Text = "Простой отчёт";
            this.btnToReport.UseVisualStyleBackColor = true;
            this.btnToReport.Click += new System.EventHandler(this.btnToReport_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Enabled = false;
            this.btnToExcel.Location = new System.Drawing.Point(127, 58);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(109, 25);
            this.btnToExcel.TabIndex = 4;
            this.btnToExcel.Text = "Отчёт в Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(242, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SelectSemesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(339, 95);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.btnToReport);
            this.Controls.Add(this.cbSemesters);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSemesterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите семестр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSemesters;
        private System.Windows.Forms.Button btnToReport;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnCancel;
    }
}