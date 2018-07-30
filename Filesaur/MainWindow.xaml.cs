using System;
using System.Threading;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Filesaur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Operations index (is that even the proper name?)
        int Move = 0;
        int Delete = 1;

        // Error codes index (is that even the proper name?)
        int NoOperationsExecuted = 101;

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
            process.StartInfo.WorkingDirectory = ScriptsDir;

            if (operationToExecute == Move)
            {
                process.StartInfo.FileName = "move.bat";
                process.StartInfo.Arguments = String.Format("{0} {1} {2}", textbox_FromDir.Text, textbox_ToDir.Text, textbox_Filetype.Text);
            }
            else if (operationToExecute == Delete)
            {
                process.StartInfo.FileName = "delete.bat";
                process.StartInfo.Arguments = String.Format("{0} {1}", textbox_FromDir.Text, textbox_Filetype.Text);
            }
            else
            {
                exitCode = NoOperationsExecuted;
                MessageBox.Show(exitCode.ToString());
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
                StartCMD(Move);
            }
            else if (comboBox1.SelectedIndex == Delete)
            {
                StartCMD(Delete);
            }
        }
    }
}
