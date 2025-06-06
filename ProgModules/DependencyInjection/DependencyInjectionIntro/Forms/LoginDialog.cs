using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DependencyInjectionIntro.Interfaces;
using DependencyInjectionIntro.Services;

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
