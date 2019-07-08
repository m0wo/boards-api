using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;
using Boards.API.Extensions;

namespace Boards.API.Services
{
    public class BoardService : IBoardService
    {
        private readonly IRepository<Board> _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BoardService(IRepository<Board> boardRepository, IUnitOfWork unitOfWork)
        {
           _boardRepository = boardRepository;
           _unitOfWork = unitOfWork; 
        }

        public async Task<BoardResponse> DeleteAsync(int id, User user)
        {
            var existingBoard = await _boardRepository.FindByIdAsync(id);
            if (existingBoard == null)
                return new BoardResponse("Board not found");

            if(!user.IsItemEditable(existingBoard))
                return new BoardResponse("Invalid permissions");

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

        public async Task<Board> FindAsync(int id)
        {
            return await _boardRepository.FindByIdAsync(id); 
        }

        public async Task<IEnumerable<Board>> ListAsync()
        {
            return await _boardRepository.ListAsync();
        }

        public async Task<BoardResponse> SaveAsync(Board board, User user)
        {
            try
            {
                board.Owner = user;
                board.OwnerId = user.Id;

                await _boardRepository.AddAsync(board);
                await _unitOfWork.CompleteAsync();

                return new BoardResponse(board);
            }
            catch (Exception ex)
            {
                return new BoardResponse($"An error occurred when saving the board: {ex.Message}");
            }
        }

        public async Task<BoardResponse> UpdateAsync(int id, Board board, User user)
        {
            var existingBoard = await _boardRepository.FindByIdAsync(id);
            if (existingBoard == null)
                return new BoardResponse("Board not found.");
            
            if(!user.IsItemEditable(existingBoard))
                return new BoardResponse("Invalid permissions");
            
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