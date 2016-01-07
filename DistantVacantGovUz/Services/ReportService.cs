using System.Collections.Generic;
using System.IO;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using PDF = iTextSharp.text;

namespace DistantVacantGovUz.Services
{
    /// <summary>
    /// Класс для генерации отчетов
    /// </summary>
    public static class ReportService
    {
        /// <summary>
        /// Генерация отчета
        /// </summary>
        /// <param name="reportType">Тип отчета (PDF или XLS)</param>
        /// <param name="reportName">Название отчета</param>
        /// <param name="language">Язык отчета</param>
        /// <param name="parameters">Параметры отчета, словарь вида "название-параметр"</param>
        /// <param name="dataSource">Исходные данные для генерации</param>
        /// <returns>Возвратит байты сгенерированного отчета, или <value>null</value> при ошибки генерации</returns>
        public static byte[] GenerateReport(ReportType reportType, string reportName, string language, Dictionary<string, object> parameters, List<VacancyItem> dataSource)
        {
            switch (reportType)
            {
                case ReportType.Pdf:
                    return GeneratePdfReport(reportName, language, parameters, dataSource);
                case ReportType.Xls:
                    return GenerateXlsReport(reportName, language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GeneratePdfReport(string reportName, string language, Dictionary<string, object> parameters, List<VacancyItem> dataSource)
        {
            switch (reportName)
            {
                case "PRINT_VERSION":
                    return GeneratePrintVersionPdf(language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GenerateXlsReport(string reportName, string language, Dictionary<string, object> parameters, List<VacancyItem> dataSource)
        {
            switch (reportName)
            {
                case "PRINT_VERSION":
                    return GeneratePrintVersionXls(language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GeneratePrintVersionPdf(string language, Dictionary<string, object> parameters, List<VacancyItem> dataSource)
        {
            #region {PDF Document init}
            var document = new PDF.Document(PDF.PageSize.A4.Rotate());
            var stream = new MemoryStream();

            PDF.pdf.PdfWriter.GetInstance(document, stream);
            document.Open();
            #endregion

            #region {Fonts init}
            var baseFont = PDF.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", PDF.pdf.BaseFont.IDENTITY_H, PDF.pdf.BaseFont.NOT_EMBEDDED);
            var baseFontB = PDF.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\timesbd.ttf", PDF.pdf.BaseFont.IDENTITY_H, PDF.pdf.BaseFont.NOT_EMBEDDED);

            var fnt10 = new PDF.Font(baseFont, 10f);
            var fnt9B = new PDF.Font(baseFontB, 9f);
            var fnt10B = new PDF.Font(baseFontB, 10f);
            var fnt8 = new PDF.Font(baseFont, 8f);
            var fnt8B = new PDF.Font(baseFontB, 8f);
            #endregion

            #region {Translations init}
            var dataTableColumnNames = new Dictionary<string, string>();

            switch (language)
            {
                case "ru":
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", @"Наименование" + "\n" + "должности");
                    dataTableColumnNames.Add("category", "Категория");
                    dataTableColumnNames.Add("salary", "Оклад");
                    dataTableColumnNames.Add("employment", "Занятость");
                    dataTableColumnNames.Add("gender", "Пол");
                    dataTableColumnNames.Add("experience", "Необходимый" + "\n" + "стаж");
                    dataTableColumnNames.Add("education", "Образование");
                    dataTableColumnNames.Add("department", "Отдел, подразделение");
                    dataTableColumnNames.Add("specialization", "Функциональность");
                    dataTableColumnNames.Add("requirements", "Требования");
                    dataTableColumnNames.Add("information", "Дополнительная" + "\n" + "информация");
                    break;
                case "uz":
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", "Ish o'rni" + "\n" + "nomlanishi");
                    dataTableColumnNames.Add("category", "Toifa");
                    dataTableColumnNames.Add("salary", "Maosh");
                    dataTableColumnNames.Add("employment", "Bandlik");
                    dataTableColumnNames.Add("gender", "Jinsi");
                    dataTableColumnNames.Add("experience", "Talab etilgan" + "\n" + "ish tajribasi");
                    dataTableColumnNames.Add("education", "Ma'lumot");
                    dataTableColumnNames.Add("department", "Bo'lim, bo'linma");
                    dataTableColumnNames.Add("specialization", "Mutaxassisligi");
                    dataTableColumnNames.Add("requirements", "Talablar");
                    dataTableColumnNames.Add("information", "Qo'shimcha" + "\n" + "ma'lumot");
                    break;
                case "en":
                default:
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", "Job title");
                    dataTableColumnNames.Add("category", "Category");
                    dataTableColumnNames.Add("salary", "Salary");
                    dataTableColumnNames.Add("employment", "Employment");
                    dataTableColumnNames.Add("gender", "Gender");
                    dataTableColumnNames.Add("experience", "Experience");
                    dataTableColumnNames.Add("education", "Education");
                    dataTableColumnNames.Add("department", "Department");
                    dataTableColumnNames.Add("specialization", "Specialization");
                    dataTableColumnNames.Add("requirements", "Requirements");
                    dataTableColumnNames.Add("information", "Additional" + "\n" + "information");
                    break;
            }
            #endregion

            #region {Whom}
            // whom
            if (parameters["whom"] != null && (string)parameters["whom"] != "")
            {
                var pdfTableWhom = new PDF.pdf.PdfPTable(2);

                PDF.pdf.PdfPCell wcell;
                wcell = new PDF.pdf.PdfPCell(new PDF.Phrase(@"", fnt9B));

                var whomColumnWidths = new float[] { 392f, 392f };

                pdfTableWhom.SpacingAfter = 6f;
                pdfTableWhom.LockedWidth = true;
                pdfTableWhom.SetTotalWidth(whomColumnWidths);

                wcell.Phrase = new PDF.Phrase("", fnt9B);
                wcell.Border = PDF.Rectangle.NO_BORDER;
                wcell.HorizontalAlignment = PDF.Element.ALIGN_LEFT;

                pdfTableWhom.AddCell(wcell);

                wcell.Phrase = new PDF.Phrase((string)parameters["whom"], fnt9B);
                wcell.HorizontalAlignment = PDF.Element.ALIGN_RIGHT;

                pdfTableWhom.AddCell(wcell);

                document.Add(pdfTableWhom);
            }
            #endregion

            #region {Header}
            // header
            if (parameters["header"] != null && (string)parameters["header"] != "")
            {
                var phraseHeader = new PDF.Phrase((string)parameters["header"], fnt9B);
                var paragraphHeader = new PDF.Paragraph(phraseHeader);
                paragraphHeader.Alignment = PDF.Element.ALIGN_CENTER;
                paragraphHeader.SpacingAfter = 12f;

                document.Add(paragraphHeader);
            }
            #endregion

            #region {Data table}
            // data
            if (dataSource != null && dataSource.Count > 0)
            {
                var pdfTable = new PDF.pdf.PdfPTable(12);

                // width
                var columnWidths = new float[] { 24f, 96f, 80f, 32f, 24f, 24f, 24f, 24f, 96f, 140f, 140f, 80f };

                pdfTable.LockedWidth = true;
                pdfTable.SetTotalWidth(columnWidths);

                PDF.pdf.PdfPCell cell;

                // table header
                cell = new PDF.pdf.PdfPCell(new PDF.Phrase(dataTableColumnNames["sequence_num"], fnt10B));

                cell.HorizontalAlignment = PDF.Element.ALIGN_CENTER;
                cell.VerticalAlignment = PDF.Element.ALIGN_MIDDLE;

                pdfTable.AddCell(cell);

                cell.Phrase = new PDF.Phrase(dataTableColumnNames["job_title"], fnt10B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["category"], fnt10B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["salary"], fnt8B);
                cell.Rotation = 90; // ROTATE
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["employment"], fnt8B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["gender"], fnt8B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["experience"], fnt8B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["education"], fnt8B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["department"], fnt10B);
                cell.Rotation = 0; // ROTATE revert
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["specialization"], fnt10B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["requirements"], fnt10B);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["information"], fnt8B);
                pdfTable.AddCell(cell);

                switch (language)
                {
                    case "ru":
                        #region {Table data RU}
                        foreach (var vi in dataSource)
                        {
                            // table data
                            cell = new PDF.pdf.PdfPCell(new PDF.Phrase(vi.SequenceNumber, fnt10));

                            cell.HorizontalAlignment = PDF.Element.ALIGN_CENTER;
                            cell.VerticalAlignment = PDF.Element.ALIGN_MIDDLE;

                            pdfTable.AddCell(cell);

                            cell.Phrase = new PDF.Phrase(vi.DescriptionRu, fnt10B);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.CategoryFromIdRu(vi.Category), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.Salary.Replace(" ", "\n"), fnt8);
                            cell.Rotation = 90; // ROTATE
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.EmploymentFromIdRu(vi.Employment), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.GenderFromIdRu(vi.Gender), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.ExperienceFromIdRu(vi.Experience), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.EducationFromIdRu(vi.Education).Replace(" ", "\n"), fnt8); // Образование
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.DepartmentRu, fnt8);
                            cell.Rotation = 0; // ROTATE revert
                            cell.HorizontalAlignment = PDF.Element.ALIGN_LEFT;
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.SpecializationRu, fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.RequirementsRu, fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.InformationRu, fnt8);
                            pdfTable.AddCell(cell);
                        }
                        #endregion
                        break;
                    case "uz":
                        #region {Table data UZ}
                        foreach (var vi in dataSource)
                        {
                            // table data
                            cell = new PDF.pdf.PdfPCell(new PDF.Phrase(vi.SequenceNumber, fnt10));

                            cell.HorizontalAlignment = PDF.Element.ALIGN_CENTER;
                            cell.VerticalAlignment = PDF.Element.ALIGN_MIDDLE;

                            pdfTable.AddCell(cell);

                            cell.Phrase = new PDF.Phrase(vi.DescriptionUz, fnt10B);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.CategoryFromIdUz(vi.Category), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.Salary.Replace(" ", "\n"), fnt8);
                            cell.Rotation = 90; // ROTATE
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.EmploymentFromIdUz(vi.Employment), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.GenderFromIdUz(vi.Gender), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.ExperienceFromIdUz(vi.Experience), fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(Vacancy.EducationFromIdUz(vi.Education).Replace(" ", "\n"), fnt8); // Образование
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.DepartmentUz, fnt8);
                            cell.Rotation = 0; // ROTATE revert
                            cell.HorizontalAlignment = PDF.Element.ALIGN_LEFT;
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.SpecializationUz, fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.RequirementsUz, fnt8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.InformationUz, fnt8);
                            pdfTable.AddCell(cell);
                        }
                        #endregion
                        break;
                    case "en":
                    default:
                        #region {Table data EN}
                        #endregion
                        break;
                }

                document.Add(pdfTable);
            }
            #endregion

