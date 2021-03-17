using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {

        public void Configure(EntityTypeBuilder<Security> builder)
        {

        }
    }
}
