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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostResponse> DeleteAsync(int id, User user)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
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

        public async Task<Post> FindAsync(int id)
        {
            return await _postRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<PostResponse> SaveAsync(Post post, User user)
        {
            try
            {
                post.Owner = user;
                post.OwnerId = user.Id;
                await _postRepository.AddAsync(post); 
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception ex)
            {
                
                return new PostResponse($"An error occurred when saving the post: {ex.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(int id, Post post, User user)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
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