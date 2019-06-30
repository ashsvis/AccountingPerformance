namespace AccountingPerformanceView
{
    partial class MoveStudentToGroupForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStudent = new System.Windows.Forms.TextBox();
            this.cbSpecialities = new System.Windows.Forms.ComboBox();
            this.cbSpecializations = new System.Windows.Forms.ComboBox();
            this.cbStudyGroups = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbStudent, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSpecialities, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbSpecializations, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbStudyGroups, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 164);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Студент:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Специальность:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Специализация:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Группа:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbStudent
            // 
            this.tbStudent.BackColor = System.Drawing.SystemColors.Window;
            this.tbStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStudent.Location = new System.Drawing.Point(110, 8);
            this.tbStudent.Name = "tbStudent";
            this.tbStudent.ReadOnly = true;
            this.tbStudent.Size = new System.Drawing.Size(465, 23);
            this.tbStudent.TabIndex = 1;
            this.tbStudent.TabStop = false;
            // 
            // cbSpecialities
            // 
            this.cbSpecialities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSpecialities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialities.FormattingEnabled = true;
            this.cbSpecialities.Location = new System.Drawing.Point(110, 37);
            this.cbSpecialities.Name = "cbSpecialities";
            this.cbSpecialities.Size = new System.Drawing.Size(465, 23);
            this.cbSpecialities.TabIndex = 2;
            this.cbSpecialities.DropDown += new System.EventHandler(this.cbSpecialities_DropDown);
            this.cbSpecialities.SelectionChangeCommitted += new System.EventHandler(this.cbSpecialities_SelectionChangeCommitted);
            // 
            // cbSpecializations
            // 
            this.cbSpecializations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSpecializations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecializations.FormattingEnabled = true;
            this.cbSpecializations.Location = new System.Drawing.Point(110, 66);
            this.cbSpecializations.Name = "cbSpecializations";
            this.cbSpecializations.Size = new System.Drawing.Size(465, 23);
            this.cbSpecializations.TabIndex = 3;
            this.cbSpecializations.DropDown += new System.EventHandler(this.cbSpecializations_DropDown);
            this.cbSpecializations.SelectionChangeCommitted += new System.EventHandler(this.cbSpecializations_SelectionChangeCommitted);
            // 
            // cbStudyGroups
            // 
            this.cbStudyGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbStudyGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudyGroups.FormattingEnabled = true;
            this.cbStudyGroups.Location = new System.Drawing.Point(110, 95);
            this.cbStudyGroups.Name = "cbStudyGroups";
            this.cbStudyGroups.Size = new System.Drawing.Size(156, 23);
            this.cbStudyGroups.TabIndex = 4;
            this.cbStudyGroups.DropDown += new System.EventHandler(this.cbStudyGroups_DropDown);
            this.cbStudyGroups.SelectionChangeCommitted += new System.EventHandler(this.cbStudyGroups_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 32);
            this.panel1.TabIndex = 3;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(372, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(91, 25);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "Перевести";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(469, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // MoveStudentToGroupForm
            // 
            this.AcceptButton = this.btnMove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(583, 164);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveStudentToGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Перевод студента";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStudent;
        private System.Windows.Forms.ComboBox cbSpecialities;
        private System.Windows.Forms.ComboBox cbSpecializations;
        private System.Windows.Forms.ComboBox cbStudyGroups;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMove;
    }
}