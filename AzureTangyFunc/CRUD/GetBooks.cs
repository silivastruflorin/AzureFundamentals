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
using System.Collections.Generic;

namespace AzureTangyFunc.CRUD
{
    public static class GetBooks
    {
        [FunctionName("GetBooks")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getBooks")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger GetBooks function processed a request.");

            List<Book> books = new List<Book>();
            books.Add(new Book() { Id = "23234234", Author = "test author", Title = "test title" });

            return new OkObjectResult(books);
        }
    }
}
