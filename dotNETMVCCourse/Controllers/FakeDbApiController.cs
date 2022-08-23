using System.Text.Json;
using dotNetMvcCourse.Models;
using dotNetMvcCourse.Proxies;
using Microsoft.AspNetCore.Mvc;

namespace dotNetMvcCourse.Controllers;

[ApiController]
[Route("api")]
public class FakeDbApiController
{
    private readonly IFakeDbProxy _fakeDbProxy;

    public FakeDbApiController(IFakeDbProxy fakeDbProxy)
    {
        _fakeDbProxy = fakeDbProxy;
    }

    [HttpGet]
    [Route("records")]
    public string GetAccountingList()
    {
        var response = JsonSerializer.Serialize(_fakeDbProxy.GetAccountingModels());
        return response;
    }
}