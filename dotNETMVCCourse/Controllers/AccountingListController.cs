using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotNetMvcCourse.Models;

namespace dotNetMvcCourse.Controllers;

public class AccountingListController : Controller
{
    private readonly ILogger<AccountingListController> _logger;

    public AccountingListController(ILogger<AccountingListController> logger)
    {
        _logger = logger;
    }

    public AccountingListModel GetAccountingList()
    {
        var accountingModels = new List<AccountingModel>();
        return new AccountingListModel();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}