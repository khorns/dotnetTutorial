using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Dtos.Article;

public class GetArticleDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string BodyText { get; set; }
    public ICollection<TagDto> Tags { get; set; }
}

public class TagDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}