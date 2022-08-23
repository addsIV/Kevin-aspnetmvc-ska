namespace dotNetMvcCourse.Models;

public class AccountingListModel
{
    public IEnumerable<AccountingModel> AccountingModels { get; set; }

    public AccountingModel AccountingModel { get; set; }
}