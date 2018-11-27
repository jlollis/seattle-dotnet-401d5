using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Models
{
	public class EmailSender : IEmailSender
	{
		public EmailSender(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var client = new SendGridClient("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");

			var msg = new SendGridMessage();

			msg.SetFrom("admin@AmandasBlogPosts.com");

			msg.AddTo(new EmailAddress("amanda@codefellows.com"));
			msg.AddContent(MimeType.Html, htmlMessage);

			var response = await client.SendEmailAsync(msg);

		}
	}
}
