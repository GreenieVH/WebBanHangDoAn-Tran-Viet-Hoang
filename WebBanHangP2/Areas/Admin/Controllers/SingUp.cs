using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using WebBanHangP2.DataBaseWebBH;
using WebBanHangP2.Models;

namespace WebBanHangP2.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class SingUpController : Controller
    {
        private readonly ILogger<SingUpController> _logger;
        private readonly NewDbContext _dbConnect;
        private readonly IWebHostEnvironment _enviroment;
        public string _UserNameCookis;

        public SingUpController(ILogger<SingUpController> logger, NewDbContext dbContext, IWebHostEnvironment enviroment)
        {
            _logger = logger;
            _dbConnect = dbContext;
            _enviroment = enviroment;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            return View();
        }


        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> Index(Users useInfo)
        {

            var query = from us in _dbConnect.UserEntities
                        where us.accountUser == useInfo.accountUser && us.passwordUser == useInfo.passwordUser
                        select new Users()
                        {
                            nameUser = us.nameUser,
                            idUser = us.idUser,
                            accountUser = us.accountUser,
                            passwordUser = us.passwordUser,
                            isAdmin = us.isAdmin,
                            isBan = us.isBan,
                            emailUser = us.emailUser,
                            addressUser = us.addressUser,
                            phoneUser = us.phoneUser,
                            storyUser = us.storyUser,
                            imgUser = us.imgUser
                        };

            var user = query.FirstOrDefault(x => x.accountUser == useInfo.accountUser
            && x.passwordUser == useInfo.passwordUser);
            if (user == null)
            {
                string message = "Tài khoản hoặc mật khẩu không chính xác !!";
                TempData["erorMessage"] = message;
                return Redirect("/admin/singup/index");
            }

            //foreach (var item in query)
            //{
            //    if (item.isBan == true)
            //    {
            //        string message = "Tài khoản đã bị khóa do hành vi xấu";
            //        TempData["erorMessage"] = message;
            //        return Redirect("/Home/Login");
            //    }
            //}
            var clanims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.accountUser),

                new Claim(ClaimTypes.NameIdentifier, user.accountUser),
            };
            

            if (User.Identity.IsAuthenticated)
            {
                foreach (var cclams in User.Claims)
                {
                    string s = cclams.Value;
                }
            }
            var identy = new ClaimsIdentity(clanims, CookieAuthenticationDefaults.AuthenticationScheme);

            var princical = new ClaimsPrincipal(identy);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princical);

            //foreach (var item in query)
            //{
            //    if (item.IsAdmin == true)
            //    {
            //        return Redirect("/Admin/Home/Index");
            //    }
            //}
            if (User.Identity.IsAuthenticated)
            {
                foreach (var cclams in User.Claims)
                {
                    _UserNameCookis = cclams.Value;
                }
            }
            return Redirect("/Home/Index");
        }


        [Area("Admin")]
        public IActionResult Register()
        {
            var User = from U in _dbConnect.UserEntities
                          select new Users
                          {
                                idUser = U.idUser,
                                nameUser = U.nameUser,
                                accountUser = U.accountUser,
                                passwordUser = U.passwordUser,
                                isAdmin = U.isAdmin,
                                isBan = U.isBan,
                                emailUser = U.emailUser,
                                addressUser = U.addressUser,
                                phoneUser = U.phoneUser,
                                storyUser = U.storyUser,
                                imgUser = U.imgUser
                          };
            var query = new ModleAllClass
            {
                Users = User.ToList()
            };
            return View(query);
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult NewUser([FromBody] Users user)
        {
            if (user.nameUser == "" || user.accountUser == "" || user.passwordUser == "")
            {
                return Ok(2);
            }
            if (user.passwordUser != user.passwordUserCheck)
            {
                return Ok(3);
            }
            var newUsers = new vhUserEntity
            {
                nameUser = user.nameUser,
                accountUser = user.accountUser,
                passwordUser = user.passwordUser,
                isAdmin = false,
                isBan = false,
                emailUser = "",
                addressUser = "",
                phoneUser = "",
                storyUser = "",
                imgUser = "",
            };
            _dbConnect.UserEntities.Add(newUsers);
            var vh = _dbConnect.SaveChanges();
            return Ok(vh);
        }
    }
}
