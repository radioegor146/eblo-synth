namespace EbloSynth.Modules
{
    partial class InputModuleForm
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
            this.outputLButton = new System.Windows.Forms.Button();
            this.outputRButton = new System.Windows.Forms.Button();
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
            this.configGroupBox.Location = new System.Drawing.Point(12, 12);
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
            // outputLButton
            // 
            this.outputLButton.Location = new System.Drawing.Point(218, 12);
            this.outputLButton.Name = "outputLButton";
            this.outputLButton.Size = new System.Drawing.Size(75, 23);
            this.outputLButton.TabIndex = 3;
            this.outputLButton.Text = "Output L";
            this.outputLButton.UseVisualStyleBackColor = true;
            this.outputLButton.Click += new System.EventHandler(this.outputLRadioButton_CheckedChanged);
            // 
            // outputRButton
            // 
            this.outputRButton.Location = new System.Drawing.Point(218, 41);
            this.outputRButton.Name = "outputRButton";
            this.outputRButton.Size = new System.Drawing.Size(75, 23);
            this.outputRButton.TabIndex = 4;
            this.outputRButton.Text = "Output R";
            this.outputRButton.UseVisualStyleBackColor = true;
            this.outputRButton.Click += new System.EventHandler(this.outputRRadioButton_CheckedChanged);
            // 
            // InputModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 115);
            this.Controls.Add(this.outputRButton);
            this.Controls.Add(this.outputLButton);
            this.Controls.Add(this.configGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputModuleForm";
            this.Text = "Input";
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Button refreshDeviceListButton;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.Button outputLButton;
        private System.Windows.Forms.Button outputRButton;
    }
}