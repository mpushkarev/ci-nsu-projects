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

using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionIntro {
    public partial class MainForm : Form {

        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e) {

            LoginDialog loginDialog = _serviceProvider.GetRequiredService<LoginDialog>();

            if (loginDialog.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("Успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loginDialog.Dispose();
        }

        private void ButtonRegister_Click(object sender, EventArgs e) {

            RegisterDialog registerDialog = _serviceProvider.GetRequiredService<RegisterDialog>();

            if (registerDialog.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("Успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            registerDialog.Dispose();
        }
    }
}
