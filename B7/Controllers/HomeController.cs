using B7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Data.OleDb;
using System.Data;
using Core.Services;
using Core.Models;

namespace B7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<Category> _categoryService;
        private readonly IService<CarBrand> _carBrandService;
        private readonly IService<CarModel> _carModelService;

        public HomeController(ILogger<HomeController> logger, IService<Category> categoryService, IService<CarBrand> carBrandService, IService<CarModel> carModelService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _carBrandService = carBrandService;
            _carModelService = carModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [Route("lng-plants")]
        public IActionResult LNG()
        {
            return View();
        }
        [Route("chemical-plants")]
        public IActionResult chemicalp()
        {
            return View();
        }
        [Route("mining-industry")]
        public IActionResult mining()
        {
            return View();
        }
        [Route("bridge-construction")]
        public IActionResult bridge()
        {
            return View();
        }
        [Route("steel-structures")]
        public IActionResult steel()
        {
            return View();
        }
        [Route("third-party-inspection")]
        public IActionResult thirdinspection()
        {
            return View();
        }
        [Route("pre-shipment-inspection")]
        public IActionResult preship()
        {
            return View();
        }
        [Route("coating-inspection")]
        public IActionResult coat()
        {
            return View();
        }
        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string MailSend()
        {

            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("site@b7inspection.com", "İletişim Sayfası | B7 Inspection");
            mesaj.To.Add("yigit.cetiner@metalreyonu.com.tr");
            mesaj.To.Add("info@b7inspection.comm");
            mesaj.Subject = "İletişim Sayfası | B7 Inspection";
            mesaj.IsBodyHtml = true;
            mesaj.Body = "Adı: " + Request.Form["ad"].ToString() + "<br/>" +
                         "E-mail: " + Request.Form["email"].ToString() + "<br/>" +
                         "Gsm: " + Request.Form["gsm"].ToString() + "<br/>" +
                         "Mesaj: " + Request.Form["message"].ToString() + "<br/>";

            mesaj.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("mail.b7inspection.com", 587);
            client.Credentials = new NetworkCredential("site@b7inspection.com", "*5J3e0pa8");
            client.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

            try
            {
                client.Send(mesaj);

                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

    }
}