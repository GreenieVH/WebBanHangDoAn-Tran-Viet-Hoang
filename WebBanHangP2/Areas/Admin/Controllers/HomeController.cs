using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging.Signing;
using System.Security.Claims;
using WebBanHangP2.DataBaseWebBH;
using WebBanHangP2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBanHangP2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewDbContext _dbConnect;
        private readonly IWebHostEnvironment _enviroment;
        public string _UserNameCookis;
        public HomeController(ILogger<HomeController> logger, NewDbContext dbContext, IWebHostEnvironment enviroment)
        {
            _logger = logger;
            _dbConnect = dbContext;
            _enviroment = enviroment;
        }
        [Authorize]
        [Area("Admin")]
        public IActionResult Index()
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
                                 emailUser = us.emailUser,
                                 addressUser = us.addressUser,
                                 phoneUser = us.phoneUser,
                                 storyUser = us.storyUser,
                                 imgUser = us.imgUser,
                             };

            foreach (var us in AcountUser)
            {
                if (us.isAdmin == false)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                    TempData["EmailUser"] = us.emailUser;
                    TempData["AddressUser"] = us.addressUser;
                    TempData["PhoneUser"] = us.phoneUser;
                    TempData["StoryUser"] = us.storyUser;
                    TempData["ImgUser"] = us.imgUser;
                }
            }
            return View();
        }

        [Area("Admin")]
        public IActionResult Product(string seachName, int pageSize, int pageNumber, int idSapXepKiem)
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
                                 emailUser = us.emailUser,
                                 addressUser = us.addressUser,
                                 phoneUser = us.phoneUser,
                                 storyUser = us.storyUser,
                                 imgUser = us.imgUser,
                             };

            foreach (var us in AcountUser)
            {
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                    TempData["EmailUser"] = us.emailUser;
                    TempData["AddressUser"] = us.addressUser;
                    TempData["PhoneUser"] = us.phoneUser;
                    TempData["StoryUser"] = us.storyUser;
                    TempData["ImgUser"] = us.imgUser;
                
            }

            var Product = from P in _dbConnect.ProductEntities
                          join C in _dbConnect.CategoryEntities
                          on P.idCategory equals C.idCategory
                          join S in _dbConnect.SystemEntities
                          on P.idSystem equals S.idSystem
                          where (String.IsNullOrEmpty(seachName) || P.nameProduct.ToLower().Contains(seachName.ToLower()))
                          select new Product()
                          {
                              idProduct = P.idProduct,
                              imgProduct = P.imgProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              idSystem = P.idSystem,
                              priceSaleProduct = P.priceSaleProduct,
                              nameCategory = C.nameCategory,
                              nameSystem = S.nameSystemn
                          };

            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = Product.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;

            if (idSapXepKiem == 0 || idSapXepKiem == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Product = Product.OrderBy(P => P.idProduct).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXepKiem == 2)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Product = Product.OrderBy(P => P.nameProduct).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXepKiem == 3)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Product = Product.OrderBy(P => P.priceSaleProduct).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }

            return View();

        }

        [Area("Admin")]
        public IActionResult NewProduct() 
        {
            var Category = from C in _dbConnect.CategoryEntities
                           select new Category()
                           {
                               idCategory = C.idCategory,
                               nameCategory = C.nameCategory,
                           };
            var SystemProducts = from S in _dbConnect.SystemEntities
                        select new SystemProduct()
                        {
                                idSystem = S.idSystem,
                                nameSystemn = S.nameSystemn,
                        };
            var query = new ModleAllClass()
            {
                Category = Category.ToList(),
                System = SystemProducts.ToList(),
            };
            return View(query);
        }

        [HttpPost]
        public IActionResult ProductNew([FromBody]Product product)
        {

            if (product.nameProduct == ""){
                return Ok(2);
            }
            var NewProduct = new vhProductEntity
            {
                nameProduct = product.nameProduct,
                priceProduct = product.priceProduct,
                priceSaleProduct = product.priceSaleProduct,
                imgProduct = product.imgProduct,
                idCategory = product.idCategory,
                idSystem = product.idSystem,
                newProduct = true
            };
            _dbConnect.ProductEntities.Add(NewProduct);
            var vh = _dbConnect.SaveChanges();
            return Ok(vh);
        }
        public IActionResult DeteleP(int id) 
        {
            var dlt = _dbConnect.ProductEntities.Find(id);
            _dbConnect.Remove(dlt);
            _dbConnect.SaveChanges();
            return Redirect("/admin/Home/Product");
        }
        public IActionResult DeleteU(int id)
        {
            var dlt = _dbConnect.UserEntities.Find(id);
            _dbConnect.Remove(dlt);
            _dbConnect.SaveChanges();
            return Redirect("/Admin/Home/UserS");
        }
        public IActionResult DeteleContact(int id)
        {
            var dlt = _dbConnect.ContactEntities.Find(id);
            _dbConnect.Remove(dlt);
            _dbConnect.SaveChanges();
            return Redirect("/Admin/Home/UserContactFb");
        }
        
        public IActionResult Change(int id)
        {
            ViewBag.IdProductEdit = id;
            var prd = from P in _dbConnect.ProductEntities
                      where P.idProduct == id
                      select new Product()
                      {
                          idProduct = P.idProduct,
                          nameProduct = P.nameProduct,
                          priceProduct = P.priceProduct,
                          priceSaleProduct= P.priceSaleProduct,
                          idCategory = P.idCategory,
                          idSystem = P.idSystem,
                      };

            var cate = from C in _dbConnect.CategoryEntities
                       select new Category()
                       {
                           idCategory = C.idCategory,
                           nameCategory = C.nameCategory
                       };
            var sys = from S in _dbConnect.SystemEntities
                      select new SystemProduct()
                      {
                          idSystem = S.idSystem,
                          nameSystemn = S.nameSystemn,
                      };

            var query = new ModleAllClass
            {
                Product = prd.ToList(),
                Category = cate.ToList(),
                System = sys.ToList(),
            };
            return View(query);
        }
        [HttpPost]
        public IActionResult EditChange([FromBody] Product product)
        {
            var edit = _dbConnect.ProductEntities.Find(product.idProduct);
            edit.nameProduct = product.nameProduct;
            edit.priceProduct = product.priceProduct;
            edit.priceSaleProduct = product.priceSaleProduct;
            edit.idCategory = product.idCategory;
            edit.idSystem = product.idSystem;
            edit.imgProduct = product.imgProduct;
            _dbConnect.ProductEntities.Update(edit);
            var vh = _dbConnect.SaveChanges();
            return Ok(vh);
        }

        [Area("Admin")]
        public IActionResult ChangeUser(int id)
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
        public IActionResult EditChangeUser([FromBody] Users user)
        {
            var edit = _dbConnect.UserEntities.Find(user.idUser);
            edit.nameUser = user.nameUser;
            edit.passwordUser = user.passwordUser;
            if (user.isAdminString == "1")
            {
                edit.isAdmin = true;
            }
            else if (user.isAdminString == "0")
            {
                edit.isAdmin = false;
            }

            if (user.isBanString == "1")
            {
                edit.isBan = true;
            }
            else if (user.isBanString == "0")
            {
                edit.isBan = false;
            }
            //edit.isAdmin = user.isAdmin;
            //edit.isBan = user.isBan;

            _dbConnect.UserEntities.Update(edit);
            var vh = _dbConnect.SaveChanges();
            return Ok(vh);
        }
        public IActionResult UserContactFb(string seachName, int pageSize, int pageNumber, int idSapXep)
        {
            var Contact = from C in _dbConnect.ContactEntities
                          where (String.IsNullOrEmpty(seachName) || C.nameUserContact.ToLower().Contains(seachName.ToLower()))
                          select new ContactUser()
                          {
                              idUser = C.idUser,
                              idContact =C.idContact,
                              nameUserContact = C.nameUserContact,
                              emailEmailContact = C.emailEmailContact,
                              subjectContact = C.subjectContact,
                              messageContact = C.messageContact,
                          };
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = Contact.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;

            if (idSapXep == 0 || idSapXep == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    ContactUserS = Contact.OrderBy(P => P.idUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 0 || idSapXep == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    ContactUserS = Contact.OrderBy(P => P.idUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 2)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    ContactUserS = Contact.OrderBy(P => P.idContact).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 3)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    ContactUserS = Contact.OrderBy(P => P.nameUserContact).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 4)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    ContactUserS = Contact.OrderBy(P => P.subjectContact).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            return View();
        }
        public IActionResult UserCart(string seachName, int pageSize, int pageNumber, int idSapXep)
        {
            var UserCart = from uc in _dbConnect.AddCartEntities
                           where (String.IsNullOrEmpty(seachName) || uc.nameProductAddCart.ToLower().Contains(seachName.ToLower()))
                           select new AddCart()
                           {
                               idUser = uc.idUser,
                               idProduct = uc.idProduct,
                               idAddCart = uc.idAddCart,
                               nameProductAddCart = uc.nameProductAddCart,
                               priceProductAddCart = uc.priceProductAddCart,
                               priceTotal = uc.priceTotal,
                               imgProductAddCart = uc.imgProductAddCart,
                               quantity = uc.quantity
                           };
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = UserCart.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;

            if (idSapXep == 0 || idSapXep == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    AddCart = UserCart.OrderBy(P => P.idUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 2)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    AddCart = UserCart.OrderBy(P => P.idAddCart).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 3)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    AddCart = UserCart.OrderBy(P => P.idProduct).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 4)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    AddCart = UserCart.OrderBy(P => P.nameProductAddCart).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXep == 5)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    AddCart = UserCart.OrderBy(P => P.priceProductAddCart).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            return View();
        }
        public IActionResult UserS(string seachName, int pageSize, int pageNumber, int idSapXepKiem)
        {

            var User = from U in _dbConnect.UserEntities
                          where (String.IsNullOrEmpty(seachName) || U.nameUser.ToLower().Contains(seachName.ToLower()))
                          select new Users()
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
                              imgUser = U.imgUser,
                          };
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = User.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;

            if (idSapXepKiem == 0 || idSapXepKiem == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Users = User.OrderBy(P => P.idUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXepKiem == 2)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Users = User.OrderBy(P => P.nameUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (idSapXepKiem == 3)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Users = User.OrderBy(P => P.accountUser).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult UploadImageProduct(IFormFile imageUpload)
        {
            if (imageUpload == null)
                return Json(new FileUpload()
                {
                    Status = "error",
                    Message = "File không tồn tại"
                });
            var fullPath = Path.Combine(_enviroment.WebRootPath, "fontend/img", imageUpload.FileName); // upload là foder
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                imageUpload.CopyTo(fileStream);
            }
            return Json(new FileUpload()
            {
                FileName = imageUpload.FileName.ToString(),
                FilePath = Path.Combine("/fontend/img", imageUpload.FileName),
                Status = "success",
                Message = "Upload file thành công!"
            });
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult UloadImageUser(IFormFile imageUpload)
        {
            if (imageUpload == null)
                return Json(new FileUpload()
                {
                    Status = "error",
                    Message = "File không tồn tại"
                });
            var fullPath = Path.Combine(_enviroment.WebRootPath, "imageUser", imageUpload.FileName); // upload là foder
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                imageUpload.CopyTo(fileStream);
            }
            return Json(new FileUpload()
            {
                FileName = imageUpload.FileName.ToString(),
                FilePath = Path.Combine("/imageUser", imageUpload.FileName),
                Status = "success",
                Message = "Upload file thành công!"
            });
        }

        public class FileUpload
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string Status { get; set; }
            public string Message { get; set; }
        }
    }
}
