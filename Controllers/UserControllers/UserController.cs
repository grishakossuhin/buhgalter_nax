using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Services.RegisterUser;
using BuhUchetApi.Services.UserServices.AuthentificateUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuhUchetApi.Controllers.UserControllers
{
    [Controller]
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly AuthentificateService _authentificateService;
        private readonly RegisterUserService _registerUserService;

        public UserController(AuthentificateService authentificateService, RegisterUserService registerUserService)
        {
            _authentificateService = authentificateService;
            _registerUserService = registerUserService;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<BaseAnswerVm<Account>> RegisterUser(RegisterRequestDto request)
        {
            var response = await _registerUserService.Register(request);
            return response;
        }

        [HttpPost]
        [Route("authentificateUser")]
        public async Task<BaseAnswerVm<Account>> AuthentificateUser(AuthentificateRequestDto request)
        {
            var response = await _authentificateService.Authentificate(request);
            return response;
        }
    }
}
