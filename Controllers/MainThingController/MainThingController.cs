using BuhUchetApi.Models;
using BuhUchetApi.Models.MainThingModels;
using BuhUchetApi.Services.MainThingServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace BuhUchetApi.Controllers.MainThingController
{
    [ApiController]
    [Controller]
    [Route("mainthing")]
    public class MainThingController : Controller
    {
        private readonly CreateMainThingService _mainThingService;
        public MainThingController(CreateMainThingService mainThingService)
        {
            _mainThingService = mainThingService;
        }

        [HttpPost]
        [Route("createMainThing")]
        public async Task<BaseAnswerVm<string>> Create(CreationOsDto request)
        {
            var response = await _mainThingService.CreateOs(request);
            return response;
        }
    }
}
