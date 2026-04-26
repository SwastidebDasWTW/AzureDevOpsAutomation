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

                int updateCount = 0;
                int failureCount = 0;

                for (int row = 2; row <= rowCount; row++)
                {
                    string workItemId = worksheet.Cell(row, 1).GetString().Trim();

                    try
                    {
                        if (string.IsNullOrWhiteSpace(workItemId))
                        {
                            _log?.Invoke($"Skipping row {row}: WorkItemId is empty.");
                            continue;
                        }

                        string assignedTo = worksheet.Cell(row, 2).GetString().Trim();

                        if (string.IsNullOrWhiteSpace(assignedTo))
                        {
                            _log?.Invoke($"Skipping row {row}: AssignedTo is empty.");
                            continue;
                        }

                        string estimatedTime = worksheet.Cell(row, 3).GetString().Trim();

                        if (!int.TryParse(estimatedTime, out var estimated))
                        {
                            _log?.Invoke($"Invalid estimate in row {row}, defaulting to 0.");
                            estimated = 0;
                        }

                        string testCaseReviewer = worksheet.Cell(row, 4).GetString().Trim();
                        string productOwner = worksheet.Cell(row, 5).GetString().Trim();
                        string contributor = worksheet.Cell(row, 6).GetString().Trim();
                        string codeReviewer = worksheet.Cell(row, 7).GetString().Trim();

                        var res = await _InitialTicketUpdationObj.UpdateTicketForTaskAsync(
                            assignedTo,
                            workItemId,
                            estimated,
                            testCaseReviewer,
                            productOwner,
                            contributor,
                            codeReviewer
                        );

                        if (res)
                        {
                            _log?.Invoke($"{workItemId} assigned to {assignedTo}.");
                            updateCount++;
                        }
                        else
                        {
                            _log?.Invoke($"FAILED [WorkItem {workItemId}]");
                            failureCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        _log?.Invoke($"ERROR: [Check Row {row} of excel]: {ex.Message}");
                        failureCount++;
                    }
                }

                _log?.Invoke($"Total Success: {updateCount}, Failed: {failureCount}");
                _log?.Invoke("Please check Azure DevOps for the updated ticket information.");
            }
        }
    }
}
