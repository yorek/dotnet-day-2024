# .NET Developer Days 2024

This repo contains the code samples and presentation materials for the "Event-Driven Architectures with Azure Functions and Azure SQL" session at [.NET Developer Days 2024](https://developer.microsoft.com/en-us/reactor/events/22265/).

You can watch the recording of the entire conference here: [.NET Developer Days 2024 Recording](https://www.youtube.com/watch?v=7brvNO4NdvM)

## Azure Function SQL Trigger

The sample uses .NET 8 with Isolated Environment hosting in Azure Function. 

The Azure Function SQL Trigger is in the `TriggerSQL.cs` file. Make sure you have set the connection string to the database you want to use in the `local.settings.json` file.

It is recommeneded to start locally, so make sure you have a SQL Server running on your machine. If you don't have one you can easly create one for free using the three steps described here: https://aka.ms/sql321

Create the sample table used in the demo by running the `00-setup.sql` script in the `SQL` folder, the add the connection string to the database in the `local.settings.json` file. Make sure the user used by Azure Function to connect to SQL Server has the necessary permissions as described here: [Trigger Permissions](https://github.com/Azure/azure-functions-sql-extension/blob/main/docs/GeneralSetup.md#trigger-permissions)

Run the function locally using the following command:

```
func start
```

You can now use the `01-sample-changes.sql` script to insert, updated and delete records in the sample table and see the function being triggered.

# sp_invoke_external_rest_endpoint

To run this sample you need have the Azure Function deployed to Azure and you must be using an Azure SQL database as `sp_invoke_external_rest_endpoint` is not supported in SQL Server at the moment.

You can use the `02-call-function.sql` script to call the HTTP triggered function and get the resut back.