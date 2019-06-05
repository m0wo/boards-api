using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostResponse> DeleteAsync(int id)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
            if (existingPost == null)
                return new PostResponse("Post not found");
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

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<PostResponse> SaveAsync(Post post)
        {
            try
            {
               await _postRepository.AddAsync(post); 
               await _unitOfWork.CompleteAsync();

               return new PostResponse(post);
            }
            catch (Exception ex)
            {
                
                return new PostResponse($"An error occurred when saving the post: {ex.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(int id, Post post)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
            if (existingPost == null)
                return new PostResponse("Post not found");

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