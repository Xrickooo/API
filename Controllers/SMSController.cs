using Kursach.SendSMS;
using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    public class SMSController : Controller
    {

        [HttpPost("Phone")]
        public async Task PostSMS(SMSmodel model)
        {
            SMSclient sMSclient = new SMSclient();
            await sMSclient.SendSMS(model);
            return;
        }
    }
}
