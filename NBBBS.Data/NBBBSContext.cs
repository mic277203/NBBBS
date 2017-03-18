using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBBBS.Data
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class NBBBSContext : DbContext
    {
        public NBBBSContext(DbContextOptions options) : base(options) { }

        public IConfigurationRoot Configuration { get; }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardCategory> CardCategory { get; set; }
        public DbSet<Comment> Comment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=D:\\developer\\sqlite\\DB\\nbbbs.db;");
            base.OnConfiguring(optionsBuilder);
        }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public class NBBBSContextFactory
    {
        public static void Create(string conStr)
        {
            var build = new DbContextOptionsBuilder<NBBBSContext>();
            build.UseSqlite(conStr);

            using (NBBBSContext _context = new NBBBSContext(build.Options))
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
            }
        }

    }
    /// <summary>
    /// 评论
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
        public int SysUserId { get; set; }
        [ForeignKey("SysUserId")]
        public SysUser SysUser { get; set; }

        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }
    }
    /// <summary>
    /// 帖子类型
    /// </summary>
    [Table("CardCategory")]
    public class CardCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    /// 帖子
    /// </summary>
    public class Card
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Content { get; set; }

        public int CardCategoryId { get; set; }
        [ForeignKey("CardCategoryId")]
        public CardCategory CardCategory { get; set; }
        public int SysUserId { get; set; }
        [ForeignKey("SysUserId")]
        public SysUser SysUser { get; set; }

        [MaxLength(20)]
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
    /// <summary>
    /// 人员表
    /// </summary>
    public class SysUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(20)]
        public string UserPassword { get; set; }

        [MaxLength(20)]
        public string UserEmail { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}