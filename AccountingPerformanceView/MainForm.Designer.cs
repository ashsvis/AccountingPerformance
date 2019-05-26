namespace AccountingPerformanceView
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMatters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSpecialities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMatterCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSemesters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewEditStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRecordStudentResults = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecordGroupResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMoveStudentToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListOfDebtors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSemesterStudentProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSemesterGroupProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSummaryStudentProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSpecialities = new System.Windows.Forms.ComboBox();
            this.cbSpecializations = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListOfDebtors = new System.Windows.Forms.Button();
            this.btnMoveToGroup = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tsmiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiOperations,
            this.tsmiReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLogin,
            this.toolStripMenuItem4,
            this.tsmiTeachers,
            this.tsmiMatters,
            this.tsmiSpecialities,
            this.tsmiMatterCourses,
            this.tsmiSemesters,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            this.tsmiFile.DropDownOpening += new System.EventHandler(this.tsmiFile_DropDownOpening);
            // 
            // tsmiTeachers
            // 
            this.tsmiTeachers.Name = "tsmiTeachers";
            this.tsmiTeachers.Size = new System.Drawing.Size(283, 22);
            this.tsmiTeachers.Text = "Преподаватели";
            this.tsmiTeachers.Click += new System.EventHandler(this.tsmiTeachers_Click);
            // 
            // tsmiMatters
            // 
            this.tsmiMatters.Name = "tsmiMatters";
            this.tsmiMatters.Size = new System.Drawing.Size(283, 22);
            this.tsmiMatters.Text = "Предметы";
            this.tsmiMatters.Click += new System.EventHandler(this.tsmiMatters_Click);
            // 
            // tsmiSpecialities
            // 
            this.tsmiSpecialities.Name = "tsmiSpecialities";
            this.tsmiSpecialities.Size = new System.Drawing.Size(283, 22);
            this.tsmiSpecialities.Text = "Специальности и специализации";
            this.tsmiSpecialities.Click += new System.EventHandler(this.tsmiSpecialities_Click);
            // 
            // tsmiMatterCourses
            // 
            this.tsmiMatterCourses.Name = "tsmiMatterCourses";
            this.tsmiMatterCourses.Size = new System.Drawing.Size(283, 22);
            this.tsmiMatterCourses.Text = "Курсы предметов по специальностям";
            this.tsmiMatterCourses.Click += new System.EventHandler(this.tsmiMatterCourses_Click);
            // 
            // tsmiSemesters
            // 
            this.tsmiSemesters.Name = "tsmiSemesters";
            this.tsmiSemesters.Size = new System.Drawing.Size(283, 22);
            this.tsmiSemesters.Text = "Семестры";
            this.tsmiSemesters.Click += new System.EventHandler(this.tsmiSemesters_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(280, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(283, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiOperations
            // 
            this.tsmiOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmiViewEditStudent,
            this.toolStripMenuItem2,
            this.tsmiRecordStudentResults,
            this.tsmiRecordGroupResults,
            this.toolStripMenuItem3,
            this.tsmiMoveStudentToGroup,
            this.tsmiListOfDebtors});
            this.tsmiOperations.Name = "tsmiOperations";
            this.tsmiOperations.Size = new System.Drawing.Size(75, 20);
            this.tsmiOperations.Text = "Операции";
            this.tsmiOperations.DropDownOpening += new System.EventHandler(this.tsmiOperations_DropDownOpening);
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Enabled = false;
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(299, 22);
            this.tsmiAddStudent.Text = "Поступление студента";
            this.tsmiAddStudent.Click += new System.EventHandler(this.tsmiAddStudent_Click);
            // 
            // tsmiViewEditStudent
            // 
            this.tsmiViewEditStudent.Enabled = false;
            this.tsmiViewEditStudent.Name = "tsmiViewEditStudent";
            this.tsmiViewEditStudent.Size = new System.Drawing.Size(299, 22);
            this.tsmiViewEditStudent.Text = "Просмотр/изменение данных о студенте";
            this.tsmiViewEditStudent.Click += new System.EventHandler(this.tsmiViewEditStudent_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiRecordStudentResults
            // 
            this.tsmiRecordStudentResults.Enabled = false;
            this.tsmiRecordStudentResults.Name = "tsmiRecordStudentResults";
            this.tsmiRecordStudentResults.Size = new System.Drawing.Size(299, 22);
            this.tsmiRecordStudentResults.Text = "Запись результатов сессии студента";
            this.tsmiRecordStudentResults.Click += new System.EventHandler(this.tsmiViewEditStudent_Click);
            // 
            // tsmiRecordGroupResults
            // 
            this.tsmiRecordGroupResults.Name = "tsmiRecordGroupResults";
            this.tsmiRecordGroupResults.Size = new System.Drawing.Size(299, 22);
            this.tsmiRecordGroupResults.Text = "Запись результатов сессии для группы";
            this.tsmiRecordGroupResults.Click += new System.EventHandler(this.tsmiRecordGroupResults_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiMoveStudentToGroup
            // 
            this.tsmiMoveStudentToGroup.Enabled = false;
            this.tsmiMoveStudentToGroup.Name = "tsmiMoveStudentToGroup";
            this.tsmiMoveStudentToGroup.Size = new System.Drawing.Size(299, 22);
            this.tsmiMoveStudentToGroup.Text = "Перевод студента в другую группу";
            this.tsmiMoveStudentToGroup.Click += new System.EventHandler(this.btnMoveToGroup_Click);
            // 
            // tsmiListOfDebtors
            // 
            this.tsmiListOfDebtors.Name = "tsmiListOfDebtors";
            this.tsmiListOfDebtors.Size = new System.Drawing.Size(299, 22);
            this.tsmiListOfDebtors.Text = "Список должников";
            this.tsmiListOfDebtors.Click += new System.EventHandler(this.btnListOfDebtors_Click);
            // 
            // tsmiReports
            // 
            this.tsmiReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSemesterStudentProgress,
            this.tsmiSemesterGroupProgress,
            this.tsmiSummaryStudentProgress});
            this.tsmiReports.Name = "tsmiReports";
            this.tsmiReports.Size = new System.Drawing.Size(60, 20);
            this.tsmiReports.Text = "Отчёты";
            this.tsmiReports.DropDownOpening += new System.EventHandler(this.tsmiReports_DropDownOpening);
            // 
            // tsmiSemesterStudentProgress
            // 
            this.tsmiSemesterStudentProgress.Enabled = false;
            this.tsmiSemesterStudentProgress.Name = "tsmiSemesterStudentProgress";
            this.tsmiSemesterStudentProgress.Size = new System.Drawing.Size(315, 22);
            this.tsmiSemesterStudentProgress.Text = "Отчёт об успеваемости студента за семестр";
            this.tsmiSemesterStudentProgress.Click += new System.EventHandler(this.tsmiSemesterStudentProgress_Click);
            // 
            // tsmiSemesterGroupProgress
            // 
            this.tsmiSemesterGroupProgress.Enabled = false;
            this.tsmiSemesterGroupProgress.Name = "tsmiSemesterGroupProgress";
            this.tsmiSemesterGroupProgress.Size = new System.Drawing.Size(315, 22);
            this.tsmiSemesterGroupProgress.Text = "Отчёт об успеваемости группы за семестр";
            this.tsmiSemesterGroupProgress.Click += new System.EventHandler(this.tsmiSemesterGroupProgress_Click);
            // 
            // tsmiSummaryStudentProgress
            // 
            this.tsmiSummaryStudentProgress.Enabled = false;
            this.tsmiSummaryStudentProgress.Name = "tsmiSummaryStudentProgress";
            this.tsmiSummaryStudentProgress.Size = new System.Drawing.Size(315, 22);
            this.tsmiSummaryStudentProgress.Text = "Итоговый отчёт об успеваемости студента";
            this.tsmiSummaryStudentProgress.Click += new System.EventHandler(this.tsmiSummaryStudentProgress_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbSpecialities, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSpecializations, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 491);
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
            this.label1.Text = "Специальность:";
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
            this.label2.Text = "Специализация:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSpecialities
            // 
            this.cbSpecialities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSpecialities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialities.FormattingEnabled = true;
            this.cbSpecialities.Location = new System.Drawing.Point(110, 8);
            this.cbSpecialities.Name = "cbSpecialities";
            this.cbSpecialities.Size = new System.Drawing.Size(466, 23);
            this.cbSpecialities.TabIndex = 1;
            this.cbSpecialities.DropDown += new System.EventHandler(this.cbSpecialities_DropDown);
            this.cbSpecialities.SelectionChangeCommitted += new System.EventHandler(this.cbSpecialities_SelectionChangeCommitted);
            // 
            // cbSpecializations
            // 
            this.cbSpecializations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSpecializations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecializations.FormattingEnabled = true;
            this.cbSpecializations.Location = new System.Drawing.Point(110, 37);
            this.cbSpecializations.Name = "cbSpecializations";
            this.cbSpecializations.Size = new System.Drawing.Size(466, 23);
            this.cbSpecializations.TabIndex = 2;
            this.cbSpecializations.DropDown += new System.EventHandler(this.cbSpecializations_DropDown);
            this.cbSpecializations.SelectionChangeCommitted += new System.EventHandler(this.cbSpecializations_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnListOfDebtors);
            this.panel1.Controls.Add(this.btnMoveToGroup);
            this.panel1.Controls.Add(this.btnStudent);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 124);
            this.panel1.TabIndex = 2;
            // 
            // btnListOfDebtors
            // 
            this.btnListOfDebtors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListOfDebtors.Location = new System.Drawing.Point(408, 79);
            this.btnListOfDebtors.Name = "btnListOfDebtors";
            this.btnListOfDebtors.Size = new System.Drawing.Size(143, 23);
            this.btnListOfDebtors.TabIndex = 6;
            this.btnListOfDebtors.Text = "Список должников";
            this.btnListOfDebtors.UseVisualStyleBackColor = true;
            this.btnListOfDebtors.Click += new System.EventHandler(this.btnListOfDebtors_Click);
            // 
            // btnMoveToGroup
            // 
            this.btnMoveToGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveToGroup.Enabled = false;
            this.btnMoveToGroup.Location = new System.Drawing.Point(408, 50);
            this.btnMoveToGroup.Name = "btnMoveToGroup";
            this.btnMoveToGroup.Size = new System.Drawing.Size(143, 23);
            this.btnMoveToGroup.TabIndex = 5;
            this.btnMoveToGroup.Text = "Перевод студента";
            this.btnMoveToGroup.UseVisualStyleBackColor = true;
            this.btnMoveToGroup.Click += new System.EventHandler(this.btnMoveToGroup_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStudent.Enabled = false;
            this.btnStudent.Location = new System.Drawing.Point(408, 21);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(143, 23);
            this.btnStudent.TabIndex = 4;
            this.btnStudent.Text = "Данные о студенте";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.tsmiViewEditStudent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск студента";
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(68, 30);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(288, 23);
            this.tbFind.TabIndex = 3;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ф.И.О.:";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(582, 8);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 3);
            this.panel2.Size = new System.Drawing.Size(265, 182);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 196);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(839, 287);
            this.panel3.TabIndex = 4;
            // 
            // tsmiLogin
            // 
            this.tsmiLogin.Name = "tsmiLogin";
            this.tsmiLogin.Size = new System.Drawing.Size(283, 22);
            this.tsmiLogin.Text = "Вход...";
            this.tsmiLogin.Click += new System.EventHandler(this.tsmiLogin_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(280, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АРМ заведующего отделением";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmiReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiMatters;
        private System.Windows.Forms.ToolStripMenuItem tsmiSpecialities;
        private System.Windows.Forms.ToolStripMenuItem tsmiMatterCourses;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewEditStudent;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecordStudentResults;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecordGroupResults;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveStudentToGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiListOfDebtors;
        private System.Windows.Forms.ToolStripMenuItem tsmiSemesterStudentProgress;
        private System.Windows.Forms.ToolStripMenuItem tsmiSemesterGroupProgress;
        private System.Windows.Forms.ToolStripMenuItem tsmiSummaryStudentProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSpecialities;
        private System.Windows.Forms.ComboBox cbSpecializations;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnListOfDebtors;
        private System.Windows.Forms.Button btnMoveToGroup;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiSemesters;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeachers;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

