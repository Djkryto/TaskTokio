using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Server.Appliaction;
using Web_Server.Handler;
using Web_Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Server.Controllers
{
    [Route("server")]
    [ApiController]
    public class ServerController : Controller
    {
        private DataHandler _dataHandler;

        public ServerController(DataHandler dataHandler) => _dataHandler = dataHandler;

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add() => Ok(await _dataHandler.AddAsync(HttpContext));

        [HttpPost]
        [AllowAnonymous]
        [Route("remove")]
        public async Task<IActionResult> Remove() => Ok(await _dataHandler.RemoveAsync(HttpContext));

        [HttpGet]
        [AllowAnonymous]
        [Route("getOrders")]
        public void Get() => _dataHandler.Get(HttpContext);
    }
}
