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

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }

        public DbSet<QuestionComment> QuestionComments { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userInfoCfg = modelBuilder.Entity<UserInfo>();
            userInfoCfg.Property(p => p.UserName).HasMaxLength(64);
            userInfoCfg.Property(p => p.LoginName).HasMaxLength(64);
            userInfoCfg.Property(p => p.LoginPassword).HasMaxLength(128);
            userInfoCfg.Property(p => p.Phone).HasMaxLength(16);
            userInfoCfg.Property(p => p.Introduction).HasMaxLength(512);
            userInfoCfg.Property(p => p.Email).HasMaxLength(64);
            // userInfoCfg.Property(p => p.HeadPortrait).HasMaxLength(1024);
            userInfoCfg.Property(p => p.CreateTime).HasColumnType("datetime2");


            var articleCfg = modelBuilder.Entity<Article>();
            articleCfg.Property(p => p.Title).HasMaxLength(128);
            articleCfg.Property(p => p.Content).HasMaxLength(2048);
            articleCfg.Property(p => p.Tag).HasMaxLength(128);
            articleCfg.Property(p => p.CreateTime).HasColumnType("datetime2");
            articleCfg.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict); ;
            articleCfg.HasMany(p => p.CollectionArticles).WithOne().HasForeignKey(p => p.ArticleId).OnDelete(DeleteBehavior.Cascade);
            articleCfg.HasMany(p => p.ArticleComments).WithOne(p => p.Article).HasForeignKey(p => p.ArticleId).OnDelete(DeleteBehavior.Cascade);

            var articleCommentCfg = modelBuilder.Entity<ArticleComment>();
            articleCommentCfg.Property(p => p.Content).HasMaxLength(512);
            articleCommentCfg.Property(p => p.CreateTime).HasColumnType("datetime2");
            articleCommentCfg.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict);

            var questionCfg = modelBuilder.Entity<Question>();
            questionCfg.Property(p => p.Title).HasMaxLength(128);
            questionCfg.Property(p => p.Content).HasMaxLength(2048);
            questionCfg.Property(p => p.Tag).HasMaxLength(128);
            questionCfg.Property(p => p.CreateTime).HasColumnType("datetime2");
            questionCfg.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict);
            questionCfg.HasMany(p => p.QuestionComments).WithOne(p => p.Question).HasForeignKey(p => p.QuestionId).OnDelete(DeleteBehavior.Cascade);

            var questionCommentCfg = modelBuilder.Entity<QuestionComment>();
            questionCommentCfg.Property(p => p.Content).HasMaxLength(512);
            questionCommentCfg.Property(p => p.CreateTime).HasColumnType("datetime2");
            questionCommentCfg.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict);


            var advertisementCfg = modelBuilder.Entity<Advertisement>();
            advertisementCfg.Property(p => p.ImgUrl).HasMaxLength(1024);
            advertisementCfg.Property(p => p.Url).HasMaxLength(128);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MySwiftCodeBBS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }

    }
