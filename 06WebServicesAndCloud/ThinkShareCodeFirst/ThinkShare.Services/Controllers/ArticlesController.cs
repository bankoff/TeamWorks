namespace ThinkShare.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Http.Cors;
    using ThinkShare.Data;
    using ThinkShare.Model;
    using ThinkShare.Services.Models;
    using System.Collections.Generic;
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticlesController : ApiController
    {
        private ThinkShareDbContext db = new ThinkShareDbContext();

        // GET: api/Articles
        public IQueryable<Object> GetArticles()
        {
            return db.Articles.Select(x => new ArticleModel
            {
                ArticleId = x.Id,
                ArticleHead = x.Heading,
                ArticleAuthor = x.Author,
                ArticleCategory = x.Category.PictureUrl
            });
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(new ArticleModel
            {
                ArticleId = article.Id,
                ArticleHead = article.Heading,
                ArticleAuthor = article.Author,
                ArticleText = article.Text,
                Date = article.Date,
                Category = article.Category.Id,
                Comments = article.Comments.Select(x => new CommentModel
                {
                    Author = x.Author,
                    Text = x.Text,
                    Date = x.Date
                }).ToList()
            });
        }
        
        // GET: api/Articles/Pesho
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticlesByAuthorName(string name)
        {
            var articles = db.Articles
                .Where(x => x.Author == name)
                .Select(x => new ArticleModel
                            {
                                ArticleId = x.Id,
                                ArticleHead = x.Heading,
                                ArticleAuthor = x.Author,
                                ArticleCategory = x.Category.PictureUrl
                            });

            if (articles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        // GET: api/Articles/Categories/3
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticlesByCategoryId(int id)
        {
            var articles = db.Articles
                .Where(x => x.Category.Id == id)
                .Select(x => new ArticleModel
                            {
                                ArticleId = x.Id,
                                ArticleHead = x.Heading,
                                ArticleAuthor = x.Author,
                                ArticleCategory = x.Category.PictureUrl
                            });

            if (articles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        // GET: api/Articles/Pesho
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticlesByTag(string tagName)
        {
            var articles = db.Articles
                .Where(x => x.Tags.Any(t => t.Word == tagName))
                .Select(x => new ArticleModel
                            {
                                ArticleId = x.Id,
                                ArticleHead = x.Heading,
                                ArticleAuthor = x.Author,
                                ArticleCategory = x.Category.PictureUrl
                            });

            if (articles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        // PUT: api/Articles/PutArticle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, ArticleModel article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArticle = this.db.Articles.FirstOrDefault(a => a.Id == id);

            if (existingArticle == null)
            {
                return BadRequest("Such article does not exists!");
            }
            else if (existingArticle.Password != article.Password)
            {
                return BadRequest("Invalid password!");
            }

            existingArticle.Heading = article.ArticleHead;
            existingArticle.Text = article.ArticleText;
            existingArticle.Date = DateTime.Now;
            existingArticle.Author = article.ArticleAuthor;
            existingArticle.CategoryId = article.Category;

            this.db.SaveChanges();

            return Ok();
            //return Ok(existingArticle);
        }

        // POST: api/Articles/PostArticle
        [ResponseType(typeof(ArticleModel))]
        public IHttpActionResult PostArticle(ArticleModel article)
        {
            if (article == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tags = GenerateTags(article.ArticleHead);
            var newArticle = new Article
            {
                Heading = article.ArticleHead,
                Author = article.ArticleAuthor,
                Text = article.ArticleText,
                Date = DateTime.Now,
                CategoryId = article.Category,
                Password = article.Password
            };

            foreach (var tag in tags)
            {
                newArticle.Tags.Add(tag);
            }

            db.Articles.Add(newArticle);
            db.SaveChanges();

            return Ok(newArticle);
        }



        // DELETE: api/Articles/5
        [ResponseType(typeof(PasswordModel))]
        public IHttpActionResult DeleteArticle(int id, PasswordModel password)
        {
            var existingArticle = this.db.Articles.FirstOrDefault(a => a.Id == id);

            if (existingArticle == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }
            else if (existingArticle.Password != password.Password)
            {
                return BadRequest("Invalid password!");
            }

            this.db.Articles.Remove(existingArticle);
            this.db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ICollection<Tag> GenerateTags(string articleHead)
        {
            var list = new List<Tag>();
            var tagsAsString = articleHead.Split(new char[] { ' ', '!', '.', ',', ';', '?', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var tag in tagsAsString)
            {
                var current = db.Tags.FirstOrDefault(t => t.Word == tag);
                if (current != null)
                {
                    list.Add(current);
                }
                else
                {
                    var newTag = new Tag()
                    {
                        Word = tag
                    };
                    list.Add(newTag);
                }
            }

            return list;
        }
    }
}