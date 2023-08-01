﻿using Application.Abstractions;
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
    public class GetPostByIdhandler : IRequestHandler<GetPostById, Post>

    {

        private readonly IPostRepository _postrepo;

        public GetPostByIdhandler(IPostRepository postrepo)
        {
            _postrepo = postrepo;
        }

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {

            return await _postrepo.GetPostByID(request.PostId);

        }
    }
}
