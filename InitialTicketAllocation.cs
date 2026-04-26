using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureDevOpsAutomation
{
    public class InitialTicketAllocation
    {
        private readonly string organization = "mktp-dev";
        private readonly string project = "Tech";

        public async Task<bool> UpdateTicketForTaskAsync(string assignedTo, string workItemId,int estimatedTime,string? testCaseReviewer,string productOwner,string contributor,string? codeReviewer)
        {
            var url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{workItemId}?api-version=5.0";

            using (var client = new HttpClient())
            {
                var fetchToken = new FetchToken();
                var authToken = await fetchToken.FetchTokenThroughAzureCLI();
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                
                var json = new CreateDynamicJson().JsonForInitialTicketAllocation(assignedTo, estimatedTime, testCaseReviewer, productOwner, contributor, codeReviewer);
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json-patch+json")
                };

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
        }
    }
}
