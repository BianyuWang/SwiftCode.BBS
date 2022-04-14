using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories;
using SwiftCode.BBS.Repositories.Base;
using SwiftCode.BBS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwiftCode.BBS.Tests
{
  public  class ArticleServicesShould
    {
        private  DbContextOptions<SwiftCodeBBSContext> _dbContext { get; set; }
        //add dbcontext in memory
        public ArticleServicesShould()
        {
            _dbContext = new DbContextOptionsBuilder<SwiftCodeBBSContext>()
                 .UseInMemoryDatabase(databaseName: "in-memory")
                 .Options;
        }
        [Fact]
        public async Task AddNewItemAsIncompleteForAdditonalAsync()
        {
            using (var context = new SwiftCodeBBSContext(_dbContext))
            {
                var repository = new BaseRepository<Article>(context);

                var articleRepository = new ArticalRepository(context);

                ArticleServices articleServices = new ArticleServices(repository, articleRepository);

                // create a fake article 
                var fakeArticle = new Article
                {
                    Id = 1,
                    Tag = "Test",
                    Title = "Test",
                    Content = "Test",
                    CreateUser = new UserInfo() { },
                    CreateUserId = 1
                 };
                

                await articleServices.AdditionalItemAsync(fakeArticle, true, 3);

                var itemsInDatabase = await context.Articles.CountAsync();
                Assert.Equal(1, itemsInDatabase);

                var item = await context.Articles.FirstAsync();
                Assert.Equal("Test", item.Title);

                var difference = DateTime.Now.AddDays(-3) - item.CreateTime;
                Assert.True(difference < TimeSpan.FromSeconds(1));
            }


        }


    }
}
