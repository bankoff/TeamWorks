namespace ThinkShare.Data
{
    using ThinkShare.Data.Repositories;
    using ThinkShare.Model;

    public interface IThinkShareData
    {
        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        void SaveChanges();
    }
}
