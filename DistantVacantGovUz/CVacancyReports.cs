using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PDF = iTextSharp.text;

namespace DistantVacantGovUz
{
    public static class CVacancyReports
    {
        public enum REPORT_TYPE
        {
            PDF,
            XLS
        };

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

                PDF.pdf.PdfPTable pdfTableVisa = new PDF.pdf.PdfPTable(2);

                float[] visaColumnWidths = new float[] { 392f, 392f };

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

                    vcell.Phrase = new PDF.Phrase(visa.subject, fnt_9_b);
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
            return null;
        }
    }
}
