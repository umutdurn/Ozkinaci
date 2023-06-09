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
        private readonly ICarBrandService _carBrandService;
        private readonly IService<Equipment> _equipmentService;
        private readonly ICarModelService _carModelService;
        private readonly IAdvertService _advertService;

        public HomeController(ILogger<HomeController> logger, IService<Category> categoryService, ICarBrandService carBrandService, ICarModelService carModelService, IService<Equipment> equipmentService, IAdvertService advertService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _carBrandService = carBrandService;
            _carModelService = carModelService;
            _equipmentService = equipmentService;
            _advertService = advertService;
        }

        public IActionResult Index()
        {
            var showcase = _advertService.ShowcaseInclude();

            return View(showcase);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("iletisim")]
        public IActionResult Iletisim()
        {
            return View();
        }
        [Route("arac-listesi")]
        public IActionResult ListCar()
        {
            var listCar = _advertService.GetAllInclude();

            return View(listCar);
        }
        [Route("arac/{id}")]
        public IActionResult Car(int id) {

            var advert = _advertService.GetByIdInclude(id);

            return View(advert);
        
        }
        [Route("kullanilmis-otomobiller")]
        public IActionResult KullanilmisOtomobiller()
        {
            return View();
        }
        [Route("detayli-expertiz")]
        public IActionResult DetayliExpertiz()
        {
            return View();
        }
        [Route("finansman-kredi")]
        public IActionResult FinansmanKredi()
        {
            return View();
        }
        [Route("oto-bakim-servisi")]
        public IActionResult OtoBakimServisi()
        {
            return View();
        }
        [Route("sigorta-islemleri")]
        public IActionResult Sigortaİslemleri()
        {
            return View();
        }
        [Route("hakkimizda")]
        public IActionResult Hakkimizda()
        {
            return View();
        }
        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }
        [Route("guvenli-alim-satim")]
        public IActionResult GuvenliAlimSatim()
        {
            return View();
        }
        [Route("otomobil-degerleme")]
        public IActionResult PriceMyCar()
        {
            var brands = _carBrandService.GetAll().ToList();

            ViewBag.Brands = brands;

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GetModels(int id) { 
        
            var carBrand = await _carBrandService.FirstOfDefaultAsync(x => x.Id == id);

            var models = _carModelService.Where(x => x.CarBrand == carBrand).Result;

            return Json(models);
        
        }
        [HttpPost]
        public async Task<JsonResult> GetEquipment(int id)
        {

            var carModels = _carModelService.GetByIdIncludeModels(id);

            return Json(carModels.Equipment);

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