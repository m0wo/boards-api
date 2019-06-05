using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BoardService(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
           _boardRepository = boardRepository;
           _unitOfWork = unitOfWork; 
        }

        public async Task<BoardResponse> DeleteAsync(int id)
        {
            var existingBoard = await _boardRepository.FindByIdAsync(id);
            if (existingBoard == null)
                return new BoardResponse("Board not found");

            try
            {
                _boardRepository.Remove(existingBoard);                
                await _unitOfWork.CompleteAsync();

                return new BoardResponse(existingBoard);
            }
            catch (Exception ex)
            {
               return new BoardResponse($"An error occurred when deleting the board: {ex.Message}"); 
            }
        }

        public async Task<IEnumerable<Board>> ListAsync()
        {
            return await _boardRepository.ListAsync();
        }

        public async Task<BoardResponse> SaveAsync(Board board)
        {
            try
            {
                await _boardRepository.AddAsync(board);
                await _unitOfWork.CompleteAsync();

                return new BoardResponse(board);
            }
            catch (Exception ex)
            {
                return new BoardResponse($"An error occurred when saving the board: {ex.Message}");
            }
        }

        public async Task<BoardResponse> UpdateAsync(int id, Board board)
        {
            var existingBoard = await _boardRepository.FindByIdAsync(id);
            if (existingBoard == null)
                return new BoardResponse("Board not found.");
            
            existingBoard.Name = board.Name;
            existingBoard.Description = board.Description;
            
            try
            {
                _boardRepository.Update(existingBoard);
                await _unitOfWork.CompleteAsync();

                return new BoardResponse(existingBoard);
            }
            catch (Exception ex)
            {
                //logging should go here
                return new BoardResponse($"An error occurred when updating the board: {ex.Message}");
            }
        }
    }
}