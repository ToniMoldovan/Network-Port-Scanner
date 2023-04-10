using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect_Securitate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string pythonPath = "C:\\Users\\anton\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe"; // Path to Python executable
        private string scriptFolderPath = "D:\\Facultate\\Proiect-Securitate\\Proiect-Securitate\\scripts";

        private async void btn_testScript_ClickAsync(object sender, EventArgs e)
        {
            UpdateProgressBar(0);

            string scriptPath = scriptFolderPath + "\\testScript.py"; // Path to Python script

            ProcessStartInfo startInfo = new ProcessStartInfo(); // Create new process
            startInfo.FileName = pythonPath; // Set Python executable path
            startInfo.Arguments = scriptPath; // Set Python script path
            startInfo.UseShellExecute = false; // Do not use shell
            startInfo.RedirectStandardOutput = true; // Redirect standard output (so we can read it)

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.OutputDataReceived += (s, args) =>
                {
                    if (args.Data != null && args.Data.Contains("Progress:"))
                    {
                        string[] split = args.Data.Split(':');
                        int progress = int.Parse(split[1].Trim());
                        UpdateProgressBar(progress);
                    }
                };
                process.Start();
                process.BeginOutputReadLine();

                while (!process.HasExited)
                {
                    await Task.Delay(100);
                }

                UpdateProgressBar(100);
            }


        }

        private void UpdateProgressBar(int progress)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() =>
                {
                    UpdateProgressBar(progress);
                }));
            }
            else
            {
                progressBar.Value = progress;
                progressBar.Refresh();
            }
        }
    }
}
