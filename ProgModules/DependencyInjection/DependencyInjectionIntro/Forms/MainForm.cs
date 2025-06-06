using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DependencyInjectionIntro.Data;
using DependencyInjectionIntro.Interfaces;
using DependencyInjectionIntro.Services;
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
