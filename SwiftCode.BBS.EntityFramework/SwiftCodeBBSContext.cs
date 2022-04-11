using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.EntityFramework
{
   public class SwiftCodeBBSContext :DbContext
    {
        public SwiftCodeBBSContext()
        {

        }
        public SwiftCodeBBSContext(DbContextOptions<SwiftCodeBBSContext> options )
            :base(options)
        {


        }

        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var articleCfg = modelBuilder.Entity<Article>();
            articleCfg.Property(p => p.Title).HasMaxLength(128);
             articleCfg.Property(p => p.Submitter).HasMaxLength(64);
            articleCfg.Property(p => p.Category).HasMaxLength(256);
            articleCfg.Property(p => p.Content).HasMaxLength(2048);
            articleCfg.Property(p => p.Mark).HasMaxLength(128);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MySwiftCodeBBS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }

    }
