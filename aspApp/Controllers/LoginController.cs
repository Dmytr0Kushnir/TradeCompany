using aspApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TradingCompany.BusinessLogic.Interfaces;

namespace aspApp.Controllers
{
    public class LoginController : Controller
    {
        public static bool active;
        IAuthManager _managerA;
        IProductManager _managerP;
        public LoginController(IAuthManager authManager, IProductManager productManager)
        {
            active = false;
            _managerA = authManager;
            _managerP = productManager;
        }
        public IActionResult Index()
        {

            active = false;
            var user = new LoginViewModel();
            return View(user);

        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            var login = _managerA.Login(model.UserName, model.Password);
            
            if (login )
            {
                var id = _managerA.GetId(model.UserName);
                var user = _managerP.GetListOfPeople().Where(p => p.Id == id).FirstOrDefault();
                active = true;               
                return View("../Home/Index", user);
            }
            else
            {
                active = false;
                return View("../Home/Error",new ErrorViewModel());
            }



        }

        public IActionResult Register()
        {
            active = false;
            var user = new RegisterViewModel();
            return View(user);

        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var u = new RegisterViewModel();
            // if (model.Login != null || model.Password != null || model.RoleDTO != null || model.LastName != null || model.FirstName != null || model.Email != null)

            if (u != model) 
            {
                var register = _managerA.Registration(model.Login, model.Password, model.FirstName, model.LastName, model.DateOfBirth, model.Email);

                if (register)
                {
                    active = true;
                    var id = _managerA.GetId(model.Login);
                    var user = _managerP.GetListOfPeople().Where(p => p.Id == id).FirstOrDefault();
                    return View("../Home/Index", user);
                }
                else
                {

                    return View("../Login/Register", new RegisterViewModel());
                }
            }
            else
            {
                active = false;
                return View("../Login/Register", new RegisterViewModel());

            }



        }
    }
}
