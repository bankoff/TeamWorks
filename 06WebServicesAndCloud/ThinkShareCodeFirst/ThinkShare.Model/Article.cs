namespace ThinkShare.Model
{
    using System;
    using System.Collections.Generic;

    public class Article
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Article()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Heading { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }
    }
}
