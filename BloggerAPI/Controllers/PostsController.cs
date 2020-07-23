using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AggregatorContext;
using BlogDataModel;
using BloggerAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AggregatorDBContext _context;

        public PostsController(AggregatorDBContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Article>>> GetPosts()
        {
            var query = (from aa in _context.ArticleAuthors
                         join p in _context.Posts
                         on aa.PostID equals p.PostID
                         join a in _context.Authors
                         on aa.AuthorID equals a.AuthorID
                         join ac in _context.ArticleCategories
                         on p.PostID equals ac.PostID
                         join c in _context.Categories
                         on ac.CategoryID equals c.CategoryID
                         select (new Article
                         {

                             ArticleTitle = p.PostTitle,
                             Summary = p.Summary,
                             ArticleDateCreated = p.PostDateCreated,
                             ArticleURL = p.absURI,
                             Author = a.AuthorName,
                             Category = c.CategoryName
                         })).ToList();
            return query;
                                   
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostID)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostID }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostID == id);
        }
    }
}
