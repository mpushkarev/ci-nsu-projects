/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2025                                    *
*                                                                              *
*  Description:                                                                *
*    Basic demonstration of dependency injection in a WinForms                 *
*    application, featuring a simple user authentication and                   *
*    registration system. The core logic is separated into service             *
*    interfaces and multiple implementations (including fake,                  *
*    list, and real authentication managers).                                  *
*    As one of my early projects using these patterns, some aspects            *
*    may be simplistic or suitable for further improvement.                    *
*                                                                              *
\******************************************************************************/

using DependencyInjectionIntro.Interfaces;

namespace DependencyInjectionIntro {
    public partial class RegisterDialog : Form {

        private readonly IAuthManager _authManager;

        public RegisterDialog(IAuthManager authManager) {
            _authManager = authManager;
            InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, EventArgs e) {

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string repeat = textBoxPasswordRepeat.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeat)) {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != repeat) {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isTaken = _authManager.IsLoginTaken(login);

            if (isTaken) {
                MessageBox.Show("Логин уже занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = _authManager.Register(login, password);

            if (!success) {
                MessageBox.Show("Ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
