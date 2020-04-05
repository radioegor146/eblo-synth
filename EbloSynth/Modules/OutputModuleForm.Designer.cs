namespace EbloSynth.Modules
{
    partial class OutputModuleForm
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
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.refreshDeviceListButton = new System.Windows.Forms.Button();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.inputLButton = new System.Windows.Forms.Button();
            this.inputRButton = new System.Windows.Forms.Button();
            this.configGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(6, 35);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(188, 21);
            this.deviceComboBox.TabIndex = 1;
            this.deviceComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceComboBox_SelectedIndexChanged);
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.refreshDeviceListButton);
            this.configGroupBox.Controls.Add(this.deviceLabel);
            this.configGroupBox.Controls.Add(this.deviceComboBox);
            this.configGroupBox.Location = new System.Drawing.Point(93, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(200, 92);
            this.configGroupBox.TabIndex = 2;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Config";
            // 
            // refreshDeviceListButton
            // 
            this.refreshDeviceListButton.Location = new System.Drawing.Point(6, 62);
            this.refreshDeviceListButton.Name = "refreshDeviceListButton";
            this.refreshDeviceListButton.Size = new System.Drawing.Size(188, 23);
            this.refreshDeviceListButton.TabIndex = 4;
            this.refreshDeviceListButton.Text = "Refresh device list";
            this.refreshDeviceListButton.UseVisualStyleBackColor = true;
            this.refreshDeviceListButton.Click += new System.EventHandler(this.refreshDeviceListButton_Click);
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(6, 16);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(44, 13);
            this.deviceLabel.TabIndex = 3;
            this.deviceLabel.Text = "Device:";
            // 
            // inputLButton
            // 
            this.inputLButton.Location = new System.Drawing.Point(12, 12);
            this.inputLButton.Name = "inputLButton";
            this.inputLButton.Size = new System.Drawing.Size(75, 23);
            this.inputLButton.TabIndex = 3;
            this.inputLButton.Text = "Input L";
            this.inputLButton.UseVisualStyleBackColor = true;
            this.inputLButton.Click += new System.EventHandler(this.inputLButton_Click);
            // 
            // inputRButton
            // 
            this.inputRButton.Location = new System.Drawing.Point(12, 41);
            this.inputRButton.Name = "inputRButton";
            this.inputRButton.Size = new System.Drawing.Size(75, 23);
            this.inputRButton.TabIndex = 4;
            this.inputRButton.Text = "Input R";
            this.inputRButton.UseVisualStyleBackColor = true;
            this.inputRButton.Click += new System.EventHandler(this.inputRButton_Click);
            // 
            // OutputModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 115);
            this.Controls.Add(this.inputRButton);
            this.Controls.Add(this.inputLButton);
            this.Controls.Add(this.configGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputModuleForm";
            this.Text = "Output";
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Button refreshDeviceListButton;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.Button inputLButton;
        private System.Windows.Forms.Button inputRButton;
    }
}