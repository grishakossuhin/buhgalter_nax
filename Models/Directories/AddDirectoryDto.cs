
using System.Threading;

namespace BuhUchetApi.Models.Directories
{
    public class AddDirectoryDto
    {
        public Enums.Directories Directory { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        
        public int Spi { get; set; }
    }
}
