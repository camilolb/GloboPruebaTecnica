using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly DatabaseContext _dbContext;

        public SecurityRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Security> Get(string userName, string password)
        {
            var response = await _dbContext.Security.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return response;
        }
    }
}
