using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.Directories;
using BuhUchetApi.Services.Directories;
using BuhUchetApi.Services.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuhUchetApi.Controllers.DirectoriesController
{
    [Controller]
    [ApiController]
    [Route("directory")]
    public class DorectoryController
    {
        private readonly AddDirectory _addDirectory;
        private readonly GetDirectory _getDirectory;
        private readonly RemoveDirectory _removeDirectory;
        private readonly UpdateDirectory _updateDirectory;

        [HttpPost]
        [Route("addDirectory")]
        public async Task<BaseAnswerVm<string>> AddDirectory(AddDirectoryDto request)
        {
            var response = await _addDirectory.AddDir(request);
            return response;
        }

        [HttpPost]
        [Route("removeDirectory")]
        public async Task<BaseAnswerVm<string>> RemoveDirectory(RemoveDirectoryDto request)
        {
            var response = await _removeDirectory.RemoveDir(request);
            return response;
        }

        [HttpPost]
        [Route("updateDirectory")]
        public async Task<BaseAnswerVm<string>> UpdateDirectory(UpdateDirectoryDto request)
        {
            var response = await _updateDirectory.UpdateDir(request);
            return response;
        }

        [HttpPost]
        [Route("getDirectory")]
        public async Task<BaseAnswerVm<List<GetDirectoryVm>>> UpdateDirectory(Enums.Directories dir)
        {
            var response = await _getDirectory.GetDir(dir);
            return response;
        }

    }
}
