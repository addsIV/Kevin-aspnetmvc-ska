namespace dotNetMvcCourse.Models;

public class AccountingListModel
{
    public List<AccountingModel> AccountingModels { get; set; }
    public AccountingListModel(List<AccountingModel> accountingModels)
    {
        AccountingModels = accountingModels;
    }

}