using System;
using System.Collections.Generic;
using System.Text;

namespace DistantVacantGovUz
{
    public class CReportVisaItem
    {
        public string jobTitle;
        public string subject;

        public CReportVisaItem()
        {
        }

        public CReportVisaItem(string jobTitle, string subject)
        {
            this.jobTitle = jobTitle;
            this.subject = subject;
        }
    }
}
