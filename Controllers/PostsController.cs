using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services;
using Boards.API.Extensions;
using Boards.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Boards.API.Controllers
{
    [Route("/api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostResource>> ListAsync()
        {
            var posts = await _postService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(post);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(id, post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }
    }
}