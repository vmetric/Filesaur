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

namespace Filesaur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                // Makes all necessary fields visible
                fromDir.Visibility = System.Windows.Visibility.Visible;
                toDir.Visibility = System.Windows.Visibility.Visible;
                filetype.Visibility = System.Windows.Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // Hides unnecessary field
                toDir.Visibility = Visibility.Hidden;
                // show all the things
                fromDir.Visibility = Visibility.Visible;
                filetype.Visibility = Visibility.Visible;
            }


        }
    }
}
