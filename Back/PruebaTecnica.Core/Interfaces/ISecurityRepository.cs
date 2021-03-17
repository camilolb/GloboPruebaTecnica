using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> Get(string userName, string password);
    }
}
