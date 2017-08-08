using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaioCulturalNew.Services
{
    public interface IAuthService
    {
        void SaveCredentials(string UserName, string Password);
        string UserName { get; }
        string Password { get; }
    }
}
