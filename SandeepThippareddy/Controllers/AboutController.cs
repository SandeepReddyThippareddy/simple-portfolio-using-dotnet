using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SandeepThippareddy.Dtos;
using SandeepThippareddy.Interfaces;
using SandeepThippareddy.Models;
using SandeepThippareddy.Utilities.Enums;
using System;
using System.IO;

namespace SandeepThippareddy.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IMapper _mapper;

        private readonly IDownloaderService _downloaderService;

        private readonly IConfiguration _config;

        public AboutController(IMapper mapper, IDownloaderService downloaderService, IConfiguration configuration) : base(configuration)
        {
            _mapper = mapper;
            _downloaderService = downloaderService;
            _config = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new DownloaderDto());
        }

        [HttpGet]
        public IActionResult DownloadCV()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadCV([FromForm] DownloaderDto downloaderDto)
        {
            try
            {
                var downloaderModel = _mapper.Map<DownloaderModel>(downloaderDto);

                if (_downloaderService.SaveDownloaderData(downloaderModel))
                {
                    string filePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "Utilities\\Sandeep_Thippareddy_CV.pdf");

                    string fileName = "Sandeep_Thippareddy_CV.pdf";

                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                    return File(fileBytes, "application/force-download", fileName);
                }
                else
                {
                    Notify("Unable to download the CV", "Please try again", NotificationType.error);

                    ModelState.AddModelError(string.Empty, "Unable to download CV");

                    return RedirectToAction(nameof(DownloadCV));
                }

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
