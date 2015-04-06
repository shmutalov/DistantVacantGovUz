using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            try { i_portal_vacancy_id = int.Parse( this.portal_vacancy_id ); } catch { }
        }
    }

    public enum VACANCY_FILE_VERSION
    {
        VERSION_1, // xls/xlsx 1
        VERSION_2, // xls/xlsx 2
        VERSION_3, // xml 1
        UNKNOWN = -1
    }

    public static class CVacancyFileType
    {
        private static string errorMessage = "";

        public static string GetLastError()
        {
            return errorMessage;
        }

        public static List<CVacancyItem> OpenFile (string fileName)
        {
            BinaryReader reader;
            VACANCY_FILE_VERSION ver = VACANCY_FILE_VERSION.UNKNOWN;

            using (reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                try
                {
                    byte [] bytes = reader.ReadBytes(3);

                    //D0 CF 11 = xls version
                    if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        NPOI.HSSF.UserModel.HSSFWorkbook xlWb = new NPOI.HSSF.UserModel.HSSFWorkbook(reader.BaseStream);
                        NPOI.HSSF.UserModel.HSSFSheet xlSheet = (NPOI.HSSF.UserModel.HSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_1;
                        }
                        else
                        {
                            ver = VACANCY_FILE_VERSION.UNKNOWN;
                        }
                    }
                    //EF BB BF = xml version
                    else if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        ver = VACANCY_FILE_VERSION.VERSION_3;
                    }
                    // 50 4B 03 = xlsx version (unsupported for now by ExcelLibrary)
                    else if (bytes[0] == 0x50 && bytes[1] == 0x4B && bytes[2] == 0x03)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        NPOI.XSSF.UserModel.XSSFWorkbook xlWb = new NPOI.XSSF.UserModel.XSSFWorkbook(reader.BaseStream);
                        NPOI.XSSF.UserModel.XSSFSheet xlSheet = (NPOI.XSSF.UserModel.XSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_1;
                        }
                        else
                        {
                            ver = VACANCY_FILE_VERSION.UNKNOWN;
                        }
                    }
                    else
                    {
                        errorMessage = "Unknown file version";
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return null;
                }
            }

            switch (ver)
            {
                case VACANCY_FILE_VERSION.VERSION_1:
                    return OpenFileVer1(fileName);
                case VACANCY_FILE_VERSION.VERSION_2:
                    return OpenFileVer2(fileName);
                case VACANCY_FILE_VERSION.VERSION_3:
                    return OpenFileVer3(fileName);
                default:
                    errorMessage = "Unknown file version";
                    return null;
            }
        }

        public static bool SaveFile(string fileName, List<CVacancyItem> vacancies)
        {
            return false;
        }

        public static bool SaveFileAs(string fileName, List<CVacancyItem> vacancies, VACANCY_FILE_VERSION ver)
        {
            return false;
        }

        private static List<CVacancyItem> OpenFileVer1(string fileName)
        {
            NPOI.SS.UserModel.IWorkbook xlWb;
            NPOI.SS.UserModel.ISheet xlSheet;

            xlWb = NPOI.SS.UserModel.WorkbookFactory.Create(fileName);

            xlSheet = xlWb.GetSheetAt(0);
            
            List<CVacancyItem> ret = new List<CVacancyItem>();

            int i = 0;

            //while (!xlSheet.Cells[i, 0].IsEmpty)
            while (!(xlSheet.GetRow(i) == null))
            {
                if (i > 1)
                {
                    ret.Add(new CVacancyItem(
                                xlSheet.GetRow(i).GetCell(0).StringCellValue
                                , xlSheet.GetRow(i).GetCell(1).StringCellValue
                                , xlSheet.GetRow(i).GetCell(2).StringCellValue
                                , xlSheet.GetRow(i).GetCell(3).StringCellValue
                                , xlSheet.GetRow(i).GetCell(4).StringCellValue
                                , xlSheet.GetRow(i).GetCell(5).StringCellValue
                                , xlSheet.GetRow(i).GetCell(6).StringCellValue
                                , xlSheet.GetRow(i).GetCell(7).StringCellValue
                                , xlSheet.GetRow(i).GetCell(8).StringCellValue
                                , xlSheet.GetRow(i).GetCell(9).StringCellValue
                                , xlSheet.GetRow(i).GetCell(10).StringCellValue
                                , xlSheet.GetRow(i).GetCell(11).StringCellValue
                                , xlSheet.GetRow(i).GetCell(12).StringCellValue
                                , xlSheet.GetRow(i).GetCell(13).StringCellValue
                                , xlSheet.GetRow(i).GetCell(14).StringCellValue
                                , xlSheet.GetRow(i).GetCell(15).StringCellValue
                                , xlSheet.GetRow(i).GetCell(16).StringCellValue
                                , xlSheet.GetRow(i).GetCell(17).StringCellValue
                                , xlSheet.GetRow(i).GetCell(18).StringCellValue
                                , xlSheet.GetRow(i).GetCell(19).StringCellValue
                                , xlSheet.GetRow(i).GetCell(20).StringCellValue
                                , xlSheet.GetRow(i).GetCell(21).StringCellValue
                                , xlSheet.GetRow(i).GetCell(22).StringCellValue
                                , "0"
                            )
                        );
                }

                i++;
            }

            return ret;
        }

        private static List<CVacancyItem> OpenFileVer2(string fileName)
        {
            NPOI.SS.UserModel.IWorkbook xlWb;
            NPOI.SS.UserModel.ISheet xlSheet;

            xlWb = NPOI.SS.UserModel.WorkbookFactory.Create(fileName);

            xlSheet = xlWb.GetSheetAt(0);

            List<CVacancyItem> ret = new List<CVacancyItem>();

            int i = 0;

            //while (!xlSheet.Cells[i, 0].IsEmpty)
            while (!(xlSheet.GetRow(i) == null))
            {
                if (i > 1)
                {
                    ret.Add(new CVacancyItem(
                                xlSheet.GetRow(i).GetCell(0).StringCellValue
                                , xlSheet.GetRow(i).GetCell(1).StringCellValue
                                , xlSheet.GetRow(i).GetCell(2).StringCellValue
                                , xlSheet.GetRow(i).GetCell(3).StringCellValue
                                , xlSheet.GetRow(i).GetCell(4).StringCellValue
                                , xlSheet.GetRow(i).GetCell(5).StringCellValue
                                , xlSheet.GetRow(i).GetCell(6).StringCellValue
                                , xlSheet.GetRow(i).GetCell(7).StringCellValue
                                , xlSheet.GetRow(i).GetCell(8).StringCellValue
                                , xlSheet.GetRow(i).GetCell(9).StringCellValue
                                , xlSheet.GetRow(i).GetCell(10).StringCellValue
                                , xlSheet.GetRow(i).GetCell(11).StringCellValue
                                , xlSheet.GetRow(i).GetCell(12).StringCellValue
                                , xlSheet.GetRow(i).GetCell(13).StringCellValue
                                , xlSheet.GetRow(i).GetCell(14).StringCellValue
                                , xlSheet.GetRow(i).GetCell(15).StringCellValue
                                , xlSheet.GetRow(i).GetCell(16).StringCellValue
                                , xlSheet.GetRow(i).GetCell(17).StringCellValue
                                , xlSheet.GetRow(i).GetCell(18).StringCellValue
                                , xlSheet.GetRow(i).GetCell(19).StringCellValue
                                , xlSheet.GetRow(i).GetCell(20).StringCellValue
                                , xlSheet.GetRow(i).GetCell(21).StringCellValue
                                , xlSheet.GetRow(i).GetCell(22).StringCellValue
                                , xlSheet.GetRow(i).GetCell(23).StringCellValue
                            )
                        );
                }

                i++;
            }

            return ret;
        }

        private static List<CVacancyItem> OpenFileVer3(string fileName)
        {
            return null;
        }
    }
}
