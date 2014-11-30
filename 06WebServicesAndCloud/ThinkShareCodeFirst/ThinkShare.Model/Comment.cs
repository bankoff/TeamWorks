namespace ThinkShare.Model
{
    using System;
    using System.Collections.Generic;

    public class Comment
    {
        private ICollection<Comment> subComments;

        public Comment()
        {
            this.subComments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string PictureUrl { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public int? ArticleId { get; set; }

        public virtual ICollection<Comment> SubComments
        {
            get
            {
                return this.subComments;
            }

            set
            {
                this.subComments = value;
            }
        }
    }
}
