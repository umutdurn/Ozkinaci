using B7.Filter;
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
        private readonly IEquipmentService _equipmentService;
        private readonly IAdvertService _advertService;
        private readonly IService<Admin> _adminService;

        public AdminController(IService<Gallery> imageGallery, IAdvertService advertService, IService<CarBrand> carBrand, ICarModelService carModelService, IService<Category> categoryService, IEquipmentService equipmentService, IService<Admin> adminService)
        {
            _imageGallery = imageGallery;
            _advertService = advertService;
            _carBrand = carBrand;
            _carModelService = carModelService;
            _categoryService = categoryService;
            _equipmentService = equipmentService;
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [LoginFilter]
        public IActionResult AddToCar(){

            var carBrand = _carBrand.GetAll();

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach(var brand in carBrand)
            {

                brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });

            }

            ViewBag.CarBrand = brandList;

            return View();
        }
        [LoginFilter]
        [HttpPost]
        public async Task<JsonResult> Getmodels(int id) { 
        
            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id == id);

            var models = _carModelService.Where(x => x.CarBrand == brand).Result;

            return Json(models);
        
        }
        [LoginFilter]
        [HttpPost]
        public async Task<JsonResult> GetEquipment(int id)
        {

            var model = await _carModelService.FirstOfDefaultAsync(x => x.Id == id);

            var equipment = _equipmentService.Where(x => x.CarModel == model).Result;

            return Json(equipment);

        }
        [LoginFilter]
        public async Task<IActionResult> UpdateToCar(int id)
        {
            var carBrand = _carBrand.GetAll();

            var advert = _advertService.GetByIdInclude(id);

            var carModel = advert.CarModel.CarBrand.CarModel;

            var equipment = advert.CarModel.Equipment;

            List<SelectListItem> modelList = new List<SelectListItem>();

            foreach (var model in carModel)
            {
                if (advert.CarModel.Id == model.Id)
                {
                    modelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString(), Selected = true });
                }
                else
                {
                    modelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString() });
                }
            }

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach (var brand in carBrand)
            {
                if (advert.CarModel.CarBrand.Id == brand.Id)
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString(), Selected = true });
                }
                else
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
                }
            }

            List<SelectListItem> equipmentList = new List<SelectListItem>();

            foreach (var equ in equipment)
            {
                if (equ.Id == advert.Equipment.Id)
                {
                    equipmentList.Add(new SelectListItem { Text = equ.Name, Value = equ.Id.ToString(), Selected = true });
                }
                else
                {
                    equipmentList.Add(new SelectListItem { Text = equ.Name, Value = equ.Id.ToString() });
                }
            }

            ViewBag.CarModel = modelList;
            ViewBag.CarBrand = brandList;
            ViewBag.Equipment = equipmentList;

            return View(advert);
        }
        [LoginFilter]
        public async Task<IActionResult> AddAdvert(Advert advert)
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
            var equipment = await _equipmentService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["Equipment"]));

            advert.CarModel = carModel;
            advert.Equipment = equipment;

            await _advertService.AddAsync(advert);

            return RedirectToAction(nameof(UpdateToCar), new { id = advert.Id });
        }
        [LoginFilter]
        public async Task<IActionResult> UpdateAdvert(Advert getAdvert)
        {

            var carModel = await _carModelService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarModel"]));

            var advert = _advertService.GetByIdInclude(getAdvert.Id);
            advert.CarModel = carModel;
            advert.Gear = getAdvert.Gear;
            advert.Fuel = getAdvert.Fuel;
            advert.Year = getAdvert.Year;
            advert.Km = getAdvert.Km;
            advert.MaxSpeed = getAdvert.MaxSpeed;
            advert.To0100 = getAdvert.To0100;
            advert.Tork = getAdvert.Tork;
            advert.EmptyWeight = getAdvert.EmptyWeight;
            advert.FuelConsumption = getAdvert.FuelConsumption;
            advert.CylinderVolume = getAdvert.CylinderVolume;
            advert.CylinderNumber = getAdvert.CylinderNumber;
            advert.ValveNumber = getAdvert.ValveNumber;
            advert.CaseType = getAdvert.CaseType;
            advert.EnginePower = getAdvert.EnginePower;
            advert.Color = getAdvert.Color;
            advert.TypeOfTransfer = getAdvert.TypeOfTransfer;
            advert.Price = getAdvert.Price;


            string Images = HttpContext.Session.GetString("galeri");

            List<Gallery> Gallerys = advert.Gallery.ToList();

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

            _advertService.Update(advert);

            HttpContext.Session.Remove("galeri");

            return RedirectToAction(nameof(UpdateToCar), new { id = advert.Id });
        }
        [LoginFilter]
        public async Task<IActionResult> DeleteToCar(int id) { 
        
            var advert = await _advertService.FirstOfDefaultAsync(x => x.Id == id);

            _advertService.Remove(advert);

            return RedirectToAction(nameof(ListCar));

        }
        [LoginFilter]

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
        [LoginFilter]
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

            ViewBag.Category = categoryList;
            ViewBag.Brands = brandList;

            return View();
        
        }
        [LoginFilter]
        public IActionResult UpdateToCarModel(int id)
        {

            var carModel = _carModelService.GetByIdIncludeModels(id);

            var categories = _categoryService.GetAll();

            List<SelectListItem> categoryList = new List<SelectListItem>();

            foreach (var category in categories)
            {
                if (carModel.Category.Id == category.Id)
                {
                    categoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString(), Selected = true });
                }
                else
                {
                    categoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
                }
                
            }

            var brands = _carBrand.GetAll();

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach (var brand in brands)
            {
                if (carModel.CarBrand.Id == brand.Id)
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString(), Selected = true });
                }
                else
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
                }
                
            }

            ViewBag.Category = categoryList;
            ViewBag.Brands = brandList;

            return View(carModel);

        }
        [LoginFilter]
        public async Task<IActionResult> AddModel(CarModel model) {

            var category = await _categoryService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["Category"]));
            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarBrand"]));

            model.Category = category;
            model.CarBrand = brand;

            await _carModelService.AddAsync(model);

            return RedirectToAction(nameof(ListCarModel));

        }
        [LoginFilter]
        public async Task<IActionResult> DeleteCarModel(int id) {


            var carModel = await _carModelService.FirstOfDefaultAsync(x => x.Id == id);

            _carModelService.Remove(carModel);

            return RedirectToAction(nameof(ListCarModel));

        }
        [LoginFilter]
        [HttpPost]
        public async Task<IActionResult> UpdateModel(CarModel model)
        {

            var category = await _categoryService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["Category"]));
            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarBrand"]));

            model.Category = category;
            model.CarBrand = brand;

            _carModelService.Update(model);

            return RedirectToAction(nameof(ListCarModel));

        }
        [LoginFilter]
        public IActionResult ListCarModel() {

            var carModels = _carModelService.GetAllIncludeModels();

            return View(carModels);
        
        }
        [LoginFilter]
        public IActionResult ListCar()
        {

            var adverts = _advertService.GetAllInclude();

            return View(adverts);

        }
        [LoginFilter]
        public IActionResult AddBrand()
        {
            return View();

        }
        [LoginFilter]
        public async Task<IActionResult> AddToBrand(CarBrand brand) {

            await _carBrand.AddAsync(brand);

            return RedirectToAction(nameof(ListCarBrand));

        }
        [LoginFilter]
        public async Task<IActionResult> UpdateBrand(int id)
        {

            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id == id);

            return View(brand);

        }
        [LoginFilter]
        [HttpPost]
        public IActionResult UpdateToBrand(CarBrand brand)
        {
            brand.Order = 0;

            _carBrand.Update(brand);

            return RedirectToAction(nameof(ListCarBrand));

        }
        [LoginFilter]
        public async Task<IActionResult> DeleteBrand(int id)
        {

            var brand = await _carBrand.FirstOfDefaultAsync(x => x.Id==id);

            _carBrand.Remove(brand);


            return RedirectToAction(nameof(ListCarBrand));
        }
        [LoginFilter]
        public IActionResult ListCarBrand() {

            var brands = _carBrand.GetAll().ToList();

            return View(brands);

        }
        [LoginFilter]
        public IActionResult addcategory() {

            return View();

        }
        [LoginFilter]
        public async Task<IActionResult> updatecategory(int id)
        {

            var category = await _categoryService.FirstOfDefaultAsync(x => x.Id == id);

            return View(category);

        }
        [LoginFilter]
        public async Task<IActionResult> AddToCategory(Category category) { 
        
            await _categoryService.AddAsync(category);

            return RedirectToAction(nameof(listcategories));

        }
        [LoginFilter]
        public IActionResult UpdateToCategory(Category category)
        {

            _categoryService.Update(category);

            return RedirectToAction(nameof(listcategories));

        }
        [LoginFilter]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.FirstOfDefaultAsync(x => x.Id == id);

            _categoryService.Remove(category);

            return RedirectToAction(nameof(listcategories));

        }
        [LoginFilter]
        public IActionResult listcategories() { 
        
           var categories = _categoryService.GetAll().ToList();
           return View(categories);
        
        }
        [LoginFilter]
        public IActionResult AddToCarEquipment() {

            var carBrand = _carBrand.GetAll();

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach (var brand in carBrand)
            {
                brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
            }

            ViewBag.CarBrand = brandList;

            return View();
        
        }
        [LoginFilter]
        public async Task<IActionResult> UpdateToCarEquipment(int id)
        {
            var carEquipment = _equipmentService.GetByIdAllInclude(id);


            var carBrand = _carBrand.GetAll();
            var carModel = _carModelService.GetAllIncludeModelsByCarBrand(carEquipment.CarModel.CarBrand);

            List<SelectListItem> brandList = new List<SelectListItem>();

            foreach (var brand in carBrand)
            {
                if (carEquipment.CarModel.CarBrand.Id == brand.Id)
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString(), Selected = true });
                }
                else
                {
                    brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
                }
                
            }

            ViewBag.CarBrand = brandList;

            List<SelectListItem> carModelList = new List<SelectListItem>();

            foreach (var model in carModel)
            {
                if (carEquipment.CarModel.Id == model.Id)
                {
                    carModelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString(), Selected = true });
                }
                else
                {
                    carModelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString() });
                }

            }

            ViewBag.CarModel = carModelList;

            return View(carEquipment);

        }
        [LoginFilter]
        public async Task<IActionResult> AddEquipment(Equipment equipment) {

            var model = await _carModelService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarModel"]));

            equipment.CarModel = model;

            await _equipmentService.AddAsync(equipment);

            return RedirectToAction(nameof(ListCarEquipment));

        }
        [LoginFilter]
        public async Task<IActionResult> UpdateEquipment(Equipment equipment)
        {

            var model = await _carModelService.FirstOfDefaultAsync(x => x.Id == Convert.ToInt32(Request.Form["CarModel"]));

            equipment.CarModel = model;

            _equipmentService.Update(equipment);

            return RedirectToAction(nameof(ListCarEquipment));

        }
        [LoginFilter]
        public IActionResult ListCarEquipment() {

            var equipments = _equipmentService.GetAll().ToList();

            return View(equipments);
        
        }
        [LoginFilter]
        public async Task<IActionResult> RemoveCarEquipment(int id)
        {

            var equipment = await _equipmentService.FirstOfDefaultAsync(x => x.Id == id);

            _equipmentService.Remove(equipment);

            return RedirectToAction(nameof(ListCarEquipment));

        }
        [LoginFilter]
        [HttpGet]
        public async Task UpdateRow(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _equipmentService.GetAll();
            var first = await _equipmentService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _equipmentService.Update(first);
        }
        [LoginFilter]
        [HttpGet]
        public async Task UpdateRowCategories(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _categoryService.GetAll();
            var first = await _categoryService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _categoryService.Update(first);
        }
        [LoginFilter]
        [HttpGet]
        public async Task UpdateRowBrand(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _carBrand.GetAll();
            var first = await _carBrand.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _carBrand.Update(first);
        }
        [LoginFilter]
        [HttpGet]
        public async Task UpdateRowCarModel(int Id, int fromPosition, int toPosition)
        {
            var KategoriList = _carModelService.GetAll();
            var first = await _carModelService.FirstOfDefaultAsync(c => c.Id == Id);
            first.Order = toPosition;

            _carModelService.Update(first);
        }
        [LoginFilter]
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
        [HttpPost]
        public async Task<IActionResult> AdminLogin()
        {

            var admin = await _adminService.FirstOfDefaultAsync(x => x.Mail == Request.Form["Mail"].ToString() && x.Password == Request.Form["Password"].ToString());

            if (admin != null)
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddHours(12);
                Response.Cookies.Append("AdminLogin","true", cookie);

                return RedirectToAction("ListCar");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
