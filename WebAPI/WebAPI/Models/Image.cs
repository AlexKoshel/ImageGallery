using System;

namespace WebAPI.Models
{
    public class Image
    {
       
        public Guid Id { get; set; }       
        public byte[] ImageData { get; set; }
        public virtual Media Media { get; set; }
    }
}