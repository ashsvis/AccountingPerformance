using AccountingPerformanceModel;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    /// <summary>
    /// Класс формы редактирования предметов
    /// </summary>
    public partial class MattersForm : Form
    {
        Root _root;

        public MattersForm(Root root)
        {
            InitializeComponent();
            _root = root;
            // создаём панель с таблицей автоматически по классу и списку
            panel1.Controls.Add(GridPanelBuilder.BuildPropertyPanel(root, new Matter(), root.Matters));
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MattersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
