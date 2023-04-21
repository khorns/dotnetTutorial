using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}