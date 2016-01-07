using DistantVacantGovUz.Enums;

namespace DistantVacantGovUz.Models
{
    public class VacancyItem
    {
        public string SequenceNumber;
        public string DescriptionRu;
        public string DescriptionUz;
        public string CategoryString;
        public string Salary;
        public string EmploymentString;
        public string GenderString;
        public string ExperienceString;
        public string EducationString;
        public string ExpireDate;
        public string DepartmentRu;
        public string SpecializationRu;
        public string RequirementsRu;
        public string InformationRu;
        public string DepartmentUz;
        public string SpecializationUz;
        public string RequirementsUz;
        public string InformationUz;

        // helper ids
        public string CategoryIdString;
        public string EmploymentIdString;
        public string GenderIdString;
        public string ExperienceIdString;
        public string EducationIdString;
        public string PortalVacancyIdString;

        // helper ids converted to int
        public int CategoryId;
        public int EmploymentId;
        public int GenderId;
        public int ExperienceId;
        public int EducationId;
        public int PortalVacancyId;

        // helper ids converted to enum
        public VacancyCategory Category;
        public VacancyEmployment Employment;
        public VacancyGender Gender;
        public VacancyExperience Experience;
        public VacancyEducationLevel Education;

        private bool _isValid;

        public static VacancyItem Copy(VacancyItem source, VacancyItem destination)
        {
            if (source != null && destination != null)
            {
                destination.DescriptionRu = string.Copy(source.DescriptionRu);
                destination.DescriptionUz = string.Copy(source.DescriptionUz);
                destination.CategoryString = string.Copy(source.CategoryString);
                destination.Salary = string.Copy(source.Salary);
                destination.EmploymentString = string.Copy(source.EmploymentString);
                destination.GenderString = string.Copy(source.GenderString);
                destination.ExperienceString = string.Copy(source.ExperienceString);
                destination.EducationString = string.Copy(source.EducationString);
                destination.ExpireDate = string.Copy(source.ExpireDate);
                destination.DepartmentRu = string.Copy(source.DepartmentRu);
                destination.SpecializationRu = string.Copy(source.SpecializationRu);
                destination.RequirementsRu = string.Copy(source.RequirementsRu);
                destination.InformationRu = string.Copy(source.InformationRu);
                destination.DepartmentUz = string.Copy(source.DepartmentUz);
                destination.SpecializationUz = string.Copy(source.SpecializationUz);
                destination.RequirementsUz = string.Copy(source.RequirementsUz);
                destination.InformationUz = string.Copy(source.InformationUz);

                destination.CategoryIdString = string.Copy(source.CategoryIdString);
                destination.EmploymentIdString = string.Copy(source.EmploymentIdString);
                destination.GenderIdString = string.Copy(source.GenderIdString);
                destination.ExperienceIdString = string.Copy(source.ExperienceIdString);
                destination.EducationIdString = string.Copy(source.EducationIdString);

                destination.Category = source.Category;
                destination.Employment = source.Employment;
                destination.Gender = source.Gender;
                destination.Experience = source.Experience;
                destination.Education = source.Education;

                destination.CategoryId = source.CategoryId;
                destination.EmploymentId = source.EmploymentId;
                destination.GenderId = source.GenderId;
                destination.ExperienceId = source.ExperienceId;
                destination.EducationId = source.EducationId;
            }

            return destination;
        }

        public bool IsValid()
        {
            _isValid = true;

            if (DescriptionRu.Trim() == "")
                _isValid = false;

            if (DescriptionUz.Trim() == "")
                _isValid = false;

            if (CategoryString.Trim() == "")
                _isValid = false;

            if (Salary.Trim() == "")
                _isValid = false;

            if (ExpireDate.Trim() == "")
                _isValid = false;

            if (DepartmentRu.Trim() == "")
                _isValid = false;

            if (SpecializationRu.Trim() == "")
                _isValid = false;

            if (DepartmentUz.Trim() == "")
                _isValid = false;

            if (SpecializationUz.Trim() == "")
                _isValid = false;

            return _isValid;
        }

        public VacancyItem()
        {
            SequenceNumber = string.Empty;
            DescriptionRu = string.Empty;
            DescriptionUz = string.Empty;
            CategoryString = string.Empty;
            Salary = string.Empty;
            EmploymentString = string.Empty;
            GenderString = string.Empty;
            ExperienceString = string.Empty;
            EducationString = string.Empty;
            ExpireDate = string.Empty;
            DepartmentRu = string.Empty;
            SpecializationRu = string.Empty;
            RequirementsRu = string.Empty;
            InformationRu = string.Empty;
            DepartmentUz = string.Empty;
            SpecializationUz = string.Empty;
            RequirementsUz = string.Empty;
            InformationUz = string.Empty;

            // helper ids
            CategoryIdString = string.Empty;
            EmploymentIdString = string.Empty;
            GenderIdString = string.Empty;
            ExperienceIdString = string.Empty;
            EducationIdString = string.Empty;
            PortalVacancyIdString = string.Empty;

            // helper ids converted to int
            CategoryId = -1;
            EmploymentId = -1;
            GenderId = -1;
            ExperienceId = -1;
            EducationId = -1;
            PortalVacancyId = -1;

            Category = VacancyCategory.Unknown;
            Education = VacancyEducationLevel.Unknown;
            Employment = VacancyEmployment.Unknown;
            Experience = VacancyExperience.Unknown;
            Gender = VacancyGender.Unknown;

            // is valide?
            _isValid = false;
        }

