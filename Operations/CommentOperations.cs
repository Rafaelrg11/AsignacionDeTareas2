using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class CommentOperations
    {
        ApplicationDbcontext _context;
        public CommentOperations(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Comments>> GetComments()
        {
            var result = await _context.Comments.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Comments> GetComment(int idComment)
        {
            var result = await _context.Comments.FindAsync(idComment);

            return result;
        }

        public async Task<Comments> CreateComment(Comments comments)
        {
            var result = await _context.Comments.AddAsync(comments);

            await _context.SaveChangesAsync();

            return comments;
        }

        public async Task<bool> UpdateComment(CommentsDto2 commentsDto)
        {
            Comments? comments = await _context.Comments.FindAsync(commentsDto.idComment);
            if (comments != null)
            {
                comments.descriptionCommet = commentsDto.descriptionCommet;
                comments.idTask = commentsDto.idTask;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteComment(int idComment)
        {
            var result = await _context.Comments.FindAsync(idComment);
            if (result == null)
            {
                return false;
            }
            _context.Comments.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
