using System;
using System.Threading;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Filesaur
{
    public partial class MainWindow : Window
    {
        // Operations index
        const int Move = 0;
        const int Delete = 1;
        const int CreateDummyFiles = 2;
        const int Sort = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to start a command prompt window, executing "operationToExecute"
        public void StartCMD(int operationToExecute)
        {


            // Declares a new process, "process," and sets its working directory to folder "Scripts" in the same dir as the exe.
            // I.e., if the exe is at C:\1\Filesaur.exe, then the working directory will be set to C:\1\Scripts
            Process process = new Process();
            process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "Scripts";

            // Checks what the operationToExecute is, then:
            // Sets the filename for the process to start to the respective name (e.g., move.bat for Move) and then fills in necessary arguments with appropriate data from textboxes.
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
                process.StartInfo.Arguments = String.Format("{0} {1} {2} {3}", textbox3.Text, textbox2.Text, textbox1.Text, textbox4.Text);
            }
            else if (operationToExecute == Sort)
            {
                process.StartInfo.FileName = "sort.bat";
                process.StartInfo.Arguments = String.Format("{0} {1} {2}", textbox1.Text, textbox2.Text, textbox3.Text);
            }
            else
            {
                // If something unknown was entered for operationToExecute, display error message and return.
                MessageBox.Show("Error: StartCMD() was fed unknown operationToExecute");
                return;
            }
            // Start new thread for ran process.
            Thread thread = new Thread(new ThreadStart(() => process.Start()));
            thread.Start();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == Move)
            {
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Directory to move files from";
                textbox2.Text = "Directory to move files to";
                textbox3.Text = "Filetype of files to move";

                // Hides unnecessary fields
                textbox4.Visibility = Visibility.Hidden;

                // Makes all necessary fields visible
                textbox1.Visibility = Visibility.Visible;
                textbox2.Visibility = Visibility.Visible;
                textbox3.Visibility = Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == Delete)
            {
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Directory to delete files from";
                textbox3.Text = "Filetype of files to delete";

                // Hides unnecessary fields
                textbox2.Visibility = Visibility.Hidden;
                textbox4.Visibility = Visibility.Hidden;

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
                textbox4.Text = "Filetype to create (including dot, e.g., .png)";

                // Makes all necessary fields visible
                textbox1.Visibility = Visibility.Visible;
                textbox2.Visibility = Visibility.Visible;
                textbox3.Visibility = Visibility.Visible;
                textbox4.Visibility = Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex == Sort)
            {
                // Changes the content of the respective textboxes to explain what to put in them
                textbox1.Text = "Directory containing unsorted files";
                textbox2.Text = "Directory to sort files to (ensure it is NOT in the above directory)";
                textbox3.Text = "Intensity (1 for file type, 2 for file extension)";

                // Hides unnecessary fields
                textbox4.Visibility = Visibility.Hidden;

                // Makes all necessary fields visible
                textbox1.Visibility = Visibility.Visible;
                textbox2.Visibility = Visibility.Visible;
                textbox3.Visibility = Visibility.Visible;
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
            else if (comboBox1.SelectedIndex == Sort)
            {
                StartCMD(Sort);
            }
        }
    }
}
