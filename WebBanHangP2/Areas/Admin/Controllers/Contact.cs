using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHangP2.DataBaseWebBH;
using WebBanHangP2.Models;

namespace WebBanHangP2.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class Contact : Controller
    {
        private readonly ILogger<Contact> _logger;
        private readonly NewDbContext _dbConnect;
        private readonly IWebHostEnvironment _enviroment;
        public string _UserNameCookis;


        public Contact(ILogger<Contact> logger, NewDbContext dbContext, IWebHostEnvironment enviroment)
        {
            _logger = logger;
            _dbConnect = dbContext;
            _enviroment = enviroment;
        }

        public object Viewbag { get; private set; }

        [Area("Admin")]
        public IActionResult ContactUser()
        {
            var Contact = from C in _dbConnect.ContactEntities
                          select new ContactUser()
                          {
                              idUser = C.idUser,
                              idContact = C.idContact,
                              nameUserContact = C.nameUserContact,
                              emailEmailContact = C.emailEmailContact,
                              subjectContact = C.subjectContact,
                              messageContact = C.messageContact,
                          };
            List<ContactUser> listContact = Contact.ToList();
            return View();
        }
        [Authorize]
        public IActionResult ContactAdd([FromBody] ContactUser contactUser)
        {
            int idUserContact = 0;
            if (User.Identity.IsAuthenticated)
            {
                foreach (var cclams in User.Claims)
                {
                    _UserNameCookis = cclams.Value;
                }
            }

            if (_UserNameCookis != null)
            {
                var AcountUser = from us in _dbConnect.UserEntities
                                 where us.accountUser == _UserNameCookis
                                 select new Users()
                                 {
                                     nameUser = us.nameUser,
                                     idUser = us.idUser,
                                     accountUser = us.accountUser,
                                     passwordUser = us.passwordUser,
                                     isAdmin = us.isAdmin,
                                     isBan = us.isBan,
                                     addressUser = us.addressUser,
                                     emailUser = us.emailUser,
                                     phoneUser = us.phoneUser,
                                     storyUser = us.storyUser,
                                     imgUser = us.imgUser,
                                 };
                foreach (var us in AcountUser)
                {
                    idUserContact = us.idUser;

                }
            }
            else
            {
                return Redirect("/Home/Index");
            }
            if (contactUser.nameUserContact == "" || contactUser.emailEmailContact == "" || contactUser.subjectContact == "")
            {
                return Ok(2);
            }
            
            var contactUserAdd = new vhContactEntity
            {
                idUser = idUserContact,
                nameUserContact = contactUser.nameUserContact,
                emailEmailContact = contactUser.emailEmailContact,
                subjectContact = contactUser.subjectContact,
                messageContact = contactUser.messageContact,
            };
            _dbConnect.Add(contactUserAdd);
            var check =  _dbConnect.SaveChanges();
            return Ok(check);
        }
        [Area("Admin")]
        public IActionResult UserProfile() 
        {
            if (User.Identity.IsAuthenticated)
            {
                foreach (var cclams in User.Claims)
                {
                    _UserNameCookis = cclams.Value;
                }
            }

            var AcountUser = from us in _dbConnect.UserEntities
                             where us.accountUser == _UserNameCookis
                             select new Users()
                             {
                                 nameUser = us.nameUser,
                                 idUser = us.idUser,
                                 accountUser = us.accountUser,
                                 passwordUser = us.passwordUser,
                                 isAdmin = us.isAdmin,
                                 isBan = us.isBan,
                                 imgUser = us.imgUser,
                                 emailUser = us.emailUser,
                                 addressUser = us.addressUser,
                                 phoneUser = us.phoneUser,
                                 storyUser = us.storyUser,
                             };

            foreach (var us in AcountUser)
            {

                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                
            }
            List<Users> Users = AcountUser.ToList();
            return View(Users);
        }
        [Area("Admin")]
        public IActionResult UserProfileChange(int id)
        {
            ViewBag.idUserEdit = id;
            var ur = from U in _dbConnect.UserEntities
                     where U.idUser == id
                     select new Users()
                     {
                         idUser = U.idUser,
                         nameUser = U.nameUser,
                         accountUser = U.accountUser,
                         passwordUser = U.passwordUser,
                         isAdmin = U.isAdmin,
                         isBan = U.isBan,
                         isAdminString = U.isAdmin.ToString(),
                         emailUser = U.emailUser,
                         addressUser = U.addressUser,
                         phoneUser = U.phoneUser,
                         storyUser = U.storyUser,
                         imgUser = U.imgUser,
                     };
            var que = new ModleAllClass
            {
                Users = ur.ToList()
            };
            return View(que);

        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult EditProfileChange([FromBody]Users user) 
        {
            var edit = _dbConnect.UserEntities.Find(user.idUser);
            edit.nameUser = user.nameUser;
            edit.accountUser = user.accountUser;
            edit.passwordUser = user.passwordUser;
            edit.emailUser = user.emailUser;
            edit.addressUser = user.addressUser;
            edit.phoneUser = user.phoneUser;
            edit.storyUser = user.storyUser;
            edit.imgUser = user.imgUser.ToString();
            _dbConnect.UserEntities.Update(edit);
            var vh = _dbConnect.SaveChanges();
            return Ok(vh);
        }
    }
}
