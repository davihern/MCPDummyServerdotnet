
using MCPServerDemo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    // 👇 Add MCP Server to IoC
    .AddMcpServer()
    .WithHttpTransport()
    // 👇 Register MCP Tool
    .WithTools<TimeTool>();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapMcp("/mcptime");

app.Run();
