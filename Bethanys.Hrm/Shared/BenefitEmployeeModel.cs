namespace Bethanys.Hrm.Shared
{
    public class BenefitEmployeeModel
    {
        public int BenefitId { get; set; }

        public bool Selected { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool Premium { get; set; }
    }
}
