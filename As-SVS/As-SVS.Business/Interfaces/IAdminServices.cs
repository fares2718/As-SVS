using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IAdminServices : IBaseServices<Admin>
    {
        public Task AssignRoleAsync<T>(T entity);
        public Task DeactivatePersonAsync(int Id);
    }
}
