namespace DistantVacantGovUz.Models
{
    public class ReportVisaItem
    {
        public readonly string JobTitle;
        public readonly string Subject;

        public ReportVisaItem(string jobTitle, string subject)
        {
            JobTitle = jobTitle;
            Subject = subject;
        }
    }
}
