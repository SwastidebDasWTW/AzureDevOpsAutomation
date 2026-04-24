using ClosedXML.Excel;

namespace AzureDevOpsAutomation
{
    public class FetchDataFromExcel
    {
        private readonly string filePath;
        private readonly InitialTicketAllocation _InitialTicketUpdationObj;
        private readonly Action<string> _log;
        int updateCount = 0;
        public FetchDataFromExcel(string filePath, Action<string> log)
        {
            this.filePath = filePath;
            _InitialTicketUpdationObj = new InitialTicketAllocation();
            _log = log;
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
                    string testCaseReviewer = worksheet.Cell(row, 4).GetString();
                    string productOwner = worksheet.Cell(row, 5).GetString();
                    string contributor = worksheet.Cell(row, 6).GetString();

                    var res=await _InitialTicketUpdationObj.UpdateTicketForQaTaskAsync(
                        assignedTo,
                        workItemId,
                        estimated,
                        testCaseReviewer,
                        productOwner,
                        contributor
                    );
                    if(res){
                        _log?.Invoke($"{workItemId} Assigned to {assignedTo} with:-\n  Estimated Hours: {estimated}, \n  Test Case Reviewer: {testCaseReviewer}, \n  Product Owner: {productOwner}, \n  Contributor: {contributor}");
                        updateCount++;
                    }
                }
                _log?.Invoke($"Total {updateCount} tickets updated successfully.");
                _log?.Invoke("Please check Azure DevOps for the updated ticket information.");
            }
        }
    }
}
