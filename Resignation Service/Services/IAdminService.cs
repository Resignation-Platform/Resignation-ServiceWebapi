using Resignation_Service.ViewModels;
using System.Collections.Generic;

namespace Resignation_Service.Services
{
    public interface IAdminService
    {
        public List<AdminDetailsViewModel> FetchDetailsForAdmin(string AdminEmpNo, string AdminRole);
    }
}
