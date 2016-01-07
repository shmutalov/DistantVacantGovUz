using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace DistantVacantGovUz.Utils
{
    public static class VacancyFileUtil
    {
        private static string _errorMessage = string.Empty;

        public static string GetLastError()
        {
            return _errorMessage;
        }

        public static List<VacancyItem> OpenFile(string fileName)
        {
            BinaryReader reader;
            var ver = VacancyFileVersion.Unknown;

            using (reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                try
                {
                    var bytes = reader.ReadBytes(3);

                    //D0 CF 11 = xls version
                    if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        var xlWb = new HSSFWorkbook(reader.BaseStream);
                        var xlSheet = (HSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VacancyFileVersion.Version2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VacancyFileVersion.Version1;
                        }
                        else
                        {
                            ver = VacancyFileVersion.Unknown;
                        }
                    }
                    //EF BB BF = xml version
                    else if (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                    //else if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        ver = VacancyFileVersion.Version3;
                    }
                    // 50 4B 03 = xlsx version (unsupported for now by ExcelLibrary)
                    else if (bytes[0] == 0x50 && bytes[1] == 0x4B && bytes[2] == 0x03)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        var xlWb = new NPOI.XSSF.UserModel.XSSFWorkbook(reader.BaseStream);
                        var xlSheet = (NPOI.XSSF.UserModel.XSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VacancyFileVersion.Version2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VacancyFileVersion.Version1;
                        }
                        else
                        {
                            ver = VacancyFileVersion.Unknown;
                        }
                    }
                    else
                    {
                        _errorMessage = "Unknown file version";
                    }
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                    return null;
                }
            }

            switch (ver)
            {
                case VacancyFileVersion.Version1:
                    return OpenFileVer1(fileName);
                case VacancyFileVersion.Version2:
                    return OpenFileVer2(fileName);
                case VacancyFileVersion.Version3:
                    return OpenFileVer3(fileName);
                default:
                    _errorMessage = "Unknown file version";
                    return null;
            }
        }

        public static bool SaveFile(string fileName, List<VacancyItem> vacancies)
        {
            // default file version is VERSION_3
            return SaveFileAsVer3(fileName, vacancies);
        }

        public static bool SaveFileAs(string fileName, List<VacancyItem> vacancies, VacancyFileVersion ver)
        {
            switch (ver)
            {
                case VacancyFileVersion.Version1:
                    return SaveFileAsVer1(fileName, vacancies);
                case VacancyFileVersion.Version2:
                    return SaveFileAsVer2(fileName, vacancies);
                case VacancyFileVersion.Version3:
                    return SaveFileAsVer3(fileName, vacancies);
                default:
                    return false;
            }
        }

        private static bool SaveFileAsVer1(string fileName, List<VacancyItem> vacancies)
        {
            #region {Excel document init}

            var xlWb = HSSFWorkbook.Create(NPOI.HSSF.Model.InternalWorkbook.CreateWorkbook());
            var xlSheet = (HSSFSheet)xlWb.CreateSheet("Vacancies");

            FileStream writer;

            try
            {
                writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception)
            {
                return false;
            }

            var currentRow = 0;
            var currentCol = 0;

            #endregion

            #region {Table header column names}

            var dataTableColumnNames = new Dictionary<string, string>
            {
                ["sequence_num"] = "№",
                ["description_ru"] = "Русское наименование",
                ["description_uz"] = "Узбекское наименование (латиницой)",
                ["category"] = "Категория",
                ["salary"] = "Заработная плата",
                ["employment"] = "Занятость",
                ["gender"] = "Пол",
                ["experience"] = "Необходимый стаж",
                ["education"] = "Образование",
                ["expire_date"] = "Действителен до",
                ["department_ru"] = "Отдел / Подразделение (на русском)",
                ["specialization_ru"] = "Функциональность (на русском)",
                ["requirements_ru"] = "Требования (на русском)",
                ["information_ru"] = "Дополнительная информация (на русском)",
                ["department_uz"] = "Отдел / Подразделение (на узбекском)",
                ["specialization_uz"] = "Функциональность (на узбекском)",
                ["requirements_uz"] = "Требования (на узбекском)",
                ["information_uz"] = "Дополнительная информация (на узбекском)",
                ["category_id"] = "CAT_ID",
                ["employment_id"] = "EMP_ID",
                ["gender_id"] = "GENDER_ID",
                ["experience_id"] = "EXP_ID",
                ["education_id"] = "EDU_ID"
            };

            //dataTableColumnNames["portal_vacancy_id"] = "PORTAL_VAC_ID";
            #endregion

            #region {Table header}
            // table header
            var columnNamesRow = (HSSFRow)xlSheet.CreateRow(currentRow);

            var cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["sequence_num"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["category"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["salary"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["education"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["expire_date"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_uz"]);

            // "IDs"
            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["category_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol, CellType.String);
            cell.SetCellValue(dataTableColumnNames["education_id"]);

            currentRow++;
            currentCol = 0;

            var columnNumsRow = (HSSFRow)xlSheet.CreateRow(currentRow);

            // table header column numbers
            //for (int i = 0; i < 24; i++)
            for (var i = 0; i < 23; i++)
            {
                cell = (HSSFCell)columnNumsRow.CreateCell(currentCol++, CellType.String);
                cell.SetCellValue(currentCol);
            }

            currentRow++;
            currentCol = 0;
            #endregion

            #region {Table data}
            if (vacancies != null && vacancies.Count > 0)
            {
                foreach (var vacancy in vacancies)
                {
                    var dataRow = (HSSFRow)xlSheet.CreateRow(currentRow);

                    var dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SequenceNumber);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DescriptionRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DescriptionUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.CategoryString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.Salary);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EmploymentString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.GenderString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExperienceString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EducationString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExpireDate);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DepartmentRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SpecializationRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.RequirementsRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.InformationRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DepartmentUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SpecializationUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.RequirementsUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.InformationUz);

                    // "IDs"
                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.CategoryId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EmploymentId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.GenderId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExperienceId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol, CellType.String);
                    dataCell.SetCellValue(vacancy.EducationId.ToString());

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

        private static bool SaveFileAsVer2(string fileName, List<VacancyItem> vacancies)
        {
            #region {Excel document init}
            var xlWb = HSSFWorkbook.Create(NPOI.HSSF.Model.InternalWorkbook.CreateWorkbook());
            var xlSheet = (HSSFSheet)xlWb.CreateSheet("Vacancies");

            //MemoryStream stream = new MemoryStream();
            FileStream writer;

            try
            {
                writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception)
            {
                return false;
            }

            var currentRow = 0;
            var currentCol = 0;
            #endregion

            #region {Table header column names}

            var dataTableColumnNames = new Dictionary<string, string>
            {
                ["sequence_num"] = "№",
                ["description_ru"] = "Русское наименование",
                ["description_uz"] = "Узбекское наименование (латиницой)",
                ["category"] = "Категория",
                ["salary"] = "Заработная плата",
                ["employment"] = "Занятость",
                ["gender"] = "Пол",
                ["experience"] = "Необходимый стаж",
                ["education"] = "Образование",
                ["expire_date"] = "Действителен до",
                ["department_ru"] = "Отдел / Подразделение (на русском)",
                ["specialization_ru"] = "Функциональность (на русском)",
                ["requirements_ru"] = "Требования (на русском)",
                ["information_ru"] = "Дополнительная информация (на русском)",
                ["department_uz"] = "Отдел / Подразделение (на узбекском)",
                ["specialization_uz"] = "Функциональность (на узбекском)",
                ["requirements_uz"] = "Требования (на узбекском)",
                ["information_uz"] = "Дополнительная информация (на узбекском)",
                ["category_id"] = "CAT_ID",
                ["employment_id"] = "EMP_ID",
                ["gender_id"] = "GENDER_ID",
                ["experience_id"] = "EXP_ID",
                ["education_id"] = "EDU_ID",
                ["portal_vacancy_id"] = "PORTAL_VAC_ID"
            };

            #endregion

            #region {Table header}
            // table header
            var columnNamesRow = (HSSFRow)xlSheet.CreateRow(currentRow);

            var cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["sequence_num"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["description_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["category"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["salary"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["education"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["expire_date"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_ru"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["department_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["specialization_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["requirements_uz"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["information_uz"]);

            // "IDs"
            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["category_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["employment_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["gender_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["experience_id"]);

            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, CellType.String);
            cell.SetCellValue(dataTableColumnNames["education_id"]);

            // PORTAL ID
            cell = (HSSFCell)columnNamesRow.CreateCell(currentCol, CellType.String);
            cell.SetCellValue(dataTableColumnNames["portal_vacancy_id"]);

            currentRow++;
            currentCol = 0;

            var columnNumsRow = (HSSFRow)xlSheet.CreateRow(currentRow);

            // table header column numbers
            for (var i = 0; i < 24; i++)
            {
                cell = (HSSFCell)columnNumsRow.CreateCell(currentCol++, CellType.String);
                cell.SetCellValue(currentCol);
            }

            currentRow++;
            currentCol = 0;
            #endregion

            #region {Table data}
            if (vacancies != null && vacancies.Count > 0)
            {
                foreach (var vacancy in vacancies)
                {
                    var dataRow = (HSSFRow)xlSheet.CreateRow(currentRow);

                    var dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SequenceNumber);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DescriptionRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DescriptionUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.CategoryString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.Salary);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EmploymentString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.GenderString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExperienceString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EducationString);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExpireDate);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DepartmentRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SpecializationRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.RequirementsRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.InformationRu);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.DepartmentUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.SpecializationUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.RequirementsUz);

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.InformationUz);

                    // "IDs"
                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.CategoryId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EmploymentId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.GenderId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.ExperienceId.ToString());

                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol++, CellType.String);
                    dataCell.SetCellValue(vacancy.EducationId.ToString());

                    // PORTAL ID
                    dataCell = (HSSFCell)dataRow.CreateCell(currentCol, CellType.String);
                    dataCell.SetCellValue(vacancy.PortalVacancyIdString);

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

        private static bool SaveFileAsVer3(string fileName, List<VacancyItem> vacancies)
        {
            #region {Xml document init}
            var xml = new XmlDocument();

            var root = xml.CreateElement("vacancies");
            root.SetAttribute("version", "3"); // version 3
            xml.AppendChild(root);
            xml.InsertBefore(xml.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
            #endregion

            #region {Data}
            if (vacancies != null && vacancies.Count > 0)
            {
                foreach (var vacancy in vacancies)
                {
                    var vacList = xml.CreateElement("VacancyItem");
                    vacList.SetAttribute("sequence_number", vacancy.SequenceNumber);

                    var el = xml.CreateElement("description_ru");
                    var xText = xml.CreateTextNode(vacancy.DescriptionRu);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("description_uz");
                    xText = xml.CreateTextNode(vacancy.DescriptionUz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("category_id");
                    el.SetAttribute("id", vacancy.CategoryIdString);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("salary");
                    xText = xml.CreateTextNode(vacancy.Salary);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("employment_id");
                    el.SetAttribute("id", vacancy.EmploymentIdString);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("gender_id");
                    el.SetAttribute("id", vacancy.GenderIdString);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("experience_id");
                    el.SetAttribute("id", vacancy.ExperienceIdString);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("education_id");
                    el.SetAttribute("id", vacancy.EducationIdString);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("expire_date");
                    el.SetAttribute("value", vacancy.ExpireDate);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("department_ru");
                    xText = xml.CreateTextNode(vacancy.DepartmentRu);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("specialization_ru");
                    xText = xml.CreateTextNode(vacancy.SpecializationRu);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("requirements_ru");
                    xText = xml.CreateTextNode(vacancy.RequirementsRu);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("information_ru");
                    xText = xml.CreateTextNode(vacancy.InformationRu);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("department_uz");
                    xText = xml.CreateTextNode(vacancy.DepartmentUz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("specialization_uz");
                    xText = xml.CreateTextNode(vacancy.SpecializationUz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("requirements_uz");
                    xText = xml.CreateTextNode(vacancy.RequirementsUz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("information_uz");
                    xText = xml.CreateTextNode(vacancy.InformationUz);
                    el.AppendChild(xText);

                    vacList.AppendChild(el);

                    el = xml.CreateElement("portal_vacancy_id");
                    el.SetAttribute("id", vacancy.PortalVacancyIdString);

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
            catch (Exception)
            {
                return false;
            }
            #endregion

            return true;
        }

        private static List<VacancyItem> OpenFileVer1(string fileName)
        {
            var xlWb = WorkbookFactory.Create(fileName);

            var xlSheet = xlWb.GetSheetAt(0);

            var ret = new List<VacancyItem>();

            var i = 0;

            while (xlSheet.GetRow(i) != null)
            {
                if (i > 1)
                {
                    ret.Add(new VacancyItem(
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

        private static List<VacancyItem> OpenFileVer2(string fileName)
        {
            var xlWb = WorkbookFactory.Create(fileName);

            var xlSheet = xlWb.GetSheetAt(0);

            var ret = new List<VacancyItem>();

            var i = 0;

            //while (!xlSheet.Cells[i, 0].IsEmpty)
            while (xlSheet.GetRow(i) != null)
            {
                if (i > 1)
                {
                    ret.Add(new VacancyItem(
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

        private static List<VacancyItem> OpenFileVer3(string fileName)
        {
            var xml = new XmlDocument();
            var vacs = new List<VacancyItem>();

            try
            {
                xml.Load(fileName);

                var root = xml.DocumentElement;

                if (root == null)
                    return null;

                // Check version
                if (root.Name != "vacancies" || root.GetAttribute("version") != "3")
                    return null;

                foreach (XmlElement element in root.ChildNodes)
                {
                    if (element.Name == "VacancyItem")
                    {
                        var vacancy = new VacancyItem
                        {
                            SequenceNumber = element.GetAttribute("sequence_number")
                        };

                        foreach (XmlElement e in element.ChildNodes)
                        {
                            switch (e.Name)
                            {
                                case "description_ru":
                                    vacancy.DescriptionRu = e.InnerText;
                                    break;
                                case "description_uz":
                                    vacancy.DescriptionUz = e.InnerText;
                                    break;
                                case "category_id":
                                    vacancy.CategoryIdString = e.GetAttribute("id");
                                    break;
                                case "salary":
                                    vacancy.Salary = e.InnerText;
                                    break;
                                case "employment_id":
                                    vacancy.EmploymentIdString = e.GetAttribute("id");
                                    break;
                                case "gender_id":
                                    vacancy.GenderIdString = e.GetAttribute("id");
                                    break;
                                case "experience_id":
                                    vacancy.ExperienceIdString = e.GetAttribute("id");
                                    break;
                                case "education_id":
                                    vacancy.EducationIdString = e.GetAttribute("id");
                                    break;
                                case "expire_date":
                                    vacancy.ExpireDate = e.GetAttribute("value");
                                    break;
                                case "department_ru":
                                    vacancy.DepartmentRu = e.InnerText;
                                    break;
                                case "specialization_ru":
                                    vacancy.SpecializationRu = e.InnerText;
                                    break;
                                case "requirements_ru":
                                    vacancy.RequirementsRu = e.InnerText;
                                    break;
                                case "information_ru":
                                    vacancy.InformationRu = e.InnerText;
                                    break;
                                case "department_uz":
                                    vacancy.DepartmentUz = e.InnerText;
                                    break;
                                case "specialization_uz":
                                    vacancy.SpecializationUz = e.InnerText;
                                    break;
                                case "requirements_uz":
                                    vacancy.RequirementsUz = e.InnerText;
                                    break;
                                case "information_uz":
                                    vacancy.InformationUz = e.InnerText;
                                    break;
                                case "portal_vacancy_id":
                                    vacancy.PortalVacancyIdString = e.GetAttribute("id");
                                    break;
                                default:
                                    continue;
                            }
                        }

                        vacancy.ResetIds();
                        vacs.Add(vacancy);
                    }
                }

                return vacs;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
