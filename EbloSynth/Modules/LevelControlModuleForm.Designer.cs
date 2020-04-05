namespace EbloSynth.Modules
{
    partial class LevelControlModuleForm
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
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelTrackBar = new System.Windows.Forms.TrackBar();
            this.soundInputButton = new System.Windows.Forms.Button();
            this.cvInputButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.configGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.levelLabel);
            this.configGroupBox.Controls.Add(this.levelTrackBar);
            this.configGroupBox.Location = new System.Drawing.Point(93, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(200, 86);
            this.configGroupBox.TabIndex = 0;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Config";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(7, 20);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(36, 13);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Level:";
            // 
            // levelTrackBar
            // 
            this.levelTrackBar.LargeChange = 50;
            this.levelTrackBar.Location = new System.Drawing.Point(6, 36);
            this.levelTrackBar.Maximum = 1000;
            this.levelTrackBar.Name = "levelTrackBar";
            this.levelTrackBar.Size = new System.Drawing.Size(188, 45);
            this.levelTrackBar.TabIndex = 1;
            this.levelTrackBar.TickFrequency = 100;
            this.levelTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.levelTrackBar.Scroll += new System.EventHandler(this.levelTrackBar_Scroll);
            // 
            // soundInputButton
            // 
            this.soundInputButton.Location = new System.Drawing.Point(12, 12);
            this.soundInputButton.Name = "soundInputButton";
            this.soundInputButton.Size = new System.Drawing.Size(75, 23);
            this.soundInputButton.TabIndex = 1;
            this.soundInputButton.Text = "Input";
            this.soundInputButton.UseVisualStyleBackColor = true;
            this.soundInputButton.Click += new System.EventHandler(this.soundInputButton_Click);
            // 
            // cvInputButton
            // 
            this.cvInputButton.Location = new System.Drawing.Point(12, 41);
            this.cvInputButton.Name = "cvInputButton";
            this.cvInputButton.Size = new System.Drawing.Size(75, 23);
            this.cvInputButton.TabIndex = 2;
            this.cvInputButton.Text = "CV";
            this.cvInputButton.UseVisualStyleBackColor = true;
            this.cvInputButton.Click += new System.EventHandler(this.cvInputButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(299, 12);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(75, 23);
            this.outputButton.TabIndex = 3;
            this.outputButton.Text = "Output";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // LevelControlModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 104);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.cvInputButton);
            this.Controls.Add(this.soundInputButton);
            this.Controls.Add(this.configGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelControlModuleForm";
            this.Text = "Level Control";
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.TrackBar levelTrackBar;
        private System.Windows.Forms.Button soundInputButton;
        private System.Windows.Forms.Button cvInputButton;
        private System.Windows.Forms.Button outputButton;
    }
}