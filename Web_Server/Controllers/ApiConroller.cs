using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Server.Handler.Service;

namespace Web_Server.Controllers
{
    /// <summary>
    /// Api посредник между сервером и клиентом.
    /// </summary>
    [Route("api")]
    [ApiController]
    public class ApiConroller : Controller
    {
        private readonly HttpService _httpService;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="httpService"></param>
        public ApiConroller(HttpService httpService) => _httpService = httpService;

        /// <summary>
        /// Отправка данных на сервеер.
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public IActionResult Add() => Ok(_httpService.Add(HttpContext));

        /// <summary>
        /// Отправка данных на сервеер.
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("remove")]
        public IActionResult Remove() => Ok(_httpService.Remove(HttpContext));

        /// <summary>
        /// Получение данных с сервера.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("getOrders")]
        public void Get() => _httpService.GetAsync(HttpContext);
    }
}