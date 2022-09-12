using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureTangyFunc.Models;

namespace AzureTangyFunc.CRUD
{
    public static class AddBook
    {
        [FunctionName("AddBook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "add-book")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger AddBook function processed a request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Book data = JsonConvert.DeserializeObject<Book>(requestBody);

            return new OkObjectResult(data);
        }
    }
}
