using Bethanys.Components;

namespace Bethanys.Hrm.Shared
{
    public class BenefitEmployeeModel: ITableModel
    {
        public int BenefitId { get; set; }

        public bool Selected { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool Premium { get; set; }
        public bool HighLightRow => Premium;
        public bool ShowChildTemplate => false;
    }
}
