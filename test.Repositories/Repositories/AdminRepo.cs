using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DbEntities.Models;
using test.DbEntities.ViewModels;
using test.Repositories.IRepositories;

namespace test.Repositories.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly DbHallodocContext _context;
        public AdminRepo(DbHallodocContext context) {
            _context = context;
        }

        public DashboardViewModel GetUserRepo()
        {
            var user = _context.Users.ToList();
            DashboardViewModel dashboard = new DashboardViewModel()
            {
                users = user,
            };
            return dashboard;
        }
    }
}
