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
    
    public class PostsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBoardService _boardService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IBoardService boardService, IUserService userService, IPostService postService, IMapper mapper)
        {
            _boardService = boardService;
            _userService = userService;
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/boards/{boardId:int}/posts")]
        public async Task<IEnumerable<PostResource>> getPostsForBoard([FromRoute] int boardId)
        {
            var posts = await _postService.ListAsync(boardId);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);

            return resources;
        }

        [HttpGet]
        [Route("/api/posts/{postId:int}")]
        public async Task<IActionResult> getBoardPostById([FromRoute] int postId)
        {
            var result = await _postService.FindAsync(postId);
            var resource = _mapper.Map<Post, PostResource>(result);
            return Ok(resource);
        }

        [HttpPost]
        [Route("/api/boards/{boardId:int}/posts")]
        public async Task<IActionResult> PostAsync([FromRoute] int boardId, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(boardId, post, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));
            
            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }

        [HttpPut]
        [Route("/api/posts/{postId:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int boardId, [FromRoute] int postId, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(postId, post, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }

        [HttpDelete]
        [Route("/api/posts/{postId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int boardId, [FromRoute] int postId)
        {
            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var result = await _postService.DeleteAsync(postId, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));
            
            var postResource = _mapper.Map<Post, PostResource>(result.Post);
            return Ok(postResource);
        }
    }
}