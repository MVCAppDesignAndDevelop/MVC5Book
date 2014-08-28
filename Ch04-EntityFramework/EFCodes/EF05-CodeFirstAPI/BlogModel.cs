using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF05_CodeFirstAPI
{
    public class BlogModel : DbContext
    {
        public BlogModel()
            : base("name=BlogDb")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogInfo> BlogInfo { get; set; }
        public virtual DbSet<BlogArticle> BlogArticles { get; set; }
        public virtual DbSet<BlogFile> BlogFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var blogTable = modelBuilder.Entity<Blog>().ToTable("Blogs");
            var blogArticleTable = modelBuilder.Entity<BlogArticle>().ToTable("BlogArticles");
            var blogInfo = modelBuilder.Entity<BlogInfo>().ToTable("BlogInfo");
            var blogFile = modelBuilder.Entity<BlogFile>().ToTable("BlogFiles");

            // 移除表格複數化規則
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            blogTable
                .Property(c => c.Id)
                .IsRequired()
                .HasColumnType("bigint");

            blogArticleTable
                .Property(c => c.BlogId)
                .IsRequired()
                .HasColumnType("bigint");
            blogArticleTable
                .Property(c => c.Subject)
                .HasMaxLength(250)
                .IsRequired();
            blogArticleTable
                .Property(c => c.Body)
                .HasMaxLength(4000)
                .IsRequired();

            // relationship configuration.
            // define primary key.
            blogTable.HasKey(c => c.Id);

            // 1-to-0 relationship
            blogTable
                .HasRequired(c => c.Info)
                .WithRequiredPrincipal(c => c.Blog)
                .Map(m =>
                {
                    m.MapKey("BlogId");
                });

            // 1-to-1 relationship
            //blogInfo
            //    .HasKey(c => c.Id)
            //    .HasRequired(c => c.Blog)
            //    .WithRequiredPrincipal(c => c.Info);

            // 1-to-n relationship.

            blogTable.HasMany(c => c.Articles).WithRequired(c => c.Blog);

            // m-to-n relationship.
            blogArticleTable
                .HasKey(c => c.Id)
                .HasMany(c => c.Files)
                .WithMany(c => c.Articles)
                .Map(m =>
                {
                    m.ToTable("BlogArticleFiles");
                    m.MapLeftKey("BlogArticleId");
                    m.MapRightKey("BlogFileId");
                });

            // stored procedure mapping discussed at 4.6.6 section.
            // blogTable.MapToStoredProcedures();
            /*
            blogTable.MapToStoredProcedures(
                m =>
                {
                    m.Insert(i =>
                        {                            
                            i.HasName("blog_add")
                                .Parameter(c => c.OwnerId, "ownerId")
                                .Parameter(c => c.Caption, "caption")
                                .Result(c => c.Id, "blogId");
                        });
                    m.Update(u =>
                        {
                            u.HasName("blog_update")
                                .Parameter(c => c.Id, "id")
                                .Parameter(c => c.OwnerId, "ownerId")
                                .Parameter(c => c.Caption, "caption");
                        });
                    m.Delete(d =>
                        {
                            d.HasName("blog_delete")
                                .Parameter(c => c.Id, "id");
                        });
                });
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}
