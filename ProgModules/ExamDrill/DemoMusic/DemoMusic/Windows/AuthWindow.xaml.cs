using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DemoMusic.Models;

namespace DemoMusic.Windows {
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window {

        private MusicDemoContext _context;

        public AuthWindow() {
            InitializeComponent();
            _context = new MusicDemoContext();
        }

        private void ButtonAuth(object sender, RoutedEventArgs e) {

            MainWindow mainWindowKostil = new MainWindow(new User { Id = 1, Role = "Администратор", Fio = "Никифорова Весения Николаевна", Login = "94d5ous@gmail.com", Password = "uzWC67"});
            mainWindowKostil.Show();
            this.Close();

            return;

            if (!string.IsNullOrWhiteSpace(BoxLogin.Text) && !string.IsNullOrWhiteSpace(BoxPassword.Text)) {

                User? user = _context.Users.FirstOrDefault(u => u.Login == BoxLogin.Text && u.Password == BoxPassword.Text);

                if (user != null) {
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                } else {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                MessageBox.Show("Не все поля заполнены", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ButtonGuest(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
