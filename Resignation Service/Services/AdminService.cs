using AutoMapper;
using System;
using Resignation_Service.Repository;
using Resignation_Service.ViewModels;
using System.Collections.Generic;
using Resignation_Service.Models;

namespace Resignation_Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mappeer;
        public AdminService(IAdminRepository adminrepository, IMapper mapper)
        {
                this._adminRepository = adminrepository;
                this._mappeer = mapper; 
        }
        public List<AdminDetailsViewModel> FetchDetailsForAdmin(string AdminEmpNo, string AdminRole)
        {
             List<AdminDetails> adminDetails =this._adminRepository.FetchDetailsForAdmin(AdminEmpNo, AdminRole); 
            return this._mappeer.Map<List<AdminDetailsViewModel>>(adminDetails);
            
        }
    }
}
