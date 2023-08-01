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

app.UseHttpsRedirection();

app.RegisterEndpointDefinition();

app.Run();
