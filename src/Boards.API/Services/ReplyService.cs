using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReplyService(IReplyRepository replyRepository, IUnitOfWork unitOfWork)
        {
            _replyRepository = replyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReplyResponse> DeleteAsync(int id)
        {
            var existingReply = await _replyRepository.FindByIdAsync(id);
            if(existingReply == null)
                return new ReplyResponse("Reply not found");
            
            try
            {
                _replyRepository.Remove(existingReply);
                await _unitOfWork.CompleteAsync();
                return new ReplyResponse(existingReply);
            }
            catch (Exception ex)
            {
                return new ReplyResponse($"An error occurred when deleting the reply: {ex.Message}");
            }
        }

        public async Task<Reply> FindAsync(int id)
        {
            return await _replyRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Reply>> ListAsync()
        {
            return await _replyRepository.ListAsync();
        }

        public async Task<ReplyResponse> SaveAsync(Reply reply)
        {
            try
            {
                await _replyRepository.AddAsync(reply);
                await _unitOfWork.CompleteAsync();
                return new ReplyResponse(reply);
            }
            catch (Exception ex)
            {
                return new ReplyResponse($"An error occurred when saving the reply: {ex.Message}"); 
            }
            
        }

        public async Task<ReplyResponse> UpdateAsync(int id, Reply reply)
        {
            var existingReply = await _replyRepository.FindByIdAsync(id);
            if(existingReply == null)
                return new ReplyResponse("Reply not found");

            existingReply.Body = reply.Body;
            
            try
            {
                _replyRepository.Update(existingReply);
                await _unitOfWork.CompleteAsync();
                return new ReplyResponse(existingReply);
            }
            catch (Exception ex)
            {
                return new ReplyResponse($"An error occurred when deleting the reply: {ex.Message}");
            }
        }
    }
}