namespace EbloSynth.Modules
{
    partial class SineSynthModuleForm
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
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.frequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cvInputButton = new System.Windows.Forms.Button();
            this.soundOutputButton = new System.Windows.Forms.Button();
            this.configGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.frequencyLabel);
            this.configGroupBox.Controls.Add(this.frequencyNumericUpDown);
            this.configGroupBox.Location = new System.Drawing.Point(93, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(258, 60);
            this.configGroupBox.TabIndex = 0;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Config";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(6, 16);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(60, 13);
            this.frequencyLabel.TabIndex = 1;
            this.frequencyLabel.Text = "Frequency:";
            // 
            // frequencyNumericUpDown
            // 
            this.frequencyNumericUpDown.DecimalPlaces = 3;
            this.frequencyNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.frequencyNumericUpDown.Location = new System.Drawing.Point(6, 32);
            this.frequencyNumericUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Name = "frequencyNumericUpDown";
            this.frequencyNumericUpDown.Size = new System.Drawing.Size(246, 20);
            this.frequencyNumericUpDown.TabIndex = 1;
            this.frequencyNumericUpDown.Value = new decimal(new int[] {
            228,
            0,
            0,
            0});
            this.frequencyNumericUpDown.ValueChanged += new System.EventHandler(this.frequencyNumericUpDown_ValueChanged);
            // 
            // cvInputButton
            // 
            this.cvInputButton.Location = new System.Drawing.Point(12, 12);
            this.cvInputButton.Name = "cvInputButton";
            this.cvInputButton.Size = new System.Drawing.Size(75, 23);
            this.cvInputButton.TabIndex = 1;
            this.cvInputButton.Text = "CV";
            this.cvInputButton.UseVisualStyleBackColor = true;
            this.cvInputButton.Click += new System.EventHandler(this.cvInputButton_Click);
            // 
            // soundOutputButton
            // 
            this.soundOutputButton.Location = new System.Drawing.Point(357, 12);
            this.soundOutputButton.Name = "soundOutputButton";
            this.soundOutputButton.Size = new System.Drawing.Size(75, 23);
            this.soundOutputButton.TabIndex = 2;
            this.soundOutputButton.Text = "Output";
            this.soundOutputButton.UseVisualStyleBackColor = true;
            this.soundOutputButton.Click += new System.EventHandler(this.soundOutputButton_Click);
            // 
            // SineSynthModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 78);
            this.Controls.Add(this.soundOutputButton);
            this.Controls.Add(this.cvInputButton);
            this.Controls.Add(this.configGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SineSynthModuleForm";
            this.Text = "Sine Synth";
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.NumericUpDown frequencyNumericUpDown;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button cvInputButton;
        private System.Windows.Forms.Button soundOutputButton;
    }
}