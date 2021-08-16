using System;

namespace LinkManager.Api.src.BusinessRules.Authentication.Responses
{
    public class LoginResponse : BusinessRuleResponse<LoginResponseData>
    {        
    }

    public class LoginResponseData
    {
        public string AccessToken { get; set; }
        public LoginResponseUser User { get; set; }
        public LoginResponseCompany Company { get; set; }
    }

    public class LoginResponseUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class LoginResponseCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}