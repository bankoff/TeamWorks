﻿namespace ThinkShare.Model
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }

            set
            {
                this.articles = value;
            }
        }
    }
}
