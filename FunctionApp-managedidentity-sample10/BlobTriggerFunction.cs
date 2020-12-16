using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;

namespace FunctionApp_managedidentity_sample10
{
    public class BlobTriggerFunction
    {

        private string subscriptionId;
        private string resourceGroup;
        private string dataFactoryName;
        private string pipelineName;

        public BlobTriggerFunction()
        {
            subscriptionId = Environment.GetEnvironmentVariable("SubscriptionID", EnvironmentVariableTarget.Process);
            resourceGroup = Environment.GetEnvironmentVariable("ResourceGroup", EnvironmentVariableTarget.Process);
            dataFactoryName = Environment.GetEnvironmentVariable("DataFactoryName", EnvironmentVariableTarget.Process);
            pipelineName = Environment.GetEnvironmentVariable("PipelineName", EnvironmentVariableTarget.Process);
        }

        [FunctionName("BlobTriggerFunction")]
        public async Task RunAsync([BlobTrigger("files/{name}", Connection = "StorageConnection")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            //Specifing the application
            //var azureServiceTokenProvider = new AzureServiceTokenProvider($"RunAs=App;AppId=your_app_id");

            //to run locally on your Vs instance
            // var azureServiceTokenProvider = new AzureServiceTokenProvider($"RunAs=Developer; DeveloperTool=VisualStudio");
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var accessToken = await azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);
            ServiceClientCredentials cred = new TokenCredentials(accessToken);

            var myDataFactoryClient = new DataFactoryManagementClient(cred)
            {
                SubscriptionId = subscriptionId
            };

            var dataFactoryRequestResult = myDataFactoryClient.Pipelines.CreateRunWithHttpMessagesAsync(resourceGroup, dataFactoryName, pipelineName).Result;
        }
    }
}
