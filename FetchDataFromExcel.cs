using ClosedXML.Excel;

namespace AzureDevOpsAutomation
{
    public class FetchDataFromExcel
    {
        private readonly string filePath;
        private readonly InitialTicketAllocation _InitialTicketUpdationObj;
        public FetchDataFromExcel(string filePath, string pat)
        {
            this.filePath = filePath;
            _InitialTicketUpdationObj = new InitialTicketAllocation();
        }
        public async Task FetchDataAndUpdateInitialTicketInfo()
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                int rowCount = worksheet.LastRowUsed().RowNumber();

                for (int row = 2; row <= rowCount; row++)
                {
                    string workItemId = worksheet.Cell(row, 1).GetString();
                    string assignedTo = worksheet.Cell(row, 2).GetString();
                    string estimatedTime = worksheet.Cell(row, 3).GetString();

                    int estimated = int.TryParse(estimatedTime, out var val) ? val : 0;

                    await _InitialTicketUpdationObj.UpdateTicketAsync(
                        assignedTo,
                        workItemId,
                        estimated
                    );
                }
            }
        }
    }
}
