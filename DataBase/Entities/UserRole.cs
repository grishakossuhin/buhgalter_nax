using System;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.DataBase.Entities
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public Roles Role { get; set; }
    }
}
