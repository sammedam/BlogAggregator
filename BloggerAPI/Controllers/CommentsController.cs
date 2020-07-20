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

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AggregatorDBContext _context;

        public CommentsController(AggregatorDBContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloggerAPI.Models.Comments>>> GetComments()
        {
            //return await _context.Comments.ToListAsync();
            var query = (from cc in _context.CommentatorComments
                         join c in _context.Comments
                         on cc.CommentID equals c.CommentID
                         join commenter in _context.commentators
                         on cc.CommentatorID equals commenter.CommentatorID
                         select (new BloggerAPI.Models.Comments
                         {
                             CommentPosted = c.CommentPosted,
                             Commenter = commenter.CommentatorName,
                             DateCommentPosted = c.DateCommentPosted
                         }

                         )).ToList();
            return query;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDataModel.Comments>> GetComments(int id)
        {
            var comments = await _context.Comments.FindAsync(id);

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments(int id, BlogDataModel.Comments comments)
        {
            if (id != comments.CommentID)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BlogDataModel.Comments>> PostComments(BlogDataModel.Comments comments)
        {
            _context.Comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComments", new { id = comments.CommentID }, comments);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogDataModel.Comments>> DeleteComments(int id)
        {
            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();

            return comments;
        }

        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.CommentID == id);
        }
    }
}
