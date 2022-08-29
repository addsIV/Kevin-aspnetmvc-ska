using dotNetMvcCourse.Models;

namespace dotNetMvcCourse.Proxies;

public interface IDbProxy
{
    IEnumerable<AccountingModel> GetAccountingModels();
    void InsertToFake(AccountingModel accountingModel);
}