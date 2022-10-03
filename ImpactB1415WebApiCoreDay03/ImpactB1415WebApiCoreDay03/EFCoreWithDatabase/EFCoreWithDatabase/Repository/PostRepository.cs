using EFCoreWithDatabase.Models;
using EFCoreWithDatabase.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWithDatabase.Repository
{
    public class PostRepository : IPostRepository
    {
        BlogDBContext context;

        public PostRepository(BlogDBContext context)
        {
            this.context = context;
        }
        public async Task<int> AddPost(Post post)
        {
            if (context != null)
            {
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();

                return post.PostId;
            }

            return 0;
        }

        public async Task<int> DeletePost(int? postId)
        {
            int result = 0;

            if (context != null)
            {
                //Find the post for specific post id
                var post = await context.Posts.FirstOrDefaultAsync(x => x.PostId == postId);

                if (post != null)
                {
                    //Delete that post
                    context.Posts.Remove(post);

                    //Commit the transaction
                    result = await context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Category>> GetCategories()
        {
            if (context != null)
            {
                return await context.Categories.ToListAsync();
            }

            return null;
        }

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if (context != null)
            {
                return await(from p in context.Posts
                             from c in context.Categories
                             where p.PostId == postId
                             select new PostViewModel
                             {
                                 PostId = p.PostId,
                                 Title = p.Title,
                                 Description = p.Description,
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.Name,
                                 CreatedDate = p.CreatedDate
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> GetPosts()
        {
            if (context != null)
            {
                return await(from p in context.Posts
                             from c in context.Categories
                             where p.CategoryId == c.Id
                             select new PostViewModel
                             {
                                 PostId = p.PostId,
                                 Title = p.Title,
                                 Description = p.Description,
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.Name,
                                 CreatedDate = p.CreatedDate
                             }).ToListAsync();
            }

            return null;
        }

        public async Task UpdatePost(Post post)
        {
            if (context != null)
            {
                //Update that post
                context.Posts.Update(post);

                //Commit the transaction
                await context.SaveChangesAsync();
            }
        }
    }
}
