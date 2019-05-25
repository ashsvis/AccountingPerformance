using AccountingPerformanceModel;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    public partial class SemestersForm : Form
    {
        Root _root;

        public SemestersForm(Root root)
        {
            InitializeComponent();
            _root = root;
            // содаем панель с таблицей автоматически по классу и списку
            panel1.Controls.Add(GridPanelBuilder.BuildPropertyPanel(root, new Semester(), root.Semesters));
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemestersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
