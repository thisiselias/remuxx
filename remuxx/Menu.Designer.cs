namespace remuxx
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InstallButton = new Button();
            UninstallButton = new Button();
            InstallLabel = new Label();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // InstallButton
            // 
            InstallButton.Location = new Point(39, 61);
            InstallButton.Name = "InstallButton";
            InstallButton.Size = new Size(75, 32);
            InstallButton.TabIndex = 0;
            InstallButton.Text = "Install";
            InstallButton.UseVisualStyleBackColor = true;
            InstallButton.Click += InstallButton_Click;
            // 
            // UninstallButton
            // 
            UninstallButton.Location = new Point(115, 61);
            UninstallButton.Name = "UninstallButton";
            UninstallButton.Size = new Size(75, 32);
            UninstallButton.TabIndex = 0;
            UninstallButton.Text = "Uninstall";
            UninstallButton.UseVisualStyleBackColor = true;
            UninstallButton.Click += UninstallButton_Click;
            // 
            // InstallLabel
            // 
            InstallLabel.AutoSize = true;
            InstallLabel.Location = new Point(39, 96);
            InstallLabel.Name = "InstallLabel";
            InstallLabel.Size = new Size(91, 15);
            InstallLabel.TabIndex = 1;
            InstallLabel.Text = "crazy easter egg";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(15, 34);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(110, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "by sillycatmoments";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 3;
            label1.Text = "remuxx installer";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 162);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(InstallLabel);
            Controls.Add(UninstallButton);
            Controls.Add(InstallButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InstallButton;
        private Button UninstallButton;
        private Label InstallLabel;
        private LinkLabel linkLabel1;
        private Label label1;
    }
}
