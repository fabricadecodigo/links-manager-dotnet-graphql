using System;

namespace LinkManager.Domain.src.Entities
{
    public class ForgotPassword : Entity
    {
        public string Email { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}