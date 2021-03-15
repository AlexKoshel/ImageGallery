using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Media
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Discription { get; set; }

        public Guid ImageId { get; set; }

        public Guid GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }
        public virtual Image Image { get; set; }
    }
}