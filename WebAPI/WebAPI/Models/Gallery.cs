using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Gallery
    {
        public Guid Id { get; set; }              
        public string Title { get; set; }
        public virtual ICollection<Media> Media { get; set; }        
    }
}