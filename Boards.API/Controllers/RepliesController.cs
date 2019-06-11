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
    public class RepliesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReplyService _replyService;
        private readonly IMapper _mapper;

        public RepliesController(IUserService userService, IReplyService replyService, IMapper mapper)
        {
            _userService = userService;
            _replyService = replyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/posts/{postId:int}/replies")]
        public async Task<IEnumerable<ReplyResource>> GetRepliesForPost([FromRoute] int postId)
        {
            var replies = await _replyService.ListAsync(postId);
            var resources = _mapper.Map<IEnumerable<Reply>, IEnumerable<ReplyResource>>(replies);

            return resources;
        }

        [HttpGet]
        [Route("/api/replies/{replyId:int}")]
        public async Task<IActionResult> FindAsync([FromRoute] int replyId)
        {
            var result = await _replyService.FindAsync(replyId);
            var resource = _mapper.Map<Reply, ReplyResource>(result);
            return Ok(resource);
        }

        [HttpPost]
        [Route("/api/posts/{postId:int}/replies")]
        public async Task<IActionResult> PostAsync([FromRoute] int postId, [FromBody] SaveReplyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var reply = _mapper.Map<SaveReplyResource, Reply>(resource);
            var result = await _replyService.SaveAsync(postId, reply, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));
            
            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }

        [HttpPut("{replyId}")]
        [Route("/api/replies/{replyId:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int replyId, [FromBody] SaveReplyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var reply = _mapper.Map<SaveReplyResource, Reply>(resource);
            var result = await _replyService.UpdateAsync(replyId, reply, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }

        [HttpDelete("{replyId}")]
        [Route("/api/replies/{replyId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int replyId)
        {
            var email = HttpContext.User.Identity.Name;
            var user = await _userService.FindByEmailAsync(email);

            var result = await _replyService.DeleteAsync(replyId, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));
            
            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }
    }
}