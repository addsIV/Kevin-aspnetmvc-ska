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
        FakeDb.AccountingList = new List<AccountingModel>();
        var accountingListModel = new AccountingListModel()
        {
            AccountingModels = new List<AccountingModel>(),
            AccountingModel = new AccountingModel()
        };
        
        return View(accountingListModel);
    }

    [HttpPost]
    public IActionResult SaveToFakeDb(AccountingModel accountingModel)
    {
        if (accountingModel.amount <= 0)
        {
            ModelState.AddModelError("amount", "amount can not less then 0.");
            return View("Index", new AccountingListModel()
            {
                AccountingModels = FakeDb.AccountingList
            });
        }
      
        FakeDb.AccountingList.Add(accountingModel);
        var accountingListModel = new AccountingListModel
        {
            AccountingModels = FakeDb.AccountingList
        };
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