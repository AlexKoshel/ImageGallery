using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Image
    {
       
        public Guid Id { get; set; }       
        public byte[] ImageFile { get; set; }
        public virtual Media Media { get; set; }
    }
}