        public VacancyItem(
                string sequenceNumber,
                string descriptionRu,
                string descriptionUz,
                string categoryString,
                string salary,
                string employmentString,
                string genderString,
                string experienceString,
                string educationString,
                string expireDate,
                string departmentRu,
                string specializationRu,
                string requirementsRu,
                string informationRu,
                string departmentUz,
                string specializationUz,
                string requirementsUz,
                string informationUz,

                // helper ids
                string categoryIdString,
                string employmentIdString,
                string genderIdString,
                string experienceIdString,
                string educationIdString,
                string portalVacancyIdString
            )
        {
            SequenceNumber = sequenceNumber;
            DescriptionRu = descriptionRu;
            DescriptionUz = descriptionUz;
            CategoryString = categoryString;
            Salary = salary;
            EmploymentString = employmentString;
            GenderString = genderString;
            ExperienceString = experienceString;
            EducationString = educationString;
            ExpireDate = expireDate;
            DepartmentRu = departmentRu;
            SpecializationRu = specializationRu;
            RequirementsRu = requirementsRu;
            InformationRu = informationRu;
            DepartmentUz = departmentUz;
            SpecializationUz = specializationUz;
            RequirementsUz = requirementsUz;
            InformationUz = informationUz;

            // helper ids
            CategoryIdString = categoryIdString;
            EmploymentIdString = employmentIdString;
            GenderIdString = genderIdString;
            ExperienceIdString = experienceIdString;
            EducationIdString = educationIdString;
            PortalVacancyIdString = portalVacancyIdString;

            // helper ids converted to int and enum
            try { CategoryId = int.Parse(CategoryIdString); Category = (VacancyCategory)CategoryId; }
            catch { /* ignore */ }
            try { EmploymentId = int.Parse(EmploymentIdString); Employment = (VacancyEmployment)EmploymentId; }
            catch { /* ignore */ }
            try { GenderId = int.Parse(GenderIdString); Gender = (VacancyGender)GenderId; }
            catch { /* ignore */ }
            try { ExperienceId = int.Parse(ExperienceIdString); Experience = (VacancyExperience)ExperienceId; }
            catch { /* ignore */ }
            try { EducationId = int.Parse(EducationIdString); Education = (VacancyEducationLevel)EducationId; }
            catch { /* ignore */ }
            try { PortalVacancyId = int.Parse(PortalVacancyIdString); }
            catch { /* ignore */ }
        }

        public void ResetIds()
        {
            // helper ids converted to int and enum

            int.TryParse(CategoryIdString, out CategoryId);
            Category = (VacancyCategory)CategoryId;

            int.TryParse(CategoryIdString, out CategoryId);
            Category = (VacancyCategory)CategoryId;

            int.TryParse(EmploymentIdString, out EmploymentId);
            Employment = (VacancyEmployment)EmploymentId;

            int.TryParse(GenderIdString, out GenderId);
            Gender = (VacancyGender)GenderId;

            int.TryParse(ExperienceIdString, out ExperienceId);
            Experience = (VacancyExperience)ExperienceId;

            int.TryParse(EducationIdString, out EducationId);
            Education = (VacancyEducationLevel)EducationId;

            int.TryParse(PortalVacancyIdString, out PortalVacancyId);

            CategoryString = Vacancy.CategoryFromIdRu(Category);
            EmploymentString = Vacancy.EmploymentFromIdRu(Employment);
            GenderString = Vacancy.GenderFromIdRu(Gender);
            ExperienceString = Vacancy.ExperienceFromIdRu(Experience);
            EducationString = Vacancy.EducationFromIdRu(Education);
        }

        public void InitFromCVacancy(Vacancy v)
        {
            SequenceNumber = string.Empty;
            DescriptionRu = v.StrDescriptionRu;
            DescriptionUz = v.StrDescriptionUz;

            Salary = v.StrSalary;

            ExpireDate = v.ExpireDate;
            DepartmentRu = v.DepartmentRu;
            SpecializationRu = v.SpecializationRu;
            RequirementsRu = v.RequirementsRu;
            InformationRu = v.InformationRu;
            DepartmentUz = v.DepartmentUz;
            SpecializationUz = v.SpecializationUz;
            RequirementsUz = v.RequirementsUz;
            InformationUz = v.InformationUz;
            PortalVacancyIdString = v.Id;

            CategoryIdString = ((int)(v.Category)).ToString();
            EmploymentIdString = ((int)(v.Employment)).ToString();
            GenderIdString = ((int)(v.Gender)).ToString();
            ExperienceIdString = ((int)(v.Experience)).ToString();
            EducationIdString = ((int)(v.EducatonLevel)).ToString();

            ResetIds();
        }
    }
}
