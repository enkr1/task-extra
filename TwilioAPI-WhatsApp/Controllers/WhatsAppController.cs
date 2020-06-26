using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.AspNet.Mvc;

// References:
// Twilio API for WhatsApp https://www.twilio.com/docs/whatsapp/quickstart/csharp & https://www.twilio.com/docs/whatsapp/api#overview
// Send WhatsApp messages using C# https://www.youtube.com/watch?v=sL-lfKV78t4
// How to Send and Receive SMS Messages Using C# and ASP.NET https://www.youtube.com/watch?v=ndxQXnoDIj8


namespace TwilioAPI_WhatsApp.Controllers
{
    public class WhatsAppController : TwilioController
    {
        // GET: WhatsApp
        // http://localhost:51042/WhatsApp
        public ActionResult Index()
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "AC9674fce0c45ad51f5d3524cb2902e249";
            const string authToken = "677718a2b8ad09fb58a04e893ea36253";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                body: "Hello, this is a demo message!",
                to: new Twilio.Types.PhoneNumber("whatsapp:+6581287402")
            );

            //Console.WriteLine(message.Sid);
            //return View();

            // message.AccountSid
            return Content("A messasge has sent to your WhatsApp! Check your phone now.");
        }
    }
}