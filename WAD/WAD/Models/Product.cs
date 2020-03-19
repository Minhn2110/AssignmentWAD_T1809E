using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAD.Models
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public string Name { get; set; }
        public string Thumbnail { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}