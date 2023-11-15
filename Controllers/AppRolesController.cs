using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AdventureLandWebapp.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
                _roleManager = roleManager;
        }

        //List all the roles created

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
                }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            // avoid duplicate
            if (!_roleManager.RoleExistsAsync(roleName: model.Name).GetAwaiter().GetResult()) { 
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
