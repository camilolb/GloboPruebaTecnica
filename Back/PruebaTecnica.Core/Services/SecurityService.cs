using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
namespace PruebaTecnica.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        

        public SecurityService(ISecurityRepository userRepository)
        {
            _securityRepository = userRepository;
        }


        public async Task<Security> Get(string userName, string password)
        {
            return await _securityRepository.Get(userName, password);
        }


    }
}
