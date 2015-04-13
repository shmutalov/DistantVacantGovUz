using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace DistantVacantGovUz
{
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
                    else if (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                    //else if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
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
            // default file version is VERSION_3
            return SaveFileAsVer3(fileName, vacancies);
        }

        public static bool SaveFileAs(string fileName, List<CVacancyItem> vacancies, VACANCY_FILE_VERSION ver)
        {
            switch (ver)
            {
                case VACANCY_FILE_VERSION.VERSION_1:
                    return SaveFileAsVer1(fileName, vacancies);
                case VACANCY_FILE_VERSION.VERSION_2:
                    return SaveFileAsVer2(fileName, vacancies);
                case VACANCY_FILE_VERSION.VERSION_3:
                    return SaveFileAsVer3(fileName, vacancies);
                default:
                    return false;
            }
        }

        private static bool SaveFileAsVer1(string fileName, List<CVacancyItem> vacancies)
        {
            #region {Excel document init}
            NPOI.HSSF.UserModel.HSSFWorkbook xlWb = NPOI.HSSF.UserModel.HSSFWorkbook.Create(NPOI.HSSF.Model.InternalWorkbook.CreateWorkbook());
            NPOI.HSSF.UserModel.HSSFSheet xlSheet = (NPOI.HSSF.UserModel.HSSFSheet)xlWb.CreateSheet("Vacancies");

            //MemoryStream stream = new MemoryStream();
            FileStream writer = null;

            try
            {
                writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception ex)
            {
                return false;
            }

            int currentRow = 0;
            int currentCol = 0;
            #endregion

            #region {Table header column names}
            Dictionary<String, String> dataTableColumnNames = new Dictionary<String, String>();

            dataTableColumnNames["sequence_num"] = "№";
            dataTableColumnNames["description_ru"] = "Русское наименование";
            dataTableColumnNames["description_uz"] = "Узбекское наименование (латиницой)";
            dataTableColumnNames["category"] = "Категория";
            dataTableColumnNames["salary"] = "Заработная плата";
            dataTableColumnNames["employment"] = "Занятость";
            dataTableColumnNames["gender"] = "Пол";
            dataTableColumnNames["experience"] = "Необходимый стаж";
            dataTableColumnNames["education"] = "Образование";
            dataTableColumnNames["expire_date"] = "Действителен до";
            dataTableColumnNames["department_ru"] = "Отдел / Подразделение (на русском)";
            dataTableColumnNames["specialization_ru"] = "Функциональность (на русском)";
            dataTableColumnNames["requirements_ru"] = "Требования (на русском)";
            dataTableColumnNames["information_ru"] = "Дополнительная информация (на русском)";
            dataTableColumnNames["department_uz"] = "Отдел / Подразделение (на узбекском)";
            dataTableColumnNames["specialization_uz"] = "Функциональность (на узбекском)";
            dataTableColumnNames["requirements_uz"] = "Требования (на узбекском)";
            dataTableColumnNames["information_uz"] = "Дополнительная информация (на узбекском)";
            dataTableColumnNames["category_id"] = "CAT_ID";
            dataTableColumnNames["employment_id"] = "EMP_ID";
            dataTableColumnNames["gender_id"] = "GENDER_ID";
            dataTableColumnNames["experience_id"] = "EXP_ID";
            dataTableColumnNames["education_id"] = "EDU_ID";
            //dataTableColumnNames["portal_vacancy_id"] = "PORTAL_VAC_ID";
            #endregion

            #region {Table header}
            // table header
            NPOI.HSSF.UserModel.HSSFRow columnNamesRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);
            NPOI.HSSF.UserModel.HSSFCell cell;

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["sequence_num"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["category"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["salary"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["education"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["expire_date"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_uz"]);

            // "IDs"
            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["category_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["education_id"]);

            // PORTAL ID
            //cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            //cell.SetCellValue(dataTableColumnNames["portal_vacancy_id"]);

            currentRow++;
            currentCol = 0;

            NPOI.HSSF.UserModel.HSSFRow columnNumsRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);

            // table header column numbers
            //for (int i = 0; i < 24; i++)
            for (int i = 0; i < 23; i++)
            {
                cell = (NPOI.HSSF.UserModel.HSSFCell)columnNumsRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(currentCol);
            }

            currentRow++;
            currentCol = 0;
            #endregion

            #region {Table data}
            if (vacancies != null && vacancies.Count > 0)
            {
                for (int i = 0; i < vacancies.Count; i++)
                {
                    NPOI.HSSF.UserModel.HSSFRow dataRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);
                    NPOI.HSSF.UserModel.HSSFCell dataCell;

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].seqNum);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].description_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].description_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].category);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].salary);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].employment);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].gender);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].experience);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].education);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].expire_date);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].department_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].specialization_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].requirements_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].information_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].department_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].specialization_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].requirements_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].information_uz);

                    // "IDs"
                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_category_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_employment_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_gender_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_experience_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_education_id.ToString());

                    // PORTAL ID
                    //dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    //dataCell.SetCellValue(vacancies[i].portal_vacancy_id);

                    currentRow++;
                    currentCol = 0;
                }
            }
            #endregion

            #region {Excel document finalize}
            xlWb.Write(writer);
            writer.Flush();
            writer.Close();
            #endregion

            return true;
        }

        private static bool SaveFileAsVer2(string fileName, List<CVacancyItem> vacancies)
        {
            #region {Excel document init}
            NPOI.HSSF.UserModel.HSSFWorkbook xlWb = NPOI.HSSF.UserModel.HSSFWorkbook.Create(NPOI.HSSF.Model.InternalWorkbook.CreateWorkbook());
            NPOI.HSSF.UserModel.HSSFSheet xlSheet = (NPOI.HSSF.UserModel.HSSFSheet)xlWb.CreateSheet("Vacancies");

            //MemoryStream stream = new MemoryStream();
            FileStream writer = null;

            try
            {
                writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception ex)
            {
                return false;
            }

            int currentRow = 0;
            int currentCol = 0;
            #endregion

            #region {Table header column names}
            Dictionary<String, String> dataTableColumnNames = new Dictionary<String, String>();

            dataTableColumnNames["sequence_num"] = "№";
            dataTableColumnNames["description_ru"] = "Русское наименование";
            dataTableColumnNames["description_uz"] = "Узбекское наименование (латиницой)";
            dataTableColumnNames["category"] = "Категория";
            dataTableColumnNames["salary"] = "Заработная плата";
            dataTableColumnNames["employment"] = "Занятость";
            dataTableColumnNames["gender"] = "Пол";
            dataTableColumnNames["experience"] = "Необходимый стаж";
            dataTableColumnNames["education"] = "Образование";
            dataTableColumnNames["expire_date"] = "Действителен до";
            dataTableColumnNames["department_ru"] = "Отдел / Подразделение (на русском)";
            dataTableColumnNames["specialization_ru"] = "Функциональность (на русском)";
            dataTableColumnNames["requirements_ru"] = "Требования (на русском)";
            dataTableColumnNames["information_ru"] = "Дополнительная информация (на русском)";
            dataTableColumnNames["department_uz"] = "Отдел / Подразделение (на узбекском)";
            dataTableColumnNames["specialization_uz"] = "Функциональность (на узбекском)";
            dataTableColumnNames["requirements_uz"] = "Требования (на узбекском)";
            dataTableColumnNames["information_uz"] = "Дополнительная информация (на узбекском)";
            dataTableColumnNames["category_id"] = "CAT_ID";
            dataTableColumnNames["employment_id"] = "EMP_ID";
            dataTableColumnNames["gender_id"] = "GENDER_ID";
            dataTableColumnNames["experience_id"] = "EXP_ID";
            dataTableColumnNames["education_id"] = "EDU_ID";
            dataTableColumnNames["portal_vacancy_id"] = "PORTAL_VAC_ID";
            #endregion

            #region {Table header}
            // table header
            NPOI.HSSF.UserModel.HSSFRow columnNamesRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);
            NPOI.HSSF.UserModel.HSSFCell cell;

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["sequence_num"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["category"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["salary"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["education"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["expire_date"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_ru"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_uz"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_uz"]);

            // "IDs"
            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["category_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience_id"]);

            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["education_id"]);

            // PORTAL ID
            cell = (NPOI.HSSF.UserModel.HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue(dataTableColumnNames["portal_vacancy_id"]);

            currentRow++;
            currentCol = 0;

            NPOI.HSSF.UserModel.HSSFRow columnNumsRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);

            // table header column numbers
            for (int i = 0; i < 24; i++)
            {
                cell = (NPOI.HSSF.UserModel.HSSFCell)columnNumsRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(currentCol);
            }

            currentRow++;
            currentCol = 0;
            #endregion

            #region {Table data}
            if (vacancies != null && vacancies.Count > 0)
            {
                for (int i = 0; i < vacancies.Count; i++)
                {
                    NPOI.HSSF.UserModel.HSSFRow dataRow = (NPOI.HSSF.UserModel.HSSFRow)xlSheet.CreateRow(currentRow);
                    NPOI.HSSF.UserModel.HSSFCell dataCell;

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].seqNum);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].description_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].description_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].category);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].salary);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].employment);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].gender);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].experience);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].education);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].expire_date);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].department_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].specialization_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].requirements_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].information_ru);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].department_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].specialization_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].requirements_uz);

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].information_uz);

                    // "IDs"
                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_category_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_employment_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_gender_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_experience_id.ToString());

                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].i_education_id.ToString());

                    // PORTAL ID
                    dataCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    dataCell.SetCellValue(vacancies[i].portal_vacancy_id);

                    currentRow++;
                    currentCol = 0;
                }
            }
            #endregion

            #region {Excel document finalize}
            xlWb.Write(writer);
            writer.Flush();
            writer.Close();
            #endregion

            return true;
        }

        private static bool SaveFileAsVer3(string fileName, List<CVacancyItem> vacancies)
        {
            #region {Xml document init}
            XmlDocument xml = new XmlDocument();

            XmlElement root = xml.CreateElement("vacancies");
            root.SetAttribute("version", "3"); // version 3
            xml.AppendChild(root);
            xml.InsertBefore(xml.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
            #endregion

            #region {Data}
            if (vacancies != null && vacancies.Count > 0)
            {
                for (int i = 0; i < vacancies.Count; i++)
                {
                    XmlElement vacList;

                    vacList = xml.CreateElement("VacancyItem");
                    vacList.SetAttribute("sequence_number", vacancies[i].seqNum);

                    XmlElement el;
                    XmlText xText;

                    el = xml.CreateElement("description_ru");
                    xText = xml.CreateTextNode(vacancies[i].description_ru);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("description_uz");
                    xText = xml.CreateTextNode(vacancies[i].description_uz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("category_id");
                    el.SetAttribute("id", vacancies[i].category_id);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("salary");
                    xText = xml.CreateTextNode(vacancies[i].salary);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("employment_id");
                    el.SetAttribute("id", vacancies[i].employment_id);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("gender_id");
                    el.SetAttribute("id", vacancies[i].gender_id);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("experience_id");
                    el.SetAttribute("id", vacancies[i].experience_id);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("education_id");
                    el.SetAttribute("id", vacancies[i].education_id);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("expire_date");
                    el.SetAttribute("value", vacancies[i].expire_date);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("department_ru");
                    xText = xml.CreateTextNode(vacancies[i].department_ru);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("specialization_ru");
                    xText = xml.CreateTextNode(vacancies[i].specialization_ru);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("requirements_ru");
                    xText = xml.CreateTextNode(vacancies[i].requirements_ru);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("information_ru");
                    xText = xml.CreateTextNode(vacancies[i].information_ru);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("department_uz");
                    xText = xml.CreateTextNode(vacancies[i].department_uz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("specialization_uz");
                    xText = xml.CreateTextNode(vacancies[i].specialization_uz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("requirements_uz");
                    xText = xml.CreateTextNode(vacancies[i].requirements_uz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("information_uz");
                    xText = xml.CreateTextNode(vacancies[i].information_uz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("portal_vacancy_id");
                    el.SetAttribute("id", vacancies[i].portal_vacancy_id);

                    vacList.AppendChild(el);

                    root.AppendChild(vacList);
                }
            }
            #endregion

            #region {Xml finalize}
            try
            {
                xml.Save(fileName);
            }
            catch (Exception ex)
            {
                return false;
            }
            #endregion

            return true;
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
            XmlDocument xml = new XmlDocument();
            List<CVacancyItem> vacs = new List<CVacancyItem>();

            try
            {
                xml.Load(fileName);

                XmlElement root = xml.DocumentElement;

                // Check version
                if (root.Name == "vacancies" && root.GetAttribute("version") == "3")
                {
                    foreach (XmlElement n in root.ChildNodes)
                    {
                        if (n.Name == "VacancyItem")
                        {
                            CVacancyItem v = new CVacancyItem();

                            v.seqNum = n.GetAttribute("sequence_number");

                            foreach (XmlElement e in n.ChildNodes)
                            {
                                switch (e.Name)
                                {
                                    case "description_ru":
                                        v.description_ru = e.InnerText;
                                        break;
                                    case "description_uz":
                                        v.description_uz = e.InnerText;
                                        break;
                                    case "category_id":
                                        v.category_id = e.GetAttribute("id");
                                        break;
                                    case "salary":
                                        v.salary = e.InnerText;
                                        break;
                                    case "employment_id":
                                        v.employment_id = e.GetAttribute("id");
                                        break;
                                    case "gender_id":
                                        v.gender_id = e.GetAttribute("id");
                                        break;
                                    case "experience_id":
                                        v.experience_id = e.GetAttribute("id");
                                        break;
                                    case "education_id":
                                        v.education_id = e.GetAttribute("id");
                                        break;
                                    case "expire_date":
                                        v.expire_date = e.GetAttribute("value");
                                        break;
                                    case "department_ru":
                                        v.department_ru = e.InnerText;
                                        break;
                                    case "specialization_ru":
                                        v.specialization_ru = e.InnerText;
                                        break;
                                    case "requirements_ru":
                                        v.requirements_ru = e.InnerText;
                                        break;
                                    case "information_ru":
                                        v.information_ru = e.InnerText;
                                        break;
                                    case "department_uz":
                                        v.department_uz = e.InnerText;
                                        break;
                                    case "specialization_uz":
                                        v.specialization_uz = e.InnerText;
                                        break;
                                    case "requirements_uz":
                                        v.requirements_uz = e.InnerText;
                                        break;
                                    case "information_uz":
                                        v.information_uz = e.InnerText;
                                        break;
                                    case "portal_vacancy_id":
                                        v.portal_vacancy_id = e.GetAttribute("id");
                                        break;
                                    default:
                                        continue;
                                }
                            }

                            v.ResetIds();
                            vacs.Add(v);
                        }
                        else
                            continue;
                    }

                    return vacs;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
