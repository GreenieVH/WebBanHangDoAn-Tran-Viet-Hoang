using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using WebBanHangP2.DataBaseWebBH;
using WebBanHangP2.Models;

namespace WebBanHangP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewDbContext _dbConnect;
        private int pageSize;
        public string _UserNameCookis;
        public HomeController(ILogger<HomeController> logger, NewDbContext dbContext)
        {
            _logger = logger;
            _dbConnect = dbContext;
        }

        public IActionResult Index()
        {
            var product = from p in _dbConnect.ProductEntities
                          join c in _dbConnect.CategoryEntities
                          on p.idCategory equals c.idCategory
                          join s in _dbConnect.SystemEntities
                          on p.idSystem equals s.idSystem
                          select new Product()
                          {
                                idProduct = p.idProduct,
                                nameProduct = p.nameProduct,
                                priceProduct = p.priceProduct,
                                priceSaleProduct = p.priceSaleProduct,
                                imgProduct  = p.imgProduct,
                                idCategory = p.idCategory,
                                idSystem = p.idSystem,
                              
                          };
            List<Product> products = product.ToList();

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
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                }
            }


            return View(products);
        }

        [Authorize]
        public IActionResult Shop(int pageSize,int pageNumber,string seachName, int costSale, int newOld,int company)
        {
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
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                }
            }
            else
            {
                 return Redirect("/Home/Index");
            }



            bool checkNew = false;
            if(newOld == 1 || newOld == 0)
            {
                checkNew = true;
            }else if(newOld == 2)
            {
                checkNew = false;
            }
            var Product = from P in _dbConnect.ProductEntities
                          join C in _dbConnect.CategoryEntities
                          on P.idCategory equals C.idCategory
                          join S in _dbConnect.SystemEntities
                          on P.idSystem equals S.idSystem
                          where (String.IsNullOrEmpty(seachName) || P.nameProduct.ToLower().Contains(seachName.ToLower()))
                          && P.idCategory == company 
                          select new Product()
                          {
                              idProduct = P.idProduct,
                              imgProduct = P.imgProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              idSystem = P.idSystem,
                              priceSaleProduct = P.priceSaleProduct,
                              newProduct = P.newProduct,
                              nameCategory = C.nameCategory,
                              nameSystem = S.nameSystemn
                          };

            if(company == 0 )
            {
                Product = from P in _dbConnect.ProductEntities
                          join C in _dbConnect.CategoryEntities
                          on P.idCategory equals C.idCategory
                          join S in _dbConnect.SystemEntities
                          on P.idSystem equals S.idSystem
                          where (String.IsNullOrEmpty(seachName) || P.nameProduct.ToLower().Contains(seachName.ToLower()))
                          && P.newProduct == checkNew
                          select new Product()
                          {
                              idProduct = P.idProduct,
                              imgProduct = P.imgProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              idSystem = P.idSystem,
                              priceSaleProduct = P.priceSaleProduct,
                              newProduct = P.newProduct,
                              nameCategory = C.nameCategory,
                              nameSystem = S.nameSystemn
                          };
            }
            if (pageSize == 0)
            {
                pageSize = 8;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = Product.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;

            if (costSale == 0)
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
            if (costSale == 1)
            {
                var Model = new ModleAllClass()
                {
                    ToolCont = ToolCont,
                    Product = Product.OrderBy(P => P.priceProduct).Skip(skip).Take(pageSize).ToList(),
                    PageCount = pageCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };
                return View(Model);
            }
            if (costSale == 2)
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

        [Authorize]
        public IActionResult Cart() {
            int idUserAddCart = 0;
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
                                     isBan = us.isBan
                                 };
                foreach (var us in AcountUser)
                {
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                    idUserAddCart = us.idUser;
                }
            }
            var ProductCart = from P in _dbConnect.AddCartEntities
                              where P.idUser == idUserAddCart
                              select new AddCart()
                              {
                                  idAddCart = P.idAddCart,
                                  imgProductAddCart = P.imgProductAddCart,
                                  nameProductAddCart =P.nameProductAddCart,
                                  priceProductAddCart =P.priceProductAddCart,
                                  quantity =P.quantity,
                                  priceTotal = P.priceTotal,
                                  idProduct = P.idProduct,
                              };
            var Product = from pd in _dbConnect.ProductEntities
                          select new Product()
                          {
                              idProduct = pd.idProduct,
                              nameProduct = pd.nameProduct,
                              imgProduct = pd.imgProduct,
                              priceProduct = pd.priceProduct,
                              priceSaleProduct = pd.priceSaleProduct,

                          };
            var model = new ModleAllClass
            {
                AddCart = ProductCart.ToList(),
                Product = Product.ToList()
            };
            return View(model);
        }

        [Authorize]
        public IActionResult AddCart(int id)
        {
            int idUserCart = 0;
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
                    idUserCart = us.idUser;
                    
                }
            }
            else
            {
                return Redirect("/Home/Index");
            }

            var product = from P in _dbConnect.ProductEntities
                          where P.idProduct == id
                          select new Product()
                          {
                              idProduct = P.idProduct,
                              nameProduct = P.nameProduct,
                              priceSaleProduct = P.priceSaleProduct,
                              imgProduct = P.imgProduct,
                          };
            
            List<Product> products = product.ToList();
            var checkcart = from C in _dbConnect.AddCartEntities
                            where C.idUser == idUserCart
                            select new AddCart()
                            {
                                idProduct = C.idProduct
                            };
            foreach (var item in checkcart.ToList())
            {
                if(item.idProduct == id)
                {
                    return Redirect("/Home/Cart");
                }
            }

            var AddCartU = new vhAddCartEntity
            {
                idUser = idUserCart,
                nameProductAddCart = products[0].nameProduct,
                priceProductAddCart = products[0].priceSaleProduct,
                priceTotal = products[0].priceSaleProduct,
                imgProductAddCart = products[0].imgProduct,
                quantity = 1,
                idProduct = products[0].idProduct
            };
            _dbConnect.Add(AddCartU);
            _dbConnect.SaveChanges();
            
            return Redirect("/Home/Cart");
        }
        public IActionResult DeleteCart(int id)
        {
            var Delete = _dbConnect.AddCartEntities.Find(id);
            _dbConnect.AddCartEntities.Remove(Delete);
            _dbConnect.SaveChanges();
            return Redirect("/Home/Cart");
        }
        public IActionResult Checkout() {
            return View();
        }
        [Authorize]
        public IActionResult Single_product(int pageSize, int pageNumber, string seachName)
        {
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
                                     isBan = us.isBan
                                 };
                foreach (var us in AcountUser)
                {
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                }
            }
            

            var Product = from P in _dbConnect.ProductEntities
                          where (String.IsNullOrEmpty(seachName) || P.nameProduct.ToLower().Contains(seachName.ToLower()))
                          select new Product {
                              idProduct = P.idProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              priceSaleProduct = P.priceSaleProduct,
                              imgProduct = P.imgProduct,
                          };
            if (pageSize == 0)
            {
                pageSize = 4;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var ToolCont = Product.Count();
            var pageCount = (int)Math.Ceiling((double)ToolCont / pageSize);
            var skip = pageNumber * pageSize - pageSize;


            var Model1 = new ModleAllClass()
            {
                ToolCont = (int)ToolCont,
                Product = Product.OrderBy(P => P.idProduct).Skip(skip).Take(pageSize).ToList(),
                PageCount = pageCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
            };
            return View(Model1);
        }
        public IActionResult ProductDetail(int id)
        {
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
                    TempData["IdUser"] = us.idUser;
                    TempData["UserName"] = us.nameUser;
                    TempData["AccountUser"] = us.accountUser;
                    TempData["AccountPass"] = us.passwordUser;
                    TempData["CheckAdmin"] = us.isAdmin;
                }
            }
            else
            {
                return Redirect("/Home/Index");
            }

            ViewBag.id = id;
            var Product = from P in _dbConnect.ProductEntities
                          where P.idProduct == id
                          select new Product
                          {
                              idProduct = P.idProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              priceSaleProduct = P.priceSaleProduct,
                              imgProduct = P.imgProduct,
                          };
            var ProductRandom = from P in _dbConnect.ProductEntities
                          select new Product
                          {
                              idProduct = P.idProduct,
                              nameProduct = P.nameProduct,
                              priceProduct = P.priceProduct,
                              priceSaleProduct = P.priceSaleProduct,
                              imgProduct = P.imgProduct,
                          };
            var model = new ModleAllClass()
            {
                Product = Product.ToList(),
                ProductRandom = ProductRandom.ToList()
            };
            return View(model);
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}