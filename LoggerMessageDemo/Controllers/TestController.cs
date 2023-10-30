using System;
using Microsoft.AspNetCore.Mvc;

namespace LoggerMessageDemo.Controllers;
public partial class TestController
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [LoggerMessage(0, LogLevel.Information, "Writing hello world response to {Person}")]
    partial void LogHelloWorld(Person person);

    [HttpGet("/")]
    public string Get()
    {
        var person = new Person(123, "Joe Blogs");

        LogHelloWorld(person);

        return "Hello world!";
    }

    public record Person(int Id, string Name);
}
