namespace Bethanys.Hrm.Shared;

public class EmployeeModel
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public bool ShowBenefits { get; set; }
    public bool HasPremiumBenefits { get; set; }

    public List<EmployeeBenefit> Benefits { get; set; } = new List<EmployeeBenefit>();
}

