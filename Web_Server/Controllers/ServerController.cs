using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Server.Handler;

namespace Web_Server.Controllers
{
    /// <summary>
    /// Серверный Api.
    /// </summary>
    [Route("server")]
    [ApiController]
    public class ServerController : Controller
    {
        private DataHandler _dataHandler;
        /// <summary>
        /// .ctor
        /// </summary>
        public ServerController(DataHandler dataHandler) => _dataHandler = dataHandler;

        /// <summary>
        /// Обработка данных на добавление пользователя.
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add() => Ok(await _dataHandler.AddAsync(HttpContext));

        /// <summary>
        /// Обработка данных на удаление пользователя.
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("remove")]
        public async Task<IActionResult> Remove() => Ok(await _dataHandler.RemoveAsync(HttpContext));

        /// <summary>
        /// Получение данных из базы данных.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("getOrders")]
        public void Get() => _dataHandler.Get(HttpContext);
    }
}
