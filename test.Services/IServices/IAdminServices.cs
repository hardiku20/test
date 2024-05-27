using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DbEntities.ViewModels;

namespace test.Services.IServices
{
    public interface IAdminServices
    {
        DashboardViewModel GetUserTable();
    }
}
