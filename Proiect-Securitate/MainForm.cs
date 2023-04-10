using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            ChangeButtonState(false);
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


            ChangeButtonState(true);
        }

        private void scanNetworkBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);
            UpdateProgressBar(0);

            string interfaceName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the network interface:", "Network Interface Name", "Ethernet");

            string scriptPath = scriptFolderPath + "\\scanNetwork.py"; // Path to Python script

            ProcessStartInfo startInfo = new ProcessStartInfo(); // Create new process
            startInfo.FileName = pythonPath; // Set Python executable path
            startInfo.Arguments = $"\"{scriptPath}\" \"{interfaceName}\""; // Set Python script path and interface name as arguments
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
                    Application.DoEvents();
                }

                UpdateProgressBar(100);
            }

            ChangeButtonState(true);
        }

        private void generateTrafficBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);
            UpdateProgressBar(0);
            
            // Prompt user for IP address to ping and number of packets
            string ipAddress = Microsoft.VisualBasic.Interaction.InputBox("Enter IP Address to ping:", "IP Address");
            int numPackets = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter number of packets to send:", "Number of Packets"));

            // Construct the command to execute the Python script with the given arguments
            string scriptPath = scriptFolderPath + "\\generateTraffic.py";
            string arguments = $"-i {ipAddress} -n {numPackets}";
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\" {arguments}",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            // Launch the Python script and update the progress bar as it runs
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
                    Thread.Sleep(100);
                }

                UpdateProgressBar(100);
            }

            ChangeButtonState(true);
        }

        private async void scanOpenPortsBtn_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);
            UpdateProgressBar(0);

            // Show a dialog to get the desired output file path
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save Open Ports Output";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                UpdateProgressBar(0);

                string scriptPath = scriptFolderPath + "\\scanOpenPorts.py"; // Path to Python script
                string outputFile = saveFileDialog.FileName;

                ProcessStartInfo startInfo = new ProcessStartInfo(); // Create new process
                startInfo.FileName = pythonPath; // Set Python executable path
                startInfo.Arguments = $"\"{scriptPath}\" \"{outputFile}\""; // Set Python script path and output file path
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

                    MessageBox.Show("Open ports scan completed.");
                }
            }

            ChangeButtonState(true);
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
                // Clamp progress value to range [0, 100]
                if (progress < 0)
                {
                    progressBar.Value = 0;
                }
                else if (progress > 100)
                {
                    progressBar.Value = 100;
                }
                else
                {
                    progressBar.Value = progress;
                }

                progressBar.Refresh();
            }
        }

        private void ChangeButtonState(bool enabled)
        {
            if (enabled)
            {
                this.scanNetworkBtn.Enabled = true;
                this.btn_testScript.Enabled = true;
                this.generateTrafficBtn.Enabled = true;
                this.scanOpenPortsBtn.Enabled = true;
            }
            else
            {
                this.scanNetworkBtn.Enabled = false;
                this.btn_testScript.Enabled = false;
                this.generateTrafficBtn.Enabled = false;
                this.scanOpenPortsBtn.Enabled = false;
            }
        }

    }
}
