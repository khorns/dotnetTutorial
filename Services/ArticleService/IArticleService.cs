using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Services.ArticleService
{
    public interface IArticleService
    {
        Task<ServiceResponse<List<GetArticleDto>>> GetAllArticle();
    }
}