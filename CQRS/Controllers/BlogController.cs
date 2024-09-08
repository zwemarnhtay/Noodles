using CQRS.Models;
using CQRS.Services.Blog.Commands;
using CQRS.Services.Blog.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogController : ControllerBase
  {
    private readonly CreateBlog _createBlog;
    private readonly UpdateBlog _updateBlog;
    private readonly DeleteBlog _deleteBlog;
    private readonly GetBlog _getBlog;
    private readonly GetBlogList _getBlogList;

    public BlogController(
      CreateBlog createBlog,
      UpdateBlog updateBLog,
      DeleteBlog deleteBlog,
      GetBlog getBlog,
      GetBlogList getBlogList
      )
    {
      _createBlog = createBlog;
      _updateBlog = updateBLog;
      _deleteBlog = deleteBlog;
      _getBlog = getBlog;
      _getBlogList = getBlogList;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(BlogModel blog)
    {
      try
      {
        var result = await _createBlog.Run(blog);

        var msg = result > 0 ? "created success" : "failed";
        return Ok(msg);
      }
      catch (Exception)
      {

        throw;
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlogAsunc(int id, BlogModel blog)
    {
      var result = await _updateBlog.Run(id, blog);
      var msg = result > 0 ? "updated success" : "failed";
      return Ok(msg);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogAsync(int id)
    {
      var result = await _deleteBlog.Run(id);
      var msg = result > 0 ? "deleted success" : "failed";
      return Ok(msg);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogAsync(int id)
    {
      var result = await _getBlog.Run(id);
      if (result is null) return NotFound("no data found");
      return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogListAsync()
    {
      var result = await _getBlogList.Run();
      if (result.Count < 1) return NotFound("no data found");
      return Ok(result);
    }
  }
}