            #region {Footer}
            // footer
            if (parameters["footer"] != null && (string)parameters["footer"] != "")
            {
                var phraseFooter = new PDF.Phrase((string)parameters["footer"], fnt9B);
                var paragraphFooter = new PDF.Paragraph(phraseFooter);
                paragraphFooter.Alignment = PDF.Element.ALIGN_LEFT;
                paragraphFooter.SpacingBefore = 6f;
                paragraphFooter.SpacingAfter = 6f;

                document.Add(paragraphFooter);
            }
            #endregion

            #region {Visas}
            // visas
            if (parameters["visas"] != null && ((List<ReportVisaItem>)(parameters["visas"])).Count > 0)
            {
                var visas = (List<ReportVisaItem>)parameters["visas"];

                /*PDF.pdf.PdfPTable pdfTableVisa = new PDF.pdf.PdfPTable(2);

                float[] visaColumnWidths = new float[] { 392f, 392f };*/

                var pdfTableVisa = new PDF.pdf.PdfPTable(3);

                var visaColumnWidths = new float[] { 212f, 212f, 360f };

                pdfTableVisa.SpacingBefore = 12f;
                pdfTableVisa.LockedWidth = true;
                pdfTableVisa.SetTotalWidth(visaColumnWidths);

                PDF.pdf.PdfPCell vcell;
                vcell = new PDF.pdf.PdfPCell(new PDF.Phrase(@"", fnt9B));

                foreach (var visa in visas)
                {
                    vcell.Phrase = new PDF.Phrase(visa.JobTitle, fnt9B);
                    vcell.Border = PDF.Rectangle.NO_BORDER;
                    vcell.HorizontalAlignment = PDF.Element.ALIGN_LEFT;

                    pdfTableVisa.AddCell(vcell);

                    vcell.Phrase = new PDF.Phrase(visa.Subject + "\n\n", fnt9B);
                    vcell.HorizontalAlignment = PDF.Element.ALIGN_RIGHT;

                    pdfTableVisa.AddCell(vcell);

                    vcell.Phrase = new PDF.Phrase("", fnt9B);
                    vcell.HorizontalAlignment = PDF.Element.ALIGN_RIGHT;

                    pdfTableVisa.AddCell(vcell);
                }

                document.Add(pdfTableVisa);
            }
            #endregion

