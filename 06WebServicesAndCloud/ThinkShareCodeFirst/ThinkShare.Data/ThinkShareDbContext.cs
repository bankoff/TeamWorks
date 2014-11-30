namespace ThinkShare.Data
{
    using System.Data.Entity;

    using ThinkShare.Data.Migrations;
    using ThinkShare.Model;

    public class ThinkShareDbContext : DbContext, IThinkShareDbContext
    {
        public ThinkShareDbContext()
            : base("ThinkShareConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ThinkShareDbContext, Configuration>());
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
