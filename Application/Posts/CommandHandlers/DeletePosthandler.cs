using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class DeletePosthandler : IRequestHandler<DeleteCommand,Unit>
    { 

        private readonly IPostRepository _postsRepo;

        public DeletePosthandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {

            await _postsRepo.DeletePost(request.PostID);
            return Unit.Value;
        }

      
    }
}
