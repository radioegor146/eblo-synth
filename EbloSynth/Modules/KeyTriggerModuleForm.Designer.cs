namespace EbloSynth.Modules
{
    partial class KeyTriggerModuleForm
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
            this.triggerButton = new System.Windows.Forms.Button();
            this.cvOutputButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // triggerButton
            // 
            this.triggerButton.Location = new System.Drawing.Point(12, 12);
            this.triggerButton.Name = "triggerButton";
            this.triggerButton.Size = new System.Drawing.Size(100, 100);
            this.triggerButton.TabIndex = 0;
            this.triggerButton.Text = "Trigger";
            this.triggerButton.UseVisualStyleBackColor = true;
            this.triggerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.triggerButton_MouseDown);
            this.triggerButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.triggerButton_MouseUp);
            // 
            // cvOutputButton
            // 
            this.cvOutputButton.Location = new System.Drawing.Point(118, 12);
            this.cvOutputButton.Name = "cvOutputButton";
            this.cvOutputButton.Size = new System.Drawing.Size(75, 23);
            this.cvOutputButton.TabIndex = 1;
            this.cvOutputButton.Text = "CV";
            this.cvOutputButton.UseVisualStyleBackColor = true;
            this.cvOutputButton.Click += new System.EventHandler(this.cvOutputButton_Click);
            // 
            // KeyTriggerModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 125);
            this.Controls.Add(this.cvOutputButton);
            this.Controls.Add(this.triggerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyTriggerModuleForm";
            this.Text = "Key Trigger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button triggerButton;
        private System.Windows.Forms.Button cvOutputButton;
    }
}