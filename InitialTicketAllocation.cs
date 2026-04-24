using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsAutomation
{
    public class InitialTicketAllocation
    {
        private readonly string organization = "mktp-dev";
        private readonly string project = "Tech";

        public async Task<bool> UpdateTicketAsync(string assignedTo, string workItemId,int EstimatedTime)
        {
            var url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{workItemId}?api-version=5.0";

            using (var client = new HttpClient())
            {
                var fetchToken = new FetchToken();
                var authToken = await fetchToken.FetchTokenThroughAzureCLI();
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                var json = $@"[
                    {{
                        ""op"": ""add"",
                        ""path"": ""/fields/System.AssignedTo"",
                        ""value"": ""{assignedTo}""
                    }},
                    {{
                        ""op"": ""add"",
                        ""path"": ""/fields/Microsoft.VSTS.Scheduling.OriginalEstimate"",
                        ""value"": {EstimatedTime}
                    }},
                    {{
                        ""op"": ""add"",
                        ""path"": ""/fields/Microsoft.VSTS.Scheduling.RemainingWork"",
                        ""value"": {EstimatedTime}
                    }},
                    {{
                        ""op"": ""add"",
                        ""path"": ""/fields/Microsoft.VSTS.Scheduling.CompletedWork"",
                        ""value"": 0
                    }},
                    {{
                        ""op"": ""add"",
                        ""path"": ""/fields/System.State"",
                        ""value"": ""New""
                    }}
                ]";
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
