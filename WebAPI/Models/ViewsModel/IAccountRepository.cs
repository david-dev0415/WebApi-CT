using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IAccountRepository
    {
        Task Add(AccountViewModel accountView);
        Task Update(AccountViewModel accountView);
        Task Delete(string id);
        Task<AccountViewModel> GetAccount(string id);
        Task<IEnumerable<AccountViewModel>> GetAccounts();
    }
}
