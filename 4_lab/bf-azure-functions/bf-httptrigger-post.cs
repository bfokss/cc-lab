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
using bf.Functions.Rest.Database.Entities;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace bf.Functions
{
    public static class bf_httptrigger_post
    {
        [FunctionName("bf_httptrigger_post")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Post), Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
            optionsBuilder.UseSqlServer("Server=tcp:cdv-sql-server.database.windows.net,1433;Initial Catalog=cdv_sql_db;Persist Security Info=False;User ID=cdv_admin;Password=Mypassword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var db = new PeopleDb(optionsBuilder.Options);

            var person = await req.Content.ReadAsAsync<PersonEntity>();

            string fn = person.FirstName;
            string ln = person.LastName;
            string pn = person.PhoneNumber;

            /*

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            JsonSerializerSettings serSettings = new JsonSerializerSettings();
            serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            PersonEntity outObject = JsonConvert.DeserializeObject<PersonEntity>(requestBody, serSettings);

            */


            log.LogInformation($"FirstName: {fn}");
            log.LogInformation($"LastName: {ln}");
            log.LogInformation($"PhoneNumber: {pn}");


            
            var personEntity = new PersonEntity(
                fn,
                ln, 
                pn
            );

            db.People.Add(personEntity);
            await db.SaveChangesAsync();
            

            return new OkResult();
        }
    }
}
