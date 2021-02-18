using System;
using System.Net.Mail;
using FluentValidation;
using FluentValidation.Validators;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn
{
    public class LogInModelValidator: AbstractValidator<LogInModelRequest>
    {
        public LogInModelValidator()
        {
            RuleFor(m => m.Email).Custom(IsEmailMatching);
        }

        private static void IsEmailMatching(string email, CustomContext context)
        {
            try
            {
                var mailAddress = new MailAddress(email);
            }
            catch (FormatException)
            {
                context.AddFailure("Email address is the incorrect format.");
            }
            catch (ArgumentException)
            {
                context.AddFailure("Email address is empty.");
            }
        }
    }
}