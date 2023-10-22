using System;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.Services.RegisterUser
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Thirdname { get; set; }
        public Guid Post { get; set; }
        public Guid Departament { get; set; }
        public Guid Mol { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
