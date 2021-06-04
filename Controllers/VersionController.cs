using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using PISlaba1.Models;

namespace PISlaba1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class PISlaba1 : ControllerBase
   {
       // GET api/values
       [HttpGet]
       public ActionResult<string> Get()
       {
           var versionInfo = new Version
           {
               Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
               Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
               ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
           };

           return Ok(versionInfo);
       }
    }
}