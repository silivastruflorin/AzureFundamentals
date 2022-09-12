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
    public static class GetBookById
    {
        [FunctionName("GetBookById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetBookById/{id}")] HttpRequest req, string id,
            ILogger log)
        {

            var dummyBook = new Book() { Id=$"{id}", Author = "This is an test", Title=$"This is book with id{id}"};


            return new OkObjectResult(dummyBook);
        }
    }
}
