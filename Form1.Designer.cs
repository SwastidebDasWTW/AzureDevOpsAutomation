namespace AzureDevOpsAutomation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private FlowLayoutPanel panelActions;
        private Button btnRun;
        private RichTextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitle = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            panelActions = new FlowLayoutPanel();
            btnRun = new Button();
            txtLog = new RichTextBox();

            panelActions.SuspendLayout();
            SuspendLayout();

            // 🧠 Title
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(120, 20);
            labelTitle.Text = "Automate your Azure DevOps tasks effortlessly";

            // 📂 File Path
            txtFilePath.Location = new Point(120, 80);
            txtFilePath.Size = new Size(320, 27);
            txtFilePath.PlaceholderText = "Select your Excel file...";

            // 🔘 Browse Button
            btnBrowse.Location = new Point(460, 78);
            btnBrowse.Size = new Size(100, 30);
            btnBrowse.Text = "Browse";
            btnBrowse.Click += btnBrowse_Click;

            // 📦 Action Panel
            panelActions.Location = new Point(120, 130);
            panelActions.Size = new Size(440, 80);
            panelActions.FlowDirection = FlowDirection.TopDown;
            panelActions.WrapContents = false;

            // ▶️ Run Button
            btnRun.Size = new Size(420, 35);
            btnRun.Text = "Initial Ticket Updation";
            btnRun.Click += btnRun_Click;

            panelActions.Controls.Add(btnRun);

            // 📝 Log Box
            txtLog.Location = new Point(120, 220);
            txtLog.Size = new Size(440, 160);
            txtLog.ReadOnly = true;

            // 🧱 Form
            ClientSize = new Size(720, 420);
            Controls.Add(labelTitle);
            Controls.Add(txtFilePath);
            Controls.Add(btnBrowse);
            Controls.Add(panelActions);
            Controls.Add(txtLog);

            Text = "ADO Automation Tool";

            panelActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}