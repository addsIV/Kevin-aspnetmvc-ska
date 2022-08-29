using System.Text.Json;
using dotNetMvcCourse.Models;
using dotNetMvcCourse.Proxies;
using Microsoft.AspNetCore.Mvc;

namespace dotNetMvcCourse.Controllers;

[ApiController]
[Route("api")]
public class FakeDbApiController
{
    private readonly IDbProxy _dbProxy;

    public FakeDbApiController(IDbProxy dbProxy)
    {
        _dbProxy = dbProxy;
    }

    [HttpGet]
    [Route("records")]
    public string GetAccountingList()
    {
        var response = JsonSerializer.Serialize(_dbProxy.GetAccountingModels());
        return response;
    }
}