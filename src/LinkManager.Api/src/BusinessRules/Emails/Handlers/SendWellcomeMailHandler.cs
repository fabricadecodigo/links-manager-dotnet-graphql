using HandlebarsDotNet;
using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Api.src.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public class SendWellcomeMailHandler : SendMailHandler, ISendWellcomeMailHandler
    {
        private readonly ILogger _logger;
        public SendWellcomeMailHandler(
            ILogger<SendWellcomeMailHandler> logger,
            IMailSenderHelper mailSenderHelper
            ) : base(mailSenderHelper)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(SendMailRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando a busca pelo template");
                var current = System.IO.Directory.GetCurrentDirectory();
                _logger.LogInformation($"Diretório atual: {current}");
                var templateFile = System.IO.Path.Combine(current, "src", "BusinessRules", "Emails", "Templates", "wellcome.html");
                _logger.LogInformation($"Caminho do template atual: {templateFile}");

                _logger.LogInformation("Iniciando a leitura do conteúdo do arquivo");
                var source = System.IO.File.ReadAllText(templateFile);

                _logger.LogInformation("Fazendo o parse do template para o handlebars");
                var template = Handlebars.Compile(source);
                var data = new
                {
                    name = request.Name
                };

                var result = template(data);

                _logger.LogInformation("Template html gerado com sucesso");

                _logger.LogInformation("Enviando o email");
                await _mailSenderHelper
                    .SetSubject("Bem vindo ao LinksManager")
                    .SetTo(request.Name, request.Email)
                    .SetHtml(result)
                    .SendMail();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao enviar o email de boas vindas");
                throw;
            }

        }
    }
}