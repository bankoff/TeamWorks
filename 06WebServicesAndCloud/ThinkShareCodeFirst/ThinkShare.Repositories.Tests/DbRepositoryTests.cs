namespace ThinkShare.Repositories.Tests
{
    using System;
    using System.Data.Entity;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ThinkShare.Data;
    using ThinkShare.Data.Repositories;
    using ThinkShare.Model;

    [TestClass]
    public class DbRepositoryTests
    {
        private static Random rand = new Random();

        private static TransactionScope tranScope;

        private DbContext dbContext;

        public DbRepositoryTests()
        {
            this.dbContext = new ThinkShareDbContext();
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void Add_ValidCategory_ShouldCategoryIdBiggerThanNull()
        {
            var category = new Category
            {
                PictureUrl = "http://www.test.com/",
                Title = "Testss"
            };
            this.dbContext.Set<Category>().Add(category);
            this.dbContext.SaveChanges();
            Assert.IsTrue(category.Id > 0);
        }

        [TestMethod]
        public void Add_ValidArticle_ShouldArticleIdBiggerThanNull()
        {
            var article = new Article
            {
                Author = "Pesho",
                Category = new Category
                {
                    PictureUrl = "http://www.test.com/",
                    Title = "Testss"
                },
                Password = "TestPass",
                Date = DateTime.Now
            };

            this.dbContext.Set<Article>().Add(article);
            this.dbContext.SaveChanges();
            Assert.IsTrue(article.Id > 0);
        }

        [TestMethod]
        public void Add_ValidComment_ShouldCommentIdBiggerThanNull()
        {
            var comment = new Comment
            {
                PictureUrl = "http://www.test.com/",
                Text = "Testss",
                Date = DateTime.Now
            };
            this.dbContext.Set<Comment>().Add(comment);
            this.dbContext.SaveChanges();
            Assert.IsTrue(comment.Id > 0);
        }

        [TestMethod]
        public void Add_WhenCategoryIsValid_ShouldReturnNotZeroId()
        {
            int catId;
            using (TransactionScope scope = new TransactionScope())
            {
                var category = new Category
                {
                    PictureUrl = "http://www.test.com/",
                    Title = "Testss"
                };
                this.dbContext.Set<Category>().Add(category);
                this.dbContext.SaveChanges();
                scope.Complete();
                catId = category.Id;
            }

            Assert.IsTrue(catId != 0);

            var catEntity = this.dbContext.Set<Category>().Find(catId);
            Assert.IsNotNull(catEntity);
        }

        [TestMethod]
        public void Add_WhenArticleIsValid_ShouldReturnNotZeroId()
        {
            int articleId;
            using (TransactionScope scope = new TransactionScope())
            {
                var article = new Article
                {
                    Author = "Pesho",
                    Category = new Category
                    {
                        PictureUrl = "http://www.test.com/",
                        Title = "Testss"
                    },
                    Password = "TestPass",
                    Date = DateTime.Now
                };

                this.dbContext.Set<Article>().Add(article);
                this.dbContext.SaveChanges();
                scope.Complete();
                articleId = article.Id;
            }

            Assert.IsTrue(articleId != 0);

            var articleEntity = this.dbContext.Set<Article>().Find(articleId);
            Assert.IsNotNull(articleEntity);
        }

        [TestMethod]
        public void Add_WhenCommentIsValid_ShouldReturnNotZeroId()
        {
            int commentId;
            using (TransactionScope scope = new TransactionScope())
            {
                var comment = new Comment
                {
                    PictureUrl = "http://www.test.com/",
                    Text = "Testss",
                    Date = DateTime.Now
                };
                this.dbContext.Set<Comment>().Add(comment);
                this.dbContext.SaveChanges();
                scope.Complete();
                commentId = comment.Id;
            }

            Assert.IsTrue(commentId != 0);

            var commentEntity = this.dbContext.Set<Comment>().Find(commentId);
            Assert.IsNotNull(commentEntity);
        }

        ////[TestMethod]
        ////public void Add_WhenNameIsValid_ShouldAddCategoryToDatabase()
        ////{
        ////    using (TransactionScope scope = new TransactionScope())
        ////    {
        ////    var categoryName = "Test category";
        ////    var category = new Category
        ////    {
        ////        PictureUrl = "http://www.test.com/",
        ////        Title = "Test"
        ////    };

        ////        var createdCategory = this.categoriesRepository.Add(category);
        ////    var foundCategory = this.dbContext.Set<Category>().Find(createdCategory.Id);
        ////    Assert.IsNotNull(foundCategory);
        ////    Assert.AreEqual(categoryName, foundCategory.Name);
        ////    }
        ////}

        ////[TestMethod]
        ////public void Add_WhenNameIsValid_ShouldReturnNotZeroId()
        ////{
        ////    var category = new Category()
        ////    {
        ////        PictureUrl = "http://www.test.com/",
        ////        Title = "Test",
        ////        Id = Category.Id
        ////    };

        ////    var createdCategory = this.dbContext.Set<Category>().Add(category);
        ////    var createdCategoryId = createdCategory.
        ////    Assert.IsTrue(createdCategory.Id != 0);
        ////}
    }
}
