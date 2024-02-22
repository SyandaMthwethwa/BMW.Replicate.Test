using BMW.Assessment.ReplicateForm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BMW.Assessment.ReplicateForm
{
    public partial class FormReplicate : Form
    {
        private StringBuilder logBuilder = new StringBuilder();
        private string logFilePath = "log.txt";


        public FormReplicate()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            sourceTextBox.Text = Properties.Settings.Default.SourceDirectory;
            destinationTextBox.Text = Properties.Settings.Default.DestinationDirectory;
            includeSubdirectoriesCheckBox.Checked = Properties.Settings.Default.IncludeSubdirectories;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.SourceDirectory = sourceTextBox.Text;
            Properties.Settings.Default.DestinationDirectory = destinationTextBox.Text;
            Properties.Settings.Default.IncludeSubdirectories = includeSubdirectoriesCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnReplicate_Click(object sender, EventArgs e)
        {
            string sourceDir = sourceTextBox.Text;
            string destinationDir = destinationTextBox.Text;
            bool includeSubdirectories = includeSubdirectoriesCheckBox.Checked;
            

            if (!Directory.Exists(sourceDir) || !Directory.Exists(destinationDir))
            {
                MessageBox.Show("Source or destination directory does not exist.");
                return;
            }

            logBuilder.Clear();
            CompareDirectories(sourceDir, destinationDir, includeSubdirectories);
            Log(logBuilder.ToString());
            SaveSettings();
            MessageBox.Show("Comparison completed. Please check the log for details.");
        }

        private void CompareDirectories(string sourceDir, string destinationDir, bool includeSubdirectories)
        {

            string[] files = Directory.GetFiles(sourceDir);
            string[] dirs = Directory.GetDirectories(sourceDir);
            List<string> sourceFiles = Directory.GetFiles(sourceDir).Select(Path.GetFileName).ToList();
            List<string> destinationFiles = Directory.GetFiles(destinationDir).Select(Path.GetFileName).ToList();
            IEnumerable<string> filesmissingfromSource = destinationFiles.Except(sourceFiles);


            int progressMax = 0;
            foreach (string file in files)
            {
                progressMax++;
                StartProgressBar(progressMax);
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                if (!File.Exists(destFile) || File.GetLastWriteTime(file) != File.GetLastWriteTime(destFile) || new FileInfo(file).Length != new FileInfo(destFile).Length)
                {
                    File.Copy(file, destFile, true);
                    Log($"Copied {file} to {destFile} @ {DateTime.Now}");
                }
            }

            foreach(string file in filesmissingfromSource)
            {
                string filePath = Path.Combine(destinationDir, file);
                File.Delete(filePath);
                Log($"Non Exist File Deleted: {file} from: {filePath} @: {DateTime.Now}");
            }
           

            foreach (string dir in dirs)
            {
                string destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                    Log($"Created directory: {destDir} @ {DateTime.Now}");
                }
                CompareDirectories(dir, destDir, includeSubdirectories);
            }


            if (!includeSubdirectories)
            {
                foreach (string dir in Directory.GetDirectories(destinationDir))
                {
                    if (!dirs.Contains(dir))
                    {
                        Directory.Delete(dir, true);
                        Log($"Deleted directory: {dir} @ {DateTime.Now}");
                    }
                }
            }
        }

        private void Log(string message)
        {
            logBuilder.AppendLine(message);
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            File.WriteAllText(logFilePath, logBuilder.ToString());
            System.Diagnostics.Process.Start("notepad.exe", logFilePath);
        }

        private void btnBrowseSrc_Click(object sender, EventArgs e)
        {
            var SourceDirectoryBrowserDialog = new FolderBrowserDialog();
            DialogResult result = SourceDirectoryBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(SourceDirectoryBrowserDialog.SelectedPath))
            {
                sourceTextBox.Text = SourceDirectoryBrowserDialog.SelectedPath;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            var DestinationDirectoryBrowserDialog = new FolderBrowserDialog();
            DialogResult result = DestinationDirectoryBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(DestinationDirectoryBrowserDialog.SelectedPath))
            {
                destinationTextBox.Text = DestinationDirectoryBrowserDialog.SelectedPath;
            }
        }

        private void StartProgressBar(int progresMax)
        {
            progressBar1.Step = 1;
            progressBar1.Maximum = Convert.ToInt32(progresMax);
            progressBar1.PerformStep();
        }
    }
}