# FunctionApp-managedidentity-sample10
Blob Trigger Function App
Step #1:
Add local.settings.json ->
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "StorageConnection": "",    // Enter azure storage connection string
        "SubscriptionID": "",       // Enter subscription id of datafactory
        "ResourceGroup": "",        // Enter resourcegroup of datafactory
        "DataFactoryName": "",      // Enter datafactory name
        "PipelineName": ""          // Enter pipeline, which you want to trigger
    }
}

Step #2: Start debugging using F5
