using AccountingPerformanceModel;
using System.Linq;
using System.Windows.Forms;

namespace AccountingPerformanceView
{
    public partial class LoginForm : Form
    {
        private readonly Root _root;

        public LoginForm(Root root)
        {
            InitializeComponent();
            _root = root;
            foreach (var teacher in _root.Teachers)
            {
                cbTeacher.Items.Add(teacher);
            }
        }

        private void cbTeacher_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            btnEnter.Enabled = cbTeacher.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(tbLogin.Text) &&
                !string.IsNullOrWhiteSpace(tbPassword.Text);
        }

        private void btnEnter_Click(object sender, System.EventArgs e)
        {
            if (CheckValidLoginPassword())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show(this, "Логин или пароль пользователя неверны", "Попытка входа в программу",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool CheckValidLoginPassword()
        {
            return _root.Teachers.Any(item => item.IdTeacher == ((Teacher)cbTeacher.SelectedItem).IdTeacher &&
                                   item.Login == tbLogin.Text && item.Password == tbPassword.Text);
        }
    }
}
