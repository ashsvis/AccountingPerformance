using AccountingPerformanceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class TeachersForm : Form
    {
        Root _root;

        public TeachersForm(Root root)
        {
            InitializeComponent();
            _root = root;
            // содаем панель с таблицей автоматически по классу и списку
            panel1.Controls.Add(GridPanelBuilder.BuildPropertyPanel(root, new Teacher(), root.Teachers));
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeachersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
