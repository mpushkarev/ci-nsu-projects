using System.Windows;
using System.Windows.Controls;
using SimpleCRUD.Data;
using SimpleCRUD.Models;
using SimpleCRUD.Controls;
using SimpleCRUD.Windows;

namespace SimpleCRUD {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private AppDbContext _context;
        private List<Item> _items;
        private string? _currentSort;

        public MainWindow() {
            InitializeComponent();

            _context = new AppDbContext();

            _items = _context.Items.ToList();

            DrawItems(_items);
        }

        public void DrawItems(List<Item> items) {
            ListItems.ItemsSource = items.Select(i => new ItemControl(i));
        }

        public void ApplyFilter() {
            List<Item> temp = _items.Where(q => q.Name.Contains(FindBox.Text)).ToList();

            if (_currentSort == "по возрастанию") {
                temp = temp.OrderBy(q => q.Name).ToList();
            } else if (_currentSort == "по убыванию") {
                temp = temp.OrderByDescending(q => q.Name).ToList();
            }

            DrawItems(temp);
        }

        private void FindBox_TextChanged(object sender, TextChangedEventArgs e) {
            ApplyFilter();
        }

        private void SortRadio_Checked(object sender, RoutedEventArgs e) {
            if (!IsLoaded) return;
            RadioButton rb = (RadioButton)sender;
            _currentSort = rb.Content.ToString();
            ApplyFilter();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) {
            ItemWindow itemWindow = new ItemWindow();
            itemWindow.ShowDialog();

            if (itemWindow.DialogResult == true) {
                Item newItem = itemWindow.CurrentItem;
                _context.Items.Add(newItem);
                _context.SaveChanges();

                _items.Add(newItem);
                ApplyFilter();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e) {
            ItemControl? selectedItem = (ListItems.SelectedItem as ItemControl);
            
            if (selectedItem != null) {
                Item item = selectedItem.DataContext as Item;

                ItemWindow itemWindow = new ItemWindow(item);
                itemWindow.ShowDialog();

                if (itemWindow.DialogResult == true) {
                    Item newItem = itemWindow.CurrentItem;
                    _context.Items.Update(newItem);
                    _context.SaveChanges();

                    _items = _context.Items.ToList();
                    DrawItems(_items);
                    ApplyFilter();
                }
            } else {
                MessageBox.Show("Сначала выберите элемент для редактирования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e) {
            ItemControl? selectedItem = (ListItems.SelectedItem as ItemControl);

            if (selectedItem != null) {
                Item item = selectedItem.DataContext as Item;

                MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить элемент \"{item.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    _context.Items.Remove(item);
                    _context.SaveChanges();

                    _items.Remove(item);
                    ApplyFilter();
                }
            } else {
                MessageBox.Show("Сначала выберите элемент для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}