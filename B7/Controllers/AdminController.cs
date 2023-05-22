using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace B7.Controllers
{
    public class AdminController : Controller
    {
        private readonly IService<Gallery> _imageGallery;
        private readonly IService<CarBrand> _carBrand;
        private readonly ICarModelService _carModelService;
        private readonly IService<Category> _categoryService;
        private readonly IService<Equipment> _equipmentService;
        private readonly IAdvertService _advertService;

        public AdminController(IService<Gallery> imageGallery, IAdvertService advertService, IService<CarBrand> carBrand, ICarModelService carModelService, IService<Category> categoryService, IService<Equipment> equipmentService)
        {
            _imageGallery = imageGallery;
            _advertService = advertService;
            _carBrand = carBrand;
            _carModelService = carModelService;
            _categoryService = categoryService;
            _equipmentService = equipmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCar(){

            var carModel = _carModelService.GetAll();

            List<SelectListItem> modelList = new List<SelectListItem>();

            foreach(var model in carModel)
            {

                modelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString() });

            }

            ViewBag.CarBrand = modelList;

            return View();
        }
        public async Task<string> AddAdvert(Advert advert)
        {
            string Images = HttpContext.Session.GetString("galeri");

            List<Gallery> Gallerys = new List<Gallery>();

            if (!String.IsNullOrEmpty(Images))
            {
                string[] Image = Images.Split('/');

                for (int i = 0; i < Image.Length; i++)
                {
                    if (!String.IsNullOrEmpty(Image[i]))
                    {
                        Gallerys.Add(new Gallery { Image = Image[i], Advert = advert });
                    }
                }
            }

            advert.Gallery = Gallerys;

            var carModel = await _carModelService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarModel"]));

            advert.CarModel = carModel;

            await _advertService.AddAsync(advert);

            return advert.Id.ToString();
        }
        [HttpPost]
        public async Task<IActionResult> UploadHandler(string deleteImage)
        {

            string uploadFiles = "";
            string newSession = HttpContext.Session.GetString("galeri");
            string kayitKlasoru = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/tema/images/upload");

            if (!String.IsNullOrEmpty(deleteImage))
            {
                var kombinKlasor = Path.Combine(kayitKlasoru, deleteImage);

                FileInfo file = new FileInfo(kombinKlasor);
                if (file.Exists)
                {
                    file.Delete();
                }

                var galerryImages = await _imageGallery.SingleOrDefaultAsync(x => x.Image == deleteImage);

                if (galerryImages != null)
                {
                    _imageGallery.Remove(galerryImages);
                }

                uploadFiles = deleteImage;

                if (!String.IsNullOrEmpty(newSession))
                {
                    string rplc = deleteImage + "/";
                    newSession = newSession.Replace(rplc, "");
                }
            }
            else
            {
                var files = Request.Form.Files;

                foreach (var file in files)
                {

                    string tarih = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Millisecond}";
                    string dosyaAdi = $"{SEOUrlOlustur(file.FileName.Split('.').First()) + "-" + tarih}.{file.FileName.Split('.').Last()}";
                    var kombinKlasor = Path.Combine(kayitKlasoru, dosyaAdi);

                    using (var fileStream = new FileStream(kombinKlasor, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    uploadFiles += dosyaAdi + "/";
                    newSession += dosyaAdi + "/";
                }
            }

            if (!String.IsNullOrEmpty(newSession))
            {
                HttpContext.Session.SetString("galeri", newSession);
            }

            return Json(uploadFiles);

        }

        public IActionResult AddToCarModel() {

            var categories = _categoryService.GetAll();

            List<SelectListItem> categoryList = new List<SelectListItem>();

            foreach (var category in categories) {

                categoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }

            var brands = _carBrand.GetAll();

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach (var brand in brands) {

                brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
            }

            var equipments = _equipmentService.GetAll();

            List<SelectListItem> equipmentList = new List<SelectListItem>();

            foreach (var equipment in equipments) {
                equipmentList.Add(new SelectListItem { Text = equipment.Name, Value = equipment.Id.ToString() });
            }

            ViewBag.Category = categoryList;
            ViewBag.Brands = brandList;
            ViewBag.Equipment = equipmentList;

            return View();
        
        }

        public async Task<string> AddModel(CarModel model) {

            var category = await _categoryService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["Category"]));
            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarBrand"]));
            var equipment = await _equipmentService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["Equipment"]));

            model.Category = category;
            model.CarBrand = brand;
            model.Equipment = equipment;

            await _carModelService.AddAsync(model);

            return model.Id.ToString();

        }

        public IActionResult ListCarModel() {

            var carModels = _carModelService.GetAllIncludeModels();

            return View(carModels);
        
        }
        public IActionResult ListCar()
        {

            var adverts = _advertService.GetAllInclude();

            return View(adverts);

        }
        public IActionResult AddBrand()
        {
            return View();

        }
        public async Task<string> AddToBrand(CarBrand brand) {

            await _carBrand.AddAsync(brand);

            return brand.Id.ToString();
        
        }

        public IActionResult ListCarBrand() {

            var brands = _carBrand.GetAll().ToList();

            return View(brands);

        }

        public IActionResult addcategory() {

            return View();

        }

        public async Task<string> AddToCategory(Category category) { 
        
            await _categoryService.AddAsync(category);

            return category.Id.ToString();
        
        }

        public IActionResult listcategories() { 
        
           var categories = _categoryService.GetAll().ToList();
           return View(categories);
        
        }

        public IActionResult AddToCarEquipment() {

            return View();
        
        }

        public async Task<string> AddEquipment(Equipment equipment) { 
        
            await _equipmentService.AddAsync(equipment);

            return equipment.Id.ToString();
        
        }

        public IActionResult ListCarEquipment() {

            var equipments = _equipmentService.GetAll().ToList();

            return View(equipments);
        
        }
        [HttpGet]
        public async Task UpdateRow(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _equipmentService.GetAll();
            var first = await _equipmentService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _equipmentService.Update(first);
        }
        [HttpGet]
        public async Task UpdateRowCategories(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _categoryService.GetAll();
            var first = await _categoryService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _categoryService.Update(first);
        }
        [HttpGet]
        public async Task UpdateRowBrand(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _carBrand.GetAll();
            var first = await _carBrand.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _carBrand.Update(first);
        }
        [HttpGet]
        public async Task UpdateRowCarModel(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _carModelService.GetAll();
            var first = await _carModelService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _carModelService.Update(first);
        }
        public string SEOUrlOlustur(string deger)
        {

            string donen = deger.ToLower();

            donen = donen.Replace("!", "");
            donen = donen.Replace("'", "");
            donen = donen.Replace("^", "");
            donen = donen.Replace("+", "");
            donen = donen.Replace("%", "");
            donen = donen.Replace("&", "");
            donen = donen.Replace("/", "");
            donen = donen.Replace("(", "");
            donen = donen.Replace(")", "");
            donen = donen.Replace("=", "");
            donen = donen.Replace("?", "");
            donen = donen.Replace("_", "-");
            donen = donen.Replace(" ", "-");
            donen = donen.Replace("*", "");
            donen = donen.Replace(".", "");
            donen = donen.Replace(">", "");
            donen = donen.Replace("£", "");
            donen = donen.Replace("#", "");
            donen = donen.Replace("$", "");
            donen = donen.Replace("½", "");
            donen = donen.Replace("|", "-");
            donen = donen.Replace("{", "");
            donen = donen.Replace("}", "");
            donen = donen.Replace("[", "");
            donen = donen.Replace("]", "");
            donen = donen.Replace("\\", "");
            donen = donen.Replace("ğ", "g");
            donen = donen.Replace("ü", "u");
            donen = donen.Replace("ş", "s");
            donen = donen.Replace("ö", "o");
            donen = donen.Replace("ç", "c");
            donen = donen.Replace(":", "-");
            donen = donen.Replace("ı", "i");

            return donen;

        }

    }
}
