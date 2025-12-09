using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using DemoMusic.Models;

namespace DemoMusic.ViewControllers {
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl {

        private string projPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public ProductControl(Equipment equipment) {
            InitializeComponent();

            DataContext = equipment;

            string path = $"{projPath}\\Images\\{(equipment.Pic ?? "picture.png")}";

            string imgPath = File.Exists(path)
                ? path
                : $"{projPath}\\Images\\picture.png";

            BoxImage.Source = new BitmapImage(new Uri(imgPath));

            if (equipment.Discount > 15) {
                BoxDiscont.Background = new BrushConverter().ConvertFrom("#2E8B57") as SolidColorBrush;
            }
            if (equipment.Discount > 0) {
                BoxPrice.Foreground = Brushes.Red;
                BoxPrice.TextDecorations.Add(TextDecorations.Strikethrough);

                BoxNewPrice.Text = (equipment.Cost * (1 - equipment.Discount / 100.0)).ToString();
            }
            if (equipment.Avail == 0) {
                BoxCount.Foreground = Brushes.Blue;
            }
        }
    }
}
