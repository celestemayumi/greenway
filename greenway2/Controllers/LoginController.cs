using greenway2.DTOs;
using greenway2.Services;
using Microsoft.AspNetCore.Mvc;

namespace greenway2.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var logins = await _loginService.GetAllLoginsAsync();
            return View(logins);  
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var login = await _loginService.GetLoginByIdAsync(id);
            if (login == null)
            {
                return NotFound(); 
            }
            return View(login);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _loginService.DeleteLoginAsync(id);
            return RedirectToAction(nameof(Index));  
        }
    }
}
