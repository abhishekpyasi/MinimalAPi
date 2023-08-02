using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApiCQRS.Abstractions;
using MinimalApiCQRS.Filters;

namespace MinimalApiCQRS.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        void IEndpointDefinition.RegisterEndpoints(WebApplication app)
        {

            var post = app.MapGroup("/api/posts");

            post.MapGet("/{id}", GetPostbyId).WithName("GetPostById");

            post.MapPost("/", Createpost).AddEndpointFilter<PostValidationFilter>();

            post.MapGet("/", GetAllPosts);

            post.MapPut("/{id}", UpdatepostAsync);

            post.MapDelete("/{id}", DeletePostAsync);

        }

        private async Task<IResult> GetPostbyId(IMediator mediator, int id)
        {

            var getPost = new GetPostById() { PostId = id };

            var post = await mediator.Send(getPost);

            return Results.Ok(post);
        }
        private async Task<IResult>Createpost(IMediator mediator, [FromBody] Post post)
        {

            var createPostCommand = new CreatePost() { PostContent = post.Content };

            var createdPost = await mediator.Send(createPostCommand);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);


        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var getQuery = new GetAllPosts();

            var posts = await mediator.Send(getQuery);
            return Results.Ok(posts);

        }

        private async Task<IResult> UpdatepostAsync(IMediator mediator, Post post, int id)
        {
            var updatedPostCommand = new UpdatePost() { PostId = id, postContent = post.Content };

            var postUpdated = await mediator.Send(updatedPostCommand);
            return Results.Ok(postUpdated);

        }

        private async Task<IResult> DeletePostAsync(IMediator mediator, int id)
        {

            var deleteCommand = new DeleteCommand() { PostID = id };
            var x = await mediator.Send(deleteCommand);
            return TypedResults.NoContent();

        }

    }
}
