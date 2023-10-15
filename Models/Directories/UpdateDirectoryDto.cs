using System;

namespace BuhUchetApi.Models.Directories
{
    public class UpdateDirectoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Spi { get; set; }
        public Enums.Directories Directory { get; set; }
    }
}
