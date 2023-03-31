using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstWebApiExample.Models;

namespace FirstWebApiExample.Data
{
    public class FirstWebApiExampleContext : DbContext
    {
        public FirstWebApiExampleContext (DbContextOptions<FirstWebApiExampleContext> options)
            : base(options)
        {
        }

        public DbSet<FirstWebApiExample.Models.Person> Person { get; set; } = default!;
    }
}
