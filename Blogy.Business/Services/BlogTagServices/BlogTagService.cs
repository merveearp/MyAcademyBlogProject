using AutoMapper;
using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Business.Services.BlogTagServices;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.DataAccess.Repositories.TagRepositories;

public class BlogTagService : IBlogTagService
{
    private readonly IBlogTagRepository _blogTagRepository;

    private readonly IMapper _mapper;

    public BlogTagService(IBlogTagRepository blogTagRepository, IMapper mapper)
    {
        _blogTagRepository = blogTagRepository;
        _mapper = mapper;
      
    }

    public async Task AddTagToBlogAsync(int blogId, int tagId)
    {
        await _blogTagRepository.AddTagToBlogAsync(blogId, tagId);

    }

    public async Task<List<ResultBlogTagDto>> GetAllAsync()
    {
        var blogTags = await _blogTagRepository.GetAllAsync();
        return _mapper.Map<List<ResultBlogTagDto>>(blogTags);
    }

    public async Task<List<ResultTagDto>> GetTagsByBlogIdAsync(int blogId)
    {
        var tags = await _blogTagRepository.GetTagsByBlogIdAsync(blogId);
        return _mapper.Map<List<ResultTagDto>>(tags);
    }

    public async Task RemoveTagFromBlogAsync(int blogId, int tagId)
    {
        await _blogTagRepository.RemoveTagFromBlogAsync(blogId, tagId);

    }
}
