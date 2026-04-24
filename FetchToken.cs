using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureDevOpsAutomation
{
    public class FetchToken
    {
        public async Task<string> FetchTokenThroughAzureCLI()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c az account get-access-token --resource 499b84ac-1321-427f-aa17-267ca6975798",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                using var doc = JsonDocument.Parse(output);
                return doc.RootElement.GetProperty("accessToken").GetString();
            }
        }
    }
}
