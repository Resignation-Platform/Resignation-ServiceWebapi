using Resignation_Service.Models;
using System.Collections.Generic;

namespace Resignation_Service.Repository
{
    public interface IAdminRepository
    {
        public List<AdminDetails> FetchDetailsForAdmin(string AdminEmpNo, string AdminRole);
    }
}
