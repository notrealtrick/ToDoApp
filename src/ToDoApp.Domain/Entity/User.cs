using System;
using Volo.Abp.Domain.Entities;

namespace ToDoApp
{
    public class User : Entity<Guid>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}