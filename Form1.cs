namespace AzureDevOpsAutomation
{
    public partial class Form1 : Form
    {
        private string _filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panelDrop_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                string file = files[0];

                if (!file.EndsWith(".xlsx") && !file.EndsWith(".xls"))
                {
                    MessageBox.Show("Please drop a valid Excel file.");
                    return;
                }

                _filePath = file;
                lblFilePath.Text = $"Selected File: {_filePath}";
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                MessageBox.Show("Please drag and drop an Excel file first.");
                return;
            }

            try
            {
                var processor = new FetchDataFromExcel(_filePath, null);
                await processor.FetchDataAndUpdateInitialTicketInfo();

                MessageBox.Show("Initial Ticket Updation completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
