using System;

namespace BuhUchetApi.Models.Directories
{
    public class RemoveDirectoryDto
    {
        public Guid Id { get; set; }
        public Enums.Directories Directory { get; set; }
    }
}
