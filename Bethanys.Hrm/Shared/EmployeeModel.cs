using System.ComponentModel.DataAnnotations;
using Bethanys.Components;

namespace Bethanys.Hrm.Shared;

public class EmployeeModel: ITableModel
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public bool ShowBenefits { get; set; }
    public bool HasPremiumBenefits { get; set; }

    public List<EmployeeBenefit> Benefits { get; set; } = new List<EmployeeBenefit>();
    public bool HighLightRow => HasPremiumBenefits;
    public bool ShowChildTemplate => ShowBenefits;
}

