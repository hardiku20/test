using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DbEntities.ViewModels;

namespace test.Repositories.IRepositories
{
    public interface IAdminRepo
    {
        DashboardViewModel GetUserRepo();
    }
}
