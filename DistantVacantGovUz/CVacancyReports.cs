using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PDF = iTextSharp.text;

using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Класс для генерации отчетов
    /// </summary>
    public static class CVacancyReports
    {
        /// <summary>
        /// Тип отчета
        /// </summary>
        public enum REPORT_TYPE
        {
            PDF,
            XLS
        };

        /// <summary>
        /// Генерация отчета
        /// </summary>
        /// <param name="reportType">Тип отчета (PDF или XLS)</param>
        /// <param name="reportName">Название отчета</param>
        /// <param name="language">Язык отчета</param>
        /// <param name="parameters">Параметры отчета, словарь вида "название-параметр"</param>
        /// <param name="dataSource">Исходные данные для генерации</param>
        /// <returns>Возвратит байты сгенерированного отчета, или <value>null</value> при ошибки генерации</returns>
        public static byte[] GenerateReport(REPORT_TYPE reportType, string reportName, string language, Dictionary<String, Object> parameters, List<CVacancyItem> dataSource)
        {
            switch (reportType)
            {
                case REPORT_TYPE.PDF:
                    return GeneratePdfReport(reportName, language, parameters, dataSource);
                case REPORT_TYPE.XLS:
                    return GenerateXlsReport(reportName, language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GeneratePdfReport(string reportName, string language, Dictionary<String, Object> parameters, List<CVacancyItem> dataSource)
        {
            switch (reportName)
            {
                case "PRINT_VERSION":
                    return GeneratePrintVersionPdf(language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GenerateXlsReport(string reportName, string language, Dictionary<String, Object> parameters, List<CVacancyItem> dataSource)
        {
            switch (reportName)
            {
                case "PRINT_VERSION":
                    return GeneratePrintVersionXls(language, parameters, dataSource);
                default:
                    return null;
            }
        }

        private static byte[] GeneratePrintVersionPdf(string language, Dictionary<String, Object> parameters, List<CVacancyItem> dataSource)
        {
            #region {PDF Document init}
            PDF.Document document = new PDF.Document(PDF.PageSize.A4.Rotate());
            MemoryStream stream = new MemoryStream();

            PDF.pdf.PdfWriter.GetInstance(document, stream);
            document.Open();
            #endregion

            #region {Fonts init}
            PDF.pdf.BaseFont baseFont = PDF.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", PDF.pdf.BaseFont.IDENTITY_H, PDF.pdf.BaseFont.NOT_EMBEDDED);
            PDF.pdf.BaseFont baseFontB = PDF.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\timesbd.ttf", PDF.pdf.BaseFont.IDENTITY_H, PDF.pdf.BaseFont.NOT_EMBEDDED);

            PDF.Font fnt_10 = new PDF.Font(baseFont, 10f);
            PDF.Font fnt_9_b = new PDF.Font(baseFontB, 9f);
            PDF.Font fnt_10_b = new PDF.Font(baseFontB, 10f);
            PDF.Font fnt_8 = new PDF.Font(baseFont, 8f);
            PDF.Font fnt_8_b = new PDF.Font(baseFontB, 8f);
            #endregion

            #region {Translations init}
            Dictionary<String, String> dataTableColumnNames = new Dictionary<String, String>();

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
            if (parameters["whom"] != null && (String)parameters["whom"] != "")
            {
                PDF.pdf.PdfPTable pdfTableWhom = new PDF.pdf.PdfPTable(2);

                PDF.pdf.PdfPCell wcell;
                wcell = new PDF.pdf.PdfPCell(new PDF.Phrase(@"", fnt_9_b));

                float[] whomColumnWidths = new float[] { 392f, 392f };

                pdfTableWhom.SpacingAfter = 6f;
                pdfTableWhom.LockedWidth = true;
                pdfTableWhom.SetTotalWidth(whomColumnWidths);

                wcell.Phrase = new PDF.Phrase("", fnt_9_b);
                wcell.Border = PDF.pdf.PdfPCell.NO_BORDER;
                wcell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_LEFT;

                pdfTableWhom.AddCell(wcell);

                wcell.Phrase = new PDF.Phrase((String)parameters["whom"], fnt_9_b);
                wcell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_RIGHT;

                pdfTableWhom.AddCell(wcell);

                document.Add(pdfTableWhom);
            }
            #endregion

            #region {Header}
            // header
            if (parameters["header"] != null && (String)parameters["header"] != "")
            {
                PDF.Phrase phraseHeader = new PDF.Phrase((String)parameters["header"], fnt_9_b);
                PDF.Paragraph paragraphHeader = new PDF.Paragraph(phraseHeader);
                paragraphHeader.Alignment = PDF.Element.ALIGN_CENTER;
                paragraphHeader.SpacingAfter = 12f;

                document.Add(paragraphHeader);
            }
            #endregion

            #region {Data table}
            // data
            if (dataSource != null && dataSource.Count > 0)
            {
                PDF.pdf.PdfPTable pdfTable = new PDF.pdf.PdfPTable(12);

                // width
                float[] columnWidths = new float[] { 24f, 96f, 80f, 32f, 24f, 24f, 24f, 24f, 96f, 140f, 140f, 80f };

                pdfTable.LockedWidth = true;
                pdfTable.SetTotalWidth(columnWidths);

                PDF.pdf.PdfPCell cell;

                // table header
                cell = new PDF.pdf.PdfPCell(new PDF.Phrase(dataTableColumnNames["sequence_num"], fnt_10_b));

                cell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PDF.pdf.PdfPCell.ALIGN_MIDDLE;

                pdfTable.AddCell(cell);

                cell.Phrase = new PDF.Phrase(dataTableColumnNames["job_title"], fnt_10_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["category"], fnt_10_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["salary"], fnt_8_b);
                cell.Rotation = 90; // ROTATE
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["employment"], fnt_8_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["gender"], fnt_8_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["experience"], fnt_8_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["education"], fnt_8_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["department"], fnt_10_b);
                cell.Rotation = 0; // ROTATE revert
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["specialization"], fnt_10_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["requirements"], fnt_10_b);
                pdfTable.AddCell(cell);
                cell.Phrase = new PDF.Phrase(dataTableColumnNames["information"], fnt_8_b);
                pdfTable.AddCell(cell);

                switch (language)
                {
                    case "ru":
                        #region {Table data RU}
                        foreach (CVacancyItem vi in dataSource)
                        {
                            // table data
                            cell = new PDF.pdf.PdfPCell(new PDF.Phrase(vi.seqNum, fnt_10));

                            cell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_CENTER;
                            cell.VerticalAlignment = PDF.pdf.PdfPCell.ALIGN_MIDDLE;

                            pdfTable.AddCell(cell);

                            cell.Phrase = new PDF.Phrase(vi.description_ru, fnt_10_b);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.CategoryFromIdRu(vi.e_category_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.salary.Replace(" ", "\n"), fnt_8);
                            cell.Rotation = 90; // ROTATE
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.EmploymentFromIdRu(vi.e_employment_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.GenderFromIdRu(vi.e_gender_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.ExperienceFromIdRu(vi.e_experience_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.EducationFromIdRu(vi.e_education_id).Replace(" ", "\n"), fnt_8); // Образование
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.department_ru, fnt_8);
                            cell.Rotation = 0; // ROTATE revert
                            cell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_LEFT;
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.specialization_ru, fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.requirements_ru, fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.information_ru, fnt_8);
                            pdfTable.AddCell(cell);
                        }
                        #endregion
                        break;
                    case "uz":
                        #region {Table data UZ}
                        foreach (CVacancyItem vi in dataSource)
                        {
                            // table data
                            cell = new PDF.pdf.PdfPCell(new PDF.Phrase(vi.seqNum, fnt_10));

                            cell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_CENTER;
                            cell.VerticalAlignment = PDF.pdf.PdfPCell.ALIGN_MIDDLE;

                            pdfTable.AddCell(cell);

                            cell.Phrase = new PDF.Phrase(vi.description_uz, fnt_10_b);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.CategoryFromIdUz(vi.e_category_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.salary.Replace(" ", "\n"), fnt_8);
                            cell.Rotation = 90; // ROTATE
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.EmploymentFromIdUz(vi.e_employment_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.GenderFromIdUz(vi.e_gender_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.ExperienceFromIdUz(vi.e_experience_id), fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(CVacancy.EducationFromIdUz(vi.e_education_id).Replace(" ", "\n"), fnt_8); // Образование
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.department_uz, fnt_8);
                            cell.Rotation = 0; // ROTATE revert
                            cell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_LEFT;
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.specialization_uz, fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.requirements_uz, fnt_8);
                            pdfTable.AddCell(cell);
                            cell.Phrase = new PDF.Phrase(vi.information_uz, fnt_8);
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
            if (parameters["footer"] != null && (String)parameters["footer"] != "")
            {
                PDF.Phrase phraseFooter = new PDF.Phrase((String)parameters["footer"], fnt_9_b);
                PDF.Paragraph paragraphFooter = new PDF.Paragraph(phraseFooter);
                paragraphFooter.Alignment = PDF.Element.ALIGN_LEFT;
                paragraphFooter.SpacingBefore = 6f;
                paragraphFooter.SpacingAfter = 6f;

                document.Add(paragraphFooter);
            }
            #endregion

            #region {Visas}
            // visas
            if (parameters["visas"] != null && ((List<CReportVisaItem>)(parameters["visas"])).Count > 0)
            {
                List<CReportVisaItem> visas = (List<CReportVisaItem>)parameters["visas"];

                /*PDF.pdf.PdfPTable pdfTableVisa = new PDF.pdf.PdfPTable(2);

                float[] visaColumnWidths = new float[] { 392f, 392f };*/

                PDF.pdf.PdfPTable pdfTableVisa = new PDF.pdf.PdfPTable(3);

                float[] visaColumnWidths = new float[] { 212f, 212f, 360f };

                pdfTableVisa.SpacingBefore = 12f;
                pdfTableVisa.LockedWidth = true;
                pdfTableVisa.SetTotalWidth(visaColumnWidths);

                PDF.pdf.PdfPCell vcell;
                vcell = new PDF.pdf.PdfPCell(new PDF.Phrase(@"", fnt_9_b));

                foreach (CReportVisaItem visa in visas)
                {
                    vcell.Phrase = new PDF.Phrase(visa.jobTitle, fnt_9_b);
                    vcell.Border = PDF.pdf.PdfPCell.NO_BORDER;
                    vcell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_LEFT;

                    pdfTableVisa.AddCell(vcell);

                    vcell.Phrase = new PDF.Phrase(visa.subject + "\n\n", fnt_9_b);
                    vcell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_RIGHT;

                    pdfTableVisa.AddCell(vcell);

                    vcell.Phrase = new PDF.Phrase("", fnt_9_b);
                    vcell.HorizontalAlignment = PDF.pdf.PdfPCell.ALIGN_RIGHT;

                    pdfTableVisa.AddCell(vcell);
                }

                document.Add(pdfTableVisa);
            }
            #endregion

            #region {PDF document finalize}
            document.Close();
            byte[] bytes = stream.ToArray();
            stream.Close();
            #endregion

            return bytes;
        }

        private static byte[] GeneratePrintVersionXls(string language, Dictionary<String, Object> parameters, List<CVacancyItem> dataSource)
        {
            #region {Excel document init}
            HSSFWorkbook xlWb = HSSFWorkbook.Create(InternalWorkbook.CreateWorkbook());
            HSSFSheet xlSheet = (HSSFSheet)xlWb.CreateSheet("Vacancies");

            MemoryStream stream = new MemoryStream();

            int currentRow = 0;
            int currentCol = 0;

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
            HSSFFont fontNormal = (HSSFFont)xlWb.CreateFont();
            fontNormal.FontName = "Times New Roman";

            HSSFFont fontBold = (HSSFFont)xlWb.CreateFont();
            fontBold.FontName = "Times New Roman";
            fontBold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            #endregion

            #region {Cell styles init}
            #region {Whom cell styles}
            HSSFCellStyle whCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            HSSFCellStyle hdrCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            HSSFCellStyle thCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();
            HSSFCellStyle thCellStyleRotated = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            HSSFCellStyle tdCellStyleL = (HSSFCellStyle)xlWb.CreateCellStyle();
            HSSFCellStyle tdCellStyleC = (HSSFCellStyle)xlWb.CreateCellStyle();
            HSSFCellStyle tdCellStyleRotated = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            HSSFCellStyle ftrCellStyle = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            HSSFCellStyle visaCellStyleL = (HSSFCellStyle)xlWb.CreateCellStyle();

            visaCellStyleL.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            visaCellStyleL.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;

            visaCellStyleL.WrapText = true;

            visaCellStyleL.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
            visaCellStyleL.BorderRight = NPOI.SS.UserModel.BorderStyle.None;

            visaCellStyleL.SetFont(fontBold);

            HSSFCellStyle visaCellStyleR = (HSSFCellStyle)xlWb.CreateCellStyle();

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
            Dictionary<String, String> dataTableColumnNames = new Dictionary<String, String>();

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
            if (parameters["whom"] != null && (String)parameters["whom"] != "")
            {
                HSSFRow whomRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                HSSFCell whomCell = (HSSFCell)whomRow.CreateCell(9);

                whomRow.HeightInPoints = 100;

                whomCell.SetCellValue((String)parameters["whom"]);
                whomCell.CellStyle = whCellStyle;

                NPOI.SS.Util.CellRangeAddress whomCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 9, 11);
                
                xlSheet.AddMergedRegion(whomCellsRange);

                currentRow++;
                currentCol = 0;
            }
            #endregion

            #region {Header}
            // header
            if (parameters["header"] != null && (String)parameters["header"] != "")
            {
                HSSFRow headerRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                HSSFCell headerCell = (HSSFCell)headerRow.CreateCell(0);

                headerRow.HeightInPoints = 50;

                headerCell.SetCellValue((String)parameters["header"]);
                headerCell.CellStyle = hdrCellStyle;

                NPOI.SS.Util.CellRangeAddress hdrCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 11);

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
                HSSFRow columnNamesRow = (HSSFRow)xlSheet.CreateRow(currentRow);
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

                HSSFRow columnNumsRow = (HSSFRow)xlSheet.CreateRow(currentRow);

                // table header column numbers
                for (int i = 0; i < 12; i++)
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
                        foreach (CVacancyItem vi in dataSource)
                        {
                            HSSFRow dataTableRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                            HSSFCell dtCell;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.seqNum);
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.description_ru);
                            dtCell.CellStyle = thCellStyle;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.CategoryFromIdRu(vi.e_category_id));
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.salary.Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.EmploymentFromIdRu(vi.e_employment_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.GenderFromIdRu(vi.e_gender_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.ExperienceFromIdRu(vi.e_experience_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.EducationFromIdRu(vi.e_education_id).Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.department_ru);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.specialization_ru);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.requirements_ru);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.information_ru);
                            dtCell.CellStyle = tdCellStyleL;

                            currentRow++;
                            currentCol = 0;
                        }
                        #endregion
                        break;
                    case "uz":
                        #region {Table data UZ}
                        foreach (CVacancyItem vi in dataSource)
                        {
                            HSSFRow dataTableRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                            HSSFCell dtCell;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.seqNum);
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.description_uz);
                            dtCell.CellStyle = thCellStyle;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.CategoryFromIdUz(vi.e_category_id));
                            dtCell.CellStyle = tdCellStyleC;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.salary.Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.EmploymentFromIdUz(vi.e_employment_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.GenderFromIdUz(vi.e_gender_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.ExperienceFromIdUz(vi.e_experience_id));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(CVacancy.EducationFromIdUz(vi.e_education_id).Replace(" ", "\n"));
                            dtCell.CellStyle = tdCellStyleRotated;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.department_uz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.specialization_uz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.requirements_uz);
                            dtCell.CellStyle = tdCellStyleL;

                            dtCell = (HSSFCell)dataTableRow.CreateCell(currentCol++, NPOI.SS.UserModel.CellType.String);
                            dtCell.SetCellValue(vi.information_uz);
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

            if (parameters["footer"] != null && (String)parameters["footer"] != "")
            {
                HSSFRow footerRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                HSSFCell footerCell = (HSSFCell)footerRow.CreateCell(0);

                footerRow.HeightInPoints = 50;

                footerCell.SetCellValue((String)parameters["footer"]);
                footerCell.CellStyle = ftrCellStyle;

                NPOI.SS.Util.CellRangeAddress ftrCellsRange = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 11);

                xlSheet.AddMergedRegion(ftrCellsRange);

                currentRow += 2;
                currentCol = 0;
            }
            #endregion

            #region {Visas}
            // visas
            if (parameters["visas"] != null && ((List<CReportVisaItem>)(parameters["visas"])).Count > 0)
            {
                List<CReportVisaItem> visas = (List<CReportVisaItem>)parameters["visas"];

                foreach (CReportVisaItem visa in visas)
                {
                    HSSFRow visaRow = (HSSFRow)xlSheet.CreateRow(currentRow);
                    HSSFCell visaCellL = (HSSFCell)visaRow.CreateCell(0);

                    visaCellL.SetCellValue(visa.jobTitle);
                    visaCellL.CellStyle = visaCellStyleL;

                    NPOI.SS.Util.CellRangeAddress visaCellsRangeL = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 0, 8);

                    xlSheet.AddMergedRegion(visaCellsRangeL);

                    HSSFCell visaCellR = (HSSFCell)visaRow.CreateCell(9);

                    visaCellR.SetCellValue(visa.jobTitle);
                    visaCellR.CellStyle = visaCellStyleR;

                    NPOI.SS.Util.CellRangeAddress visaCellsRangeR = new NPOI.SS.Util.CellRangeAddress(currentRow, currentRow, 9, 11);

                    xlSheet.AddMergedRegion(visaCellsRangeR);

                    currentRow++;
                    currentCol = 0;
                }
            }
            #endregion

            #region {Excel finalize}
            xlWb.Write(stream);

            byte[] bytes = stream.ToArray();
            stream.Close();
            #endregion

            return bytes;
        }
    }
}
