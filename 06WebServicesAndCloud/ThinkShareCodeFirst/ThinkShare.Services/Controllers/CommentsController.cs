namespace ThinkShare.Services.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using ThinkShare.Data;
    using ThinkShare.Model;
    using ThinkShare.Services.Models;

    public class CommentsController : ApiController
    {
        private ThinkShareDbContext db = new ThinkShareDbContext();

        // GET: api/Comments/GetComments
        public IQueryable<Object> GetComments()
        {
            return db.Comments.Select(x => new CommentModel
            {
                ArticleId = x.ArticleId,
                Author = x.Author,
                Text = x.Text,
                Date = x.Date
            });
        }

        // GET: api/Comments/GetComment/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(new CommentModel
            {
                ArticleId = comment.ArticleId,
                Author = comment.Author,
                Text = comment.Text,
                Date = comment.Date
            });
        }

        // PUT: api/Comments/PutComment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comments/PostComment
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(CommentModel comment)
        {
            if (comment == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newComment = new Comment
            {
                Date = DateTime.Now,
                Author = comment.Author,
                ArticleId = comment.ArticleId,
                Text = comment.Text
            };

            db.Comments.Add(newComment);
            db.SaveChanges();

            return Ok(newComment);
        }

        // DELETE: api/Comments/DeleteComment/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.Id == id) > 0;
        }
    }
}