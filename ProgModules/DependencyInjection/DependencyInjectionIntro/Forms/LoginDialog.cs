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
    public partial class LoginDialog : Form {

        private readonly IAuthManager _authManager;

        public LoginDialog(IAuthManager authManager) {
            _authManager = authManager;
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e) {

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = _authManager.TryLogin(login, password);

            if (!success) {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
