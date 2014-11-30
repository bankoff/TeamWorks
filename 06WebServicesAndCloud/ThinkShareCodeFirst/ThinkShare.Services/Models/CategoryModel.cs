namespace ThinkShare.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryModel
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string PictureUrl { get; set; }

    }
}