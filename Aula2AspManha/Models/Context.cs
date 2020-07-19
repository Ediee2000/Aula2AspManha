using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2AspManha.Models
{

    public class Context : DbContext
    {
        public DbSet<Address> Enderecos { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
