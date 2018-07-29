using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
            ProcessStartInfo processInfo;
            Process process;
            string executionDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (operationToExecute == Move)
            {
                processInfo = new ProcessStartInfo("cmd.exe", "/c " + executionDirectory + "\\Scripts\\move.bat");
            }
            else if (operationToExecute == Delete)
            {
                processInfo = new ProcessStartInfo("cmd.exe", "/c " + executionDirectory + "\\Scripts\\delete.bat");
            }
            else
            {
                exitCode = MoveNotExecuted;
                return;
            }

            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // Redirect the output
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // Read the streams
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
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
