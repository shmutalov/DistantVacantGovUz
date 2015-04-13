using System;
using System.Collections.Generic;
using System.Text;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Элемент списка резюме (поступившие/принятые/рассмотренные/зарезервированные)
    /// </summary>
    public class CVacancyResumeItem
    {
        public string request_number;
        public string request_name;
        public string request_from;
        public string request_date;
        public string request_status;

        public CVacancyResumeItem(
                string request_number
                , string request_name
                , string request_from
                , string request_date
                , string request_status
            )
        {
            this.request_number = request_number;
            this.request_name = request_name;
            this.request_from = request_from;
            this.request_date = request_date;
            this.request_status = request_status;
        }
    }
}
