using Azure.Storage.Queues;
//CONNECTION STRING
using Azure.Storage.Queues;

string coonectionString = "IN AZURE STORAGE ACCOUNT SIDE BAR SECURITY AND NETWROK ACCESS KEYS ";
string QueueName = "aweh-prod"; //no caps for que name
//CREATE QUEUE
QueueClient queueClient = new QueueClient(coonectionString, QueueName);

await queueClient.CreateIfNotExistsAsync();
Console.WriteLine($"Created queue - {QueueName}");
Console.WriteLine("DONE");

//storage browsers check if it it is there in storage account

//INSERT MESSSAGES
Console.WriteLine($"\nAdding messages to {QueueName}");
await queueClient.SendMessageAsync("The Message");