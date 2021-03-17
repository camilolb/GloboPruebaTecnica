using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> Get(string userName, string passWord);
    }
}
