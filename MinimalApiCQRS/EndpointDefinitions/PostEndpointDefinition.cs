using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApiCQRS.Abstractions;

namespace MinimalApiCQRS.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        void IEndpointDefinition.RegisterEndpoints(WebApplication app)
        {


            app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
            {

                var getPost = new GetPostById() { PostId = id };

                var post = await mediator.Send(getPost);

                return Results.Ok(post);
            }).WithName("GetPostById");


            app.MapPost("/api/posts", async (IMediator mediator, [FromBody] Post post) =>
            {
                var createPostCommand = new CreatePost() { PostContent = post.Content };

                var createdPost = await mediator.Send(createPostCommand);
                return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);

            });

            app.MapGet("/api/posts/", async (IMediator mediator) =>
            {
                var getQuery = new GetAllPosts();

                var posts = await mediator.Send(getQuery);
                return Results.Ok(posts);
            });

            app.MapPut("/api/posts/{id}", async (IMediator mediator, Post post, int id) =>
            {

                var updatedPostCommand = new UpdatePost() { PostId = id, postContent = post.Content };

                var postUpdated = await mediator.Send(updatedPostCommand);
                return Results.Ok(postUpdated);
            });

            app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
            {

                var deleteCommand = new DeleteCommand() { PostID = id };
                var x = await mediator.Send(deleteCommand);
                return Results.NoContent();

            });

        }
    }
}
