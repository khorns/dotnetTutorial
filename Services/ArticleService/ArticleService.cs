using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tutorial.Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ArticleService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public async Task<ServiceResponse<List<GetArticleDto>>> GetAllArticle()
        {
            var serviceResponse = new ServiceResponse<List<GetArticleDto>>();
            var articles = await _context.Articles.Include("Tags").ToListAsync();

            // This method is performing manual mapping
            // var articles = await _context.Articles.Include("Tags")
            // .Select(a => new GetArticleDto
            // {
            //     Id = a.Id,
            //     Title = a.Title,
            //     Tags = (ICollection<TagDto>)a.Tags.Select(t => new TagDto
            //     {
            //         Id = t.Id,
            //         Name = t.Name,
            //         Description = t.Description
            //     })
            // })
            // .ToListAsync();

            serviceResponse.Data = articles.Select(x => _mapper.Map<GetArticleDto>(x)).ToList();
            return serviceResponse;
        }
    }
}