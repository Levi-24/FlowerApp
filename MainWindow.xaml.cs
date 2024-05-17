using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace FlowerApp
{
    public partial class MainWindow : Window
    {
        List<Flower> flowers = new List<Flower>();
        List<Flower> copy = new List<Flower>();

        public MainWindow()
        {
            InitializeComponent();

            using (var sr = new StreamReader("../../../src/flowers.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) flowers.Add(new Flower(sr.ReadLine()));
            }

            flowers = flowers.OrderBy(x => x.Name).ToList();
            foreach (var item in flowers) lbxFlower.Items.Add(item.Name);
            lbxFlower.SelectedIndex = 0;
        }

        private void lbxFlower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxFlower.SelectedIndex != -1)
            {
                int index = lbxFlower.SelectedIndex;
                var select = flowers[index];
                txbName.Text = select.Name;
                txbPrice.Text = select.Price.ToString();
                txbColor.Text = select.Color;

                string source = "../../../src/IMAGES/" + select.Image + '.' + select.ImageType;
                image.Source = new ImageSourceConverter().ConvertFromString(source) as ImageSource;
            }
            else
            {
                txbName.Text = "";
                txbPrice.Text = "";
                txbColor.Text = "";
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lbxFlower.Items.Count > 0)
            {
                flowers.RemoveAt(lbxFlower.SelectedIndex);

                lbxFlower.Items.Clear();
                foreach (var item in flowers) lbxFlower.Items.Add(item.Name);

                lbxFlower.SelectedIndex = 0;
            }
            if (lbxFlower.Items.Count == 0)
            {
                btnDel.IsEnabled = false;
                btnCopy.IsEnabled = false;
            }
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            copy.Add(flowers[lbxFlower.SelectedIndex]);

            lbxCopy.Items.Clear();
            foreach (var item in copy)
            {
                lbxCopy.Items.Add(item.Name);
            }
        }
    }
}