            #region {PDF document finalize}
            document.Close();
            var bytes = stream.ToArray();
            stream.Close();
            #endregion

            return bytes;
        }

        private static byte[] GeneratePrintVersionXls(string language, Dictionary<string, object> parameters, List<VacancyItem> dataSource)
        {
            #region {Excel document init}
            var xlWb = HSSFWorkbook.Create(InternalWorkbook.CreateWorkbook());
            var xlSheet = (HSSFSheet)xlWb.CreateSheet("Vacancies");

            var stream = new MemoryStream();

            var currentRow = 0;
            var currentCol = 0;

            xlSheet.SetColumnWidth(0, 1500); // seq_num
            xlSheet.SetColumnWidth(1, 7500); // desc
            xlSheet.SetColumnWidth(2, 6500); // cat
            xlSheet.SetColumnWidth(3, 3000); // sal
            xlSheet.SetColumnWidth(4, 3000); // emp
            xlSheet.SetColumnWidth(5, 3000); // gender
            xlSheet.SetColumnWidth(6, 3000); // exp
            xlSheet.SetColumnWidth(7, 3000); // edu
            xlSheet.SetColumnWidth(8, 8000); // dep
            xlSheet.SetColumnWidth(9, 13000); // spec
            xlSheet.SetColumnWidth(10, 10000); // req
            xlSheet.SetColumnWidth(11, 6500); // info
            #endregion

            #region {Fonts init}
            var fontNormal = (HSSFFont)xlWb.CreateFont();
            fontNormal.FontName = "Times New Roman";

            var fontBold = (HSSFFont)xlWb.CreateFont();
            fontBold.FontName = "Times New Roman";
            fontBold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            #endregion

            #region {Cell styles init}
            #region {Whom cell styles}
            var whCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

            whCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            whCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;

            whCellStyle.WrapText = true;

            whCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            whCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            whCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            whCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            whCellStyle.SetFont(fontBold);
            #endregion

            #region {Header cell styles}
            var hdrCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

            hdrCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            hdrCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            hdrCellStyle.WrapText = true;

            hdrCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            hdrCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            hdrCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            hdrCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            hdrCellStyle.SetFont(fontBold);
            #endregion

            #region {Table header cell style init}
            var thCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();
            var thCellStyleRotated = (HSSFCellStyle)xlWb.CreateCellStyle();

            thCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            thCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            thCellStyle.WrapText = true;

            thCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thick;

            thCellStyle.SetFont(fontBold);

            thCellStyleRotated.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            thCellStyleRotated.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            thCellStyleRotated.WrapText = true;

            thCellStyleRotated.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyleRotated.BorderTop = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyleRotated.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thick;
            thCellStyleRotated.BorderRight = NPOI.SS.UserModel.BorderStyle.Thick;

            thCellStyleRotated.SetFont(fontBold);

            thCellStyleRotated.Rotation = 90;
            #endregion

            #region {Table data cell style init}
            var tdCellStyleL = (HSSFCellStyle)xlWb.CreateCellStyle();
            var tdCellStyleC = (HSSFCellStyle)xlWb.CreateCellStyle();
            var tdCellStyleRotated = (HSSFCellStyle)xlWb.CreateCellStyle();

            tdCellStyleL.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            tdCellStyleL.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            tdCellStyleL.WrapText = true;

            tdCellStyleL.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleL.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleL.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleL.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            tdCellStyleL.SetFont(fontNormal);

            tdCellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            tdCellStyleC.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            tdCellStyleC.WrapText = true;

            tdCellStyleC.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleC.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleC.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleC.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            tdCellStyleC.SetFont(fontNormal);

            tdCellStyleRotated.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            tdCellStyleRotated.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            tdCellStyleRotated.WrapText = true;

            tdCellStyleRotated.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleRotated.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleRotated.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            tdCellStyleRotated.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            tdCellStyleRotated.SetFont(fontNormal);

            tdCellStyleRotated.Rotation = 90;
            #endregion

            #region {Footer cell styles}
            var ftrCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

            ftrCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            ftrCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;

            ftrCellStyle.WrapText = true;

            ftrCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            ftrCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            ftrCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            ftrCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            ftrCellStyle.SetFont(fontBold);
            #endregion

            #region {Visa cell styles}
            var visaCellStyleL = (HSSFCellStyle)xlWb.CreateCellStyle();

            visaCellStyleL.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            visaCellStyleL.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;

            visaCellStyleL.WrapText = true;

            visaCellStyleL.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            visaCellStyleL.SetFont(fontBold);

            var visaCellStyleR = (HSSFCellStyle)xlWb.CreateCellStyle();

            visaCellStyleR.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            visaCellStyleR.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;

            visaCellStyleR.WrapText = true;

            visaCellStyleR.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleR.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleR.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleR.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            visaCellStyleR.SetFont(fontBold);
            #endregion

            #endregion

            #region {Translations init}
            var dataTableColumnNames = new Dictionary<string, string>();

            switch (language)
            {
                case "ru":
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", @"Наименование" + "\n" + "должности");
                    dataTableColumnNames.Add("category", "Категория");
                    dataTableColumnNames.Add("salary", "Оклад");
                    dataTableColumnNames.Add("employment", "Занятость");
                    dataTableColumnNames.Add("gender", "Пол");
                    dataTableColumnNames.Add("experience", "Необходимый" + "\n" + "стаж");
                    dataTableColumnNames.Add("education", "Образование");
                    dataTableColumnNames.Add("department", "Отдел, подразделение");
                    dataTableColumnNames.Add("specialization", "Функциональность");
                    dataTableColumnNames.Add("requirements", "Требования");
                    dataTableColumnNames.Add("information", "Дополнительная" + "\n" + "информация");
                    break;
                case "uz":
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", "Ish o'rni" + "\n" + "nomlanishi");
                    dataTableColumnNames.Add("category", "Toifa");
                    dataTableColumnNames.Add("salary", "Maosh");
                    dataTableColumnNames.Add("employment", "Bandlik");
                    dataTableColumnNames.Add("gender", "Jinsi");
                    dataTableColumnNames.Add("experience", "Talab etilgan" + "\n" + "ish tajribasi");
                    dataTableColumnNames.Add("education", "Ma'lumot");
                    dataTableColumnNames.Add("department", "Bo'lim, bo'linma");
                    dataTableColumnNames.Add("specialization", "Mutaxassisligi");
                    dataTableColumnNames.Add("requirements", "Talablar");
                    dataTableColumnNames.Add("information", "Qo'shimcha" + "\n" + "ma'lumot");
                    break;
                case "en":
                default:
                    dataTableColumnNames.Add("sequence_num", "№");
                    dataTableColumnNames.Add("job_title", "Job title");
                    dataTableColumnNames.Add("category", "Category");
                    dataTableColumnNames.Add("salary", "Salary");
                    dataTableColumnNames.Add("employment", "Employment");
                    dataTableColumnNames.Add("gender", "Gender");
                    dataTableColumnNames.Add("experience", "Experience");
                    dataTableColumnNames.Add("education", "Education");
                    dataTableColumnNames.Add("department", "Department");
                    dataTableColumnNames.Add("specialization", "Specialization");
                    dataTableColumnNames.Add("requirements", "Requirements");
                    dataTableColumnNames.Add("information", "Additional" + "\n" + "information");
                    break;
            }
            #endregion

            #region {Whom}
            // whom
            if (parameters["whom"] != null && (string)parameters["whom"] != "")
            {
                var whomRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                var whomCell = (HSSFCell)whomRow.CreateCell(9);

                whomRow.HeightInPoints = 100;

                whomCell.SetCellValue((string)parameters["whom"]);
                whomCell.CellStyle = whCellStyle;

                var whomCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 9, 11);

                xlSheet.AddMergedRegion(whomCellsRange);

                currentRow++;
                currentCol = 0;
            }
            #endregion

