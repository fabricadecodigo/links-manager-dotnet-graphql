using System;

namespace LinkManager.BusinessRules.Users.Responses
{
    public class UserResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}