# FunctionApp-managedidentity-sample10
Blob Trigger Function App <br />
Step #1: <br />
Add local.settings.json -> <br />
{ 
    "IsEncrypted": false, <br />
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true", <br />
        "FUNCTIONS_WORKER_RUNTIME": "dotnet", <br />
        "StorageConnection": "",    // Enter azure storage connection string <br />
        "SubscriptionID": "",       // Enter subscription id of datafactory <br />
        "ResourceGroup": "",        // Enter resourcegroup of datafactory <br />
        "DataFactoryName": "",      // Enter datafactory name <br />
        "PipelineName": ""          // Enter pipeline, which you want to trigger <br />
    } <br />
} <br />
<br />
Step #2: Start debugging using F5 <br />
