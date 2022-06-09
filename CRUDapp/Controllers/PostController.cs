using CRUDapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await PostRepository.GetPostsAsync();
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetPostsId(int id)
        {
            Post postToReturn = await PostRepository.GetPostByIdAsync(id);

            return postToReturn == null ? NotFound() : Ok(postToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Post post)
        {
            await PostRepository.CreatePostAsync(post);

            return CreatedAtAction(nameof(GetPostsId), new { id = post.PostId }, post);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, Post post)
        {
            if (id != post.PostId) return BadRequest();

            await PostRepository.UpdatePostAsync(post);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Post postToDelete = await PostRepository.GetPostByIdAsync(id);
            if (postToDelete == null) return NotFound();

            await PostRepository.DeletePostAsync(id);

            return NoContent();
        }
    }
}
