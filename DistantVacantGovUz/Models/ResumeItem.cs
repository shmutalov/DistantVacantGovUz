namespace DistantVacantGovUz.Models
{
    /// <summary>
    /// Элемент списка резюме (поступившие/принятые/рассмотренные/зарезервированные)
    /// </summary>
    public class ResumeItem
    {
        public string RequestNumber;
        public string RequestName;
        public string RequestFrom;
        public string RequestDate;
        public string RequestStatus;

        public ResumeItem(
                string requestNumber
                , string requestName
                , string requestFrom
                , string requestDate
                , string requestStatus
            )
        {
            RequestNumber = requestNumber;
            RequestName = requestName;
            RequestFrom = requestFrom;
            RequestDate = requestDate;
            RequestStatus = requestStatus;
        }
    }
}
