using SUO.BusinessObjects.LoginUsers;
using SUO.DataAccessLayer.Repositories.LoginUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.LoginUsers
{    
    public class LoginUserAction
    {
        private readonly ILoginUsersRepository _loginUserAction;

        public  LoginUserAction(ILoginUsersRepository loginUserAction)
        {
            _loginUserAction = loginUserAction;
        }
        public IEnumerable<GetLoginUsersResponse> LoginUsersByRutPass(string usuario, string password) {

            var loginUsuario = _loginUserAction.LoginUsers(usuario, password);

            return (loginUsuario.Result);

        }
    }
}
