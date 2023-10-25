using AspNetCoreHero.ToastNotification.Abstractions;
using FineBlog.Data;
using FineBlog.Models;
using FineBlog.Utilites;
using FineBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using X.PagedList;

namespace FineBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        public INotyfService _notification { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ApplicationDbContext context,
                                INotyfService notyfService,
                                IWebHostEnvironment webHostEnvironment,
                                UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _notification = notyfService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            var listOfcategorys = new List<Category>();

            var loggedInUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);
            var loggedInUserRole = await _userManager.GetRolesAsync(loggedInUser!);
            if (loggedInUserRole[0] == WebsiteRoles.WebsiteAdmin)
            {
                listOfcategorys = await _context.Categorys!.Include(x => x.ApplicationUser).ToListAsync();
            }
            else
            {
                listOfcategorys = await _context.Categorys!.Include(x => x.ApplicationUser).Where(x => x.ApplicationUser!.Id == loggedInUser!.Id).ToListAsync();
            }

            var listOfcategoryVM = listOfcategorys.Select(x => new CategoryVM()
            {
                CateID = x.CateID,
                CateName = x.catename,

            }).ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(await listOfcategoryVM.OrderByDescending(x => x.CateID).ToPagedListAsync(pageNumber, pageSize));
        }
    }
}
