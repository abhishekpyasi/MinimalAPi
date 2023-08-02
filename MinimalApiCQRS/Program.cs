using Application.Abstractions;
using Application.Posts.Commands;
using Application.Posts.Queries;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiCQRS.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
var app = builder.Build();
app.Use(async (ctx, next) =>
{

    try
    {

       await next(ctx);
    }

    catch (Exception ex)
    {

        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsJsonAsync(ex.Message);
    }

});

app.UseHttpsRedirection();

app.RegisterEndpointDefinition();

app.Run();
