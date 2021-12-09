using CSharpLearning.WebAPI.Options;

namespace CSharpLearning.WebAPI.Services
{
    public class EmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService(EmailOptions optionsAccessor)
        {
            _emailOptions = optionsAccessor;
        }
    }
}
