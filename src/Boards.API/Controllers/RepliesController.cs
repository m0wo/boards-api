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
    public class RepliesController : Controller
    {
        private readonly IReplyService _replyService;
        private readonly IMapper _mapper;

        public RepliesController(IReplyService replyService, IMapper mapper)
        {
            _replyService = replyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReplyResource>> ListAsync()
        {
            var replies = await _replyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Reply>, IEnumerable<ReplyResource>>(replies);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync(int id)
        {
            var result = await _replyService.FindAsync(id);
            var resource = _mapper.Map<Reply, ReplyResource>(result);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveReplyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var reply = _mapper.Map<SaveReplyResource, Reply>(resource);
            var result = await _replyService.SaveAsync(reply);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReplyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var reply = _mapper.Map<SaveReplyResource, Reply>(resource);
            var result = await _replyService.UpdateAsync(id, reply);

            if (!result.Success)
                return BadRequest(result.Message);

            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _replyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var replyResource = _mapper.Map<Reply, ReplyResource>(result.Reply);
            return Ok(replyResource);
        }
    }
}