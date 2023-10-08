using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.DataBase.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
