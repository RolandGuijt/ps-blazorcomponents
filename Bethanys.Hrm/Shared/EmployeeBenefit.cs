namespace Bethanys.Hrm.Shared
{
    public class EmployeeBenefit
    {
        public int EmployeeId { get; set; }
        public int BenefitId { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
