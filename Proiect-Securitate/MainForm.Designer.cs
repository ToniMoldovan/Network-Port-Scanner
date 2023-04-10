namespace Proiect_Securitate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scanNetworkBtn = new System.Windows.Forms.Button();
            this.generateTrafficBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.scanOpenPortsBtn = new System.Windows.Forms.Button();
            this.btn_testScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scanNetworkBtn
            // 
            this.scanNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanNetworkBtn.Location = new System.Drawing.Point(12, 107);
            this.scanNetworkBtn.Name = "scanNetworkBtn";
            this.scanNetworkBtn.Size = new System.Drawing.Size(111, 65);
            this.scanNetworkBtn.TabIndex = 0;
            this.scanNetworkBtn.Text = "Scan Network";
            this.scanNetworkBtn.UseVisualStyleBackColor = true;
            this.scanNetworkBtn.Click += new System.EventHandler(this.scanNetworkBtn_Click);
            // 
            // generateTrafficBtn
            // 
            this.generateTrafficBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateTrafficBtn.Location = new System.Drawing.Point(640, 107);
            this.generateTrafficBtn.Name = "generateTrafficBtn";
            this.generateTrafficBtn.Size = new System.Drawing.Size(132, 65);
            this.generateTrafficBtn.TabIndex = 1;
            this.generateTrafficBtn.Text = "Generate Traffic";
            this.generateTrafficBtn.UseVisualStyleBackColor = true;
            this.generateTrafficBtn.Click += new System.EventHandler(this.generateTrafficBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to our app!";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 318);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(760, 40);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.UseWaitCursor = true;
            // 
            // scanOpenPortsBtn
            // 
            this.scanOpenPortsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanOpenPortsBtn.Location = new System.Drawing.Point(208, 107);
            this.scanOpenPortsBtn.Name = "scanOpenPortsBtn";
            this.scanOpenPortsBtn.Size = new System.Drawing.Size(132, 65);
            this.scanOpenPortsBtn.TabIndex = 4;
            this.scanOpenPortsBtn.Text = "Scan Open Ports";
            this.scanOpenPortsBtn.UseVisualStyleBackColor = true;
            this.scanOpenPortsBtn.Click += new System.EventHandler(this.scanOpenPortsBtn_Click);
            // 
            // btn_testScript
            // 
            this.btn_testScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_testScript.Location = new System.Drawing.Point(431, 107);
            this.btn_testScript.Name = "btn_testScript";
            this.btn_testScript.Size = new System.Drawing.Size(132, 65);
            this.btn_testScript.TabIndex = 5;
            this.btn_testScript.Text = "Test Python Script";
            this.btn_testScript.UseVisualStyleBackColor = true;
            this.btn_testScript.Click += new System.EventHandler(this.btn_testScript_ClickAsync);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.btn_testScript);
            this.Controls.Add(this.scanOpenPortsBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateTrafficBtn);
            this.Controls.Add(this.scanNetworkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proiect Securitate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanNetworkBtn;
        private System.Windows.Forms.Button generateTrafficBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button scanOpenPortsBtn;
        private System.Windows.Forms.Button btn_testScript;
    }
}

