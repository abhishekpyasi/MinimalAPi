using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.QueryHandlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts,ICollection<Post>>
    {

        private readonly IPostRepository _postrepo;

        public GetAllPostsHandler(IPostRepository postrepo)
        {
            _postrepo = postrepo;
        }

        public Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {

            return _postrepo.GetAllPosts();
        }
    }
}
