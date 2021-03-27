using System;

namespace WebAPI.Models
{
    public class Media
    {       
        public Guid Id { get; set; }       
        public string Name { get; set; }      
        public string Discription { get; set; }
        public byte[] ImageData { get; set; }
        public Guid GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }        
    }
}