            #region {Header}
            // header
            if (parameters["header"] != null && (string)parameters["header"] != "")
            {
                var headerRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                var headerCell = (HSSFCell)headerRow.CreateCell(0);

                headerRow.HeightInPoints = 50;

                headerCell.SetCellValue((string)parameters["header"]);
                headerCell.CellStyle = hdrCellStyle;

                var hdrCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 11);

                xlSheet.AddMergedRegion(hdrCellsRange);

                currentRow += 2;
                currentCol = 0;
            }
            #endregion

            #region {Data table}
            // data
            if (dataSource != null && dataSource.Count > 0)
            {
                // table header
                var columnNamesRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                HSSFCell cell;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["sequence_num"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["job_title"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["category"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["salary"]);
                cell.CellStyle = thCellStyleRotated;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["employment"]);
                cell.CellStyle = thCellStyleRotated;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["gender"]);
                cell.CellStyle = thCellStyleRotated;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["experience"]);
                cell.CellStyle = thCellStyleRotated;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["education"]);
                cell.CellStyle = thCellStyleRotated;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["department"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["specialization"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["requirements"]);
                cell.CellStyle = thCellStyle;

                cell = (HSSFCell)columnNamesRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue(dataTableColumnNames["information"]);
                cell.CellStyle = thCellStyle;

                columnNamesRow.HeightInPoints = 100;

                currentRow++;
                currentCol = 0;

                var columnNumsRow = (HSSFRow)xlSheet.CreateRow(currentRow);

                // table header column numbers
                for (var i = 0; i < 12; i++)
                {
                    cell = (HSSFCell)columnNumsRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                    cell.SetCellValue(currentCol);
                    cell.CellStyle = thCellStyle;
                }

                // table data
                currentRow++;
                currentCol = 0;

                switch (language)
                {
                    case "ru":
                        #region {Table data RU}
                        foreach (var vi in dataSource)
                        {
                            var dataTableRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                            HSSFCell dtCell;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.SequenceNumber);
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.DescriptionRu);
                            dtCell.CellStyle = thCellStyle;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.CategoryFromIdRu(vi.Category));
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.Salary.Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.EmploymentFromIdRu(vi.Employment));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.GenderFromIdRu(vi.Gender));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.ExperienceFromIdRu(vi.Experience));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.EducationFromIdRu(vi.Education).Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.DepartmentRu);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.SpecializationRu);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.RequirementsRu);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.InformationRu);
                            dtCell.CellStyle = tdCellStyleL;

                            currentRow++;
                            currentCol = 0;
                        }
                        #endregion
                        break;
                    case "uz":
                        #region {Table data UZ}
                        foreach (var vi in dataSource)
                        {
                            var dataTableRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                            HSSFCell dtCell;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.SequenceNumber);
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.DescriptionUz);
                            dtCell.CellStyle = thCellStyle;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.CategoryFromIdUz(vi.Category));
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.Salary.Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.EmploymentFromIdUz(vi.Employment));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.GenderFromIdUz(vi.Gender));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.ExperienceFromIdUz(vi.Experience));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(Vacancy.EducationFromIdUz(vi.Education).Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.DepartmentUz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.SpecializationUz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.RequirementsUz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.InformationUz);
                            dtCell.CellStyle = tdCellStyleL;

                            currentRow++;
                            currentCol = 0;
                        }
                        #endregion
                        break;
                    case "en":
                    default:
                        #region {Table data EN}
                        #endregion
                        break;
                }
            }
            #endregion

            #region {Footer}
            // footer
            currentRow++;
            currentCol = 0;

            if (parameters["footer"] != null && (string)parameters["footer"] != "")
            {
                var footerRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                var footerCell = (HSSFCell)footerRow.CreateCell(0);

                footerRow.HeightInPoints = 50;

                footerCell.SetCellValue((string)parameters["footer"]);
                footerCell.CellStyle = ftrCellStyle;

                var ftrCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 11);

                xlSheet.AddMergedRegion(ftrCellsRange);

                currentRow += 2;
                currentCol = 0;
            }
            #endregion

            #region {Visas}
            // visas
            if (parameters["visas"] != null && ((List<ReportVisaItem>)(parameters["visas"])).Count > 0)
            {
                var visas = (List<ReportVisaItem>)parameters["visas"];

                foreach (var visa in visas)
                {
                    var visaRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                    var visaCellL = (HSSFCell)visaRow.CreateCell(0);

                    visaCellL.SetCellValue(visa.JobTitle);
                    visaCellL.CellStyle = visaCellStyleL;

                    var visaCellsRangeL = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 8);

                    xlSheet.AddMergedRegion(visaCellsRangeL);

                    var visaCellR = (HSSFCell)visaRow.CreateCell(9);

                    visaCellR.SetCellValue(visa.JobTitle);
                    visaCellR.CellStyle = visaCellStyleR;

                    var visaCellsRangeR = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 9, 11);

                    xlSheet.AddMergedRegion(visaCellsRangeR);

                    currentRow++;
                    currentCol = 0;
                }
            }
            #endregion

            #region {Excel finalize}
            xlWb.Write(stream);

            var bytes = stream.ToArray();
            stream.Close();
            #endregion

            return bytes;
        }
    }
}
