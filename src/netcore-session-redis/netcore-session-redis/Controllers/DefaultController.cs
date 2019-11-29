using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_session_redis.Models;
using netcore_session_redis.SessionHelpers;

namespace netcore_session_redis.Controllers
{
    public class DefaultController : Controller
    {
        private const string KeyName = "POCO";

        [HttpGet]
        public IActionResult Index()
        {
            return View(new PocoModel{Id=Guid.NewGuid()});
        }

        [HttpPost]
        public async Task<IActionResult> Store(PocoModel model)
        {
            await this.SetSessionValue(KeyName, model);
            return Ok("Variable stored");
        }

        [HttpGet]
        public async Task<IActionResult> Retrieve()
        {

            var result = await this.GetSessionValue<PocoModel>(KeyName);
            return Ok(result);
        }
    }
}