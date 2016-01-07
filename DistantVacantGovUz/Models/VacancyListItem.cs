namespace DistantVacantGovUz.Models
{
    /// <summary>
    /// Элемент списка вакансий (для работы со актуальными/закрытыми списками
    /// вакансий, возвращаемым vacant.gov.uz)
    /// </summary>
    public class VacancyListItem
    {
        /// <summary>
        /// Номер вакансии
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// Наименование вакансии
        /// </summary>
        public string Description { get; private set; }

        public VacancyListItem(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}