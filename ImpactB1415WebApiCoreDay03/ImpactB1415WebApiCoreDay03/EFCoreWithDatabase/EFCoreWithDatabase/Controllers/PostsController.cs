using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreWithDatabase.Models;
using EFCoreWithDatabase.Repository;

namespace EFCoreWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }


        // GET: api/Posts
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await postRepository.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await postRepository.GetPosts();
                if (posts == null)
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPost")]
        public async Task<IActionResult> GetPost(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await postRepository.GetPost(postId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] Post model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await postRepository.UpdatePost(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Post model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await postRepository.AddPost(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        // DELETE: api/Posts/5
        [HttpDelete]
        [Route("DeletePost/{postId:int}")]
        public async Task<IActionResult> DeletePost(int? postId)
        {
            int result = 0;

            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await postRepository.DeletePost(postId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
