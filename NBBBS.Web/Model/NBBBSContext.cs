using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System.ComponentModel.DataAnnotations;

namespace NBBBS.Web.Model
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class NBBBSContext : DbContext
    {
        public NBBBSContext(DbContextOptions<NBBBSContext> options)
        : base(options)
        { }

        public DbSet<SysUser> SysUsers { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class NBBBSContextFactory
    {
        public static NBBBSContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NBBBSContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new NBBBSContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
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