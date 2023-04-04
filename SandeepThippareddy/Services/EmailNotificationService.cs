using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SandeepThippareddy.Interfaces;
using SandeepThippareddy.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SandeepThippareddy.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly MailSettingsModel _mailSettingsModel;
        public EmailNotificationService(IOptions<MailSettingsModel> mailSettings)
        {
            _mailSettingsModel = mailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(ContactModel contactModel)
        {
            try
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress("t.sandeepreddy98@gmail.com", "Sandeep Thippareddy");
                var subject = "Thanks for contacting - I will get back to you soon";
                var to = new EmailAddress("t.sandeepreddy@gmail.com");
                var plainTextContent = "Test Email with SendGrid C# Library";
                var htmlContent = "<strong>HTML text for the Test Email</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
