﻿using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>

    {

        private readonly IPostRepository _postsRepo;

        public UpdatePostHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {

           var post =  await _postsRepo.UpdatePost(request.postContent, request.PostId);

            return post;
        }
    }
}
