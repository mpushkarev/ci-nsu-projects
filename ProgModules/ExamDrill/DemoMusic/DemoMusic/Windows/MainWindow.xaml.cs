using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoMusic.Models;
using DemoMusic.ViewControllers;
using DemoMusic.Windows;

namespace DemoMusic {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private MusicDemoContext _context;
        private List<Equipment> products;

        public MainWindow(User? user = null) {
            InitializeComponent();
            _context = new MusicDemoContext();

            WelcomeName.Text = user?.Fio ?? "Гость";
            UserRole.Content = user?.Role ?? "Гость";

            if (user == null) return;

            switch (user.Role) {
                case "Администратор":
                    PanelFind.Visibility = Visibility.Visible;
                    CRUD.Visibility = Visibility.Visible;
                    ButtonOrders.Visibility = Visibility.Visible;
                    break;
                case "Менеджер":
                    ButtonOrders.Visibility = Visibility.Visible;
                    break;
                case "Авторизированный клиент":
                    break;
            }

            DrawSuppliers();

            RadioUp.IsChecked = true;

            products = _context.Equipments.ToList();

            DrawProduct(products);
        }

        // Так как поставщиков не вывел в отдельную таблицу, сделаем криво
        public void DrawSuppliers() {
            List<Supplier> suppliers = new List<Supplier>() {
                new Supplier() {
                    Id = -1,
                    Name = "все поставщики",
                }
            };
            // suppliers.AddRange(_context.Suppliers.ToList());
            // костылим временно
            var rawNames = _context.Equipments
                .Select(e => e.Supp)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToList();

            var supplierEntities = new List<Supplier>();
            int i = 1;
            foreach (var name in rawNames) {
                supplierEntities.Add(new Supplier { Id = i++, Name = name });
            }

            suppliers.AddRange(supplierEntities);

            // конец костылей

            ComboSuppliers.ItemsSource = suppliers;
        }

        public void DrawProduct(List<Equipment> products) {
            ListProducts.ItemsSource = products.Select(p => new ProductControl(p));
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void RadioUp_Checked(object sender, RoutedEventArgs e) {

        }

        private void RadioDown_Checked(object sender, RoutedEventArgs e) {

        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void ButtonOrders_Click(object sender, RoutedEventArgs e) {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e) {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) {

        }
    }
}