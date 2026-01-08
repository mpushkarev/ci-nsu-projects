using System.Windows.Controls;
using SimpleCRUD.Models;

namespace SimpleCRUD.Controls {
    /// <summary>
    /// Логика взаимодействия для ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl {
        public ItemControl(Item item) {
            InitializeComponent();

            DataContext = item;
        }
    }
}
