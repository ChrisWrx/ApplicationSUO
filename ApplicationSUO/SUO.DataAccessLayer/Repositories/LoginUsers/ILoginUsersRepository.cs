using SUO.BusinessObjects.LoginUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.LoginUsers
{
    public interface ILoginUsersRepository
    {
        Task<IEnumerable<GetLoginUsersResponse>> LoginUsers(string usuario, string password);
    }
}
