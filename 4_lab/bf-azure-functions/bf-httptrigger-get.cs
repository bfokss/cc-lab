using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using bf.Functions.Rest.Database;

namespace bf.Functions
{
    public static class bf_httptrigger_get
    {
        [FunctionName("bf_function_get")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
            optionsBuilder.UseSqlServer("Server=tcp:cdv-sql-server.database.windows.net,1433;Initial Catalog=cdv_sql_db;Persist Security Info=False;User ID=cdv_admin;Password=Mypassword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var db = new PeopleDb(optionsBuilder.Options);


            var people = await db.People.ToListAsync();
            return new JsonResult(people);
        }
    }
}
