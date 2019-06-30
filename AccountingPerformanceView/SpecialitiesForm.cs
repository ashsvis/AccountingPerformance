using AccountingPerformanceModel;
using System;
using System.Windows.Forms;
using ViewGenerator;

namespace AccountingPerformanceView
{
    /// <summary>
    /// Класс формы редактирования специальностей
    /// </summary>
    public partial class SpecialitiesForm : Form
    {
        GridPanel _gridPanel;
        Root _root;

        public SpecialitiesForm(Root root)
        {
            InitializeComponent();
            _root = root;
            // создаем панели с таблицами автоматически по классу и списку из модели
            _gridPanel = GridPanelBuilder.BuildPropertyPanel(root, new Speciality(), root.Specialities);
            _gridPanel.GridSelectedChanged += Panel_GridSelectedChanged;
            panel1.Controls.Add(_gridPanel);
            panel2.Controls.Add(GridPanelBuilder.BuildPropertyPanel(root, new Specialization(), 
                                _root.Specializations.FilteredBySpeciality(Guid.Empty)));
            panel2.Enabled = false;

        }

        private void Panel_GridSelectedChanged(object obj)
        {
            var speciality = (Speciality)obj;
            if (speciality != null)
            {
                panel2.Controls.Add(GridPanelBuilder.BuildPropertyPanel(_root, new Specialization(), _root.Specializations,
                    _root.Specializations.FilteredBySpeciality(speciality.IdSpeciality), 
                    new[] { "IdSpeciality" }, new[] { speciality.IdSpeciality }));
                panel2.Enabled = true;
            }
            else
            {
                panel2.Controls.Add(GridPanelBuilder.BuildPropertyPanel(_root, new Specialization(),
                    _root.Specializations.FilteredBySpeciality(Guid.Empty)));
                panel2.Enabled = false;
            }
            panel2.Controls.RemoveAt(0);
        }

        /// <summary>
        /// Прячем форму при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecialitiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void tsmiBack_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
