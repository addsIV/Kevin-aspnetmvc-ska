using dotNetMvcCourse.Models;

namespace dotNetMvcCourse.Proxies;

public interface IFakeDbProxy
{
    IEnumerable<AccountingModel> GetAccountingModels();
    void InsertToFake(AccountingModel accountingModel);
}