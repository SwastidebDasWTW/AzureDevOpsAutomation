namespace AzureDevOpsAutomation
{
    partial class Form1
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
            panelDrop = new Panel();
            label1 = new Label();
            lblFilePath = new Label();
            btnRun = new Button();
            SuspendLayout();
            // 
            // panelDrop
            // 
            panelDrop.AllowDrop = true;
            panelDrop.BorderStyle = BorderStyle.FixedSingle;
            panelDrop.Location = new Point(237, 29);
            panelDrop.Name = "panelDrop";
            panelDrop.Size = new Size(268, 96);
            panelDrop.TabIndex = 1;
            panelDrop.DragDrop += panelDrop_DragDrop;
            panelDrop.DragEnter += panelDrop_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-1, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(335, 141);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(50, 20);
            lblFilePath.TabIndex = 3;
            lblFilePath.Text = "label2";
            lblFilePath.Click += label2_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(266, 207);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(191, 40);
            btnRun.TabIndex = 4;
            btnRun.Text = "InitialTicketsUpdation";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRun);
            Controls.Add(lblFilePath);
            Controls.Add(label1);
            Controls.Add(panelDrop);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDrop;
        private Label label1;
        private Label lblFilePath;
        private Button btnRun;
    }
}
