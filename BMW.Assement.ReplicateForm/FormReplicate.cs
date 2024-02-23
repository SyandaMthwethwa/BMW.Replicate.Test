using BMW.Assessment.ReplicateForm.Logic;
using BMW.Assessment.ReplicateForm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using EventLog = BMW.Assessment.ReplicateForm.Logic.EventLog;

namespace BMW.Assessment.ReplicateForm
{
    public partial class FormReplicate : Form

    {
        #region Global Variables
        private StringBuilder logBuilder = new StringBuilder();
        private string logFilePath = "log.txt";
        #endregion

        public FormReplicate()
        {
            InitializeComponent();
            LoadSettings();
        }
        #region Load Settings
        private void LoadSettings()
        {
            sourceTextBox.Text = Properties.Settings.Default.SourceDirectory;
            destinationTextBox.Text = Properties.Settings.Default.DestinationDirectory;
            includeSubdirectoriesCheckBox.Checked = Properties.Settings.Default.IncludeSubdirectories;

        }
        #endregion


        #region Save Settings For Later Use
        private void SaveSettings()
        {
            Properties.Settings.Default.SourceDirectory = sourceTextBox.Text;
            Properties.Settings.Default.DestinationDirectory = destinationTextBox.Text;
            Properties.Settings.Default.IncludeSubdirectories = includeSubdirectoriesCheckBox.Checked;
            Properties.Settings.Default.DoNotDeleteDirectoriesFiles = donotdeleteCheck.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Button Replicate
        private void btnReplicate_Click(object sender, EventArgs e)
        {
            string sourceDir = sourceTextBox.Text;
            string destinationDir = destinationTextBox.Text;
            bool includeSubdirectories = includeSubdirectoriesCheckBox.Checked;
            bool donotdeletedirectoriesfiles = donotdeleteCheck.Checked;

            if (!Directory.Exists(sourceDir))
            {
                MessageBox.Show("Source directory does not exist.");
                return;
            }
            if (!Directory.Exists(destinationDir) && includeSubdirectories)
            {
                DialogResult dialogResult = MessageBox.Show("Destination directory does not exist. Do you want to create directory?", "Replicate Form", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(destinationDir);
                    new EventLog().Log($"New Destination Directory Created : {destinationDir} @ {DateTime.Now}", logBuilder);
                    includeSubdirectories = false;
                }
                else
                {
                    return;
                }
            }
            if (!Directory.Exists(destinationDir) && !includeSubdirectories)
            {
                MessageBox.Show("Destination directory does not exist.");
                return;
            }

            logBuilder.Clear();
            CompareDirectories(sourceDir, destinationDir, includeSubdirectories, donotdeletedirectoriesfiles);
            new EventLog().Log(logBuilder.ToString(), logBuilder);
            SaveSettings();
            MessageBox.Show("Comparison completed. Please check the log for details.");
        }
        #endregion

        #region Comparison Method
        private void CompareDirectories(string sourceDir, string destinationDir, bool includeSubdirectories, bool donotdeletedirectoriesfiles)
        {

            string[] files = Directory.GetFiles(sourceDir);
            string[] dirs = Directory.GetDirectories(sourceDir);
            List<string> sourceFiles = Directory.GetFiles(sourceDir).Select(Path.GetFileName).ToList();
            List<string> destinationFiles = Directory.GetFiles(destinationDir).Select(Path.GetFileName).ToList();
            IEnumerable<string> NoneExistFilesInSource = destinationFiles.Except(sourceFiles);

            int progressBarMaxValue = 0;
            foreach (string file in files)
            {
                progressBarMaxValue++;
                StartProgressBar(progressBarMaxValue);
                new Directories().CompareFile(file, destinationDir, donotdeletedirectoriesfiles, logBuilder);
            }

            if (!donotdeletedirectoriesfiles)
            {
                foreach (string file in NoneExistFilesInSource)
                {
                    progressBarMaxValue++;
                    StartProgressBar(progressBarMaxValue);
                    new Directories().DeleteNoneExistFile(file, destinationDir, logBuilder);
                }
            }


            foreach (string dir in dirs)
            {
                progressBarMaxValue++;
                StartProgressBar(progressBarMaxValue);
                string destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
                new Directories().CreateDirectoryIfNotExist(destDir, dir, logBuilder);
                CompareDirectories(dir, destDir, includeSubdirectories, donotdeletedirectoriesfiles);
            }


            if (!includeSubdirectories && !donotdeletedirectoriesfiles)
            {
                foreach (string dir in Directory.GetDirectories(destinationDir))
                {
                    progressBarMaxValue++;
                    StartProgressBar(progressBarMaxValue);
                    if (!dirs.Contains(dir))
                    {
                        Directory.Delete(dir, true);
                        new EventLog().Log($"Deleted directory: {dir} @ {DateTime.Now}", logBuilder);
                    }
                }
            }
        }
        #endregion

        #region View Logs
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            new EventLog().ViewLogs(logFilePath, logBuilder);
        }
        #endregion

        #region Browse Source Directory
        private void btnBrowseSrc_Click(object sender, EventArgs e)
        {
            var SourceDirectoryBrowserDialog = new FolderBrowserDialog();
            DialogResult result = SourceDirectoryBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(SourceDirectoryBrowserDialog.SelectedPath))
            {
                sourceTextBox.Text = SourceDirectoryBrowserDialog.SelectedPath;
            }
        }
        #endregion

        #region Browse Destination Directory
        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            var DestinationDirectoryBrowserDialog = new FolderBrowserDialog();
            DialogResult result = DestinationDirectoryBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(DestinationDirectoryBrowserDialog.SelectedPath))
            {
                destinationTextBox.Text = DestinationDirectoryBrowserDialog.SelectedPath;
            }
        }
        #endregion

        #region Exit Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Start Progress Bar
        public void StartProgressBar(int progresMax)
        {
            progressBar1.Step = 1;
            progressBar1.Maximum = Convert.ToInt32(progresMax);
            progressBar1.PerformStep();
        }
        #endregion

        #region Include Subdirectories Options
        private void includeSubdirectoriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (includeSubdirectoriesCheckBox.Checked)
            {
                destinationTextBox.Enabled = true;
            }
            else
            {
                destinationTextBox.Enabled = false;
            }
        }
        #endregion
    }
}