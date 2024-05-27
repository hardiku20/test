using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DbEntities.ViewModels;
using test.Repositories.IRepositories;
using test.Services.IServices;


namespace test.Services.Services
{
    public class AdminServices : IAdminServices
    {
        public readonly IAdminRepo _adminRepo;
        public AdminServices(IAdminRepo adminRepo)
        {
            
            _adminRepo = adminRepo;
        }

        public DashboardViewModel GetUserTable()
        {
            var model = _adminRepo.GetUserRepo();
            return model;
        }
    }
}
