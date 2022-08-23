using System.Text.Json;
using dotNetMvcCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetMvcCourse.Proxies;

public class FakeDbProxy : IFakeDbProxy
{
    public IEnumerable<AccountingModel> GetAccountingModels()
    {
        return FakeDb.AccountingList;
    }

    public void InsertToFake(AccountingModel accountingModel)
    {
        FakeDb.AccountingList.Add(accountingModel);
    }
}