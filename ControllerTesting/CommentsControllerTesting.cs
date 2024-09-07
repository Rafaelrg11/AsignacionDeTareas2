using AsignacionDeTareas2.Controllers;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AsignacionDeTareas2.DTOs;

namespace AsignacionDeTareas2Testing.ControllerTesting
{
    public class CommentsControllerTesting
    {
        public readonly CommentOperations _operation;
        public readonly CommentsController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public CommentsControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new CommentOperations(_context);
            _controller = new CommentsController(_operation, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetComments_OK()
        {
            var result = await _controller.GetComments();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetNotification_OK()
        {
            var commentId = _context.Comments.Select(a => a.idComment).FirstOrDefault();

            var result = await _controller.GetComment(commentId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateComment_OK()
        {
            var newComment = new CommentsDto2
            {
                idComment = 3,
                idTask = 3,
                descriptionCommet = "Este comentario es uno de prueba, sean serios compaes, que vaina tardada"
            };

            var result = await _controller.CreateComment(newComment);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateComment_OK()
        {
            var uComment = new CommentsDto2
            {
                idComment = 3,
                idTask = 4,
                descriptionCommet = "Este es un comentario de prueba"
            };

            var result = await _controller.UpdateComment(uComment);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
