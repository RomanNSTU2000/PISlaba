
using System.Reflection;
using System.Security.Permissions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PISlaba1.Models;
namespace PISlaba1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PISlaba1 : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
        }
    }
}
