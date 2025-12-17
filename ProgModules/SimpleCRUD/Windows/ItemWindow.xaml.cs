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
using SimpleCRUD.Models;

namespace SimpleCRUD.Windows {
    /// <summary>
    /// Логика взаимодействия для ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window {

        public Item CurrentItem { get; private set; }
        public ItemWindow(Item? item = null) {
            InitializeComponent();
            CurrentItem = item ?? new Item();
            DataContext = CurrentItem;
            this.Title = item == null ? "Добавить элемент" : "Редактировать элемент";
        }

        private void ButtonSave(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(CurrentItem.Name)) {
                MessageBox.Show("Название не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
