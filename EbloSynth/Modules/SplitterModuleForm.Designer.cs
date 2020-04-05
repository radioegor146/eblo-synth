namespace EbloSynth.Modules
{
    sealed partial class SplitterModuleForm<T>
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
            this.inputButton = new System.Windows.Forms.Button();
            this.output2Button = new System.Windows.Forms.Button();
            this.output1Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(12, 12);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(75, 23);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Input";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // output2Button
            // 
            this.output2Button.Location = new System.Drawing.Point(93, 41);
            this.output2Button.Name = "output2Button";
            this.output2Button.Size = new System.Drawing.Size(75, 23);
            this.output2Button.TabIndex = 1;
            this.output2Button.Text = "Output #2";
            this.output2Button.UseVisualStyleBackColor = true;
            this.output2Button.Click += new System.EventHandler(this.output2Button_Click);
            // 
            // output1Button
            // 
            this.output1Button.Location = new System.Drawing.Point(93, 12);
            this.output1Button.Name = "output1Button";
            this.output1Button.Size = new System.Drawing.Size(75, 23);
            this.output1Button.TabIndex = 2;
            this.output1Button.Text = "Output #1";
            this.output1Button.UseVisualStyleBackColor = true;
            this.output1Button.Click += new System.EventHandler(this.output1Button_Click);
            // 
            // SplitterModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 77);
            this.Controls.Add(this.output1Button);
            this.Controls.Add(this.output2Button);
            this.Controls.Add(this.inputButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplitterModuleForm";
            this.Text = "SplitterModuleForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button output2Button;
        private System.Windows.Forms.Button output1Button;
    }
}