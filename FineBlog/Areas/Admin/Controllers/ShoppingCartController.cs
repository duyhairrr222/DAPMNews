//using AspNetCoreHero.ToastNotification.Abstractions;
//using FineBlog.Data;
//using FineBlog.Models;
//using FineBlog.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace FineBlog.Areas.Admin.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        public INotyfService _notification { get; }
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public ShoppingCartController(ApplicationDbContext context,
//                                INotyfService notyfService,
//                                IWebHostEnvironment webHostEnvironment,
//                                UserManager<ApplicationUser> userManager)
//        {
//            _context = context;
//            _notification = notyfService;
//            _webHostEnvironment = webHostEnvironment;
//            _userManager = userManager;
//        }
//        public List<CartItem> GioHang
//        {
//            get
//            {
//                var gioHang = HttpContext.Session.Get<List<CartItem>>("Giỏ hàng");
//                if( gioHang == default(List<CartItem>))
//                {
//                    gioHang = new List<CartItem>();

//                }
//                return gioHang;
//            }
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
