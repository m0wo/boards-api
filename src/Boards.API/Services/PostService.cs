using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;
using Boards.API.Extensions;

namespace Boards.API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IBoardRepository boardRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostResponse> DeleteAsync(int postId, User user)
        {   
            var existingPost = await _postRepository.FindByIdAsync(postId);
            if (existingPost == null)
                return new PostResponse("Post not found");
            
            if(!user.IsItemEditable(existingPost))
                return new PostResponse("Invalid permissions");
            try
            {
                _postRepository.Remove(existingPost);
                await _unitOfWork.CompleteAsync();
                return new PostResponse(existingPost);
            }
            catch(Exception ex)
            {
                return new PostResponse($"An error occurred when deleting the post: {ex.Message}");
            }
        }

        public async Task<Post> FindAsync(int postId)
        {
            return await _postRepository.FindByIdAsync(postId);
        }

        public async Task<IEnumerable<Post>> ListAsync(int boardId)
        {
            IEnumerable<Post> postList = await _postRepository.ListAsync();
            return postList.Where(p => p.BoardId == boardId);
        }

        public async Task<PostResponse> SaveAsync(int boardId, Post post, User user)
        {
            try
            {
                post.Owner = user;
                post.OwnerId = user.Id;
                post.BoardId = boardId;
                await _postRepository.AddAsync(post); 
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception ex)
            {
                
                return new PostResponse($"An error occurred when saving the post: {ex.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(int postId, Post post, User user)
        {
            var existingPost = await _postRepository.FindByIdAsync(postId);
            if (existingPost == null)
                return new PostResponse("Post not found");

            if(!user.IsItemEditable(post))
                return new PostResponse("Invalid permissions");

            existingPost.Title = post.Title;
            existingPost.Body = post.Body;

            try
            {
                _postRepository.Update(existingPost);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error occurred when updating the post: {ex.Message}");
            }

        }
    }
}