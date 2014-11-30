namespace ThinkShare.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleModel
    {
        public int? ArticleId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string ArticleHead { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ArticleAuthor { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(15000)]
        public string ArticleText { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Password { get; set; }

        public int Category { get; set; }

        public string ArticleCategory { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}