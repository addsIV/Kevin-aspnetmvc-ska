using System.ComponentModel.DataAnnotations;

namespace dotNetMvcCourse.Models;

public class AccountingModel
{
    [Required]
    [Range(1,500)]
    public int amount { get; set; }
    [Required]
    public DateTime date { get; set; }
    [MaxLength(100)]
    public string remark { get; set; }
}