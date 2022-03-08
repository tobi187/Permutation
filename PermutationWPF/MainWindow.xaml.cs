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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PermutationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dateField.SelectedDate = DateTime.Today;
            var dt = DateTime.Today.ToString("dd MM yyyy");
            savePath.SelectedText = @$"C:\{dt}";
        }

private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
