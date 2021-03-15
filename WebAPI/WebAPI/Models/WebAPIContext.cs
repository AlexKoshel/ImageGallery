using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class WebAPIContext: DbContext
    {
       
        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Media> Media { get; set; }
       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("galleries");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ImageFile)
                    .IsRequired()
                    .HasColumnName("image");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("media");

                entity.HasIndex(e => e.ImageId, "media_imageid_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Discription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("discription");

                entity.Property(e => e.GalleryId).HasColumnName("galleryid");

                entity.Property(e => e.ImageId).HasColumnName("imageid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("name");

                entity.HasOne(d => d.Gallery)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.GalleryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("media_galleryid_fkey");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.Media)
                    .HasForeignKey<Media>(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("media_imageid_fkey");
            });                            
        }        
    }
}