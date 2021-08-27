using HotChocolate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Helpers
{
    public class MailSenderHelper : IMailSenderHelper
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly EmailData _emailData;

        public MailSenderHelper(
            IConfiguration configuration,
            ILogger<MailSenderHelper> logger,
            IHttpClientFactory httpClientFactory
        )
        {
            _configuration = configuration;
            _logger = logger;
            var apiKey = _configuration.GetValue("Email:Key", "");
            var apiUrl = _configuration.GetValue("Email:Url", "");
            var name = _configuration.GetValue("Email:Name", "");
            var email = _configuration.GetValue("Email:Email", "");

            if (string.IsNullOrEmpty(apiKey))
                throw new GraphQLException("A chave da api para enviar e-mail não foi configurada");
            if (string.IsNullOrEmpty(apiUrl))
                throw new GraphQLException("A url da api para enviar e-mail não foi configurada");
            if (string.IsNullOrEmpty(name))
                throw new GraphQLException("O nome do remetente do email não foi configurado");
            if (string.IsNullOrEmpty(email))
                throw new GraphQLException("O email do remetente do email não foi configurado");

            _emailData = new EmailData();
            _emailData.Sender.Name = name;
            _emailData.Sender.Email = email;

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(apiUrl);
            _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
        }

        public IMailSenderHelper SetSubject(string subject)
        {
            _emailData.Subject = subject;
            return this;
        }

        public IMailSenderHelper SetTo(string name, string email)
        {
            _emailData.To.Add(new EmailContact
            {
                Name = name,
                Email = email
            });
            return this;
        }

        public IMailSenderHelper SetHtml(string html)
        {
            _emailData.HtmlContent = html;
            return this;
        }

        public async Task SendMail()
        {
            try
            {
                var json = JsonSerializer.Serialize(_emailData, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                await _httpClient.PostAsync("smtp/email", content);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Não foi possível enviar o email");
                throw;
            }
        }

        private class EmailData
        {
            public EmailContact Sender { get; set; } = new EmailContact();
            public List<EmailContact> To { get; set; } = new List<EmailContact>();
            public string Subject { get; set; }
            public string HtmlContent { get; set; }
        }

        private class EmailContact
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}