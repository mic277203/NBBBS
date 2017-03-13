using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBBBS.Data;
using NBBBS.Service;

namespace NBBBS.Web.Controllers
{
    public class SysUsersController : Controller
    {
        private readonly ISysUserService _ISysUserService;

        public SysUsersController(ISysUserService sysUserService)
        {
            _ISysUserService = sysUserService;
        }

        // GET: SysUsers
        public IActionResult Index()
        {
            return View(_ISysUserService.List());
        }
    }
}
