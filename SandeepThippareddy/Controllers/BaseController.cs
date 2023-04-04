using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SandeepThippareddy.Utilities.Enums;
using System.Text.Json.Serialization;

namespace SandeepThippareddy.Controllers
{
    public class BaseController : Controller
    {
        private IConfiguration _config;

        public BaseController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void Notify(string message, string title,
                                    NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = _config["NotificationProvider"]
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
