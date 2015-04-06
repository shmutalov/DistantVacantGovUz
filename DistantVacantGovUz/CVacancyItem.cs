using System;
using System.Collections.Generic;
using System.Text;

namespace DistantVacantGovUz
{
    public class CVacancyItem
    {
        public string seqNum;
        public string description_ru;
        public string description_uz;
        public string category;
        public string salary;
        public string employment;
        public string gender;
        public string experience;
        public string education;
        public string expire_date;
        public string department_ru;
        public string specialization_ru;
        public string requirements_ru;
        public string information_ru;
        public string department_uz;
        public string specialization_uz;
        public string requirements_uz;
        public string information_uz;

        // helper ids
        public string category_id;
        public string employment_id;
        public string gender_id;
        public string experience_id;
        public string education_id;
        public string portal_vacancy_id;

        // helper ids converted to int
        public int i_category_id;
        public int i_employment_id;
        public int i_gender_id;
        public int i_experience_id;
        public int i_education_id;
        public int i_portal_vacancy_id;

        // helper ids converted to enum
        public VACANCY_CATEGORY e_category_id;
        public VACANCY_EMPLOYMENT e_employment_id;
        public VACANCY_GENDER e_gender_id;
        public VACANCY_EXPERIENCE e_experience_id;
        public VACANCY_EDUCATION_LEVEL e_education_id;

        private bool valide;

        public static CVacancyItem Copy(CVacancyItem source, CVacancyItem destination)
        {
            if (source != null && destination != null)
            {
                destination.description_ru = string.Copy(source.description_ru);
                destination.description_uz = string.Copy(source.description_uz);
                destination.category = string.Copy(source.category);
                destination.salary = string.Copy(source.salary);
                destination.employment = string.Copy(source.employment);
                destination.gender = string.Copy(source.gender);
                destination.experience = string.Copy(source.experience);
                destination.education = string.Copy(source.education);
                destination.expire_date = string.Copy(source.expire_date);
                destination.department_ru = string.Copy(source.department_ru);
                destination.specialization_ru = string.Copy(source.specialization_ru);
                destination.requirements_ru = string.Copy(source.requirements_ru);
                destination.information_ru = string.Copy(source.information_ru);
                destination.department_uz = string.Copy(source.department_uz);
                destination.specialization_uz = string.Copy(source.specialization_uz);
                destination.requirements_uz = string.Copy(source.requirements_uz);
                destination.information_uz = string.Copy(source.information_uz);

                destination.category_id = string.Copy(source.category_id);
                destination.employment_id = string.Copy(source.employment_id);
                destination.gender_id = string.Copy(source.gender_id);
                destination.experience_id = string.Copy(source.experience_id);
                destination.education_id = string.Copy(source.education_id);

                destination.e_category_id = source.e_category_id;
                destination.e_employment_id = source.e_employment_id;
                destination.e_gender_id = source.e_gender_id;
                destination.e_experience_id = source.e_experience_id;
                destination.e_education_id = source.e_education_id;

                destination.i_category_id = source.i_category_id;
                destination.i_employment_id = source.i_employment_id;
                destination.i_gender_id = source.i_gender_id;
                destination.i_experience_id = source.i_experience_id;
                destination.i_education_id = source.i_education_id;
            }

            return destination;
        }

        public bool IsValid()
        {
            valide = true;

            if (description_ru.Trim() == "")
                valide = false;

            if (description_uz.Trim() == "")
                valide = false;

            if (category.Trim() == "")
                valide = false;

            if (salary.Trim() == "")
                valide = false;

            if (expire_date.Trim() == "")
                valide = false;

            if (department_ru.Trim() == "")
                valide = false;

            if (specialization_ru.Trim() == "")
                valide = false;

            if (department_uz.Trim() == "")
                valide = false;

            if (specialization_uz.Trim() == "")
                valide = false;

            return valide;
        }

        public CVacancyItem()
        {
            seqNum = "";
            description_ru = "";
            description_uz = "";
            category = "";
            salary = "";
            employment = "";
            gender = "";
            experience = "";
            education = "";
            expire_date = "";
            department_ru = "";
            specialization_ru = "";
            requirements_ru = "";
            information_ru = "";
            department_uz = "";
            specialization_uz = "";
            requirements_uz = "";
            information_uz = "";

            // helper ids
            category_id = "";
            employment_id = "";
            gender_id = "";
            experience_id = "";
            education_id = "";
            portal_vacancy_id = "";

            // helper ids converted to int
            i_category_id = 0;
            i_employment_id = 0;
            i_gender_id = 0;
            i_experience_id = 0;
            i_education_id = 0;
            i_portal_vacancy_id = 0;

            e_category_id = VACANCY_CATEGORY.UNKNOWN;
            e_education_id = VACANCY_EDUCATION_LEVEL.UNKNOWN;
            e_employment_id = VACANCY_EMPLOYMENT.UNKNOWN;
            e_experience_id = VACANCY_EXPERIENCE.UNKNOWN;
            e_gender_id = VACANCY_GENDER.UNKNOWN;

            // is valide?
            valide = false;
        }

        public CVacancyItem(
                string seqNum,
                string description_ru,
                string description_uz,
                string category,
                string salary,
                string employment,
                string gender,
                string experience,
                string education,
                string expire_date,
                string department_ru,
                string specialization_ru,
                string requirements_ru,
                string information_ru,
                string department_uz,
                string specialization_uz,
                string requirements_uz,
                string information_uz,

                // helper ids
                string category_id,
                string employment_id,
                string gender_id,
                string experience_id,
                string education_id,
                string portal_vacancy_id
            )
        {
            this.seqNum = seqNum;
            this.description_ru = description_ru;
            this.description_uz = description_uz;
            this.category = category;
            this.salary = salary;
            this.employment = employment;
            this.gender = gender;
            this.experience = experience;
            this.education = education;
            this.expire_date = expire_date;
            this.department_ru = department_ru;
            this.specialization_ru = specialization_ru;
            this.requirements_ru = requirements_ru;
            this.information_ru = information_ru;
            this.department_uz = department_uz;
            this.specialization_uz = specialization_uz;
            this.requirements_uz = requirements_uz;
            this.information_uz = information_uz;

            // helper ids
            this.category_id = category_id;
            this.employment_id = employment_id;
            this.gender_id = gender_id;
            this.experience_id = experience_id;
            this.education_id = education_id;
            this.portal_vacancy_id = portal_vacancy_id;

            // helper ids converted to int and enum
            try { i_category_id = int.Parse(this.category_id); e_category_id = (VACANCY_CATEGORY)i_category_id; }
            catch { }
            try { i_employment_id = int.Parse(this.employment_id); e_employment_id = (VACANCY_EMPLOYMENT)i_employment_id; }
            catch { }
            try { i_gender_id = int.Parse(this.gender_id); e_gender_id = (VACANCY_GENDER)i_gender_id; }
            catch { }
            try { i_experience_id = int.Parse(this.experience_id); e_experience_id = (VACANCY_EXPERIENCE)i_experience_id; }
            catch { }
            try { i_education_id = int.Parse(this.education_id); e_education_id = (VACANCY_EDUCATION_LEVEL)i_education_id; }
            catch { }
            try { i_portal_vacancy_id = int.Parse(this.portal_vacancy_id); }
            catch { }
        }
    }
}
