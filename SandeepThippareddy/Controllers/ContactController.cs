using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SandeepThippareddy.Dtos;
using SandeepThippareddy.Interfaces;
using SandeepThippareddy.Models;
using SandeepThippareddy.Utilities.Enums;
using System;


namespace SandeepThippareddy.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IEmailNotificationService _emailNotificationService;

        private readonly IMapper _mapper;

        private readonly IConfiguration _config;

        public ContactController(IEmailNotificationService emailNotificationService, IMapper mapper, IConfiguration config) : base(config)
        {
            _emailNotificationService = emailNotificationService;
            _mapper = mapper;
            _config = config;   
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactDto());
        }


        [HttpPost]
        public IActionResult Index(ContactDto contactDto)
        {
            try
            {
                var contactModel = _mapper.Map<ContactModel>(contactDto);

                Notify("I have received your query, Will respond to you shortly", String.Format("Thank you <p class='text-success'>{0}</p> for reaching out..!", contactModel.Name.ToUpper()), notificationType: NotificationType.success);

                return RedirectToAction(nameof(Index));

                //Saving user data to a JSON file as APPENDING
                //Will implement EMAIL functionality a little later
                //_emailNotificationService.SendEmailAsync(_mapper.Map<ContactModel>(contactDto));

            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(String.Format("Error in function: {0} - \n Error Message:{1} - \n Stack Trace:{2}",
                                                               System.Reflection.MethodBase.GetCurrentMethod().Name,
                                                               exception.Message, exception?.ToString()));
            }
        }
    }
}
