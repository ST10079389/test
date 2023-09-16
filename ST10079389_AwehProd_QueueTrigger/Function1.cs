using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ST10079389_AwehProd_QueueTrigger
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("queue name frim storage account", Connection = "from storage account")]string myQueueItem, ILogger log)
        {
            string sqlCon = "\\inside azure, database settings connection strings with ado .net authentication, enter password where it is asked";
            try
            {
                string[] attributes = myQueueItem.Split(':');
                string id = attributes[0];
                string fullname = attributes[1];
                string name = attributes[2];

                using (SqlConnection connection = new SqlConnection(sqlCon))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO TABLE MESSAGE(ID, FULL NAME, ADDRESS, VALUES @ID, @FULLNAME, @ADDRESS)";
                        command.Parameters.AddWithValue("@id", id);//must watch with @ value
                        command.Parameters.AddWithValue("@Address", address);//must watch with @ value
                        command.Parameters.AddWithValue("@name", name);//must watch with @ value
                        command.ExecuteNonQuery();  
                    }
                }
                    log.LogInformation("Message saved successfully Id={id} FullName={fullname}, addres={address}");
            }
            catch(Exception ex)
            {
                log.LogError($"Error processing message: {ex.Message}");
            }
            //log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            string coonnect = "QueueCon";
        }
    }
}
