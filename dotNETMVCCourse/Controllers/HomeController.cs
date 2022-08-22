using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotNetMvcCourse.Models;

namespace dotNetMvcCourse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var accountingListModel = new AccountingListModel(new List<AccountingModel>()
        {
            new AccountingModel(){amount = "123", date = "2022/08/22",remark = "breakfast"},
            new AccountingModel(){amount = "123", date = "2022/08/22",remark = "breakfast"},
            new AccountingModel(){amount = "123", date = "2022/08/22",remark = "breakfast"},
        });
        
        return View(accountingListModel);
    }

    [HttpPost]
    public IActionResult SaveToFakeDb(AccountingModel accountingModel)
    {
        FakeDb.AccountingList?.Add(accountingModel);
        var accountingListModel = new AccountingListModel(FakeDb.AccountingList);
        return View("Index", accountingListModel);
    }

    [HttpGet("Hello")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}