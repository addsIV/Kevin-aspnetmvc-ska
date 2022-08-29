using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using dotNetMvcCourse.Models;
using dotNetMvcCourse.Proxies;

namespace dotNetMvcCourse.Controllers;

public class HomeController : Controller
{
    private readonly IDbProxy _dbProxy;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IDbProxy dbProxy)
    {
        _logger = logger;
        _dbProxy = dbProxy;
    }

    public IActionResult Index()
    {
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
        }
        
        if(ModelState.IsValid)
        {
            _dbProxy.InsertToFake(accountingModel);
        }
        
        return View("Index",
            new AccountingListModel
            {
                AccountingModels = _dbProxy.GetAccountingModels()
            });
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}