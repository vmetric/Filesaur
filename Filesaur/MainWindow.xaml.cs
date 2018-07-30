using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
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

        int Move = 0;
        int Delete = 1;
        int MoveNotExecuted = 2;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void StartCMD(int operationToExecute)
        {
            int exitCode;
            Process process = new Process();
            string executionDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string ScriptsDir = executionDirectory + "Scripts";

            if (operationToExecute == Move)
            {
                process.StartInfo.WorkingDirectory = ScriptsDir;
                process.StartInfo.FileName = "test.bat";
            }
            else if (operationToExecute == Delete)
            {

            }
            else
            {
                exitCode = MoveNotExecuted;
                return;
            }

            process.Start();
            process.WaitForExit();
            exitCode = process.ExitCode;
            process.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == Move)
            {
                // Makes all necessary fields visible
                textbox_FromDir.Visibility = System.Windows.Visibility.Visible;
                textbox_ToDir.Visibility = System.Windows.Visibility.Visible;
                textbox_Filetype.Visibility = System.Windows.Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == Delete)
            {
                // Hides unnecessary field
                textbox_ToDir.Visibility = Visibility.Hidden;
                // Makes all necessary fields visible
                textbox_FromDir.Visibility = Visibility.Visible;
                textbox_Filetype.Visibility = Visibility.Visible;
            }


        }

        private void buttonExecute_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == Move)
            {
                // Declares strings, one for each textbox input to be used.
                string fromDir = textbox_FromDir.Text.ToString();
                string toDir = textbox_ToDir.Text.ToString();
                string filetype = textbox_Filetype.Text.ToString();

                StartCMD(Move);
            }
            else if (comboBox1.SelectedIndex == Delete)
            {
                // Declares strings, one for each textbox input to be used.
                string fromDir = textbox_FromDir.Text.ToString();
                string filetype = textbox_Filetype.Text.ToString();
            }
        }
    }
}
