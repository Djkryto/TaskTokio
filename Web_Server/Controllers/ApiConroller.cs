using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Server.Handler.Service;
using Web_Server.Models;

namespace Web_Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiConroller : Controller
    {
        private readonly HttpService _httpService;
        public ApiConroller(HttpService httpService) => _httpService = httpService;

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public IActionResult Add() => Ok(_httpService.Add(HttpContext));

        [HttpPost]
        [AllowAnonymous]
        [Route("remove")]
        public IActionResult Remove() => Ok(_httpService.Remove(HttpContext));

        [HttpGet]
        [AllowAnonymous]
        [Route("getOrders")]
        public void Get() => _httpService.GetAsync(HttpContext);
    }
}