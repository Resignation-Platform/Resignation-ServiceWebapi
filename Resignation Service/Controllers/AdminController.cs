using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resignation_Service.Services;
using Resignation_Service.ViewModels;
using System.Collections.Generic;

namespace Resignation_Service.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpGet]
        
        public IActionResult FetchAdminActionItems(string AdminEmpNo, string AdminRole)
        {

          if (!string.IsNullOrWhiteSpace(AdminEmpNo) && !string.IsNullOrWhiteSpace(AdminRole))
          {
             List<AdminDetailsViewModel> adminDetails = this._adminService.FetchDetailsForAdmin(AdminEmpNo, AdminRole);
             return adminDetails != null ? this.Ok(adminDetails) : this.NotFound();

          }
          return this.BadRequest("Check the Input values once");
        }
    }
}
