using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<AddEmployee> AllEmployees { get; set; }
    }
}
