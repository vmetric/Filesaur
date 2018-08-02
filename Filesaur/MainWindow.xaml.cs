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
        int CreateDummyFiles = 2;

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
                process.StartInfo.Arguments = String.Format("{0} {1} {2}", textbox1.Text, textbox2.Text, textbox3.Text);
            }
            else if (operationToExecute == Delete)
            {
                process.StartInfo.FileName = "delete.bat";
                process.StartInfo.Arguments = String.Format("{0} {1}", textbox1.Text, textbox3.Text);
            }
            else if (operationToExecute == CreateDummyFiles)
            {
                process.StartInfo.FileName = "dummyfiles.bat";
                process.StartInfo.Arguments = String.Format("{0} {1} {2}", textbox3.Text, textbox2.Text, textbox1.Text);
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
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Directory to move files from";
                textbox2.Text = "Directory to move files to";
                textbox3.Text = "Filetype of files to move";

                // Makes all necessary fields visible
                textbox1.Visibility = System.Windows.Visibility.Visible;
                textbox2.Visibility = System.Windows.Visibility.Visible;
                textbox3.Visibility = System.Windows.Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == Delete)
            {
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Directory to delete files from";
                textbox3.Text = "Filetype of files to delete";

                // Hides unnecessary field
                textbox2.Visibility = Visibility.Hidden;

                // Makes all necessary fields visible
                textbox1.Visibility = Visibility.Visible;
                textbox3.Visibility = Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == CreateDummyFiles)
            {
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Location to create files";
                textbox2.Text = "Size to make files (in MB)";
                textbox3.Text = "Number of files to make";

                // Makes all necessary fields visible
                textbox1.Visibility = System.Windows.Visibility.Visible;
                textbox2.Visibility = System.Windows.Visibility.Visible;
                textbox3.Visibility = System.Windows.Visibility.Visible;
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
            else if (comboBox1.SelectedIndex == CreateDummyFiles)
            {
                StartCMD(CreateDummyFiles);
            }
        }
    }
}
