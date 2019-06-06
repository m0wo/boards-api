using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services;
using Boards.API.Extensions;
using Boards.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boards.API.Controllers
{
    [Route("/api/[controller]")]
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly IMapper _mapper;

        public BoardsController(IBoardService boardService, IMapper mapper)
        {
            _boardService = boardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BoardResource>> ListAsync()
        {
            var user = HttpContext.User.Identity;
            var boards = await _boardService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Board>, IEnumerable<BoardResource>>(boards);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync(int id)
        {
            var result = await _boardService.FindAsync(id);
            var resource = _mapper.Map<Board, BoardResource>(result);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBoardResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var board = _mapper.Map<SaveBoardResource, Board>(resource);
            var result = await _boardService.SaveAsync(board);

            if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBoardResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var board = _mapper.Map<SaveBoardResource, Board>(resource);
            var result = await _boardService.UpdateAsync(id, board);

            if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _boardService.DeleteAsync(id);

             if (!result.Success)
                return BadRequest(result.Message);

            var boardResource = _mapper.Map<Board, BoardResource>(result.Board);
            return Ok(boardResource);
        }
    }
}
