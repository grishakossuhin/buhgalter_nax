using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Services.RegisterUser;
using BuhUchetApi.Services.UserServices.AuthentificateUser;
using BuhUchetApi.Services.UserServices.RemoveUser;
using BuhUchetApi.Services.UserServices.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Controllers.UserControllers
{
    [Controller]
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly AuthentificateService _authentificateService;
        private readonly RegisterUserService _registerUserService;
        private readonly UpdateUserService _updateUserService;
        private readonly RemoveUserService _removeUserService;

        public UserController(AuthentificateService authentificateService, 
            RegisterUserService registerUserService, 
            UpdateUserService updateUserService, 
            RemoveUserService removeUserService)
        {
            _authentificateService = authentificateService;
            _registerUserService = registerUserService;
            _updateUserService = updateUserService;
            _removeUserService = removeUserService;
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

        [HttpPost]
        [Route("updateUser")]
        public async Task<BaseAnswerVm<Account>> UpdateUser(UpdateUserDto request)
        {
            var response = await _updateUserService.UpdateUser(request);
            return response;
        }

        [HttpPost]
        [Route("removeUser")]
        public async Task<BaseAnswerVm<string>> RemoveUser(Guid request)
        {
            var response = await _removeUserService.Delete(request);
            return response;
        }
    }
}
