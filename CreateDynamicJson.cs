using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AzureDevOpsAutomation
{
    public class CreateDynamicJson
    {
        public string JsonForInitialTicketAllocation(
         string assignedTo,
         int estimatedTime,
         string? testCaseReviewer,
         string productOwner,
         string contributor,
         string? codeReviewer)
        {
            var operations = new List<object>
            {
                new { op = "add", path = "/fields/System.AssignedTo", value = assignedTo },
                new { op = "add", path = "/fields/Microsoft.VSTS.Scheduling.OriginalEstimate", value = estimatedTime },
                new { op = "add", path = "/fields/Microsoft.VSTS.Scheduling.RemainingWork", value = estimatedTime },
                new { op = "add", path = "/fields/Microsoft.VSTS.Scheduling.CompletedWork", value = 0 },
                new { op = "add", path = "/fields/System.State", value = "New" },
                new { op = "add", path = "/fields/Custom.ProductOwner", value = productOwner },
                new { op = "add", path = "/fields/Custom.Contributor", value = contributor }
            };

            bool hasTestReviewer = !string.IsNullOrWhiteSpace(testCaseReviewer);
            bool hasCodeReviewer = !string.IsNullOrWhiteSpace(codeReviewer);

            if (hasTestReviewer == hasCodeReviewer) // both true or both false
            {
                throw new Exception("Exactly one of TestCaseReviewer or CodeReviewer must be provided.");
            }

            if (hasTestReviewer)
            {
                operations.Add(new { op = "add", path = "/fields/Custom.TestCaseReviewer", value = testCaseReviewer });
            }
            else
            {
                operations.Add(new { op = "add", path = "/fields/Custom.CodeReviewer", value = codeReviewer });
            }

            return JsonSerializer.Serialize(operations);
        }
    }
}
