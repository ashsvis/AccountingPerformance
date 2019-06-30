namespace AccountingPerformanceView
{
    partial class GroupPerformanceForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMatters = new System.Windows.Forms.ComboBox();
            this.cbStudyGroups = new System.Windows.Forms.ComboBox();
            this.cbSemesters = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbGrade = new System.Windows.Forms.ComboBox();
            this.lvPerformance = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnScorecard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMatters, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbStudyGroups, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbSemesters, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnScorecard, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 401);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Location = new System.Drawing.Point(8, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 22);
            this.button1.TabIndex = 6;
            this.button1.Text = "Экзаменационная ведомость";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Предмет:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Группа:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(207, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Семестр:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMatters
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbMatters, 3);
            this.cbMatters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMatters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatters.FormattingEnabled = true;
            this.cbMatters.Location = new System.Drawing.Point(72, 8);
            this.cbMatters.Name = "cbMatters";
            this.cbMatters.Size = new System.Drawing.Size(280, 23);
            this.cbMatters.TabIndex = 1;
            this.cbMatters.SelectionChangeCommitted += new System.EventHandler(this.cbMatters_SelectionChangeCommitted);
            // 
            // cbStudyGroups
            // 
            this.cbStudyGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStudyGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudyGroups.FormattingEnabled = true;
            this.cbStudyGroups.Location = new System.Drawing.Point(72, 38);
            this.cbStudyGroups.Name = "cbStudyGroups";
            this.cbStudyGroups.Size = new System.Drawing.Size(129, 23);
            this.cbStudyGroups.TabIndex = 2;
            this.cbStudyGroups.SelectionChangeCommitted += new System.EventHandler(this.cbMatters_SelectionChangeCommitted);
            // 
            // cbSemesters
            // 
            this.cbSemesters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSemesters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemesters.FormattingEnabled = true;
            this.cbSemesters.Location = new System.Drawing.Point(270, 38);
            this.cbSemesters.Name = "cbSemesters";
            this.cbSemesters.Size = new System.Drawing.Size(82, 23);
            this.cbSemesters.TabIndex = 2;
            this.cbSemesters.SelectionChangeCommitted += new System.EventHandler(this.cbMatters_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.cbGrade);
            this.panel1.Controls.Add(this.lvPerformance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 267);
            this.panel1.TabIndex = 3;
            // 
            // cbGrade
            // 
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.FormattingEnabled = true;
            this.cbGrade.Location = new System.Drawing.Point(241, 43);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(82, 23);
            this.cbGrade.TabIndex = 1;
            this.cbGrade.Visible = false;
            this.cbGrade.SelectionChangeCommitted += new System.EventHandler(this.cbGrade_SelectionChangeCommitted);
            this.cbGrade.Leave += new System.EventHandler(this.cbGrade_Leave);
            // 
            // lvPerformance
            // 
            this.lvPerformance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPerformance.FullRowSelect = true;
            this.lvPerformance.GridLines = true;
            this.lvPerformance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPerformance.Location = new System.Drawing.Point(0, 0);
            this.lvPerformance.MultiSelect = false;
            this.lvPerformance.Name = "lvPerformance";
            this.lvPerformance.ShowGroups = false;
            this.lvPerformance.ShowItemToolTips = true;
            this.lvPerformance.Size = new System.Drawing.Size(344, 267);
            this.lvPerformance.TabIndex = 0;
            this.lvPerformance.UseCompatibleStateImageBehavior = false;
            this.lvPerformance.View = System.Windows.Forms.View.Details;
            this.lvPerformance.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvPerformance_ColumnWidthChanging);
            this.lvPerformance.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvPerformance_MouseMove);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Студент";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Семестр";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Оценка";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(277, 340);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnScorecard
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnScorecard, 2);
            this.btnScorecard.Location = new System.Drawing.Point(8, 340);
            this.btnScorecard.Name = "btnScorecard";
            this.btnScorecard.Size = new System.Drawing.Size(193, 23);
            this.btnScorecard.TabIndex = 5;
            this.btnScorecard.Text = "Семестровая ведомость";
            this.btnScorecard.UseVisualStyleBackColor = true;
            this.btnScorecard.Click += new System.EventHandler(this.btnScorecard_Click);
            // 
            // GroupPerformanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(360, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GroupPerformanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты сдачи сессии";
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
        private System.Windows.Forms.ComboBox cbMatters;
        private System.Windows.Forms.ComboBox cbStudyGroups;
        private System.Windows.Forms.ComboBox cbSemesters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lvPerformance;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox cbGrade;
        private System.Windows.Forms.Button btnScorecard;
        private System.Windows.Forms.Button button1;
    }
}