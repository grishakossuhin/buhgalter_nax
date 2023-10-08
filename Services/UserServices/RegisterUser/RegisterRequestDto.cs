using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.Services.RegisterUser
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Thirdname { get; set; }
        public string Post { get; set; }
        public string Departament { get; set; }
    }
}
