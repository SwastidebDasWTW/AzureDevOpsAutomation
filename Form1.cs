using System;
using System.IO;
using System.Windows.Forms;

namespace AzureDevOpsAutomation
{
    public partial class Form1 : Form
    {
        private string _filePath;

        public Form1()
        {
            InitializeComponent();
        }

        // ?? Browse Excel
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _filePath = ofd.FileName;
                    txtFilePath.Text = _filePath;
                    Log("Excel file selected.");
                }
            }
        }

        // ?? Run automation
        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                MessageBox.Show("Please select a valid Excel file.");
                return;
            }

            try
            {
                ToggleUI(false);
                Log("Please wait... Updating tickets");

                var processor = new FetchDataFromExcel(_filePath, Log);

                await processor.FetchDataAndUpdateInitialTicketInfo();

                Log("All tickets updated successfully!");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
            finally
            {
                ToggleUI(true);
            }
        }

        // ?? Logger
        public void Log(string message)
        {
            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }

        // ?? UI toggle
        private void ToggleUI(bool enabled)
        {
            btnRun.Enabled = enabled;
            btnBrowse.Enabled = enabled;
        }
    }
}