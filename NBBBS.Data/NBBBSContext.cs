using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NBBBS.Data
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class NBBBSContext : DbContext
    {
        public NBBBSContext(DbContextOptions options) : base(options) { }

        public DbSet<SysUser> SysUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=localhost;userid=root;pwd=admin;port=3306;database=NBBBS;sslmode=none;");
            base.OnConfiguring(optionsBuilder);
        }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class NBBBSContextFactory
    {

        public static NBBBSContext Create(string connectionString)
        {
            var options = new DbContextOptionsBuilder<NBBBSContext>();
            options.UseSqlServer(connectionString);

            //Ensure database creation
            using (var context = new NBBBSContext(options.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                return context;
            }

        }
    }

    /// <summary>
    /// A basic class for an Employee
    /// </summary>
    public class SysUser
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string UserCode { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(20)]
        public string UserPassword { get; set; }

        [MaxLength(20)]
        public string UserEmail { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}